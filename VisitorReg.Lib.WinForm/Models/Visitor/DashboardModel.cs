using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorReg.Lib.WinForm.Models.Visitor
{
    public class DashboardModel
    {
        public string Month { get; set; }
        public int intMonth { get; set; }
        public int Year { get; set; }
        public int Visitors { get; set; }
        public int Contractors { get; set; }
        public int FoodDeliveries { get; set; }
        public int Couriers { get; set; }
    }
}
