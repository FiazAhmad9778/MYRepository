//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class LedgerDetailWithName
    {
        public string Name { get; set; }
        public int LedgerId { get; set; }
        public float Debit { get; set; }
        public float Credit { get; set; }
        public int AccountId { get; set; }
        public System.DateTime DateAdded { get; set; }
    }
}
