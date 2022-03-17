namespace KYChildSupportCalculator
{
    public class KYChildSupportCalculator
    {
        public static TimeSpent timeSpent = new TimeSpent();
        
        public static void Main()
        {
            UserPrompts userPrompts = new UserPrompts();
            
            Console.Clear();

            userPrompts.WelcomeTextToMenu(); //calling the non-static method
            Console.ReadLine();
            Console.Clear();

            userPrompts.Instructions();
            Console.ReadLine();
            Console.Clear();

            bool exit = false;
            do
            {
                //menus
                userPrompts.StepOneQuestions();
                userPrompts.StepTwoQuestions();
                userPrompts.StepThreeQuestions();

                //calculations below must be in this order
                userPrompts.childSupportTable.results.generalInfo.CalculateEachParentsContribution();
                userPrompts.childSupportTable.ReadTableFromFile();
                userPrompts.childSupportTable.results.CalculateEachParentsSupportObligation();
                userPrompts.childSupportTable.results.WorksheetSelector();
                userPrompts.FinalResults();

                //MenuClasses.WorkSheet();

                exit = !Validation.Prompt4YesNo("Would you like to run another child support calculation, enter 'Y' for yes OR 'N' for no?\n");
            }
            while (exit == false);

            Console.WriteLine("Good Bye!");
        }
    }
}
