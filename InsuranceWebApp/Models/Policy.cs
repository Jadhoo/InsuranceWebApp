using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceWebApp.Models
{
    public class Policy
    {
        [Display(Name = "Policy No")]
        public int PolicyNumber { get; set; }
        public int PlanNumber { get; set; }
        [Display(Name = "Plan")]
        public string PolicyName { get; set; }
        [Display(Name = "Premium")]
        public double InstallmentPremium { get; set; }
        public int InsuredId { get; set; }
        [Display(Name = "Insured")]
        public string InsuredName { get; set; }
        [Display(Name = "Sum Assured")]
        public double SumAssured { get; set; }
        [Display(Name = "Policy Status")]
        public string PolicyStatus { get; set; }
        [Display(Name = "Premium Mode")]
        public string PremiumMode { get; set; }
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PremiumDueDate { get; set; }
        public int BeneficiaryId { get; set; }
        [Display(Name = "Beneficiary")]
        public string BeneficiaryName { get; set; }
        public int OwnerId { get; set; }
        [Display(Name = "Owner")]
        public string OwnerName { get; set; }
        [Display(Name = "Policy Term")]
        public int PolicyTerm { get; set; }
    }
}