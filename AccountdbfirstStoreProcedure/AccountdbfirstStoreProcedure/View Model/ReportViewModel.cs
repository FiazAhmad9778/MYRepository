using System;
using System.Collections.Generic;
using AccountdbfirstStoreProcedure.Models;

namespace AccountdbfirstStoreProcedure.View_Model
{
    public class ReportViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int AccountId { get; set; }
        public List<UserAccount> users { get; set; }
        
    }
}