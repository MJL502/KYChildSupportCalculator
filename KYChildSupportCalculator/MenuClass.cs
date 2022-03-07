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

            Console.WriteLine("What is your first name?");
            KYChildSupportCalculator.parentOne.firstName = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            KYChildSupportCalculator.parentOne.lastName = Console.ReadLine();

            Console.WriteLine("\nWhat is the other Parents first name?");
            KYChildSupportCalculator.parentTwo.firstName = Console.ReadLine();

            Console.WriteLine("What is the other Parents last name?");
            KYChildSupportCalculator.parentTwo.lastName = Console.ReadLine();

            KYChildSupportCalculator.generalInfo.numberOfChildren = Validation.Prompt4Integer($"\nHow many children do you have with {KYChildSupportCalculator.parentTwo.firstName}?", "You did not enter a valid selection.  Please type a number (not a word) and press enter.\n");

            KYChildSupportCalculator.generalInfo.equalSchedule = Validation.Prompt4YesNo($"\nDo you and { KYChildSupportCalculator.parentTwo.firstName} {KYChildSupportCalculator.parentTwo.lastName} have an equal parenting schedule, yes ('Y') or no ('N')?\n");
            
            if (KYChildSupportCalculator.generalInfo.equalSchedule == false)
            {
                KYChildSupportCalculator.generalInfo.primaryResidence = Validation.Prompt4Integer
                    (
                    "\nWhich parent do the children reside with a majority of the time?\n" +
                    "Please enter '1' if the children live with you a majority of the time.\n" +
                    "Please enter '2' if the children reside with the other parent a majority of the time.\n",
                    "You did not enter a valid selection.\n" +
                    "Please enter '1' if the children live with you a majority of the time.\n" +
                    "Please enter '2' if the children reside with the other parent a majority of the time.\n",
                    2
                    );

                if (KYChildSupportCalculator.generalInfo.primaryResidence == 1)
                {
                    KYChildSupportCalculator.parentOne.isPrimaryResidence = true;
                }

                else if (KYChildSupportCalculator.generalInfo.primaryResidence == 2)
                {
                    KYChildSupportCalculator.parentTwo.isPrimaryResidence = true;
                }
            }  
        }
        public static void StepTwoHeader()
        {
            Header();
            Console.WriteLine($"Parent One: {KYChildSupportCalculator.parentOne.fullName}");
            Console.WriteLine($"Parent Two: {KYChildSupportCalculator.parentTwo.fullName}");
            Console.WriteLine($"Child(ren): {KYChildSupportCalculator.generalInfo.numberOfChildren}");
            ScheduleHeader();
            Console.WriteLine("STEP 2 - INCOME INFORMATION\n\n");
        }

        public static void ScheduleHeader()
        {
            if (KYChildSupportCalculator.generalInfo.equalSchedule == true)
            {
                Console.WriteLine($"Parenting Schedule: Equal\n\n");
            }
            if (KYChildSupportCalculator.generalInfo.equalSchedule == false)
            {
                if (KYChildSupportCalculator.parentOne.isPrimaryResidence == true)
                {
                    Console.WriteLine($"Parenting Schedule: Not Equal\nPrimary Residence: {KYChildSupportCalculator.parentOne.firstName}\n\n");
                }

                if (KYChildSupportCalculator.parentTwo.isPrimaryResidence == true)
                {
                    Console.WriteLine($"Parenting Schedule: Not Equal\nPrimary Residence: { KYChildSupportCalculator.parentTwo.firstName}\n\n");
                }
            }
        }

        public static void StepTwoQuestions()
        {
            MenuClasses.StepTwoHeader();

            KYChildSupportCalculator.parentOne.monthlyIncome = Validation.Prompt4Decimal($"What is your gross monthly income?", "You did not enter a valid selection.  Please enter your gross monthly income as a number.  Do not use any dollar signs or commas.  Just enter a number.");

            KYChildSupportCalculator.parentTwo.monthlyIncome = Validation.Prompt4Decimal($"What is {KYChildSupportCalculator.parentTwo.firstName}'s gross monthly income?", "You did not enter a valid selection.  Please enter your gross monthly income as a number.  Do not use any dollar signs or commas.  Just enter a number.");
        }

        public static void StepThreeHeader()
        {
            Header();
            Console.WriteLine($"Parent One: {KYChildSupportCalculator.parentOne.fullName} makes {KYChildSupportCalculator.parentOne.monthlyIncome} per month.");
            Console.WriteLine($"Parent Two: {KYChildSupportCalculator.parentTwo.fullName} makes {KYChildSupportCalculator.parentTwo.monthlyIncome} per month.");
            Console.WriteLine($"Child(ren): {KYChildSupportCalculator.generalInfo.numberOfChildren}");
            ScheduleHeader();
            Console.WriteLine("STEP 3 - EXPENSE INFORMATION\n\n");
        }

        public static void StepThreeQuestions()
        {
            MenuClasses.StepThreeHeader();

            //Maintenance payments

            string errorMessage = "You did not enter a valid selection. Please type a number (not a word) and press enter. Do not use any dollar signs or commas.  Just enter a number.";

            KYChildSupportCalculator.parentOne.maintPaid = Validation.Prompt4Decimal($"If you pay maintenance to {KYChildSupportCalculator.parentTwo.firstName}, enter the monhtly amount now.  If you do not pay maintenance enter 0.", errorMessage);

            KYChildSupportCalculator.parentTwo.maintPaid = Validation.Prompt4Decimal($"If {KYChildSupportCalculator.parentTwo.firstName} pays you maintenance, enter the monhtly amount now.  If {KYChildSupportCalculator.parentTwo.firstName} does not pay maintenance enter 0.", errorMessage);
            Console.WriteLine();

            //Prior born child support payments

            KYChildSupportCalculator.parentOne.CSPaid = Validation.Prompt4Decimal($"If you pay child support for PRIOR born children, enter the monhtly amount now.  If you do not pay child support for prior born children enter 0.", errorMessage);

            KYChildSupportCalculator.parentTwo.CSPaid = Validation.Prompt4Decimal($"If {KYChildSupportCalculator.parentTwo.firstName} pays child support for PRIOR born children, enter the monhtly amount now.  If {KYChildSupportCalculator.parentTwo.firstName} does not pay child support for PRIOR born children enter 0.", errorMessage);
            Console.WriteLine();

            //Child Care Costs

            KYChildSupportCalculator.parentOne.childCarePaid = Validation.Prompt4Decimal($"If you pay for child care, enter the monthly amount.  If you do not pay for child care enter 0.", errorMessage);

            KYChildSupportCalculator.parentTwo.childCarePaid = Validation.Prompt4Decimal($"If {KYChildSupportCalculator.parentTwo.firstName} pays for child care costs, enter the monthly amount.  If {KYChildSupportCalculator.parentTwo.firstName} does not pay for child care enter 0.", errorMessage);
            Console.WriteLine();

            //Health Insurance Costs

            KYChildSupportCalculator.parentOne.healthInsPaid = Validation.Prompt4Decimal($"If you pay for health insurance for your child(ren), enter the monthly amount.  If you do not pay for child care enter 0.", errorMessage);

            KYChildSupportCalculator.parentTwo.healthInsPaid = Validation.Prompt4Decimal($"If {KYChildSupportCalculator.parentTwo.firstName} pays for health insurance for your child(ren), enter the monthly amount.  If {KYChildSupportCalculator.parentTwo.firstName} does not pay for child care enter 0.", errorMessage);
        }

        public static void FinalHeader()
        {
            Header();
            Console.WriteLine($"Parent One: {KYChildSupportCalculator.parentOne.fullName} makes {KYChildSupportCalculator.parentOne.monthlyIncome} per month and the adjusted grosss income is {KYChildSupportCalculator.parentOne.adjustedMonthlyGross}.");
            Console.WriteLine($"Parent Two: {KYChildSupportCalculator.parentTwo.fullName} makes {KYChildSupportCalculator.parentTwo.monthlyIncome} per month and the adjusted grosss income is {KYChildSupportCalculator.parentTwo.adjustedMonthlyGross}.");
            Console.WriteLine($"Child(ren): {KYChildSupportCalculator.generalInfo.numberOfChildren}");
            ScheduleHeader();
        }

        public static void FinalResults()
        {
            FinalHeader();
            //display final child support results using a switch

            switch (KYChildSupportCalculator.generalInfo.whoIsPayor)
            {
                case "noPayor":

                    Console.WriteLine("Based on the information entered neither parent has to pay child support to the other.");
                    break;

                case "parent1":

                    Console.WriteLine($"Based on the information entered {KYChildSupportCalculator.parentOne.firstName} should pay {KYChildSupportCalculator.parentTwo.firstName} {KYChildSupportCalculator.results.finalChildSupport} per month.");
                    break;

                case "parent2":
                    Console.WriteLine($"Based on the information entered {KYChildSupportCalculator.parentTwo.firstName} should pay {KYChildSupportCalculator.parentOne.firstName} {KYChildSupportCalculator.results.finalChildSupport} per month.");
                    break;
            }
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
            Console.WriteLine("Would you like to run another child support calculation (Yes/No)?");
            //exit code

            //time code

            //save code

            //help codes
        }

    }
  
}
