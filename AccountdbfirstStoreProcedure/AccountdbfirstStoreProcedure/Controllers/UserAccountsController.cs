using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountdbfirstStoreProcedure.Models;
using AccountdbfirstStoreProcedure.View_Model;

namespace Account_Assingment.Controllers
{
    public class UserAccountsController : Controller
    {
        private AccountDbEntities _context;

        // GET: UserAccounts
        public UserAccountsController()
        {
            _context = new AccountDbEntities();
        }
        // GET: UserAccounts/CreateAccount
        public ActionResult CreateAccount()
        {
            var account = new UserAccount();
            return View(account);
        }
        // POST: UserAccounts/CreateAccount
        [HttpPost]
        public ActionResult CreateAccount(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(userAccount);
            }
           
            _context.UserAccounts.Add(userAccount);
            _context.SaveChanges();

            return RedirectToAction("ViewAllAccount", "UserAccounts");
        }

        public ActionResult Edit(int accountId)
        {
            var userAccount = _context.UserAccounts.Find(accountId);
            return View(userAccount);
        }
        [HttpPost]
        public ActionResult Edit(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(userAccount).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("ViewAllAccount");
            }
            else
            {
                return View(userAccount);
            }

        }


      
        
        // GET: UserAccounts/AddLedger
        public ActionResult AddLedger()
        {
            var ledger = new Ledger();
            ViewBag.Accounts = _context.UserAccounts.ToList();
            return View(ledger);
        }

        // POST: UserAccounts/AddLedger

        [HttpPost]
        public ActionResult AddLedger(Ledger ledger)
        {
            if (!ModelState.IsValid)
            {
                return View(ledger);
            }
            var account = _context.UserAccounts.Find(ledger.AccountId);
            if (account == null)
            {
                ViewBag.Error = "There is no account with this code";
                return View(ledger);
            }

            _context.Ledgers.Add(ledger);
            _context.SaveChanges();

            return RedirectToAction("ViewAllAccount", "UserAccounts");
        }
        //GET:UserAccounts/ViewAllAccount
        [AllowAnonymous]
        public ActionResult ViewAllAccount()
        {
            var list = _context.UserAccounts.ToList();
            return View(list);
        }
         
        public ActionResult ViewDetails(int accountId)
        {
            var list = _context.Ledgers.Where(a => a.AccountId == accountId).ToList();
            return View(list);
        }
        //Get:UserAccounts/Get Report(Report of All User)
        public ActionResult GetReport()
        {
            var Report=new ReportViewModel();
            ViewBag.Accounts = _context.UserAccounts.ToList();
            return View(Report);
        }
        //Post:UserAccounts/Get Report(Report of All User)
        [HttpPost]
        public ActionResult GetReportDetails(ReportViewModel reportQuery)
        {

            //DataSet ds = new DataSet();
            var obj = _context.spGetLedgerSummaryOfAlluserInGivenDates(reportQuery.StartDate, reportQuery.EndDate);
               

            return View(obj);
        }

        
        //Get:UserAccounts/Get SummaryorDetail of given user
        public ActionResult Summary()
        {
            var model=new ReportViewModel();
            ViewBag.Accounts = _context.UserAccounts.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult LedgerSummary(ReportViewModel model,string result)
        {
            if (result == "summary")
            {
                DataSet ds = new DataSet();
               

                   

                    SqlDataAdapter adapter = new SqlDataAdapter("spCreateReportSummary", SqlConnection());
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int).Value = model.AccountId;
                    adapter.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = model.StartDate;
                    adapter.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = model.EndDate;

                    adapter.Fill(ds);
                
               
                return View("LedgerSummary", ds);
            }


            else
            {
                var list = _context.Ledgers.Where(r =>
                    r.DateAdded >= model.StartDate && r.DateAdded <= model.EndDate &&
                    r.AccountId == model.AccountId).ToList();

                return View("LedgerDetails", list);
            }
           
        }
        private static SqlConnection SqlConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AccountDbEntities"].ConnectionString;
            System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder =
                new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(connectionString);
            connectionString = efBuilder.ProviderConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }


    }
}