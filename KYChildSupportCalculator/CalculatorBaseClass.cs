﻿using System;
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
        public string firstName;
        public string lastName;
        public string fullName;
        public decimal monthlyIncome;
        public decimal maintPaid;
        public decimal CSPaid;
        public decimal childCarePaid;
        public decimal healthInsPaid;
        public bool isPrimaryResidence;
        public decimal adjustedMonthlyGross;
        public decimal contribution;
        public decimal totalSupportObligation;
        public decimal individualSupportObligation;
    }

    public class GeneralInfo
    {
        public int numberOfChildren;
        public bool equalSchedule;
        public string primaryResidence;
        public decimal combinedIncome;
        public string payorSwitch;
        public string whoIsPayor;
    }

    public class Results
    {
        public int incomeForTable;
        public string baseSupportText;
        public int baseSupport;
        public decimal totalChildCare;
        public decimal totalHealthInsurance;
        public decimal totalSupport;
        public decimal finalChildSupport;    
    }

    public class Calculations
    {
        public static void Definitions()
        {
            //full names

            KYChildSupportCalculator.parentOne.fullName = KYChildSupportCalculator.parentOne.firstName + " " + KYChildSupportCalculator.parentOne.lastName;

            KYChildSupportCalculator.parentOne.fullName = KYChildSupportCalculator.parentOne.firstName + " " + KYChildSupportCalculator.parentOne.lastName;

            //adjusted monthly gross incomes - NOT WORKING

            KYChildSupportCalculator.parentOne.adjustedMonthlyGross =
                KYChildSupportCalculator.parentOne.monthlyIncome -
                KYChildSupportCalculator.parentOne.maintPaid -
                KYChildSupportCalculator.parentOne.CSPaid +
                KYChildSupportCalculator.parentTwo.maintPaid;

            KYChildSupportCalculator.parentTwo.adjustedMonthlyGross =
                KYChildSupportCalculator.parentTwo.monthlyIncome -
                KYChildSupportCalculator.parentTwo.maintPaid -
                KYChildSupportCalculator.parentTwo.CSPaid +
                KYChildSupportCalculator.parentOne.maintPaid;

            //calculations

            KYChildSupportCalculator.generalInfo.combinedIncome =
                KYChildSupportCalculator.parentOne.adjustedMonthlyGross +
                KYChildSupportCalculator.parentTwo.adjustedMonthlyGross;

            KYChildSupportCalculator.results.incomeForTable = (int)(Math.Floor(KYChildSupportCalculator.generalInfo.combinedIncome / 100) * 100);

            KYChildSupportCalculator.parentOne.contribution =
                KYChildSupportCalculator.parentOne.adjustedMonthlyGross /
                KYChildSupportCalculator.generalInfo.combinedIncome;

            KYChildSupportCalculator.parentTwo.contribution =
                KYChildSupportCalculator.parentTwo.adjustedMonthlyGross /
                KYChildSupportCalculator.generalInfo.combinedIncome;

            KYChildSupportCalculator.results.totalChildCare =
                KYChildSupportCalculator.parentOne.childCarePaid +
                KYChildSupportCalculator.parentTwo.childCarePaid;

            KYChildSupportCalculator.results.totalHealthInsurance =
                KYChildSupportCalculator.parentOne.healthInsPaid +
                KYChildSupportCalculator.parentTwo.healthInsPaid;

            KYChildSupportCalculator.results.totalSupport =
                KYChildSupportCalculator.results.baseSupport +
                KYChildSupportCalculator.results.totalChildCare +
                KYChildSupportCalculator.results.totalHealthInsurance;

            KYChildSupportCalculator.parentOne.individualSupportObligation =
                (KYChildSupportCalculator.results.totalSupport *
                KYChildSupportCalculator.parentOne.contribution) -
                KYChildSupportCalculator.parentOne.healthInsPaid -
                KYChildSupportCalculator.parentOne.childCarePaid;

            KYChildSupportCalculator.parentTwo.individualSupportObligation =
                (KYChildSupportCalculator.results.totalSupport *
                KYChildSupportCalculator.parentTwo.contribution) -
                KYChildSupportCalculator.parentTwo.healthInsPaid -
                KYChildSupportCalculator.parentTwo.childCarePaid;
        }

        public static void WorksheetSelector()
        { 
            //if statement for switch

            if (KYChildSupportCalculator.generalInfo.equalSchedule == true)
            {
                KYChildSupportCalculator.generalInfo.payorSwitch = "both";
            }
            else if (KYChildSupportCalculator.generalInfo.equalSchedule == false && KYChildSupportCalculator.parentOne.isPrimaryResidence == true)
            {
                KYChildSupportCalculator.generalInfo.payorSwitch = "1";
            }
            else if (KYChildSupportCalculator.generalInfo.equalSchedule == false && KYChildSupportCalculator.parentTwo.isPrimaryResidence == true)
            {
                KYChildSupportCalculator.generalInfo.payorSwitch = "2";
            }

            //switch to determine which formula to use and which parent pays

            switch (KYChildSupportCalculator.generalInfo.payorSwitch)
            {
                case "both":

                    if (KYChildSupportCalculator.parentOne.individualSupportObligation == KYChildSupportCalculator.parentTwo.individualSupportObligation)
                    {
                        KYChildSupportCalculator.results.finalChildSupport = 0;
                        KYChildSupportCalculator.generalInfo.whoIsPayor = "noPayor";
                    }

                    else if (KYChildSupportCalculator.parentOne.individualSupportObligation > KYChildSupportCalculator.parentTwo.individualSupportObligation)
                    {
                        KYChildSupportCalculator.results.finalChildSupport =
                        KYChildSupportCalculator.parentOne.individualSupportObligation - KYChildSupportCalculator.parentTwo.individualSupportObligation;
                        KYChildSupportCalculator.generalInfo.whoIsPayor = "parent1";
                    }
                    else if (KYChildSupportCalculator.parentOne.individualSupportObligation < KYChildSupportCalculator.parentTwo.individualSupportObligation)
                    {
                        KYChildSupportCalculator.results.finalChildSupport =
                        KYChildSupportCalculator.parentTwo.individualSupportObligation - KYChildSupportCalculator.parentOne.individualSupportObligation;
                        KYChildSupportCalculator.generalInfo.whoIsPayor = "parent2";
                    }
                    break;

                case "1":
                    KYChildSupportCalculator.results.finalChildSupport =
                        KYChildSupportCalculator.parentOne.individualSupportObligation;
                    break;

                case "2":
                    KYChildSupportCalculator.results.finalChildSupport =
                        KYChildSupportCalculator.parentTwo.individualSupportObligation;
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
            string path = @"C:\Users\mjlaw\source\repos\KYChildSupportCalculator\ChildSupportTable.csv";

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

            int lookUpRow = KYChildSupportCalculator.results.incomeForTable / 100;
            int lookUpColumn = KYChildSupportCalculator.generalInfo.numberOfChildren;
            KYChildSupportCalculator.results.baseSupportText = fullTable[lookUpRow, lookUpColumn];

            //add validation;

            KYChildSupportCalculator.results.baseSupport = int.Parse(KYChildSupportCalculator.results.baseSupportText);
        }
    }
}

