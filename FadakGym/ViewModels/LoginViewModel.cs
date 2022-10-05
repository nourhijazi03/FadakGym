using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FadakGym.ViewModels
{
    public class LoginViewModel
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        //public Nullable<System.DateTime> Date { get; set; }

        //public virtual Role Role { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TraineeRecord> TraineeRecords { get; set; }
    }
}