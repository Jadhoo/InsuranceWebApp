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
        [Required(ErrorMessage = "This is a mandatory field")]
        public int PlanNumber { get; set; }
        [Display(Name = "Plan")]
        public string PolicyName { get; set; }
        [Required(ErrorMessage = "This is a mandatory field")]
        [Display(Name = "Premium")]
        public double InstallmentPremium { get; set; }
        [Required(ErrorMessage = "This is a mandatory field")]
        public int InsuredId { get; set; }
        [Display(Name = "Insured")]
        public string InsuredName { get; set; }
        [Required(ErrorMessage = "This is a mandatory field")]
        [Display(Name = "Sum Assured")]
        public double SumAssured { get; set; }
        [Required(ErrorMessage = "This is a mandatory field")]
        [Display(Name = "Policy Status")]
        public string PolicyStatus { get; set; }
        [Required(ErrorMessage = "This is a mandatory field")]
        [Display(Name = "Premium Mode")]
        public string PremiumMode { get; set; }
        [Required(ErrorMessage = "This is a mandatory field")]
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PremiumDueDate { get; set; }
        [Required(ErrorMessage = "This is a mandatory field")]
        public int BeneficiaryId { get; set; }
        [Display(Name = "Beneficiary")]
        public string BeneficiaryName { get; set; }
        [Required(ErrorMessage = "This is a mandatory field")]
        public int OwnerId { get; set; }
        [Display(Name = "Owner")]
        public string OwnerName { get; set; }
        [Display(Name = "Policy Term")]
        [Required(ErrorMessage = "This is a mandatory field")]
        public int PolicyTerm { get; set; }
    }
}