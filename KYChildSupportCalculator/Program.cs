using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYChildSupportCalculator;

namespace KYChildSupportCalculator
{
    public class KYChildSupportCalculator
    {
        public static Parent parentOne = new Parent();
        public static Parent parentTwo = new Parent();
        public static GeneralInfo generalInfo = new GeneralInfo();
        public static Results results = new Results();
        public static TimeSpent timeSpent = new TimeSpent();

        public static void Main()
        {

            Console.Clear();

            MenuClasses.WelcomeTextToMenu();
            Console.ReadLine();
            Console.Clear();

            MenuClasses.Instructions();
            Console.ReadLine();
            Console.Clear();

            bool exit = false;
            do
            {
                //menus
                MenuClasses.StepOneQuestions();
                MenuClasses.StepTwoQuestions();
                MenuClasses.StepThreeQuestions();

                //calculations below must be in this order
                GeneralInfo.GeneralInfoCalculations();
                Parent.ParentFirstCalculations();
                Results.ResultsCalculations();
                ChildSupportTable.ReadTableFromFile();
                Parent.ParentFinalCalculations();
                Results.WorksheetSelector();
                MenuClasses.FinalResults();

                //MenuClasses.WorkSheet();

                //MenuClasses.exitSurvey();

                Tests();

                exit = !Validation.Prompt4YesNo("Would you like to run another child support calculation, enter 'Y' for yes OR 'N' for no?\n");
            }
            while (exit == false);

            Console.WriteLine("Good Bye!");
        }

        public static void Tests()
        {
            Console.WriteLine($"p1 full name is --{KYChildSupportCalculator.parentOne.FullName}--");
            Console.WriteLine($"p2 full name is --{KYChildSupportCalculator.parentTwo.FullName}--");
            Console.WriteLine($"p1 monthly income --{KYChildSupportCalculator.parentOne.MonthlyIncome}--");
            Console.WriteLine($"p2 monthly income --{KYChildSupportCalculator.parentTwo.MonthlyIncome}--");
            Console.WriteLine($"p1 maint is --{KYChildSupportCalculator.parentOne.MaintPaid}--");
            Console.WriteLine($"p2 maint is --{KYChildSupportCalculator.parentTwo.MaintPaid}--");
            Console.WriteLine($"p1 cs is --{KYChildSupportCalculator.parentOne.CSPaid}--");
            Console.WriteLine($"p2 cs is --{KYChildSupportCalculator.parentTwo.CSPaid}--");

            Console.WriteLine($"p1 AGI is --{KYChildSupportCalculator.parentOne.AdjustedMonthlyGross}--");
            Console.WriteLine($"p2 AGI is --{KYChildSupportCalculator.parentTwo.AdjustedMonthlyGross}--");

            Console.WriteLine($"combined income is --{KYChildSupportCalculator.generalInfo.CombinedIncome}--");
            Console.WriteLine($"income for table is --{KYChildSupportCalculator.results.IncomeForTable}--");
            Console.WriteLine($"p1 contribution is --{KYChildSupportCalculator.parentOne.Contribution}--");
            Console.WriteLine($"p2 contribution is --{KYChildSupportCalculator.parentTwo.Contribution}--");

            Console.WriteLine($"p1 cc is --{KYChildSupportCalculator.parentOne.ChildCarePaid}--");
            Console.WriteLine($"p2 cc is --{KYChildSupportCalculator.parentTwo.ChildCarePaid}--");
            Console.WriteLine($"p1 hi is --{KYChildSupportCalculator.parentOne.HealthInsPaid}--");
            Console.WriteLine($"p2 hi is --{KYChildSupportCalculator.parentTwo.HealthInsPaid}--");

            Console.WriteLine($"primary residence is {KYChildSupportCalculator.generalInfo.PrimaryResidence}--");
            Console.WriteLine($"the payor switch is --{KYChildSupportCalculator.generalInfo.PayorSwitch}--");
            Console.WriteLine($"who is payor --{KYChildSupportCalculator.generalInfo.WhoIsPayor}--");

            Console.WriteLine($"kids --{KYChildSupportCalculator.generalInfo.NumberOfChildren}--");
            Console.WriteLine($"kids for table --{KYChildSupportCalculator.generalInfo.ChildrenForTable}--");
            Console.WriteLine($"base support dec --{KYChildSupportCalculator.results.BaseSupport}--");
            Console.WriteLine($"total support --{KYChildSupportCalculator.results.TotalSupport}-- ");

            Console.WriteLine($"p1 iso is --{KYChildSupportCalculator.parentOne.IndividualSupportObligation}--");
            Console.WriteLine($"p2 iso is --{KYChildSupportCalculator.parentTwo.IndividualSupportObligation}--");
            Console.WriteLine($"final support amount --{KYChildSupportCalculator.results.FinalChildSupport}--");
            Console.ReadLine();
        }
    }
}
