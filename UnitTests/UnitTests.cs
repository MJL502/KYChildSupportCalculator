using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYChildSupportCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTests
{
    [TestClass]
    public class ParentClassTests
    {
        [TestMethod]

        public void Parent_FullName_Is_Correct_Returns_True()
        {
            //Arrange
            var testParent = new Parent();

            //Add
            testParent.FirstName = "John";
            testParent.LastName = "Doe";

            //Assert
            Assert.IsTrue(testParent.FullName == "John Doe");
        }

        [TestMethod]
        public void Parent_AdjustedMonthlyIncome_Is_Correct_Returns_True2()
        {
            //Arrange
            GeneralInfo generalInfo = new GeneralInfo();

            //Add
            generalInfo.parentOne.MonthlyIncome = 1000;
            generalInfo.parentOne.MaintPaid = 50;
            generalInfo.parentOne.CSPaid = 100;

            //Assert
            Assert.IsTrue(generalInfo.parentOne.AdjustedMonthlyGross == 850);
        }
    }

    [TestClass]
    public class GeneralInfoTests
    {
        [TestMethod]
        public void CombinedIncome_Is_Correct_Returns_True()
        {
            //Arrange
            GeneralInfo generalInfo = new GeneralInfo();

            //Add
            generalInfo.parentOne.MonthlyIncome = 7500m;
            generalInfo.parentOne.MaintPaid = 0;
            generalInfo.parentOne.CSPaid = 0;
            generalInfo.parentOne.OtherParentMaintPaid = 0;

            generalInfo.parentTwo.MonthlyIncome = 2500m;
            generalInfo.parentTwo.MaintPaid = 0;
            generalInfo.parentTwo.CSPaid = 0;
            generalInfo.parentTwo.OtherParentMaintPaid = 0;

            //Assert
            Assert.IsTrue(generalInfo.CombinedIncome == 10000m);
        }

        [TestMethod]
        public void Parent_Contribution_Is_Correct_Returns_True()
        {
            //Arrange
            GeneralInfo generalInfo = new GeneralInfo();

            //Add
            generalInfo.parentOne.MonthlyIncome = 6000;
            generalInfo.parentTwo.MonthlyIncome = 4000;

            //Assert
            Assert.IsTrue(generalInfo.parentOne.Contribution == 6000 / 10000);
        }
    }

    [TestClass]
    public class ResultsTests
    {

        [TestMethod]
        public void Total_ChildCare_Is_Correct_Returns_True()
        {
            //Arrange
            Results results = new Results();

            //Add
            results.generalInfo.parentOne.ChildCarePaid = 300;
            results.generalInfo.parentTwo.ChildCarePaid = 300;

            //Assert
            Assert.IsTrue(results.TotalChildCare == 600);
        }

        [TestMethod]
        public void Total_HelthInsurance_Is_Correct_Returns_True()
        {
            //Arrange
            Results results = new Results();

            //Add
            results.generalInfo.parentOne.HealthInsPaid = 200;
            results.generalInfo.parentTwo.HealthInsPaid = 200;

            //Assert
            Assert.IsTrue(results.TotalHealthInsurance == 400);
        }
    }

    [TestClass]
    public class ChildSupportTableTests
    {
        [TestMethod]
        public void CSV_File_Path_Is_Correct_Returns_True()
        {
            //Arrange
            string fileName = "ChildSupportTable.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\KYChildSupportCalculator\bin\Debug\net6.0\TableData", fileName);

            //Add

            //Assert
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void Reading_From_Table_Correct_Returns_True()
        {
            //Arrange
            string fileName = "ChildSupportTable.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\KYChildSupportCalculator\bin\Debug\net6.0\TableData", fileName);
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
            int MaxIncomeForTable = int.Parse(fullTable[(numRows - 1), 0]);
            //Add


            //Assert
            Assert.IsTrue(MaxIncomeForTable == 30000);
        }
    }
}
            /*
                Console.WriteLine($"p1 full name is --{KYChildSupportCalculator.parentOne.fullName}--");
                Console.WriteLine($"p2 full name is --{KYChildSupportCalculator.parentTwo.fullName}--");
                Console.WriteLine($"p1 monthly income --{KYChildSupportCalculator.parentOne.monthlyIncome}--");
                Console.WriteLine($"p2 monthly income --{KYChildSupportCalculator.parentTwo.monthlyIncome}--");
                Console.WriteLine($"p1 maint is --{KYChildSupportCalculator.parentOne.maintPaid}--");
                Console.WriteLine($"p2 maint is --{KYChildSupportCalculator.parentTwo.maintPaid}--");
                Console.WriteLine($"p1 cs is --{KYChildSupportCalculator.parentOne.CSPaid}--");
                Console.WriteLine($"p2 cs is --{KYChildSupportCalculator.parentTwo.CSPaid}--");

                Console.WriteLine($"p1 AGI is --{KYChildSupportCalculator.parentOne.adjustedMonthlyGross}--");
                Console.WriteLine($"p2 AGI is --{KYChildSupportCalculator.parentTwo.adjustedMonthlyGross}--");

                Console.WriteLine($"combined income is --{KYChildSupportCalculator.generalInfo.combinedIncome}--");
                Console.WriteLine($"income for table is --{KYChildSupportCalculator.results.incomeForTable}--");
                Console.WriteLine($"p1 contribution is --{KYChildSupportCalculator.parentOne.contribution}--");
                Console.WriteLine($"p2 contribution is --{KYChildSupportCalculator.parentTwo.contribution}--");

                Console.WriteLine($"p1 cc is --{KYChildSupportCalculator.parentOne.childCarePaid}--");
                Console.WriteLine($"p2 cc is --{KYChildSupportCalculator.parentTwo.childCarePaid}--");
                Console.WriteLine($"p1 hi is --{KYChildSupportCalculator.parentOne.healthInsPaid}--");
                Console.WriteLine($"p2 hi is --{KYChildSupportCalculator.parentTwo.healthInsPaid}--");

                Console.WriteLine($"primary residence is {KYChildSupportCalculator.generalInfo.primaryResidence}--");
                Console.WriteLine($"the payor switch is --{KYChildSupportCalculator.generalInfo.payorSwitch}--");
                Console.WriteLine($"who is payor --{KYChildSupportCalculator.generalInfo.whoIsPayor}--");

                Console.WriteLine($"kids --{KYChildSupportCalculator.generalInfo.numberOfChildren}--");
                Console.WriteLine($"kids for table --{KYChildSupportCalculator.generalInfo.childrenForTable}--");
                Console.WriteLine($"base support dec --{KYChildSupportCalculator.results.baseSupport}--");
                Console.WriteLine($"total support --{KYChildSupportCalculator.results.totalSupport}-- ");

                Console.WriteLine($"p1 iso is --{KYChildSupportCalculator.parentOne.individualSupportObligation}--");
                Console.WriteLine($"p2 iso is --{KYChildSupportCalculator.parentTwo.individualSupportObligation}--");
                Console.WriteLine($"final support amount --{KYChildSupportCalculator.results.finalChildSupport}--");
                Console.ReadLine();
            */
