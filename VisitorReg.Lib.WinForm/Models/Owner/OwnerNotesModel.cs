using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorReg.Lib.WinForm.Models.Owner
{
    public class OwnerNotesModel
    {
        public int id { get; set; }
        public string OwnerHouseNo { get; set; }
        public string OwnerNotes { get; set; }
        public string OwnerNotesDesc { get; set; }
        public DateTime? NotesExpiryDate { get; set; }
    }
}
