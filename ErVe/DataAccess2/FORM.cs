//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess2
{
    using System;
    using System.Collections.Generic;
    
    public partial class FORM
    {
        public int FormID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string FormFiller { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string WorkName { get; set; }
        public Nullable<System.DateTime> ReadyToDate { get; set; }
        public string Instructions { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> PcsAmount { get; set; }
        public Nullable<decimal> ChargeFull { get; set; }
        public Nullable<decimal> ChargeByPcs { get; set; }
        public Nullable<decimal> FreightCost { get; set; }
        public string MaterialName { get; set; }
        public string StatusName { get; set; }
        public Nullable<int> Company { get; set; }
        public Nullable<int> CC { get; set; }
        public Nullable<int> WorkMinsWR { get; set; }
        public Nullable<int> WorkMinsIT { get; set; }
        public Nullable<int> WorkMinsCS { get; set; }
        public string BillReference { get; set; }
        public Nullable<decimal> Compensation { get; set; }
        public Nullable<System.DateTime> SentToBilling { get; set; }
        public Nullable<System.DateTime> ReadyDate { get; set; }
        public Nullable<int> Cprints { get; set; }
        public Nullable<int> BWprints { get; set; }
    }
}
