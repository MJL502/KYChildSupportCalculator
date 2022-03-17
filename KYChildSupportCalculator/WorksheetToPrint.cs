using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYChildSupportCalculator
{
    public class WorksheetToPrint
    {
        UserPrompts userPrompts = new UserPrompts();

        public string WorkSheetData(Object input)
        {
            string text = input.ToString();
 
            int textLength = text.Length;
            int toAdd;
            //int toRemove;
            int startPoint;
            string finalText;
            string spacesToAdd = "";
            //StringBuilder spacesToAdd = new StringBuilder("");

            //if (textLength == 20)
            //{
            //    finalText = text;
            //}
            //return $"{KYChildSupportCalculator.parentOne.firstName}";

            //if (textLength > 20)
            //{ 
            //    //shorten string
            //}

            if (textLength < 20)
            {
                toAdd = 20 - textLength;

                //for (startPoint = 0; startPoint <= toAdd; startPoint++)
                //{
                //    spacesToAdd.Append("A");
                //}
                //return spacesToAdd.ToString();

                //finalText = spacesToAdd();


                for (startPoint = 1; startPoint <= toAdd; startPoint++)
                {
                    spacesToAdd += " ";
                }
            }
            return text + spacesToAdd;
        }
        public void ViewableSheet()
        {

            Console.WriteLine($"________________________________________________________________________________");
            Console.WriteLine($"| CHILDREN: {WorkSheetData(userPrompts.childSupportTable.results.generalInfo.NumberOfChildren)}                                               |");
            Console.WriteLine($"|______________________________________________________________________________|");

            Console.WriteLine($"|                    |{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentOne.FirstName)}|{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentTwo.FirstName)}|               |");
            Console.WriteLine($"|                    |{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentOne.LastName)}|{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentTwo.LastName)}|               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|1. Gross Income     |{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentOne.MonthlyIncome)}|{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentTwo.MonthlyIncome)}|               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|2. Maintenance      |{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentOne.MaintPaid)}|{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentTwo.MaintPaid)}|               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|3. Adjusted Income  |{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentOne.AdjustedMonthlyGross)}|{WorkSheetData(userPrompts.childSupportTable.results.generalInfo.parentTwo.MonthlyIncome)}|               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|4. Percentages      |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|5. Base Support     |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|6. Child Care       |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|7. Health insurance |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|8. Total Support    |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|10. Deductions      |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|11. Child Support   |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|                                                                              |");
            Console.WriteLine($"|______________________________________________________________________________|");
            Console.WriteLine($"|paid monthly        |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|paid bi-monthly     |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|paid bi-weekly      |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|paid weekly         |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
        }
    }
}
