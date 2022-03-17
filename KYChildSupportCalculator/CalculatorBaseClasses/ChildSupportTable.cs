using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYChildSupportCalculator
{
    public class ChildSupportTable
    {
        public Results results = new Results();
        public void ReadTableFromFile()
        {
            string fileName = "ChildSupportTable.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TableData\", fileName);
            
            /*
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string[] createText = { "Hello", "And", "Welcome" };
                File.WriteAllLines(path, createText);
            }

            // This text is always added, making the file longer over time if it is not deleted.
            string appendText = "This is extra text" + Environment.NewLine;
            File.AppendAllText(path, appendText);
            */

            //Open the file to read from.
            string[] tableRows = File.ReadAllLines(path);

            int numRows = tableRows.Length;
            int numColumns = tableRows[0].Split(',').Length;

            string[,] fullTable = new string[numRows, numColumns];

            for (int r = 0; r < numRows; r++)
            {
                string[] singleRow = tableRows[r].Split(',');
                for (int c = 0; c < numColumns; c++)
                {
                    fullTable[r, c] = singleRow[c];
                }
            }

            results.MaxIncomeForTable = int.Parse(fullTable[(numRows - 1), 0]);

            if
            (results.generalInfo.CombinedIncome > results.MaxIncomeForTable)
            {
                results.IncomeForTable = results.MaxIncomeForTable;
            }
            else
            {
                results.IncomeForTable = (int)(Math.Floor(results.generalInfo.CombinedIncome / 100) * 100);
            }

            int lookUpRow = results.IncomeForTable / 100;
            int lookUpColumn = results.generalInfo.ChildrenForTable;

            results.BaseSupport = int.Parse(fullTable[lookUpRow, lookUpColumn]);
        }
    }
}
