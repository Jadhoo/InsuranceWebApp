using InsuranceWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceWebApp.Models
{
    public class PolicyViewModel
    {
        public Policy Policy { get; set; }
        public SelectList PolicyTypeList
        {
            get
            {
                using (PolicyRepository pr = new PolicyRepository())
                {
                    return new SelectList(pr.GetPolicyTypes(), "PlanNumber", "PolicyName");
                }
            }
        }
        public SelectList InsuredList
        {
            get
            {
                using (PolicyRepository pr = new PolicyRepository())
                {
                    return new SelectList(pr.GetParticipantsByType("Insured"), "ParticipantNo", "FullName");
                }
            }
        }
        public SelectList OwnerList
        {
            get
            {
                using (PolicyRepository pr = new PolicyRepository())
                {
                    return new SelectList(pr.GetParticipantsByType("Owner"), "ParticipantNo", "FullName");
                }
            }
        }
        public SelectList BeneficiaryList
        {
            get
            {
                using (PolicyRepository pr = new PolicyRepository())
                {
                    return new SelectList(pr.GetParticipantsByType("Beneficiary"), "ParticipantNo", "FullName");
                }
            }
        }

        public enum PremiumModes
        {
            Annual = 12,
            Semiannual = 6,
            Quarterly = 3,
            Monthly = 1
        };
        public List<SelectListItem> PremiumModeList
        {
            get
            {
                return new List<SelectListItem>() {
                    new SelectListItem { Text = "Annual", Value = "Annual"},
                    new SelectListItem { Text = "Semiannual", Value = "Semiannual"},
                    new SelectListItem { Text = "Quarterly", Value = "Quarterly"},
                    new SelectListItem { Text = "Monthly", Value = "Monthly"}
                };
            }
        }
    }
}