﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InsuranceDBEntities : DbContext
    {
        public InsuranceDBEntities()
            : base("name=InsuranceDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Policies> Policies { get; set; }
        public virtual DbSet<PolicyType> PolicyType { get; set; }
        public virtual DbSet<vw_Policies> vw_Policies { get; set; }
    
        public virtual ObjectResult<usp_GetParticipantsByType_Result> usp_GetParticipantsByType(string participantType)
        {
            var participantTypeParameter = participantType != null ?
                new ObjectParameter("participantType", participantType) :
                new ObjectParameter("participantType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetParticipantsByType_Result>("usp_GetParticipantsByType", participantTypeParameter);
        }
    
        public virtual ObjectResult<PolicyType> usp_GetPolicyTypes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PolicyType>("usp_GetPolicyTypes");
        }
    
        public virtual ObjectResult<PolicyType> usp_GetPolicyTypes(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PolicyType>("usp_GetPolicyTypes", mergeOption);
        }
    
        public virtual int usp_InsertPolicy(Nullable<int> planNo, Nullable<double> installmentPremium, Nullable<int> insured, Nullable<double> sumAssured, string policyStatus, string premiumMode, Nullable<System.DateTime> premiumDueDate, Nullable<int> beneficiary, Nullable<int> owner, Nullable<int> policyTerm)
        {
            var planNoParameter = planNo.HasValue ?
                new ObjectParameter("planNo", planNo) :
                new ObjectParameter("planNo", typeof(int));
    
            var installmentPremiumParameter = installmentPremium.HasValue ?
                new ObjectParameter("installmentPremium", installmentPremium) :
                new ObjectParameter("installmentPremium", typeof(double));
    
            var insuredParameter = insured.HasValue ?
                new ObjectParameter("insured", insured) :
                new ObjectParameter("insured", typeof(int));
    
            var sumAssuredParameter = sumAssured.HasValue ?
                new ObjectParameter("sumAssured", sumAssured) :
                new ObjectParameter("sumAssured", typeof(double));
    
            var policyStatusParameter = policyStatus != null ?
                new ObjectParameter("policyStatus", policyStatus) :
                new ObjectParameter("policyStatus", typeof(string));
    
            var premiumModeParameter = premiumMode != null ?
                new ObjectParameter("premiumMode", premiumMode) :
                new ObjectParameter("premiumMode", typeof(string));
    
            var premiumDueDateParameter = premiumDueDate.HasValue ?
                new ObjectParameter("premiumDueDate", premiumDueDate) :
                new ObjectParameter("premiumDueDate", typeof(System.DateTime));
    
            var beneficiaryParameter = beneficiary.HasValue ?
                new ObjectParameter("beneficiary", beneficiary) :
                new ObjectParameter("beneficiary", typeof(int));
    
            var ownerParameter = owner.HasValue ?
                new ObjectParameter("owner", owner) :
                new ObjectParameter("owner", typeof(int));
    
            var policyTermParameter = policyTerm.HasValue ?
                new ObjectParameter("policyTerm", policyTerm) :
                new ObjectParameter("policyTerm", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_InsertPolicy", planNoParameter, installmentPremiumParameter, insuredParameter, sumAssuredParameter, policyStatusParameter, premiumModeParameter, premiumDueDateParameter, beneficiaryParameter, ownerParameter, policyTermParameter);
        }
    
        public virtual int usp_DeletePolicy(Nullable<int> policyNumber)
        {
            var policyNumberParameter = policyNumber.HasValue ?
                new ObjectParameter("policyNumber", policyNumber) :
                new ObjectParameter("policyNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_DeletePolicy", policyNumberParameter);
        }
    
        public virtual int usp_EditPolicy(Nullable<int> policyNumber, Nullable<int> planNo, Nullable<double> installmentPremium, Nullable<int> insured, Nullable<double> sumAssured, string policyStatus, string premiumMode, Nullable<System.DateTime> premiumDueDate, Nullable<int> beneficiary, Nullable<int> owner, Nullable<int> policyTerm)
        {
            var policyNumberParameter = policyNumber.HasValue ?
                new ObjectParameter("policyNumber", policyNumber) :
                new ObjectParameter("policyNumber", typeof(int));
    
            var planNoParameter = planNo.HasValue ?
                new ObjectParameter("planNo", planNo) :
                new ObjectParameter("planNo", typeof(int));
    
            var installmentPremiumParameter = installmentPremium.HasValue ?
                new ObjectParameter("installmentPremium", installmentPremium) :
                new ObjectParameter("installmentPremium", typeof(double));
    
            var insuredParameter = insured.HasValue ?
                new ObjectParameter("insured", insured) :
                new ObjectParameter("insured", typeof(int));
    
            var sumAssuredParameter = sumAssured.HasValue ?
                new ObjectParameter("sumAssured", sumAssured) :
                new ObjectParameter("sumAssured", typeof(double));
    
            var policyStatusParameter = policyStatus != null ?
                new ObjectParameter("policyStatus", policyStatus) :
                new ObjectParameter("policyStatus", typeof(string));
    
            var premiumModeParameter = premiumMode != null ?
                new ObjectParameter("premiumMode", premiumMode) :
                new ObjectParameter("premiumMode", typeof(string));
    
            var premiumDueDateParameter = premiumDueDate.HasValue ?
                new ObjectParameter("premiumDueDate", premiumDueDate) :
                new ObjectParameter("premiumDueDate", typeof(System.DateTime));
    
            var beneficiaryParameter = beneficiary.HasValue ?
                new ObjectParameter("beneficiary", beneficiary) :
                new ObjectParameter("beneficiary", typeof(int));
    
            var ownerParameter = owner.HasValue ?
                new ObjectParameter("owner", owner) :
                new ObjectParameter("owner", typeof(int));
    
            var policyTermParameter = policyTerm.HasValue ?
                new ObjectParameter("policyTerm", policyTerm) :
                new ObjectParameter("policyTerm", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_EditPolicy", policyNumberParameter, planNoParameter, installmentPremiumParameter, insuredParameter, sumAssuredParameter, policyStatusParameter, premiumModeParameter, premiumDueDateParameter, beneficiaryParameter, ownerParameter, policyTermParameter);
        }
    
        public virtual ObjectResult<usp_SearchPolicy_Result> usp_SearchPolicy(Nullable<int> policyNumber)
        {
            var policyNumberParameter = policyNumber.HasValue ?
                new ObjectParameter("policyNumber", policyNumber) :
                new ObjectParameter("policyNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_SearchPolicy_Result>("usp_SearchPolicy", policyNumberParameter);
        }
    }
}
