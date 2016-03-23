using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminator
{
    class DataGrid
    {
        public static void populateWithAlertCount(DataGridView Grid)
        {
            string selectedPath = Terminator.selectedPath;
            DataTable dt = new DataTable();
            dt.Columns.Add("Alert Count", typeof(int));
            dt.Columns.Add("File Name", typeof(string));
            int fileColumnIndex = Grid.Columns["File Name"].Index;
            List<string> keyWordList = new List<string>()
            {
                "alert",
                "confirm"
            };
            foreach (DataGridViewRow row in Grid.Rows)
            {
                string fileName = row.Cells[fileColumnIndex].Value.ToString();
                string filePath = selectedPath + "\\" + fileName;
                int alertCount = Search.getOccurence(filePath, keyWordList);
                dt.Rows.Add(alertCount.ToString(), fileName);
            }
            Grid.DataSource = dt;
            Grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
