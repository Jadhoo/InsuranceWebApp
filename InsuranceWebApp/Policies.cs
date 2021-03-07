//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceWebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Policies
    {
        public int PolicyNumber { get; set; }
        public int PlanNumber { get; set; }
        public double InstallmentPremium { get; set; }
        public int Insured { get; set; }
        public double SumAssured { get; set; }
        public string PolicyStatus { get; set; }
        public string PremiumMode { get; set; }
        public System.DateTime PremiumDueDate { get; set; }
        public int Beneficiary { get; set; }
        public int Owner { get; set; }
        public int PolicyTerm { get; set; }
    
        public virtual PolicyType PolicyType { get; set; }
    }
}
