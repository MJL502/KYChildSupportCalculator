using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYChildSupportCalculator
{
    public class GeneralInfo
    {
        public Parent parentOne = new Parent();
        public Parent parentTwo = new Parent();
        public int NumberOfChildren { get; set; }
        public int ChildrenForTable
        {
            get
            {
                int numberForTable = NumberOfChildren;
                if (numberForTable > 6)
                { numberForTable = 6; }

                return numberForTable;
            }
        }
        public bool EqualSchedule { get; set; }
        public int PrimaryResidence { get; set; }
        public decimal CombinedIncome
        {
            get
            {
                return parentOne.AdjustedMonthlyGross + parentTwo.AdjustedMonthlyGross;
            }
        }
        public string PayorSwitch { get; set; }
        public string WhoIsPayor { get; set; }

        public void CalculateEachParentsContribution()
        {
            if (parentOne.AdjustedMonthlyGross <= 0 && parentTwo.AdjustedMonthlyGross > 0)
            {
                parentOne.Contribution = 0;
                parentTwo.Contribution = 1;
            }
            else if (parentTwo.AdjustedMonthlyGross <= 0 && parentOne.AdjustedMonthlyGross > 0)
            {
                parentTwo.Contribution = 0;
                parentOne.Contribution = 1;
            }
            else if (parentTwo.AdjustedMonthlyGross <= 0 && parentOne.AdjustedMonthlyGross <= 0)
            {
                parentOne.Contribution = 0;
                parentOne.Contribution = .5m;
                parentTwo.Contribution = .5m;
            }
            else
            {
                parentOne.Contribution = Math.Round(parentOne.AdjustedMonthlyGross / CombinedIncome, 4);

                parentTwo.Contribution = Math.Round(parentTwo.AdjustedMonthlyGross / CombinedIncome, 4);
            }
        }
    }
}
