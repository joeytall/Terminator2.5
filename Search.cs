using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminator
{
    class Search
    {
        static public int getOccurence(string filePath, List<string> keyWordList)
        {
            List<string> allLines = File.ReadAllLines(filePath).ToList();
            int occurence = 0;

            foreach(string keyWord in keyWordList)
                occurence += allLines.Where(line => line.Contains(keyWord)).Count();

            return occurence;
        }
    }
}
