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
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Terminator
{
    public partial class Terminator : Form
    {
        public static string selectedPath;
        private bool newReplace = false;
        private bool expanded = false;
        private string FileName = "",
            ResultIDFolder = "";

        public Terminator()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (console.Text != "")
                console.Text += "\r\nwhatup";
            else
                console.Text = "whatup";
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            string path = txtPath.Text;
            selectedPath = path;
            string[] files;
            if (cbSubfolders.Checked)
                files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            else
                files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
            int numOfFiles = files.Length;
            int index = path.Length + 1;
            console.Text = path + " \r\n";
            resetFilter();
            scanFiles("init");
            //createDirectory();
        }

        private void resetFilter()
        {
            lbExtension.Items.Clear();
            txtContains.Text = "";
            txtExtention.Text = "";
            cbSubfolders.Checked = true;
        }

        private void loadExtensionCombobox(string[] files)
        {
            foreach (string file in files)
            {
                int dotIndex = file.IndexOf('.');
                string extension = file.Substring(dotIndex);
            }

        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                MessageBox.Show("Please select a folder!");
                btnBrowse_Click(null, null);
                return;
            }
            if (newReplace)
            {
                backupFiles();
                newReplace = false;
            }

            if (search.SelectedTab == tabPage1)
                singleLineReplacement();
            else
                multipleLineReplacement();

        }

        void lbFileList_DoubleClick(object sender, System.EventArgs e)
        {
            //var selectedItem = lbFileList.SelectedItem;
            //lbFileList.Items.Remove(selectedItem);
            //console.AppendText(selectedItem.ToString() + "removed. \r\n");
            //console.ScrollToCaret();
        }

        void lbExtension_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string extensions = "";
            foreach (ListItem item in lbExtension.SelectedItems)
            {
                extensions += item.Text + " | ";
                item.Attributes.Add("style", "background-color: lime");
            }
            txtExtention.Text = extensions.Remove(extensions.Length - 3);
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                MessageBox.Show("Please select a folder!");
                btnBrowse_Click(null, null);
                return;
            }

            string fileList = "File List: \r\n";
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            foreach (DataGridViewRow row in Grid.Rows)
                fileList += row.Cells[fileColumnIndex].Value.ToString() + "\r\n";

            Clipboard.SetText(fileList);
            MessageBox.Show("File List Copied to Clipboard Successfully!");
        }

        protected string scanFiles(string mode = "list")
        {
            string path = txtPath.Text,
                fileList = "File List: \r\n",
                extension = txtExtention.Text,
                containWord = txtContains.Text.ToLower(),
                excludeWord = txtNameExclude.Text;
            int index = path.Length + 1;
            string[] totalFiles;
            List<string> extensions = new List<string>(),
                fileNames = new List<string>();
            IEnumerable<string> files;
            SearchOption searchOption = cbSubfolders.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            totalFiles = Directory.GetFiles(path, "*.*", searchOption);
            Grid.DataSource = null;

            if (extension != "")
            {
                List<string> filesWithExt = new List<string>();
                string[] searchPatterns = extension.Split('|');
                foreach (string sp in searchPatterns)
                {
                    files = Directory.EnumerateFiles(path, "*.*", searchOption).Where(s => Regex.Match(s.Substring(index), @"\..*").Value == sp.Trim());
                    filesWithExt.AddRange(files);
                }
                filesWithExt.Sort();
                files = filesWithExt.Where(name => name.ToLower().Contains(containWord));
            }
            else
            {
                files = totalFiles.Where(name => name.ToLower().Contains(containWord));
            }

            if (excludeWord != "")
                files = files.Where(name => !name.ToLower().Contains(excludeWord));

            int fileCount = 0,
                numOfFiles = totalFiles.Length,
                qualifiedCount = files.Count();
            console.Text = "Path: " + path + "\r\n";
            if (extension != "")
                console.AppendText("With Extension: " + extension + " \r\n");
            if (containWord != "")
                console.AppendText("Name Contains:  " + containWord + " \r\n");
            if (excludeWord != "")
                console.AppendText("Name Excludes:  " + excludeWord + " \r\n");

            foreach (string file in files)
            {
                string fileName = file.Substring(index);
                fileList += fileName + "\r\n";
                fileNames.Add(fileName);

                if (mode == "init")
                {
                    string ext = Regex.Match(fileName, @"\..*").Value;
                    if (ext != "" && !extensions.Contains(ext))
                    {
                        extensions.Add(ext);
                        lbExtension.Items.Add(new ListItem(ext));
                    }
                }
                else if (mode != "clipboard")
                {
                    fileCount++;
                    loadingProgressBar(fileName, fileCount, qualifiedCount);
                }
            }
            populateGrid(fileNames);
            progressInfo.Text = "Filter Successfully Finished!";
            console.AppendText(qualifiedCount + " out of " + numOfFiles + " files found after filter. \r\n");
            return fileList;
        }


        private void loadingProgressBar(string fileName, int currentProcess, int total)
        {
            int percent = currentProcess * 100 / total;
            progressBar1.Value = percent;
            progressInfo.Text = fileName;
            progressInfo.Refresh();
            progressPrecent.Text = percent + "%";
            progressPrecent.Refresh();
        }

        protected void singleLineSearch()
        {
            string path = txtPath.Text,
                containWord = txtLineContains.Text,
                notContainWord = txtNotContain.Text;
            int totalFiles = Grid.Rows.Count,
                counter = 0,
                qualifiedCount = 0,
                fileColumnIndex = Grid.Columns["File Name"].Index;
            DataTable dt = new DataTable();
            dt.Columns.Add("Occurence", typeof(int));
            dt.Columns.Add("File Name", typeof(string));
            foreach (DataGridViewRow row in Grid.Rows)
            {
                string fileName = row.Cells[fileColumnIndex].Value.ToString(),
                filePath = path + "\\" + fileName;
                List<string> allLines = File.ReadAllLines(filePath).ToList();

                if (!string.IsNullOrEmpty(notContainWord))
                {
                    if (allLines.Where(line => line.Contains(notContainWord)).Count() == 0)
                    {
                        dt.Rows.Add(0,fileName);
                        qualifiedCount++;
                    }
                }
                else if (!string.IsNullOrEmpty(containWord))
                {
                    int occurrence = allLines.Where(line => line.Contains(containWord)).Count();
                    if (occurrence != 0)
                    {
                        dt.Rows.Add(occurrence, fileName);
                        qualifiedCount++;
                    }
                }
                counter++;

                loadingProgressBar(fileName, counter, totalFiles);
            }
            Grid.DataSource = dt;
            //Grid.Columns["Occurence"].DisplayIndex = 0;
            Grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            progressInfo.Text = "Search Finished!";
            progressInfo.Refresh();
            console.AppendText("Search files contain: \"" + containWord + "\"\r\n");
            console.AppendText(qualifiedCount + " out of " + totalFiles + " Files Found after search. \r\n");
            console.ScrollToCaret();
        }

        private void populateGrid(List<string> files)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("File Name", typeof(string));
            foreach (string file in files)
                dt.Rows.Add(file);
            Grid.DataSource = dt;
        }

        private void populateGrid(List<string> files, List<int> occurrence)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Occurence", typeof(int));
            dt.Columns.Add("File Name", typeof(string));
            foreach (string file in files)
                dt.Rows.Add(file);
            Grid.DataSource = dt;
        }

        private void populateGridWithMessageCount()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MsgCount", typeof(int));
            dt.Columns.Add("File Name", typeof(string));
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            SqlConnection conn = SystemMessage.InitSqlConnection();
            SqlCommand command = new SqlCommand();
            string sql = "";
            foreach (DataGridViewRow row in Grid.Rows)
            {
                string fileName = row.Cells[fileColumnIndex].Value.ToString();
                string filePath = txtPath.Text + "\\" + fileName;
                string fileNameWithPath = "";
                if (!fileName.Contains("\\"))
                    fileNameWithPath = Regex.Split(txtPath.Text, @"\\").Last() + "/" + fileName;

                fileNameWithPath = SystemMessage.ValidateFilename(fileNameWithPath);
                sql = "SELECT COUNT(*) FROM systemmessage WHERE FILENAME = '" + fileNameWithPath + "'";
                command = new SqlCommand(sql, conn);
                string msgCount = command.ExecuteScalar().ToString();
                dt.Rows.Add(msgCount, fileName);
            }
            Grid.DataSource = dt;
            Grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnListFiles_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                MessageBox.Show("Please select a folder!");
                btnBrowse_Click(null, null);
                return;
            }
            scanFiles("list");
        }

        protected void multipleLineReplacement()
        {
            return;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Alt | Keys.L):
                case (Keys.Alt | Keys.F):
                    btnListFiles_Click(null, null);
                    return true;
                case (Keys.Alt | Keys.C):
                    btnClipboard_Click(null, null);
                    return true;
                case (Keys.Alt | Keys.I):
                    cbSubfolders.Checked = !cbSubfolders.Checked;
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLineContains.Text) && string.IsNullOrEmpty(txtNotContain.Text) )
            {
                MessageBox.Show("Please enter search criteria!");
                return;
            }
            if (Grid.Columns.Count == 2)
                scanFiles("list");
            singleLineSearch();
        }

        private void lbFileList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void singleLineReplacement()
        {
            if (!string.IsNullOrEmpty(txtLineContains.Text) || !string.IsNullOrEmpty(txtNotContain.Text) )
            {
                MessageBox.Show("Please enter search criteria!");
                return;
            }

            if (txtReplaceWith.Text == "")
            {
                MessageBox.Show("Please enter replace criteria!");
                return;
            }

        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            string fileName = Grid.Rows[e.RowIndex].Cells[fileColumnIndex].Value.ToString();
            openSweetAlertWindow(fileName);
            //searchFileForQuotation(fileName);
        }

        private void createDirectory()
        {
            if (!Directory.Exists("results"))
                Directory.CreateDirectory("results");
            string[] folderNames = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\results");
            int newID = folderNames.Length + 1,
            fileColumnIndex = Grid.Columns["File Name"].Index;
            string idPath = "results\\" + newID.ToString() + " - " + Regex.Split(txtPath.Text, @"\\").Last(),
                modifyPath = idPath + "\\Modified",
                backupPath = idPath + "\\Backup";
            Directory.CreateDirectory(modifyPath);
            Directory.CreateDirectory(backupPath);
            ResultIDFolder = idPath;
        }

        private void backupFiles()
        {
            if (!Directory.Exists("results"))
                Directory.CreateDirectory("results");
            string[] folderNames = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\results");
            int newID = folderNames.Length + 1,
            fileColumnIndex = Grid.Columns["File Name"].Index;
            string idPath = "results\\" + newID.ToString() + " - " + Regex.Split(txtPath.Text, @"\\").Last(),
                modifyPath = idPath + "\\Modified",
                backupPath = idPath + "\\Backup";
            Directory.CreateDirectory(modifyPath);
            Directory.CreateDirectory(backupPath);
            ResultIDFolder = idPath;

            foreach (DataGridViewRow row in Grid.Rows)
            {
                string fileName = row.Cells[fileColumnIndex].Value.ToString(),
                    sourceFile = txtPath.Text + "\\" + fileName,
                    backupFile = backupPath + "\\" + fileName;
                if (backupPath.Contains("\\"))
                {
                    string[] subfolders = Regex.Split(fileName, @"\\");
                    string currentPath = backupPath;
                    foreach (string subfolder in subfolders.Take(subfolders.Length - 1))
                    {
                        currentPath += "\\" + subfolder;
                        if (!Directory.Exists(currentPath))
                            Directory.CreateDirectory(currentPath);
                    }
                }
                File.Copy(sourceFile, backupFile);
            }

            File.WriteAllLines(idPath + "\\QueryInfo.txt", Regex.Split(console.Text, "\n"));
        }


        private void console_TextChanged(object sender, EventArgs e)
        {
            newReplace = true;
        }

        private void expand_Click(object sender, EventArgs e)
        {
            if (Grid.DataSource == null)
                return;
            DataGrid.populateWithAlertCount(Grid);
            //populateGridWithMessageCount();
            //int width = expanded ? 814 : 1145;
            //this.ClientSize = new System.Drawing.Size(width, 565);
            //if (expanded)
            //{
            //    string messageCount = SystemMessage.GetMessageCount(FileName);
            //    MessageBox.Show(messageCount);
            //}
            //expanded = !expanded;
            //btnExpand.Text = expanded ? "<-" : "->";
        }

        private void populateGridWithMessage(string fileName)
        {
            FileName = fileName.Replace("\\", "/");
            DataTable dt = SystemMessage.SelectRecord(FileName);
            dataGrid.DataSource = dt;
            dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (expanded == false)
            {
                expanded = true;
                this.ClientSize = new System.Drawing.Size(1145, 565);
                btnExpand.Text = expanded ? "<-" : "->";
            }
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string cell = dataGrid.SelectedCells[0].Value.ToString(),
            columnName = dataGrid.SelectedCells[0].OwningColumn.HeaderText;
            if (columnName == "MessageDesc")
            {
                if (cell != "")
                    MessageBox.Show(cell);
                else
                {
                    int rowIndex = dataGrid.CurrentCell.RowIndex;
                    dataGrid.Rows[rowIndex].Cells[0].Value = "T" + dataGrid.Rows.Count;
                }
            }
        }

        private void Terminator_Load(object sender, EventArgs e)
        {

        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = dataGrid.Rows[e.RowIndex];
                string MsgId = row.Cells[0].Value.ToString(),
                    Message = row.Cells[1].Value.ToString();
                SystemMessage.ModifyRecord(FileName, MsgId, Message);
                populateGridWithMessage(FileName);
            }
        }

        public void deleteMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string MsgId = dataGrid.SelectedRows[0].Cells[0].Value.ToString();
                SystemMessage.DeleteRecord(FileName, MsgId);
                populateGridWithMessage(FileName);
            }
        }

        private void dataGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGrid.Rows[e.RowIndex].Selected = true;
                //rowIndex = e.RowIndex;
                dataGrid.CurrentCell = dataGrid.Rows[e.RowIndex].Cells[1];
                contextMenuStrip1.Show(dataGrid, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void Grid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Grid.Rows[e.RowIndex].Selected = true;
                //rowIndex = e.RowIndex;
                Grid.CurrentCell = Grid.Rows[e.RowIndex].Cells[0];
                contextMenuStrip2.Show(dataGrid, e.Location);
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void removeFileFromGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = Grid.SelectedRows[0];
            int rowIndex = selectedRow.Index;
            string fileName = selectedRow.Cells[0].Value.ToString();
            Grid.Rows.RemoveAt(rowIndex);
            console.AppendText(fileName + " removed. \r\n");
            console.ScrollToCaret();
        }

        private void getMessageFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            string fileName = Grid.SelectedRows[0].Cells[fileColumnIndex].Value.ToString();

            populateGridWithMessage(fileName);

        }

        private void searchForQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            string fileName = Grid.SelectedRows[0].Cells[fileColumnIndex].Value.ToString();
            //searchFileForQuotation(fileName);
        }

        void openSweetAlertWindow(string fileName)
        {
            string filePath = txtPath.Text + "\\" + fileName;
            SweetAlertForm swal = new SweetAlertForm();
            swal.Text = fileName;
            swal.init(filePath);
            swal.ShowDialog();
        }

        void searchFileForQuotation(string fileName)
        {
            string filePath = txtPath.Text + "\\" + fileName;
            if (!fileName.Contains("\\"))
                fileName = Regex.Split(txtPath.Text, @"\\").Last() + "/" + fileName;
            Form2 formQuotation = new Form2();
            formQuotation.Text = fileName;
            formQuotation.InitFilePeek(filePath);
            formQuotation.InitMessageGrid(fileName);
            formQuotation.ShowDialog();
        }

        public bool IsDirectoryEmpty(string path)
        {
            if (path == "")
                return false;
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void Terminator_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (IsDirectoryEmpty(ResultIDFolder + "\\Backup"))
            //    Directory.Delete(ResultIDFolder, true);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (ResultIDFolder == "")
                return;
            string SourcePath = ResultIDFolder + "\\Modified";
            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, "D:\\Development\\"), true);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (ResultIDFolder == "")
                return;
            string SourcePath = ResultIDFolder + "\\Backup";
            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, txtPath.Text), true);
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("Please select a path.");
                return;
            }

            CheckMessageExist();
            //CheckRetrieveMessageExist();
            //ReplaceRetrieveMessageInFiles();
        }

        private void CheckRetrieveMessageExist()
        {
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            List<string> problemFiles = new List<string>();
            foreach (DataGridViewRow row in Grid.Rows)
            {
                string fileName = row.Cells[fileColumnIndex].Value.ToString();
                if (fileName.ToLower().Contains("frame"))
                    continue;
                string filePath = txtPath.Text + "\\" + fileName;
                if (!fileName.Contains("\\"))
                    fileName = Regex.Split(txtPath.Text, @"\\").Last() + "/" + fileName;
                FileName = fileName.Replace("\\", "/");

                List<string> allLines = File.ReadAllLines(filePath).ToList();
                List<string> linesWithMsg = allLines.Where(line => line.Contains("SystemMessage.RetrieveSystemMessage") && !line.Contains("//")).ToList();
                if (linesWithMsg.Count != 0)
                    continue;

                problemFiles.Add(FileName);
                console.AppendText(FileName + "\r\n");
            }
            console.AppendText("\r\n" + problemFiles.Count + " files are not retrieveMSG. \r\n");
            console.AppendText("\r\nDone\r\n");
            console.ScrollToCaret();
        }

        private void CheckMessageExist()
        {
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            SqlConnection conn = SystemMessage.InitSqlConnection();
            SqlCommand command = new SqlCommand();
            string sql = "";
            foreach (DataGridViewRow row in Grid.Rows)
            {
                string fileName = row.Cells[fileColumnIndex].Value.ToString();
                string filePath = txtPath.Text + "\\" + fileName;
                if (!fileName.Contains("\\"))
                    fileName = Regex.Split(txtPath.Text, @"\\").Last() + "/" + fileName;
                FileName = fileName.Replace("\\", "/");

                List<string> allLines = File.ReadAllLines(filePath).ToList();
                List<string> linesWithMsg = allLines.Where(line => line.Contains("m_msg") && !line.Contains("//")).ToList();
                if (linesWithMsg.Count == 0)
                    continue;
                List<string> inFileMsgs = new List<string>();
                List<string> existMsgs = new List<string>(); 
                foreach(string line in linesWithMsg)
                {
                    Regex rx = new Regex(@"T\d+");
                    MatchCollection matches = rx.Matches(line);
                    foreach(Match match in matches)
                        inFileMsgs.Add(match.ToString());
                }
                sql = "SELECT MsgId FROM systemmessage WHERE FILENAME = '" + FileName.Replace(".cs","") + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                }
                catch
                {
                    dt = null;
                }
                da.Dispose();
                if (dt == null && inFileMsgs.Count != 0)
                {
                    console.AppendText(fileName + " has msg issues. \r\n");
                    console.AppendText(String.Join(", ",inFileMsgs).ToString() + " not found in database. \r\n");
                    console.ScrollToCaret();
                }

                foreach(DataRow dtrow in dt.Rows)
                    existMsgs.Add(dtrow[0].ToString());

                foreach(string msg in inFileMsgs)
                {
                    if (!existMsgs.Contains(msg))
                    {
                        console.AppendText(msg + " not found in database for file " + fileName + ". \r\n");
                        console.ScrollToCaret();
                    }
                }
            }
            console.AppendText("\r\nDone\r\n");
            console.ScrollToCaret();
            conn.Close();

        }
        private void ReplaceRetrieveMessageInFiles()
        {
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            foreach (DataGridViewRow row in Grid.Rows)
            {
                string fileName = row.Cells[fileColumnIndex].Value.ToString();
                string filePath = txtPath.Text + "\\" + fileName;
                List<string> allLines = File.ReadAllLines(filePath).ToList();
                List<string> linesToWrite = new List<string>();
                bool skip = false;
                if (allLines.Where(line => line.Contains("RetrieveMessage")).Count() == 0)
                    continue;
                else
                {
                    console.AppendText(fileName + " replaced. \r\n");
                    console.ScrollToCaret();
                }
                string replaceLine = "SystemMessage.RetrieveSystemMessage(this.Page.ToString(), out m_msg, litMessage);";
                if (fileName.Contains("header"))
                    replaceLine = "SystemMessage.RetrieveSystemMessage(this.Page.ToString(), out m_msg, null);";

                foreach (string line in allLines)
                {
                    if (skip == true)
                    {
                        if (line.Contains("}"))
                            skip = false;
                        continue;
                    }

                    string lineToWrite = line;
                    if (line.Contains("RetrieveMessage"))
                    {
                        if (line.Contains("void"))
                        {
                            skip = true;
                            continue;
                        }
                        lineToWrite = getIndent(line) + replaceLine;
                    }
                    linesToWrite.Add(lineToWrite);
                }
                File.WriteAllLines(filePath, linesToWrite);
            }
            MessageBox.Show("Retrieve Message Successfully Replaced!");
        }

        private string getIndent(string line)
        {
            string indent = "";
            foreach (char c in line)
            {
                if (c == ' ')
                    indent += c;
                else
                    break;
            }
            return indent;
        }

        private void btnLitMessage_Click(object sender, EventArgs e)
        {
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            List<string> filesWithDuplicatedLitmessage = new List<string>();
            List<string> filesWithoutBody = new List<string>();
            foreach (DataGridViewRow row in Grid.Rows)
            {
                string fileName = row.Cells[fileColumnIndex].Value.ToString();
                string filePath = txtPath.Text + "\\" + fileName;
                List<string> allLines = File.ReadAllLines(filePath).ToList();
                //if (allLines.Where(line => line.ToLower().Contains("id=\"litmessage\"")).Count() == 2)
                //    filesWithDuplicatedLitmessage.Add(fileName);
                //if (allLines.Where(line => line.Contains("<body")).Count() == 0)
                //    filesWithoutBody.Add(fileName);
                if (allLines.Where(line => line.ToLower().Contains("systemmessage")).Count() == 0)
                    filesWithDuplicatedLitmessage.Add(fileName);
            }
            MessageBox.Show(filesWithDuplicatedLitmessage.Count + " files don't have systemmessage initilized");
            populateGrid(filesWithDuplicatedLitmessage);
            //populateGrid(filesWithoutBody);
        }

        private void btnAddLit_Click(object sender, EventArgs e)
        {
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            List<string> problemFiles = new List<string>();
            int counter = 0;
            foreach (DataGridViewRow row in Grid.Rows)
            {
                string fileName = row.Cells[fileColumnIndex].Value.ToString();
                string filePath = txtPath.Text + "\\" + fileName;
                List<string> allLines = File.ReadAllLines(filePath).ToList();
                List<string> linesToWrite = new List<string>();
                string litMessageLine = "<asp:Literal ID=\"litMessage\" runat=\"server\" />";
                foreach (string line in allLines)
                {
                    string lineToWrite = line;
                    if (line.Contains("<body"))
                    {
                        linesToWrite.Add(lineToWrite);
                        lineToWrite = getIndent(line) + litMessageLine;
                        counter++;
                    }
                    linesToWrite.Add(lineToWrite);
                }
                File.WriteAllLines(filePath, linesToWrite);
            }
            MessageBox.Show( counter + " LitMessages out of " + Grid.RowCount + " files  added!");
        }

        private void btnReplaceCSS_Click(object sender, EventArgs e)
        {
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            List<string> problemFiles = new List<string>();
            int counter = 0;
            foreach (DataGridViewRow row in Grid.Rows)
            {
                bool cssfound = false;
                string fileName = row.Cells[fileColumnIndex].Value.ToString();
                if (!fileName.EndsWith(".aspx"))
                    continue;
                string filePath = txtPath.Text + "\\" + fileName;
                List<string> allLines = File.ReadAllLines(filePath).ToList();
                List<string> linesToWrite = new List<string>();
                foreach (string line in allLines)
                {
                    string lineToWrite = line;
                    if (line.Contains("~/Styles/Customer.css"))
                    {
                        lineToWrite = line.Replace("~/Styles", "../styles");
                        cssfound = true;
                        counter++;
                    }
                    linesToWrite.Add(lineToWrite);
                }
                if (cssfound)
                    File.WriteAllLines(filePath, linesToWrite);
            }
            MessageBox.Show(counter + " files out of " + Grid.RowCount + " files  added!");
        }

        private void findCorruptedFiles_Click(object sender, EventArgs e)
        {
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            List<string> targetFiles = SystemMessage.getProblemFiles();
            List<string> problemFiles = new List<string>();
            List<string> corruptedFiles = new List<string>();
            Dictionary<string,List<string>> msgDict = new Dictionary<string,List<string>>();
            foreach (DataGridViewRow row in Grid.Rows)
            {
                bool corrupted = false;
                string fileName = row.Cells[fileColumnIndex].Value.ToString();
                string filePath = txtPath.Text + "\\" + fileName;
                if (!fileName.Contains("\\"))
                    fileName = Regex.Split(txtPath.Text, @"\\").Last() + "/" + fileName;
                FileName = fileName.Replace("\\", "/");
                string dbFileName = FileName.Replace(".cs", "").ToLower();

                if (!targetFiles.Contains(dbFileName))
                    continue;

                List<string> allLines = File.ReadAllLines(filePath).ToList();
                List<string> linesWithMsg = allLines.Where(line => line.Contains("m_msg")).ToList();
                if (linesWithMsg.Count == 0)
                    continue;

                List<string> inFileMsgs = new List<string>();
                foreach (string line in linesWithMsg)
                {
                    MatchCollection matches = Regex.Matches(line, @"T\d+");
                    foreach (Match match in matches)
                    {
                        if (!inFileMsgs.Contains(match.ToString()))
                            inFileMsgs.Add(match.ToString());
                        else
                        {
                            console.AppendText(match.ToString() + " duplicated in " + FileName + ". \r\n");
                            corrupted = true;
                        }
                    }
                }
                if (!msgDict.ContainsKey(dbFileName))
                    msgDict.Add(dbFileName, inFileMsgs);
                else
                {
                    List<string> msgsInCurrentFile = msgDict[dbFileName];
                    foreach (string msg in inFileMsgs)
                    {
                        if (!msgsInCurrentFile.Contains(msg))
                            msgsInCurrentFile.Add(msg);
                        else
                        {
                            console.AppendText(msg + " cross file duplicated in " + FileName + ". \r\n");
                            if (!problemFiles.Contains(FileName))
                                problemFiles.Add(FileName);
                        }
                    }
                }

                if (corrupted)
                    corruptedFiles.Add(FileName);
            }
            console.AppendText("\r\nDone\r\n");
            console.AppendText(corruptedFiles.Count + " files corrupted. \r\n");
            console.AppendText(String.Join("\r\n", corruptedFiles).ToString() + "\r\n\r\n");
            console.AppendText(problemFiles.Count + " files cross file duplicated. \r\n");
            console.AppendText(String.Join("\r\n", problemFiles).ToString() + "\r\n\r\n");
            console.ScrollToCaret();
        }
    }
}
