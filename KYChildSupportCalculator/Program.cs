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
            var userPrompt = new UserPromptsClass(); //creates an instance of a non-static method to be called below

            Console.Clear();

            userPrompt.WelcomeTextToMenu(); //calling the non-static method
            Console.ReadLine();
            Console.Clear();

            UserPromptsClass.Instructions();
            Console.ReadLine();
            Console.Clear();

            bool exit = false;
            do
            {
                //menus
                UserPromptsClass.StepOneQuestions();
                UserPromptsClass.StepTwoQuestions();
                UserPromptsClass.StepThreeQuestions();

                //calculations below must be in this order
                Parent.CalculateEachParentsContribution();
                ChildSupportTable.ReadTableFromFile();
                Parent.CalculateEachParentsSupportObligation();
                Results.WorksheetSelector();
                UserPromptsClass.FinalResults();

                //MenuClasses.WorkSheet();

                exit = !Validation.Prompt4YesNo("Would you like to run another child support calculation, enter 'Y' for yes OR 'N' for no?\n");
            }
            while (exit == false);

            Console.WriteLine("Good Bye!");
        }
    }
}
