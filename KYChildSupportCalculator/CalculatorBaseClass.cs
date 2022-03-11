using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYChildSupportCalculator;

namespace KYChildSupportCalculator
{
    public class Parent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public decimal MonthlyIncome { get; set; }
        public decimal MaintPaid { get; set; }
        public decimal OtherParentMaintPaid { get; set; }
        public decimal CSPaid { get; set; }
        public decimal ChildCarePaid { get; set; }
        public decimal HealthInsPaid { get; set; }
        public bool IsPrimaryResidence { get; set; }
        public decimal AdjustedMonthlyGross
        {
            get
            {
                decimal adjustedMonthlyGross = MonthlyIncome - MaintPaid - CSPaid + OtherParentMaintPaid;
                if (adjustedMonthlyGross <= 0)
                { adjustedMonthlyGross = 0; }
                
                return adjustedMonthlyGross;
            }
        }
        public decimal Contribution { get; set; }
        public decimal IndividualSupportObligation { get; set; }


        public static void CalculateEachParentsContribution()
        {
            if (KYChildSupportCalculator.parentOne.AdjustedMonthlyGross <= 0 && KYChildSupportCalculator.parentTwo.AdjustedMonthlyGross > 0)
            {
                KYChildSupportCalculator.parentOne.Contribution = 0;
                KYChildSupportCalculator.parentTwo.Contribution = 1;
            }
            else if (KYChildSupportCalculator.parentTwo.AdjustedMonthlyGross <= 0 && KYChildSupportCalculator.parentOne.AdjustedMonthlyGross > 0)
            {
                KYChildSupportCalculator.parentTwo.Contribution = 0;
                KYChildSupportCalculator.parentOne.Contribution = 1;
            }
            else if (KYChildSupportCalculator.parentTwo.AdjustedMonthlyGross <= 0 && KYChildSupportCalculator.parentOne.AdjustedMonthlyGross <= 0)
            {
                KYChildSupportCalculator.parentOne.Contribution = 0;
                KYChildSupportCalculator.parentOne.Contribution = .5m;
                KYChildSupportCalculator.parentTwo.Contribution = .5m;
            }
            else
            {
                KYChildSupportCalculator.parentOne.Contribution =
                Math.Round(
                KYChildSupportCalculator.parentOne.AdjustedMonthlyGross /
                KYChildSupportCalculator.generalInfo.CombinedIncome
                , 4);

                KYChildSupportCalculator.parentTwo.Contribution =
                Math.Round(
                KYChildSupportCalculator.parentTwo.AdjustedMonthlyGross /
                KYChildSupportCalculator.generalInfo.CombinedIncome
                , 4);
            }
                
        }

        public static void CalculateEachParentsSupportObligation()
        {
            
            if (KYChildSupportCalculator.generalInfo.EqualSchedule == true)
            {
                KYChildSupportCalculator.parentOne.IndividualSupportObligation =
                Math.Round(
                ((KYChildSupportCalculator.results.TotalSupport -
                KYChildSupportCalculator.parentTwo.HealthInsPaid -
                KYChildSupportCalculator.parentTwo.ChildCarePaid) *
                KYChildSupportCalculator.parentOne.Contribution) -
                KYChildSupportCalculator.parentOne.HealthInsPaid -
                KYChildSupportCalculator.parentOne.ChildCarePaid
               , 2);

                KYChildSupportCalculator.parentTwo.IndividualSupportObligation =
                Math.Round(
                ((KYChildSupportCalculator.results.TotalSupport -
                KYChildSupportCalculator.parentOne.HealthInsPaid -
                KYChildSupportCalculator.parentOne.ChildCarePaid) *
                KYChildSupportCalculator.parentTwo.Contribution) -
                KYChildSupportCalculator.parentTwo.HealthInsPaid -
                KYChildSupportCalculator.parentTwo.ChildCarePaid
               , 2);
            }
            else
            {
                KYChildSupportCalculator.parentOne.IndividualSupportObligation =
                Math.Round(
                (KYChildSupportCalculator.results.TotalSupport *
                KYChildSupportCalculator.parentOne.Contribution) -
                KYChildSupportCalculator.parentOne.HealthInsPaid -
                KYChildSupportCalculator.parentOne.ChildCarePaid
                , 2);

                KYChildSupportCalculator.parentTwo.IndividualSupportObligation =
                Math.Round(
                (KYChildSupportCalculator.results.TotalSupport *
                KYChildSupportCalculator.parentTwo.Contribution) -
                KYChildSupportCalculator.parentTwo.HealthInsPaid -
                KYChildSupportCalculator.parentTwo.ChildCarePaid
                , 2);
            }
        }
    }

    public class GeneralInfo
    {
        public int NumberOfChildren { get; set; }
        public int ChildrenForTable
        {
            get
            {
                int numberForTable = NumberOfChildren;
                if (numberForTable > 6)
                { numberForTable = 6; }

                return numberForTable;
            }
        }

        public bool EqualSchedule { get; set; }
        public int PrimaryResidence { get; set; }
        public decimal CombinedIncome
        {
            get
            {
                return KYChildSupportCalculator.parentOne.AdjustedMonthlyGross + KYChildSupportCalculator.parentTwo.AdjustedMonthlyGross;
            }
        }
        public string PayorSwitch { get; set; }
        public string WhoIsPayor { get; set; }
    }

    public class Results
    {
        public int IncomeForTable { get; set; }
        public int MaxIncomeForTable { get; set; }
        public int BaseSupport { get; set; }
        public decimal TotalChildCare
        {
            get 
            {
                return KYChildSupportCalculator.parentOne.ChildCarePaid + KYChildSupportCalculator.parentTwo.ChildCarePaid;
            }
        }

        public decimal TotalHealthInsurance
        {
            get 
            {
                return KYChildSupportCalculator.parentOne.HealthInsPaid + KYChildSupportCalculator.parentTwo.HealthInsPaid;
            }
        }
        public decimal TotalSupport 
        { get
            {
                return BaseSupport + TotalChildCare + TotalHealthInsurance;
            }
        }
        public decimal FinalChildSupport { get; set; }

        public static void WorksheetSelector()
        { 
            //if statement for switch

            if (KYChildSupportCalculator.generalInfo.EqualSchedule == true)
            {
                KYChildSupportCalculator.generalInfo.PayorSwitch = "both";
            }
            else if (KYChildSupportCalculator.generalInfo.EqualSchedule == false && KYChildSupportCalculator.parentOne.IsPrimaryResidence == true)
            {
                KYChildSupportCalculator.generalInfo.PayorSwitch = "2";
            }
            else if (KYChildSupportCalculator.generalInfo.EqualSchedule == false && KYChildSupportCalculator.parentTwo.IsPrimaryResidence == true)
            {
                KYChildSupportCalculator.generalInfo.PayorSwitch = "1";
            }

            //switch to determine which formula to use and which parent pays

            switch (KYChildSupportCalculator.generalInfo.PayorSwitch)
            {
                case "both":

                    if (KYChildSupportCalculator.parentOne.IndividualSupportObligation == KYChildSupportCalculator.parentTwo.IndividualSupportObligation)
                    {
                        KYChildSupportCalculator.results.FinalChildSupport = 0;
                        KYChildSupportCalculator.generalInfo.WhoIsPayor = "noPayor";
                    }

                    else if (KYChildSupportCalculator.parentOne.IndividualSupportObligation > KYChildSupportCalculator.parentTwo.IndividualSupportObligation)
                    {
                        KYChildSupportCalculator.results.FinalChildSupport =
                        KYChildSupportCalculator.parentOne.IndividualSupportObligation - KYChildSupportCalculator.parentTwo.IndividualSupportObligation;
                        KYChildSupportCalculator.generalInfo.WhoIsPayor = "parent1";
                    }
                    else if (KYChildSupportCalculator.parentOne.IndividualSupportObligation < KYChildSupportCalculator.parentTwo.IndividualSupportObligation)
                    {
                        KYChildSupportCalculator.results.FinalChildSupport =
                        KYChildSupportCalculator.parentTwo.IndividualSupportObligation - KYChildSupportCalculator.parentOne.IndividualSupportObligation;
                        KYChildSupportCalculator.generalInfo.WhoIsPayor = "parent2";
                    }
                    break;

                case "1":
                    KYChildSupportCalculator.results.FinalChildSupport =
                        KYChildSupportCalculator.parentOne.IndividualSupportObligation;
                    KYChildSupportCalculator.generalInfo.WhoIsPayor = "parent1";
                    break;

                case "2":
                    KYChildSupportCalculator.results.FinalChildSupport =
                        KYChildSupportCalculator.parentTwo.IndividualSupportObligation;
                    KYChildSupportCalculator.generalInfo.WhoIsPayor = "parent2";
                    break;
            }
        }

        //public static string WorkSheetData(string text)
        //{
        //    int textLength = text.Length;
        //    int toAdd;
        //    //int toRemove;
        //    int startPoint;
        //    string inputText = text;
        //    string finalText;
        //    string spacesToAdd = "";
        //    //StringBuilder spacesToAdd = new StringBuilder("");

        //    //if (textLength == 20)
        //    //{
        //    //    finalText = text;
        //    //}
        //    //return $"{KYChildSupportCalculator.parentOne.firstName}";

        //    //if (textLength > 20)
        //    //{ 
        //    //    //shorten string
        //    //}

        //    if (textLength < 20)
        //    {
        //        toAdd = 20 - textLength;

        //        //for (startPoint = 0; startPoint <= toAdd; startPoint++)
        //        //{
        //        //    spacesToAdd.Append("A");
        //        //}
        //        //return spacesToAdd.ToString();

        //        //finalText = spacesToAdd();


        //        for (startPoint = 1; startPoint <= toAdd; startPoint++)
        //        {
        //            spacesToAdd += " ";
        //        }
        //    }
        //    return inputText + spacesToAdd;
        //}
    }
    public class ChildSupportTable
    {
        public static void ReadTableFromFile()
        {
            string fileName = "ChildSupportTable.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\", fileName);
            //string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\", fileName);
            //string path = @"C:\Users\mjlaw\source\repos\KYChildSupportCalculator\ChildSupportTable.csv";


            //// This text is added only once to the file.
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    string[] createText = { "Hello", "And", "Welcome" };
            //    File.WriteAllLines(path, createText);
            //}

            //// This text is always added, making the file longer over time
            //// if it is not deleted.
            //string appendText = "This is extra text" + Environment.NewLine;
            //File.AppendAllText(path, appendText);

            // Open the file to read from.
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

            KYChildSupportCalculator.results.MaxIncomeForTable = int.Parse(fullTable[(numRows - 1), 0]); 

            if
            (KYChildSupportCalculator.generalInfo.CombinedIncome > KYChildSupportCalculator.results.MaxIncomeForTable)
            {
                KYChildSupportCalculator.results.IncomeForTable = KYChildSupportCalculator.results.MaxIncomeForTable;
            }
            else
            {
                KYChildSupportCalculator.results.IncomeForTable = (int)(Math.Floor(KYChildSupportCalculator.generalInfo.CombinedIncome / 100) * 100);
            }

            int lookUpRow = KYChildSupportCalculator.results.IncomeForTable / 100;
            int lookUpColumn = KYChildSupportCalculator.generalInfo.ChildrenForTable;

            //add validation;
            
            KYChildSupportCalculator.results.BaseSupport = int.Parse(fullTable[lookUpRow, lookUpColumn]);
        }
    }
}


