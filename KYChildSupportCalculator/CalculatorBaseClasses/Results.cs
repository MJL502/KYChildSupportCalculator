using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYChildSupportCalculator
{
    public class Results
    {
        public GeneralInfo generalInfo = new GeneralInfo();
        public int IncomeForTable { get; set; }
        public int MaxIncomeForTable { get; set; }
        public int BaseSupport { get; set; }
        public decimal TotalChildCare
        {
            get { return generalInfo.parentOne.ChildCarePaid + generalInfo.parentTwo.ChildCarePaid; }
        }
        public decimal TotalHealthInsurance
        {
            get { return generalInfo.parentOne.HealthInsPaid + generalInfo.parentTwo.HealthInsPaid; }
        }
        public decimal TotalSupport
        {
            get { return BaseSupport + TotalChildCare + TotalHealthInsurance; }
        }
        public decimal FinalChildSupport { get; set; }

        public void CalculateEachParentsSupportObligation()
        {
            if (generalInfo.EqualSchedule == true)
            {
                generalInfo.parentOne.IndividualSupportObligation =
                Math.Round(
                ((TotalSupport - generalInfo.parentTwo.HealthInsPaid - generalInfo.parentTwo.ChildCarePaid) *
                generalInfo.parentOne.Contribution) -
                generalInfo.parentOne.HealthInsPaid -
                generalInfo.parentOne.ChildCarePaid
               , 2);

                generalInfo.parentTwo.IndividualSupportObligation =
                Math.Round(
                ((TotalSupport - generalInfo.parentOne.HealthInsPaid - generalInfo.parentOne.ChildCarePaid) *
                generalInfo.parentTwo.Contribution) -
                generalInfo.parentTwo.HealthInsPaid -
                generalInfo.parentTwo.ChildCarePaid
               , 2);
            }
            else
            {
                generalInfo.parentOne.IndividualSupportObligation =
                Math.Round(
                (TotalSupport * generalInfo.parentOne.Contribution) -
                generalInfo.parentOne.HealthInsPaid -
                generalInfo.parentOne.ChildCarePaid
                , 2);

                generalInfo.parentTwo.IndividualSupportObligation =
                Math.Round(
                (TotalSupport * generalInfo.parentTwo.Contribution) -
                generalInfo.parentTwo.HealthInsPaid -
                generalInfo.parentTwo.ChildCarePaid
                , 2);
            }
        }

        public void WorksheetSelector()
        {
            //if statement for switch

            if (generalInfo.EqualSchedule == true)
            {
                generalInfo.PayorSwitch = "both";
            }
            else if (generalInfo.EqualSchedule == false && generalInfo.parentOne.IsPrimaryResidence == true)
            {
                generalInfo.PayorSwitch = "2";
            }
            else if (generalInfo.EqualSchedule == false && generalInfo.parentTwo.IsPrimaryResidence == true)
            {
                generalInfo.PayorSwitch = "1";
            }

            //switch to determine which formula to use and which parent pays

            switch (generalInfo.PayorSwitch)
            {
                case "both":

                    if (generalInfo.parentOne.IndividualSupportObligation == generalInfo.parentTwo.IndividualSupportObligation)
                    {
                        FinalChildSupport = 0;
                        generalInfo.WhoIsPayor = "noPayor";
                    }

                    else if (generalInfo.parentOne.IndividualSupportObligation > generalInfo.parentTwo.IndividualSupportObligation)
                    {
                        FinalChildSupport =
                        generalInfo.parentOne.IndividualSupportObligation - generalInfo.parentTwo.IndividualSupportObligation;
                        generalInfo.WhoIsPayor = "parent1";
                    }
                    else if (generalInfo.parentOne.IndividualSupportObligation < generalInfo.parentTwo.IndividualSupportObligation)
                    {
                        FinalChildSupport =
                        generalInfo.parentTwo.IndividualSupportObligation -
                        generalInfo.parentOne.IndividualSupportObligation;
                        generalInfo.WhoIsPayor = "parent2";
                    }
                    break;

                case "1":
                    FinalChildSupport =
                    generalInfo.parentOne.IndividualSupportObligation;
                    generalInfo.WhoIsPayor = "parent1";
                    break;

                case "2":
                    FinalChildSupport =
                    generalInfo.parentTwo.IndividualSupportObligation;
                    generalInfo.WhoIsPayor = "parent2";
                    break;
            }
        }
    }
}
