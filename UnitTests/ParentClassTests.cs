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
        public void Parent_AdjustedMonthlyIncome_Is_Correct_Returns_True()
        {
            //Arrange
            var testParent = new Parent();

            //Add
            testParent.MonthlyIncome = 1000;
            testParent.MaintPaid = 50;
            testParent.CSPaid = 100;

            //Assert
            Assert.IsTrue(testParent.AdjustedMonthlyGross == 850);
        }

        /*
        public void Parent_Contribution_Is_Correct_Returns_True()
        {
            //Arrange
            var parentOne = new Parent();
            var parentTwo = new Parent();
            var mock = Substitute.For<Parent.CalculateEachParentsContribution>();
            //using NSubstitute NuGet package
            
            //Add
            mock.parentOne.AdjustedMonthlyGross = 1000;
            mock.parentTwo.AdjustedMonthlyGross = 3000;

            //Assert
            Assert.IsTrue(parentOne.Contribution == .25m && parentTwo.Contribution == .75m);
        }
        */
    }

    [TestClass]
    public class GeneralInfoTests
    {
        [TestMethod]
        public void CombinedIncome_Is_Correct_Returns_True()
        {
            //Arrange

            //Add

            //Assert
            
        }
    }
    [TestClass]

    public class ResultsTests
    {
        [TestMethod]
        public void CSV_File_Path_Is_Correct_Returns_True()
        {
            //Arrange
            string fileName = "ChildSupportTable.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\", fileName);

            //Add

            //Assert
            Assert.IsTrue(File.Exists(path));

        }

        /*
        public void Child_Support_Table_Reading_From_File_Returns_True()
        {
            //Arrange

            //Add

            //Assert

            //tests below should all work - will be removed once unit tests are operational


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

        }
        */
    }
}