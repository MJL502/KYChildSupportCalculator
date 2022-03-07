using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYChildSupportCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Child_Support_Table_Reading_From_File()
        {


            /*tests below should all work - will be removed once unit tests are operational


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

        }
    }
}