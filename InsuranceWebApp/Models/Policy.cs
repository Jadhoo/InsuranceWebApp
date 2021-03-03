using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceWebApp.Models
{
    public class Policy
    {
        public int PolicyNumber { get; set; }
        public int PlanNumber { get; set; }
        public string PolicyName { get; set; }
        public double InstallmentPremium { get; set; }
        public int InsuredId { get; set; }
        public string InsuredName { get; set; }
        public double SumAssured { get; set; }
        public string PolicyStatus { get; set; }
        public string PremiumMode { get; set; }
        public DateTime PremiumDueDate { get; set; }
        public int BeneficiaryId { get; set; }
        public string BeneficiaryName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int PolicyTerm { get; set; }
    }
}