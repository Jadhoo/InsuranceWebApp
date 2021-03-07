using InsuranceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceWebApp.DAL
{
    interface IRepository
    {
        List<PolicyType> GetPolicyTypes();
        List<Participant> GetParticipantsByType(string participantType);
        void AddPolicy(Policy policy);
        List<Policy> GetAllPolicies();
        void EditPolicy(Policy policy);
        Policy SearchPolicy(int policyNumber);
        void DeletePolicy(int policyNumber);
    }
    public class PolicyRepository : IRepository, IDisposable
    {
        enum PremiumModes
        {
            Annual = 12,
            Semiannual = 6,
            Quarterly = 3,
            Monthly = 1
        }

        double CalculatePremium(int planNumber, double sumInsured, int term, string premiumMode)
        {
            int months = (int)((PremiumModes)Enum.Parse(typeof(PremiumModes), premiumMode, true));
            double premium = (sumInsured / (term * 12)) * months;
            if (planNumber == 101)
                premium += 0.03 * premium;
            return premium;
        }
        public void AddPolicy(Policy policy)
        {
            policy.InstallmentPremium = CalculatePremium(policy.PlanNumber, policy.SumAssured, policy.PolicyTerm, policy.PremiumMode);
            using (InsuranceDBEntities db = new InsuranceDBEntities())
            {
                db.usp_InsertPolicy(policy.PlanNumber, policy.InstallmentPremium, policy.InsuredId, policy.SumAssured, policy.PolicyStatus, policy.PremiumMode, policy.PremiumDueDate, policy.BeneficiaryId, policy.OwnerId, policy.PolicyTerm);
            }
        }

        public void Dispose()
        {
            GC.Collect();
        }

        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies;
            using (InsuranceDBEntities db = new InsuranceDBEntities())
            {
                policies = db.vw_Policies.Select(policy => new Policy
                {
                    PolicyNumber = policy.PolicyNumber,
                    PolicyName = policy.PolicyName,
                    InstallmentPremium = policy.InstallmentPremium,
                    InsuredName = policy.Insured,
                    SumAssured = policy.SumAssured,
                    PolicyStatus = policy.PolicyStatus,
                    PremiumMode = policy.PremiumMode,
                    PremiumDueDate = policy.PremiumDueDate,
                    BeneficiaryName = policy.Beneficiary,
                    OwnerName = policy.Owner,
                    PolicyTerm = policy.PolicyTerm
                }).ToList();
            }
            return policies;
        }

        public List<Participant> GetParticipantsByType(string participantType)
        {
            List<Participant> participants;
            using (InsuranceDBEntities db = new InsuranceDBEntities())
            {
                participants = db.usp_GetParticipantsByType(participantType).Select
                (
                    participant => new Participant
                    {
                        ParticipantNo = participant.ParticipantNo,
                        FullName = participant.FullName
                    }
                ).ToList();
            }
            return participants;
        }

        public List<PolicyType> GetPolicyTypes()
        {
            List<PolicyType> policyTypes;
            using (InsuranceDBEntities db = new InsuranceDBEntities())
            {
                policyTypes = db.usp_GetPolicyTypes().ToList();
                return policyTypes;
            }
        }

        public void EditPolicy(Policy policy)
        {
            policy.InstallmentPremium = CalculatePremium(policy.PlanNumber, policy.SumAssured, policy.PolicyTerm, policy.PremiumMode);
            using (InsuranceDBEntities db = new InsuranceDBEntities())
            {
                db.usp_EditPolicy(policy.PolicyNumber, policy.PlanNumber, policy.InstallmentPremium, policy.InsuredId, policy.SumAssured, policy.PolicyStatus, policy.PremiumMode, policy.PremiumDueDate, policy.BeneficiaryId, policy.OwnerId, policy.PolicyTerm);
                db.SaveChanges();
            }
        }

        public Policy SearchPolicy(int policyNumber)
        {
            Policy searchedPolicy;
            using (InsuranceDBEntities db = new InsuranceDBEntities())
            {
                searchedPolicy = db.usp_SearchPolicy(policyNumber).Select(policy => new Policy
                {
                    PlanNumber = policy.PlanNumber,
                    InstallmentPremium = policy.InstallmentPremium,
                    InsuredId = policy.Insured,
                    SumAssured = policy.SumAssured,
                    PolicyStatus = policy.PolicyStatus,
                    PremiumMode = policy.PremiumMode,
                    PremiumDueDate = policy.PremiumDueDate,
                    BeneficiaryId = policy.Beneficiary,
                    OwnerId = policy.Owner,
                    PolicyTerm = policy.PolicyTerm
                }).FirstOrDefault();
                return searchedPolicy;
            }
        }

        public void DeletePolicy(int policyNumber)
        {
            using (InsuranceDBEntities db = new InsuranceDBEntities())
            {
                db.usp_DeletePolicy(policyNumber);
            }
        }
    }
}