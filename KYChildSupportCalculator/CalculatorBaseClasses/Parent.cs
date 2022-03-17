using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYChildSupportCalculator
{
    public class Parent
    {
        public string FirstName { get; set; } = "DefaultFirstName";
        public string LastName { get; set; } = "DefaultLastName";
        public string FullName { get { return FirstName + " " + LastName; } }
        public decimal MonthlyIncome { get; set; }
        public decimal MaintPaid { get; set; }
        public decimal OtherParentMaintPaid { get; set; }
        public decimal CSPaid { get; set; }
        public decimal ChildCarePaid { get; set; }
        public decimal HealthInsPaid { get; set; }
        public bool IsPrimaryResidence { get; set; }
        public decimal AdjustedMonthlyGross
        {
            get
            {
                decimal adjustedMonthlyGross = MonthlyIncome - MaintPaid - CSPaid + OtherParentMaintPaid;
                if (adjustedMonthlyGross <= 0)
                { adjustedMonthlyGross = 0; }

                return adjustedMonthlyGross;
            }
        }
        public decimal Contribution { get; set; }
        public decimal IndividualSupportObligation { get; set; }
    }
}
