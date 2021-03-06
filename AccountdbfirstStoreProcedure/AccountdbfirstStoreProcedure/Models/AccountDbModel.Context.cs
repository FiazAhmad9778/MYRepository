﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountdbfirstStoreProcedure.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AccountDbEntities : DbContext
    {
        public AccountDbEntities()
            : base("name=AccountDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Ledger> Ledgers { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<LedgerDetailWithName> LedgerDetailWithNames { get; set; }
    
        public virtual ObjectResult<spCreateReportSummary_Result> spCreateReportSummary(Nullable<System.DateTime> fromdate, Nullable<System.DateTime> todate, Nullable<int> accountid)
        {
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(System.DateTime));
    
            var accountidParameter = accountid.HasValue ?
                new ObjectParameter("Accountid", accountid) :
                new ObjectParameter("Accountid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spCreateReportSummary_Result>("spCreateReportSummary", fromdateParameter, todateParameter, accountidParameter);
        }
    
        public virtual ObjectResult<spGetLedgerSummaryOfAlluserInGivenDates_Result> spGetLedgerSummaryOfAlluserInGivenDates(Nullable<System.DateTime> fromdate, Nullable<System.DateTime> todate)
        {
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetLedgerSummaryOfAlluserInGivenDates_Result>("spGetLedgerSummaryOfAlluserInGivenDates", fromdateParameter, todateParameter);
        }
    
        public virtual ObjectResult<spGETLedgerwithAccountId_Result> spGETLedgerwithAccountId(Nullable<int> accountId)
        {
            var accountIdParameter = accountId.HasValue ?
                new ObjectParameter("AccountId", accountId) :
                new ObjectParameter("AccountId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGETLedgerwithAccountId_Result>("spGETLedgerwithAccountId", accountIdParameter);
        }
    }
}
