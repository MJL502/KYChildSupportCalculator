namespace KYChildSupportCalculator
{

    public class UserPrompts
    {
        public ChildSupportTable childSupportTable = new ChildSupportTable();

        public static string DisplayMenu(List<string> menu)
        {
            // this will write strings to the console

            foreach (string menuItem in menu)
            {
                Console.WriteLine($"{menuItem}");
            }
            return "";
        }

        public void Header()
        {
            //Header using Console.WriteLine
            Console.Clear();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("++++$                                           $++++");
            Console.WriteLine("++++$     KENTUCKY CHILD SUPPORT CALCULATOR     $++++");
            Console.WriteLine("++++$                                           $++++");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("\n");
        }

        public string WelcomeTextToMenu()
        {
            //welcome menu using strings
            Header();

            string welcome = "WELCOME TO THE KENTUCKY CHILD SUPPORT CALCULATOR\n\n";
            string effectiveDate = "This is based on the laws in effect as of January 2022.\n\n";
            string disclaimer = "By using this calculator you understand, agree, and acknowledge that this calculator provides access to publicily available information and performs mathematical operations.  This calculator does NOT provide legal advice.  Using this calculator does NOT create an attorney-client relationship with the company/persons that created the calculator, or any attorneys, websites, or third parties thay may use the calculator.\nPress ENTER to continue.";

            var menu = new List<string>();
            menu.Add(welcome);
            menu.Add(effectiveDate);
            menu.Add(disclaimer);
            UserPrompts.DisplayMenu(menu);

            return "";
        }
        public string Instructions()
        {
            Header();

            Console.WriteLine("This calculator is extremely easy to use.\n");
            Console.WriteLine("There are 3 steps.\n");
            Console.WriteLine("First, you will enter general information.");
            Console.WriteLine("Second, you will enter income information.");
            Console.WriteLine("Third, you will enter expense information.");
            Console.WriteLine("Then the calculator will do its magic.\n\n");
            Console.WriteLine("Press ENTER to begin.");

            return "";
        }

        public void StepOneQuestions()
        {
            Header();
            Console.WriteLine("STEP 1 - GENERAL INFORMATION\n\n");
            KYChildSupportCalculator.timeSpent.StartTimer();

            Console.WriteLine("What is your first name?");
            childSupportTable.results.generalInfo.parentOne.FirstName = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            childSupportTable.results.generalInfo.parentOne.LastName = Console.ReadLine();

            Console.WriteLine("\nWhat is the other Parents first name?");
            childSupportTable.results.generalInfo.parentTwo.FirstName = Console.ReadLine();

            Console.WriteLine("What is the other Parents last name?");
            childSupportTable.results.generalInfo.parentTwo.LastName = Console.ReadLine();

            childSupportTable.results.generalInfo.NumberOfChildren = Validation.Prompt4Integer($"\nHow many children do you have with {childSupportTable.results.generalInfo.parentTwo.FirstName}?", "You did not enter a valid selection.  Please type a number (not a word) and press enter.\n");

            childSupportTable.results.generalInfo.EqualSchedule = Validation.Prompt4YesNo($"\nDo you and { childSupportTable.results.generalInfo.parentTwo.FirstName} {childSupportTable.results.generalInfo.parentTwo.LastName} have an equal parenting schedule, enter 'Y' for yes OR 'N' for no?\n");

            if (childSupportTable.results.generalInfo.EqualSchedule == false)
            {
                childSupportTable.results.generalInfo.PrimaryResidence = Validation.Prompt4Integer
                    (
                    "\nWhich parent do the children reside with a majority of the time?\n" +
                    "Please enter '1' if the children live with you a majority of the time.\n" +
                    "Please enter '2' if the children reside with the other parent a majority of the time.\n",
                    "You did not enter a valid selection.\n" +
                    "Please enter '1' if the children live with you a majority of the time.\n" +
                    "Please enter '2' if the children reside with the other parent a majority of the time.\n",
                    2
                    );

                if (childSupportTable.results.generalInfo.PrimaryResidence == 1)
                {
                    childSupportTable.results.generalInfo.parentOne.IsPrimaryResidence = true;
                }

                else if (childSupportTable.results.generalInfo.PrimaryResidence == 2)
                {
                    childSupportTable.results.generalInfo.parentTwo.IsPrimaryResidence = true;
                }
            }
        }
        public void StepTwoHeader()
        {
            Header();
            Console.WriteLine($"Parent One: {childSupportTable.results.generalInfo.parentOne.FullName}");
            Console.WriteLine($"Parent Two: {childSupportTable.results.generalInfo.parentTwo.FullName}");
            Console.WriteLine($"Child(ren): {childSupportTable.results.generalInfo.NumberOfChildren}");
            ScheduleHeader();
            Console.WriteLine("STEP 2 - INCOME INFORMATION\n\n");
        }

        public void ScheduleHeader()
        {
            if (childSupportTable.results.generalInfo.EqualSchedule == true)
            {
                Console.WriteLine($"Parenting Schedule: Equal\n\n");
            }
            if (childSupportTable.results.generalInfo.EqualSchedule == false)
            {
                if (childSupportTable.results.generalInfo.parentOne.IsPrimaryResidence == true)
                {
                    Console.WriteLine($"Parenting Schedule: Not Equal\nPrimary Residence: {childSupportTable.results.generalInfo.parentOne.FirstName}\n\n");
                }

                if (childSupportTable.results.generalInfo.parentTwo.IsPrimaryResidence == true)
                {
                    Console.WriteLine($"Parenting Schedule: Not Equal\nPrimary Residence: { childSupportTable.results.generalInfo.parentTwo.FirstName}\n\n");
                }
            }
        }

        public void StepTwoQuestions()
        {
            StepTwoHeader();

            childSupportTable.results.generalInfo.parentOne.MonthlyIncome = Validation.Prompt4Decimal($"What is your gross monthly income?", "You did not enter a valid selection.  Please enter YOUR gross monthly income as a number.  Do not use any dollar signs or commas.  Just enter a number.");

            childSupportTable.results.generalInfo.parentTwo.MonthlyIncome = Validation.Prompt4Decimal($"What is {childSupportTable.results.generalInfo.parentTwo.FirstName}'s gross monthly income?", $"You did not enter a valid selection.  Please enter {childSupportTable.results.generalInfo.parentTwo.FirstName}'s gross monthly income as a number.  Do not use any dollar signs or commas.  Just enter a number.");
        }

        public void StepThreeHeader()
        {
            Header();
            Console.WriteLine($"Parent One: {childSupportTable.results.generalInfo.parentOne.FullName} makes {childSupportTable.results.generalInfo.parentOne.MonthlyIncome} per month.");
            Console.WriteLine($"Parent Two: {childSupportTable.results.generalInfo.parentTwo.FullName} makes {childSupportTable.results.generalInfo.parentTwo.MonthlyIncome} per month.");
            Console.WriteLine($"Child(ren): {childSupportTable.results.generalInfo.NumberOfChildren}");
            ScheduleHeader();
            Console.WriteLine("STEP 3 - EXPENSE INFORMATION\n\n");
        }

        public void StepThreeQuestions()
        {
            StepThreeHeader();

            //Maintenance payments

            string errorMessage = "You did not enter a valid selection. Please type a number (not a word) and press enter. Do not use any dollar signs or commas.  Just enter a number.";

           childSupportTable.results.generalInfo.parentOne.MaintPaid = Validation.Prompt4Decimal($"If you pay maintenance to {childSupportTable.results.generalInfo.parentTwo.FirstName}, enter the monhtly amount now.  If you do not pay maintenance enter 0.", errorMessage);
           childSupportTable.results.generalInfo.parentTwo.OtherParentMaintPaid =childSupportTable.results.generalInfo.parentOne.MaintPaid;

           childSupportTable.results.generalInfo.parentTwo.MaintPaid = Validation.Prompt4Decimal($"If {childSupportTable.results.generalInfo.parentTwo.FirstName} pays you maintenance, enter the monhtly amount now.  If {childSupportTable.results.generalInfo.parentTwo.FirstName} does not pay maintenance enter 0.", errorMessage);
           childSupportTable.results.generalInfo.parentOne.OtherParentMaintPaid =childSupportTable.results.generalInfo.parentTwo.MaintPaid;
            Console.WriteLine();

            //Prior born child support payments

           childSupportTable.results.generalInfo.parentOne.CSPaid = Validation.Prompt4Decimal($"If you pay child support for PRIOR born children, enter the monhtly amount now.  If you do not pay child support for prior born children enter 0.", errorMessage);

           childSupportTable.results.generalInfo.parentTwo.CSPaid = Validation.Prompt4Decimal($"If {childSupportTable.results.generalInfo.parentTwo.FirstName} pays child support for PRIOR born children, enter the monhtly amount now.  If {childSupportTable.results.generalInfo.parentTwo.FirstName} does not pay child support for PRIOR born children enter 0.", errorMessage);
            Console.WriteLine();

            //Child Care Costs

           childSupportTable.results.generalInfo.parentOne.ChildCarePaid = Validation.Prompt4Decimal($"If you pay for child care, enter the monthly amount.  If you do not pay for child care enter 0.", errorMessage);

           childSupportTable.results.generalInfo.parentTwo.ChildCarePaid = Validation.Prompt4Decimal($"If {childSupportTable.results.generalInfo.parentTwo.FirstName} pays for child care costs, enter the monthly amount.  If {childSupportTable.results.generalInfo.parentTwo.FirstName} does not pay for child care enter 0.", errorMessage);
            Console.WriteLine();

            //Health Insurance Costs

           childSupportTable.results.generalInfo.parentOne.HealthInsPaid = Validation.Prompt4Decimal($"If you pay for health insurance for your child(ren), enter the monthly amount.  If you do not pay for child care enter 0.", errorMessage);

           childSupportTable.results.generalInfo.parentTwo.HealthInsPaid = Validation.Prompt4Decimal($"If {childSupportTable.results.generalInfo.parentTwo.FirstName} pays for health insurance for your child(ren), enter the monthly amount.  If {childSupportTable.results.generalInfo.parentTwo.FirstName} does not pay for child care enter 0.", errorMessage);
        }

        public void FinalHeader()
        {
            Header();
            Console.WriteLine($"Parent One: {childSupportTable.results.generalInfo.parentOne.FullName} makes {childSupportTable.results.generalInfo.parentOne.MonthlyIncome} per month and the adjusted grosss income is {childSupportTable.results.generalInfo.parentOne.AdjustedMonthlyGross}.");
            Console.WriteLine($"Parent Two: {childSupportTable.results.generalInfo.parentTwo.FullName} makes {childSupportTable.results.generalInfo.parentTwo.MonthlyIncome} per month and the adjusted grosss income is {childSupportTable.results.generalInfo.parentTwo.AdjustedMonthlyGross}.");
            Console.WriteLine($"Child(ren): {childSupportTable.results.generalInfo.NumberOfChildren}");
            ScheduleHeader();
        }

        public void FinalResults()
        {
            FinalHeader();
            //display final child support results using a switch

            switch (childSupportTable.results.generalInfo.WhoIsPayor)
            {
                case "noPayor":

                    Console.WriteLine("Based on the information entered neither parent has to pay child support to the other.");
                    break;

                case "parent1":

                    Console.WriteLine($"Based on the information entered {childSupportTable.results.generalInfo.parentOne.FirstName} should pay {childSupportTable.results.generalInfo.parentTwo.FirstName} {childSupportTable.results.FinalChildSupport} per month.");
                    break;

                case "parent2":
                    Console.WriteLine($"Based on the information entered {childSupportTable.results.generalInfo.parentTwo.FirstName} should pay {childSupportTable.results.generalInfo.parentOne.FirstName} {childSupportTable.results.FinalChildSupport} per month.");
                    break;
            }

            Console.WriteLine();

            if (childSupportTable.results.generalInfo.parentOne.MonthlyIncome <= 0 ||childSupportTable.results.generalInfo.parentTwo.MonthlyIncome <= 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("***When one parent has no income the Court may be able to impute income to that parent, give the other parent an offset for health insurance they pay, or both.  You should consult an attorney to discuss your options.");
            }

            if (childSupportTable.results.generalInfo.CombinedIncome > childSupportTable.results.MaxIncomeForTable)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("***Since your combined monthly incomes exceeds the maximimum monthly income contemplated by the Kentucky Child Support table the Court could deviate from the calculated child support amount.  You should consult an attorney to discuss your options.");
            }

            KYChildSupportCalculator.timeSpent.EndTimer();
            Console.WriteLine($"\nIt took {KYChildSupportCalculator.timeSpent.CreateTimeSpentString(KYChildSupportCalculator.timeSpent.StartDate, KYChildSupportCalculator.timeSpent.EndDate)} to calculate your child support.");
            Console.ReadLine();
        }

    }

}
