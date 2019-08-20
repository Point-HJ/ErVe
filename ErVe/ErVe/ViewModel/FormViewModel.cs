using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ErVe.FormViewModel
{
    public class FormViewModel
    {
        public int FormID { get; set; }
        public DateTime CreateDate { get; set; }
        public string FormFiller { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public int WorkID { get; set; }
        public string WorkName { get; set; }
        public DateTime ReadyToDate { get; set; }
        public string Instructions { get; set; }
        public int Amount { get; set; }
        public int PcsAmount { get; set; }
        public decimal ChargeFull { get; set; }
        public decimal ChargeByPcs { get; set; }
        public decimal FreightCost { get; set; }
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public int WorkHoursWR { get; set; }
        public int WorkHoursIT { get; set; }
        public int WorkHoursCS { get; set; }
        public int StatusID { get; set; }
    }
}