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

        static void Main()
        {
            Console.Clear();

            MenuClasses.WelcomeTextToMenu();
            Console.ReadLine();
            Console.Clear();

            MenuClasses.Instructions();
            Console.ReadLine();
            Console.Clear();

            MenuClasses.StepOneQuestions();

            MenuClasses.StepTwoQuestions();

            MenuClasses.StepThreeQuestions();

            //calculations below must be in this precise order
            Parent.ParentInitialCalculations();
            GeneralInfo.GeneralInfoCalculations();
            Parent.ParentSecondCalculations();
            Results.ResultsInitialCalculations();
            ChildSupportTable.ReadTableFromFile();
            Results.ResultsFinalCalculations();
            Parent.ParentFinalCalculations();
            Results.WorksheetSelector();
            MenuClasses.FinalResults(); 

            //MenuClasses.WorkSheet();

            //MenuClasses.exitSurvey();

            Console.ReadLine();

        }
    }
}
