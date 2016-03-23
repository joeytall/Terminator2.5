using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminator
{
    public partial class Form2 : Form
    {
        public Dictionary<string, List<int>> detailedSearch = new Dictionary<string, List<int>>();
        public Stack<string> undoList = new Stack<string>();
        public int currentMSGID = 1;
        public string FileName = "",
        FolderName = "",
        FilePath = "",
        CurrentResultFolder = "";
        private static int[] CurrentSelection = new int[2];
        public List<string> LinesWIthQuote = new List<string>();
        public bool systemBackup = false;

        public bool FileModified = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Alt | Keys.N):
                    return true;
                case (Keys.Alt | Keys.W):
                    this.Close();
                    return true;
                case (Keys.Alt | Keys.Z):
                case (Keys.Control | Keys.Z):
                    if (undoList.Count > 0 )
                        FilePeek.Text = undoList.Pop();
                    InitFilePeek();
                    return true;
                case (Keys.Alt | Keys.Y):
                case (Keys.Control | Keys.Y):
                    FilePeek.Redo();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void InitMessageGrid(string fileName = "")
        {
            if ( fileName != "" )
                FileName = fileName.Replace("\\", "/");

            DataTable dt = SystemMessage.SelectRecord(FileName);
            messageGrid.DataSource = dt;
            messageGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dt = SystemMessage.SelectRecord(FileName, true);
            messageGridOld.DataSource = dt;
            messageGridOld.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void InitFilePeek(string filePath = "")
        {
            string[] allLines = new string[] { };
            detailedSearch.Clear();

            if (filePath == "")
                allLines = Regex.Split(FilePeek.Text, "\n");
            else
            {
                string lastFolder = FolderName;
                FolderName = Regex.Split(filePath, @"\\").Reverse().ElementAt(1);
                allLines = File.ReadAllLines(filePath);
                FilePath = filePath;
                FilePeek.Text = string.Join("\r\n", allLines);
                undoList.Push(FilePeek.Text);
            }

            int[] ASCIIquotes = { 34, 39 };
            Dictionary<int, int> quotationIndices = new Dictionary<int, int>();
            Dictionary<int, int> commentIndices = new Dictionary<int, int>();
            bool isComment = false;
            int commentStart = 0;

            for (int lineNumber = 0; lineNumber < allLines.Length; lineNumber++)
            {
                string line = allLines[lineNumber];
                string trimmedLine = line.Trim();
                int currentIndex = FilePeek.GetFirstCharIndexFromLine(lineNumber);
                if (trimmedLine.EndsWith("*/"))
                {
                    isComment = false;
                    if (!commentIndices.Keys.Contains(commentStart))
                        commentIndices.Add(commentStart, currentIndex - commentStart + line.Length);
                    continue;
                }
                else if (isComment == true)
                    continue;
                else if (trimmedLine.StartsWith("//"))
                {
                    commentIndices.Add(currentIndex, line.Length);
                    continue;
                }
                else if (trimmedLine.StartsWith("/*"))
                {
                    isComment = true;
                    commentStart = currentIndex;
                    continue;
                }
                //else if (trimmedLine.Contains("</script>") && trimmedLine.Contains("</script>"))
                //    continue;
                //else if (trimmedLine.StartsWith("<") && trimmedLine.EndsWith(">"))
                //    continue;
                else if (line.Contains('\"') || line.Contains('\''))
                {
                    //int inLineCommentStart = line.IndexOf("//");
                    //if (inLineCommentStart > 0)
                    //    line = line.Substring(0, inLineCommentStart);
                    char quote = '\0';
                    int startquoteIndex = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        char character = line[i],
                        nextChar = i == line.Length - 1 ? '~' : line[i + 1],
                        prevChar = i == 0 ? '~' : line[i - 1],
                        prevChar2 = i < 2 ? '~' : line[i - 2];
                        int ascii = (int)character;
                        if (ascii == 92)
                        {
                            i++;
                            if (i > line.Length)
                                break;
                        }
                        else if (character == quote)
                        {
                            if (nextChar == ']' || nextChar == ':')
                            {
                                quote = '\0';
                                continue;
                            }
                            else
                            {
                                int key = currentIndex + startquoteIndex,
                                    value = i - startquoteIndex + 1;
                                quotationIndices.Add(key, value);
                                quote = '\0';
                            }
                        }
                        else if (ASCIIquotes.Contains(ascii))
                        {
                            if (prevChar == '(' && prevChar2 == '$')
                                continue;
                            else
                            {
                                quote = line[i];
                                startquoteIndex = i;
                            }
                        }
                    }
                }

            }

            List<string> exclude = new List<string>(new string[] {"\"\"", "{}", string.Empty});
            foreach (KeyValuePair<int, int> pair in quotationIndices)
            {
                string word = FilePeek.Text.Substring(pair.Key, pair.Value);
                if (!exclude.Contains(word) && word != "")
                {
                    int lineNumber = FilePeek.GetLineFromCharIndex(pair.Key);
                    string lineWithQuote = FilePeek.Lines[lineNumber];
                    LinesWIthQuote.Add(lineWithQuote);

                    if (!detailedSearch.ContainsKey(word))
                        detailedSearch.Add(word, new List<int>() { pair.Key });
                    else
                        detailedSearch[word].Add(pair.Key);
                    FilePeek.Select(pair.Key, pair.Value);
                    FilePeek.SelectionBackColor = Color.PaleVioletRed;
                }
            }

            if (filePath != "")
                this.Text += " - " + detailedSearch.Count + " suspect found!";

            populateResultGrid();

            foreach (KeyValuePair<int, int> pair in commentIndices)
            {
                FilePeek.Select(pair.Key, pair.Value);
                FilePeek.SelectionColor = Color.Gray;
            }

            //FilePeek.WordWrap = true;
            FilePeek.DeselectAll();
        }

        private void populateResultGrid()
        {
            var q = detailedSearch.OrderByDescending(x => x.Value.Count);
            DataTable dt = new DataTable();
            dt.Columns.Add("Quotation", typeof(string));
            dt.Columns.Add("Occ", typeof(int));
            foreach (KeyValuePair<string, List<int>> pair in q)
                dt.Rows.Add(pair.Key, pair.Value.Count);

            grdResult.DataSource = dt;
            grdResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //prioritizeResult();

        }

        private void prioritizeResult()
        {
            int quotationIndex = grdResult.Columns["Quotation"].Index;
            string [] keyWords = {"ok", "alert", "confirm", "please", "sure", "you", "item", "initradiobuttonlist", "operationlabel", "headertext"};
            foreach ( DataGridViewRow row in grdResult.Rows )
            {
                object rowValue = row.Cells[quotationIndex].Value;
                string quote = rowValue == null ? "" : rowValue.ToString();
                string[] tokens = quote.Split(' ');
                int rowIndex = row.Index;
                if (tokens.Length >= 3)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    //row.DefaultCellStyle.ForeColor = Color.Beige;
                }
                else
                {
                    List<string> lines = LinesWIthQuote.Where(l => l.Contains(quote)).ToList();
                    foreach(string line in lines)
                    {
                        foreach (string keyword in keyWords)
                        {
                            if (line.ToLower().Contains(keyword))
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                row.DefaultCellStyle.ForeColor = Color.Beige;
                                break;
                            }
                        }
                    }
                }
            }
        }


        private Dictionary<int,string> findQuote(string quote)
        {
            string allLines = FilePeek.Text,
                line = "";
            int len = FilePeek.TextLength,
            lineNumber = 0;
            if (!detailedSearch.ContainsKey(quote))
                return null;
            List<int> indices = detailedSearch[quote];
            Dictionary<int, string> searchDetail = new Dictionary<int, string>();

            foreach ( int i in indices)
            {
                lineNumber = FilePeek.GetLineFromCharIndex(i);
                line = FilePeek.Lines.ElementAt(lineNumber);
                if (!searchDetail.ContainsKey(lineNumber))
                    searchDetail.Add(lineNumber, line);
            }
            return searchDetail;
        }

        private Dictionary<int,string> SearchInFile(string toSearch)
        {
            int len = FilePeek.TextLength;
            int lastIndex = FilePeek.Text.LastIndexOf(FilePeek.Text);
            Dictionary<int, string> searchResult = new Dictionary<int, string>();
            string [] lines = FilePeek.Lines;

            foreach (string line in lines)
            {
                if ( line.Contains(toSearch))
                {
                    int lineNumber = Array.IndexOf(lines,line);
                    if (!searchResult.ContainsKey(lineNumber))
                        searchResult.Add(lineNumber, line);
                }
            }
            return searchResult;
        }

        private void populateDetailSearchGrid(Dictionary<int,string> searchDetail)
        {
            if (searchDetail == null)
                return;
            DataTable dt = new DataTable();
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add("Line Content", typeof(string));
            foreach (KeyValuePair<int, string> pair in searchDetail)
            {
                dt.Rows.Add(pair.Key, pair.Value);
            }
            detailSearchGrid.DataSource = dt;
            detailSearchGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if ( dt.Rows.Count >0)
            {
                int lineNumber = Convert.ToInt32(detailSearchGrid.Rows[0].Cells[0].Value);
                ScrollToLine(lineNumber);
            }

        }

        private void grdResult_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if ( rowIndex != -1)
            {
                int quotationIndex = grdResult.Columns["Quotation"].Index;
                string quote = grdResult.Rows[rowIndex].Cells[quotationIndex].Value.ToString();
                populateDetailSearchGrid(findQuote(quote));
            }
        }

        private void detailSearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if ( rowIndex != -1)
            {
                int lineNumberIndex = detailSearchGrid.Columns["#"].Index,
                lineIndex = detailSearchGrid.Columns["Line Content"].Index,
                lineNumber = Convert.ToInt32(detailSearchGrid.Rows[rowIndex].Cells[lineNumberIndex].Value);
                string line = detailSearchGrid.Rows[rowIndex].Cells[lineIndex].Value.ToString();
                ScrollToLine(lineNumber);
            }

        }

        private void ScrollToLine(int lineNumber)
        {
            if (lineNumber > FilePeek.Lines.Count()) return;

            int start = FilePeek.GetFirstCharIndexFromLine(lineNumber),
                length = FilePeek.Lines[lineNumber].Length;

            FilePeek.Select(CurrentSelection[0], CurrentSelection[1]);
            //FilePeek.SelectionBackColor = Color.Black;

            CurrentSelection[0] = start;
            CurrentSelection[1] = length;
            FilePeek.Select(start, length);
            FilePeek.ScrollToCaret();
            //FilePeek.SelectionBackColor = Color.Gray;
        }

        private void grdResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string [] keyWords = {"alert", "confirm", "please", "sure", "you", "item", "initradiobuttonlist", "operationlabel", "headertext", "error", "mailaddress"};
            List<string> excludeWords = new List<string> { "*", "+", "=", "%", "join", "xhtml" };
            object cellValue = e.Value;
            string quote = cellValue == null ? "" : cellValue.ToString();
            if (string.IsNullOrEmpty(quote))
                return;
            int n;
            bool isNumeric = int.TryParse(quote, out n);
            if (isNumeric)
                return;

            string[] tokens = quote.Split(' ');
            DataGridViewRow row = grdResult.Rows[e.RowIndex];

            foreach(string exWord in excludeWords)
                if (quote.ToLower().Contains(exWord))
                    return;

            if (tokens.Length >= 3)
            {
                row.DefaultCellStyle.BackColor = Color.Red;
                row.DefaultCellStyle.ForeColor = Color.Beige;
            }
            else
            {
                List<string> lines = LinesWIthQuote.Where(l => l.Contains(quote) && !l.Contains("console.log")).ToList();
                foreach (string line in lines)
                {
                    if (line.ToLower().Contains("response") && Path.GetExtension(FileName) == ".cs")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        return;
                    }
                    else
                    {
                        foreach (string keyword in keyWords)
                        {
                            if (line.ToLower().Contains(keyword) )
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                row.DefaultCellStyle.ForeColor = Color.Beige;
                                return;
                            }
                        }
                    }

                }
            }
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow row;
                if (messageGrid.SelectedRows.Count != 0)
                    row = messageGrid.SelectedRows[0];
                else
                    row = messageGridOld.SelectedRows[0];
                string MsgId = row.Cells[0].Value.ToString(),
                    MsgDesc = row.Cells[1].Value.ToString();
                SystemMessage.DeleteRecord(FileName, MsgId, systemBackup);
                InitMessageGrid(FileName);
                Replace(MsgId, MsgDesc);
            }
        }

        private void messageGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if ( rowIndex != -1)
            {
                object value = messageGrid.Rows[rowIndex].Cells[0].Value;
                string MsgId = value == null ? "" : value.ToString();
                populateDetailSearchGrid(SearchInFile(MsgId));
            }
        }

        private void messageGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string cell = messageGrid.SelectedCells[0].Value.ToString(),
                   columnName = messageGrid.SelectedCells[0].OwningColumn.HeaderText;
            if (columnName == "MessageDesc")
            {
                if (cell == "")
                {
                    int rowIndex = messageGrid.CurrentCell.RowIndex;
                    messageGrid.Rows[rowIndex].Cells[0].Value = "T" + messageGrid.Rows.Count;
                }
            }
        }

        private void messageGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (messageGrid.SelectedRows.Count == 0)
            //    return;

            messageGrid.Rows[e.RowIndex].Selected = true;
            if (e.Button == MouseButtons.Right)
            {
                messageGrid.CurrentCell = messageGrid.Rows[e.RowIndex].Cells[1];
                databaseMenu.Show(messageGrid, e.Location);
                databaseMenu.Show(Cursor.Position);
                systemBackup = false;
            }
        }

        private void messageGridOld_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                object value = messageGridOld.Rows[rowIndex].Cells[0].Value;
                string MsgId = value == null ? "" : value.ToString();
                populateDetailSearchGrid(SearchInFile(MsgId));
            }
        }

        private void messageGridOld_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            messageGridOld.Rows[e.RowIndex].Selected = true;
            if (e.Button == MouseButtons.Right)
            {
                messageGridOld.CurrentCell = messageGridOld.Rows[e.RowIndex].Cells[1];
                databaseMenu.Show(messageGridOld, e.Location);
                databaseMenu.Show(Cursor.Position);
                systemBackup = true;
            }
        }

        private void messageGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = messageGrid.Rows[e.RowIndex];
            string MsgId = row.Cells[0].Value.ToString(),
                Message = row.Cells[1].Value.ToString();
            SystemMessage.ModifyRecord(FileName, MsgId, Message);
            InitMessageGrid();
        }

        private void grdResult_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                grdResult.Rows[e.RowIndex].Selected = true;
                grdResult.CurrentCell = grdResult.Rows[e.RowIndex].Cells[1];
                resultGridMenu.Show(grdResult, e.Location);
                resultGridMenu.Show(Cursor.Position);
            }
        }

        private string GetSelectedQuote()
        {
            DataGridViewRow row = grdResult.SelectedRows[0];
            int quotationIndex = grdResult.Columns["Quotation"].Index;
            object rowValue = row.Cells[quotationIndex].Value;
            string quote = rowValue == null ? "" : rowValue.ToString();
            return quote;
        }

        private int GetSelectedLineNumber()
        {
            DataGridViewRow selectedRow = detailSearchGrid.SelectedRows[0];
            int lineIndex = detailSearchGrid.Columns["#"].Index;
            object rowValue = selectedRow.Cells[lineIndex].Value;
            string lineNumber = rowValue == null ? "" : rowValue.ToString();
            return Convert.ToInt32(lineNumber);
        }

        private bool InsertMessage()
        {
            string quote = GetSelectedQuote();
            string message = quote.Substring(1, quote.Length - 2);
            if (message == "")
                return false;

            int count = 1;
            foreach (DataGridViewRow row in messageGrid.Rows)
            {
                object value = row.Cells[0].Value;
                if (value == null)
                    continue;
                else if (value.ToString().StartsWith("T"))
                    count++;
            }
            currentMSGID = count;

            string msgID = "T" + currentMSGID;
            SystemMessage.InsertRecord(FileName, msgID, message);
            InitMessageGrid();
            return true;
        }

        private bool HasDuplicatedMessage(string msg)
        {
            foreach (DataGridViewRow row in messageGrid.Rows)
            {
                int msgIndex = messageGrid.Columns["MessageDesc"].Index;
                object rowValue = row.Cells[msgIndex].Value;
                string message = rowValue == null ? "" : rowValue.ToString();
                if (message == msg)
                    return true;
            }
            return false;
        }

        private void Replace(string messageID = "", string messageDesc = "", string oldID = "")
        {
            FileModified = true;
            string messageFormat = getMessageFormat();
            if (messageFormat == "")
                return;

            string oldValue, newValue;
            Dictionary<int, string> linesWithQuote; 

            if ( messageID == "" )
            {
                int numMsg = currentMSGID;
                string msgID = "T" + numMsg.ToString();
                oldValue = GetSelectedQuote();
                newValue = messageFormat.Replace("TT", msgID);
                if (Path.GetExtension(FileName) != ".cs" && Path.GetExtension(FileName) != ".js")
                    newValue = oldValue[0] + newValue + oldValue.Last();
                linesWithQuote = findQuote(oldValue);
            }
            else
            {
                if (!string.IsNullOrEmpty(oldID))
                {
                    oldValue = "m_msg[\"" + oldID + "\"]";
                    newValue = "m_msg[\"" + messageID + "\"]";
                }
                else
                {
                    oldValue = messageFormat.Replace("TT", messageID);
                    newValue = messageDesc;
                }

                linesWithQuote = SearchInFile(oldValue);
            }


            if (linesWithQuote.Count == 0)
                return;

            string[] lines = FilePeek.Lines;
            foreach (KeyValuePair<int, string> pair in linesWithQuote)
            {
                int lineNumber = pair.Key;
                string line = lines[lineNumber];
                lines[lineNumber] = line.Replace(oldValue, newValue);
            }
            undoList.Push(FilePeek.Text);
            FilePeek.Lines = lines;
            InitFilePeek();
            ScrollToLine(linesWithQuote.Last().Key);
        }

        private void replaceSingleLine()
        {
            FileModified = true;
            string messageFormat = getMessageFormat();
            if (messageFormat == "")
                return;

            int numMsg = messageGrid.Rows.Count - 1;
            string msgID = "T" + numMsg.ToString(),
            oldValue = grdResult.SelectedCells[0].Value.ToString(),
            newValue = messageFormat.Replace("TT", msgID);
            if (Path.GetExtension(FileName) != ".cs")
                newValue = oldValue[0] + newValue + oldValue.Last();
            int lineNumber = GetSelectedLineNumber();
            string[] lines = FilePeek.Lines;
            string line = lines[lineNumber];

            lines[lineNumber] = line.Replace(oldValue, newValue);
            undoList.Push(FilePeek.Text);
            FilePeek.Lines = lines;
            InitFilePeek();
            ScrollToLine(lineNumber);
        }

        private void messageGridOld_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int count = messageGridOld.SelectedCells.Count;
            DataGridViewCell selectedCell = messageGridOld.SelectedCells[count-1];
            int row = selectedCell.RowIndex;
            string msgID = "T" + (messageGrid.Rows.Count),
                oldID = messageGridOld.Rows[row].Cells[0].Value.ToString(),
                msgDesc = messageGridOld.Rows[row].Cells[1].Value.ToString();
            Replace(msgID, msgDesc, oldID);
            SystemMessage.InsertRecord(FileName, msgID, msgDesc);
            InitMessageGrid();
        }

        private string getMessageFormat()
        {
            string extension = Path.GetExtension(FileName);
            Dictionary<string, string> msgFormatLookup = new Dictionary<string, string>(){
                {".aspx", "<%=m_msg[\"TT\"]%>"},
                {".ascx", "<%=m_msg[\"TT\"]%>"},
                {".cs", "m_msg[\"TT\"]"},
                {".js", "SystemMessage.retrieveJSMessage('"+FileName+"','TT')" }
            };
            if (msgFormatLookup.ContainsKey(extension))
                return msgFormatLookup[extension];
            else
                return "";
        }

        private void ReplaceLine(int lineNumber, string replaceLine)
        {
            FileModified = true;
            string[] lines = FilePeek.Lines;
            lines[lineNumber] = replaceLine;
            undoList.Push(FilePeek.Text);
            FilePeek.Lines = lines;
            InitFilePeek();
            ScrollToLine(lineNumber);
        }

        private void insertToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertMessage();
        }

        private void replaceManuallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void insertAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertMessage();
            Replace();
        }

        private void detailSearchGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = detailSearchGrid.Rows[e.RowIndex];
                int lineNumber = Convert.ToInt32(row.Cells[0].Value);
                string replaceLine = row.Cells[1].Value.ToString();
                ReplaceLine(lineNumber, replaceLine);
            }
        }

        private void SaveFile()
        {
            //string[] folderNames = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\results");
            //var q = from names in folderNames
            //        select Convert.ToInt32(Regex.Split(names, @"\\").Last().Split(' ').First());
            //int maxNum = q.Max();
            //int index = q.ToList().IndexOf(maxNum);

            //string idPath = folderNames[index],
            //    modifyPath = idPath + "\\Modified",
            //    backupPath = idPath + "\\Backup";
            ////Directory.CreateDirectory(modifyPath);
            ////Directory.CreateDirectory(backupPath);

            //string fileName = FileName.Replace("/","\\"),
            //       sourceFile = FilePath,
            //       backupFile = backupPath + "\\" + fileName,
            //       modifiedFile = modifyPath + "\\" + fileName;
            //if (backupPath.Contains("\\"))
            //{
            //    string[] subfolders = Regex.Split(fileName, @"\\");
            //    createDirectory(subfolders, backupPath);
            //    createDirectory(subfolders, modifyPath);
            //}
            //if (!File.Exists(backupFile))
            //    File.Copy(sourceFile, backupFile);
            //if (File.Exists(modifiedFile))
            //    File.Delete(modifiedFile);

            //File.AppendAllText(modifiedFile, string.Join("\r\n", FilePeek.Lines));

            File.WriteAllLines(FilePath, FilePeek.Lines);
        }

        private void createDirectory(string [] subfolders, string currentPath)
        {
            foreach (string subfolder in subfolders.Take(subfolders.Length - 1))
            {
                currentPath += "\\" + subfolder;
                if (!Directory.Exists(currentPath))
                    Directory.CreateDirectory(currentPath);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FileModified)
                SaveFile();
        }

        private void searchMsgIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string MsgId = messageGrid.SelectedRows[0].Cells[0].Value.ToString();
            populateDetailSearchGrid(SearchInFile(MsgId));
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            replaceSingleLine();
        }

        private void detailSearchGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                detailSearchGrid.Rows[e.RowIndex].Selected = true;
                detailSearchGrid.CurrentCell = detailSearchGrid.Rows[e.RowIndex].Cells[1];
                detailSearchMenu.Show(detailSearchGrid, e.Location);
                detailSearchMenu.Show(Cursor.Position);
            }
        }

    }

}
