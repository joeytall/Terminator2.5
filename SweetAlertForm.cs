using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminator
{
    public partial class SweetAlertForm : Form
    {
        public SweetAlertForm()
        {
            InitializeComponent();
        }

        private List<string> keyWordList = new List<string>() { "alert", "confirm" };

        public void init(string filePath)
        {
            FileBox.Text = string.Join("\r\n", File.ReadAllLines(filePath));
            List<string> allLines = File.ReadAllLines(filePath).ToList();
            Dictionary<int, int> keyWordIndices = new Dictionary<int, int>();
            Dictionary<int, int> commentIndices = new Dictionary<int, int>();
            for (int lineNumber = 0; lineNumber < allLines.Count(); lineNumber ++)
            {
                string line = allLines[lineNumber].Trim();
                foreach (string keyWord in keyWordList)
                {
                    //if (line.Contains(keyWord))
                    //    keyWordIndices.Add(1, 2);

                }
            }
            List<string> linesWithKeyWord = allLines.Where(line => line.Contains("alert") || line.Contains("confirm")).ToList();
        }

    }
}
