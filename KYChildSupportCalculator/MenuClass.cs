using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYChildSupportCalculator;


namespace KYChildSupportCalculator
{

    public class MenuClasses
    {
        public static string DisplayMenu(List<string> menu)
        {
            // this is the menu

            foreach (string menuItem in menu)
            {
                Console.WriteLine($"{menuItem}");
            }
            return "";
        }

        public static void Header()
        {
            //Header using Console.WriteLine in a void method
            Console.Clear();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("++++$                                           $++++");
            Console.WriteLine("++++$     KENTUCKY CHILD SUPPORT CALCULATOR     $++++");
            Console.WriteLine("++++$                                           $++++");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("\n");
        }

        public static string WelcomeTextToMenu()
        {
            //welcome menu using strings using a method with a blank return
            Header();

            string welcome = "WELCOME TO THE KENTUCKY CHILD SUPPORT CALCULATOR\n\n";
            string effectiveDate = "This is based on the laws in effect as of January 2022.\n\n";
            string disclaimer = "By using this calculator you understand, agree, and acknowledge that this calculator provides access to publicily available information and performs mathematical operations.  This calculator does NOT provide legal advice.  Using this calculator does NOT create an attorney-client relationship with the company/persons that created the calculator, or any attorneys, websites, or third parties thay may use the calculator.\nPress ENTER to continue.";

            var menu = new List<string>();
            menu.Add(welcome);
            menu.Add(effectiveDate);
            menu.Add(disclaimer);
            MenuClasses.DisplayMenu(menu);

            return "";
        }
        public static string Instructions()
        {
            //instructions using Console.WriteLine
            Header();

            Console.WriteLine("This calculator is extremely easy to use.\n");
            Console.WriteLine("There are 3 steps.\n");
            Console.WriteLine("First, you will enter general information.");
            Console.WriteLine("Second, you will enter income information.");
            Console.WriteLine("Third, you will enter expense information.");
            Console.WriteLine("Then the calculator will do its magic.\n\n");
            Console.WriteLine("At any time you can write HELP for more information about how to answer a question.");
            Console.WriteLine("Press ENTER to begin.");

            //MenuClasses.help = Console.ReadLine();
            //if (help.ToUpper = "HELP")
            //{
            //    Console.WriteLine("Lets wait until you get to the first question before you start asking for help!");
            //    Console.ReadLine();
            //}

            return "";
        }

        public static void StepOneQuestions()
        {
            MenuClasses.Header();
            Console.WriteLine("STEP 1 - GENERAL INFORMATION\n\n");

            KYChildSupportCalculator.timeSpent.StartTimer();

            Console.WriteLine("What is your first name?");
            KYChildSupportCalculator.parentOne.FirstName = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            KYChildSupportCalculator.parentOne.LastName = Console.ReadLine();

            Console.WriteLine("\nWhat is the other Parents first name?");
            KYChildSupportCalculator.parentTwo.FirstName = Console.ReadLine();

            Console.WriteLine("What is the other Parents last name?");
            KYChildSupportCalculator.parentTwo.LastName = Console.ReadLine();

            KYChildSupportCalculator.generalInfo.NumberOfChildren = Validation.Prompt4Integer($"\nHow many children do you have with {KYChildSupportCalculator.parentTwo.FirstName}?", "You did not enter a valid selection.  Please type a number (not a word) and press enter.\n");

            KYChildSupportCalculator.generalInfo.EqualSchedule = Validation.Prompt4YesNo($"\nDo you and { KYChildSupportCalculator.parentTwo.FirstName} {KYChildSupportCalculator.parentTwo.LastName} have an equal parenting schedule, enter 'Y' for yes OR 'N' for no?\n");
            
            if (KYChildSupportCalculator.generalInfo.EqualSchedule == false)
            {
                KYChildSupportCalculator.generalInfo.PrimaryResidence = Validation.Prompt4Integer
                    (
                    "\nWhich parent do the children reside with a majority of the time?\n" +
                    "Please enter '1' if the children live with you a majority of the time.\n" +
                    "Please enter '2' if the children reside with the other parent a majority of the time.\n",
                    "You did not enter a valid selection.\n" +
                    "Please enter '1' if the children live with you a majority of the time.\n" +
                    "Please enter '2' if the children reside with the other parent a majority of the time.\n",
                    2
                    );

                if (KYChildSupportCalculator.generalInfo.PrimaryResidence == 1)
                {
                    KYChildSupportCalculator.parentOne.IsPrimaryResidence = true;
                }

                else if (KYChildSupportCalculator.generalInfo.PrimaryResidence == 2)
                {
                    KYChildSupportCalculator.parentTwo.IsPrimaryResidence = true;
                }
            }  
        }
        public static void StepTwoHeader()
        {
            Header();
            Console.WriteLine($"Parent One: {KYChildSupportCalculator.parentOne.FullName}");
            Console.WriteLine($"Parent Two: {KYChildSupportCalculator.parentTwo.FullName}");
            Console.WriteLine($"Child(ren): {KYChildSupportCalculator.generalInfo.NumberOfChildren}");
            ScheduleHeader();
            Console.WriteLine("STEP 2 - INCOME INFORMATION\n\n");
        }

        public static void ScheduleHeader()
        {
            if (KYChildSupportCalculator.generalInfo.EqualSchedule == true)
            {
                Console.WriteLine($"Parenting Schedule: Equal\n\n");
            }
            if (KYChildSupportCalculator.generalInfo.EqualSchedule == false)
            {
                if (KYChildSupportCalculator.parentOne.IsPrimaryResidence == true)
                {
                    Console.WriteLine($"Parenting Schedule: Not Equal\nPrimary Residence: {KYChildSupportCalculator.parentOne.FirstName}\n\n");
                }

                if (KYChildSupportCalculator.parentTwo.IsPrimaryResidence == true)
                {
                    Console.WriteLine($"Parenting Schedule: Not Equal\nPrimary Residence: { KYChildSupportCalculator.parentTwo.FirstName}\n\n");
                }
            }
        }

        public static void StepTwoQuestions()
        {
            MenuClasses.StepTwoHeader();

            KYChildSupportCalculator.parentOne.MonthlyIncome = Validation.Prompt4Decimal($"What is your gross monthly income?", "You did not enter a valid selection.  Please enter your gross monthly income as a number.  Do not use any dollar signs or commas.  Just enter a number.");

            KYChildSupportCalculator.parentTwo.MonthlyIncome = Validation.Prompt4Decimal($"What is {KYChildSupportCalculator.parentTwo.FirstName}'s gross monthly income?", "You did not enter a valid selection.  Please enter your gross monthly income as a number.  Do not use any dollar signs or commas.  Just enter a number.");
        }

        public static void StepThreeHeader()
        {
            Header();
            Console.WriteLine($"Parent One: {KYChildSupportCalculator.parentOne.FullName} makes {KYChildSupportCalculator.parentOne.MonthlyIncome} per month.");
            Console.WriteLine($"Parent Two: {KYChildSupportCalculator.parentTwo.FullName} makes {KYChildSupportCalculator.parentTwo.MonthlyIncome} per month.");
            Console.WriteLine($"Child(ren): {KYChildSupportCalculator.generalInfo.NumberOfChildren}");
            ScheduleHeader();
            Console.WriteLine("STEP 3 - EXPENSE INFORMATION\n\n");
        }

        public static void StepThreeQuestions()
        {
            MenuClasses.StepThreeHeader();

            //Maintenance payments

            string errorMessage = "You did not enter a valid selection. Please type a number (not a word) and press enter. Do not use any dollar signs or commas.  Just enter a number.";

            KYChildSupportCalculator.parentOne.MaintPaid = Validation.Prompt4Decimal($"If you pay maintenance to {KYChildSupportCalculator.parentTwo.FirstName}, enter the monhtly amount now.  If you do not pay maintenance enter 0.", errorMessage);
            KYChildSupportCalculator.parentTwo.OtherParentMaintPaid = KYChildSupportCalculator.parentOne.MaintPaid;

            KYChildSupportCalculator.parentTwo.MaintPaid = Validation.Prompt4Decimal($"If {KYChildSupportCalculator.parentTwo.FirstName} pays you maintenance, enter the monhtly amount now.  If {KYChildSupportCalculator.parentTwo.FirstName} does not pay maintenance enter 0.", errorMessage);
            KYChildSupportCalculator.parentOne.OtherParentMaintPaid = KYChildSupportCalculator.parentTwo.MaintPaid;
            Console.WriteLine();

            //Prior born child support payments

            KYChildSupportCalculator.parentOne.CSPaid = Validation.Prompt4Decimal($"If you pay child support for PRIOR born children, enter the monhtly amount now.  If you do not pay child support for prior born children enter 0.", errorMessage);

            KYChildSupportCalculator.parentTwo.CSPaid = Validation.Prompt4Decimal($"If {KYChildSupportCalculator.parentTwo.FirstName} pays child support for PRIOR born children, enter the monhtly amount now.  If {KYChildSupportCalculator.parentTwo.FirstName} does not pay child support for PRIOR born children enter 0.", errorMessage);
            Console.WriteLine();

            //Child Care Costs

            KYChildSupportCalculator.parentOne.ChildCarePaid = Validation.Prompt4Decimal($"If you pay for child care, enter the monthly amount.  If you do not pay for child care enter 0.", errorMessage);

            KYChildSupportCalculator.parentTwo.ChildCarePaid = Validation.Prompt4Decimal($"If {KYChildSupportCalculator.parentTwo.FirstName} pays for child care costs, enter the monthly amount.  If {KYChildSupportCalculator.parentTwo.FirstName} does not pay for child care enter 0.", errorMessage);
            Console.WriteLine();

            //Health Insurance Costs

            KYChildSupportCalculator.parentOne.HealthInsPaid = Validation.Prompt4Decimal($"If you pay for health insurance for your child(ren), enter the monthly amount.  If you do not pay for child care enter 0.", errorMessage);

            KYChildSupportCalculator.parentTwo.HealthInsPaid = Validation.Prompt4Decimal($"If {KYChildSupportCalculator.parentTwo.FirstName} pays for health insurance for your child(ren), enter the monthly amount.  If {KYChildSupportCalculator.parentTwo.FirstName} does not pay for child care enter 0.", errorMessage);
        }

        public static void FinalHeader()
        {
            Header();
            Console.WriteLine($"Parent One: {KYChildSupportCalculator.parentOne.FullName} makes {KYChildSupportCalculator.parentOne.MonthlyIncome} per month and the adjusted grosss income is {KYChildSupportCalculator.parentOne.AdjustedMonthlyGross}.");
            Console.WriteLine($"Parent Two: {KYChildSupportCalculator.parentTwo.FullName} makes {KYChildSupportCalculator.parentTwo.MonthlyIncome} per month and the adjusted grosss income is {KYChildSupportCalculator.parentTwo.AdjustedMonthlyGross}.");
            Console.WriteLine($"Child(ren): {KYChildSupportCalculator.generalInfo.NumberOfChildren}");
            ScheduleHeader();
        }

        public static void FinalResults()
        {
            FinalHeader();
            //display final child support results using a switch

            switch (KYChildSupportCalculator.generalInfo.WhoIsPayor)
            {
                case "noPayor":

                    Console.WriteLine("Based on the information entered neither parent has to pay child support to the other.");
                    break;

                case "parent1":

                    Console.WriteLine($"Based on the information entered {KYChildSupportCalculator.parentOne.FirstName} should pay {KYChildSupportCalculator.parentTwo.FirstName} {KYChildSupportCalculator.results.FinalChildSupport} per month.");
                    break;

                case "parent2":
                    Console.WriteLine($"Based on the information entered {KYChildSupportCalculator.parentTwo.FirstName} should pay {KYChildSupportCalculator.parentOne.FirstName} {KYChildSupportCalculator.results.FinalChildSupport} per month.");
                    break;
            }
            KYChildSupportCalculator.timeSpent.EndTimer();
            Console.WriteLine($"\nIt took {KYChildSupportCalculator.timeSpent.CreateTimeSpentString(KYChildSupportCalculator.timeSpent.StartDate, KYChildSupportCalculator.timeSpent.EndDate)} to calculate your child support.");
            Console.ReadLine();
        }

       /* public static void WorksheetToPrint()
        {
            Header();


            Console.WriteLine($"________________________________________________________________________________");
            Console.WriteLine($"| CHILDREN: {Calculations.WorkSheetData(KYChildSupportCalculator.generalInfo.numberOfChildrenText)}                                               |");
            Console.WriteLine($"|______________________________________________________________________________|");

            Console.WriteLine($"|                    |{Calculations.WorkSheetData(KYChildSupportCalculator.parentOne.firstName)}|{Calculations.WorkSheetData(KYChildSupportCalculator.parentTwo.firstName)}|               |");
            Console.WriteLine($"|                    |{Calculations.WorkSheetData(KYChildSupportCalculator.parentOne.lastName)}|{Calculations.WorkSheetData(KYChildSupportCalculator.parentTwo.lastName)}|               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|1. Gross Income     |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|2. Maintenance      |                    |                    |               |");
            Console.WriteLine($"|____________________|____________________|____________________|_______________|");
            Console.WriteLine($"|3. Adjusted Income  |                    |                    |               |");
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
       }*/

        public static void exitSurvey()
        {
            //save code
        }

    }
  
}
