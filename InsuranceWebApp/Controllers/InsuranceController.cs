using InsuranceWebApp.DAL;
using InsuranceWebApp.Filter;
using InsuranceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceWebApp.Controllers
{
    [UnAuthorizedFilter]
    public class InsuranceController : Controller
    {
        // GET: Insurance
        [HttpGet]
        public ActionResult NewPolicy()
        { 
            var viewModel = new PolicyViewModel();
            ViewBag.Operation = "Submit";
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult NewPolicy(Policy policy)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (PolicyRepository pr = new PolicyRepository())
                    {
                        pr.AddPolicy(policy);
                    }
                }
                catch (Exception)
                {

                    return View("Error");
                }
                return RedirectToAction("Policies");
            }
            var viewModel = new PolicyViewModel();
            return View("NewPolicy", viewModel);
        }
        public ActionResult Policies()
        {
            List<Policy> policies;
            using (PolicyRepository pr = new PolicyRepository())
            {
                policies = pr.GetAllPolicies();
            }
            return View(policies);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new PolicyViewModel();
            using (PolicyRepository pr = new PolicyRepository())
            {
                viewModel.Policy = pr.SearchPolicy(id);
            }
            ViewBag.Operation = "Save";
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Policy policy, int id)
        {
            policy.PolicyNumber = id;
            using (PolicyRepository pr = new PolicyRepository())
            {
                try
                {
                    pr.EditPolicy(policy);
                }
                catch (Exception)
                {

                    return View("Error");
                }
            }
            return RedirectToAction("Policies");
        }

        public ActionResult Details(Policy policy,int id = 1)
        {
            return View(policy);
        }
        public ActionResult Delete(int id)
        {
            using (PolicyRepository pr = new PolicyRepository())
            {
                try
                {
                    pr.DeletePolicy(id);
                }
                catch (Exception)
                {

                    return View("Error");
                }
            }
            return RedirectToAction("Policies");
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Logout", "User");
        }
    }
}