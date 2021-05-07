using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorReg.Lib.WinForm.Models.Visitor
{
    public class VisitorModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ICNo { get; set; }
        public string ContactNo { get; set; }
        public string OldICNo { get; set; }
        public string NoPlate { get; set; }
        public string PassNo { get; set; }
        public string HouseNo { get; set; }
        public string PurposeVisit { get; set; }
        public DateTime DateTimeIn { get; set; }
        public DateTime? DateTimeOut { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
