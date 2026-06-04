using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nabd.Core.Enums;

namespace Nabd.Core.Entities.Identity
{
    public class Verifier : User
    {
        // I need to make it required after Admin module is ready
        public Guid? CreatedByAdminId { get; set; }

        // Navigation Properties
        public virtual ICollection<Doctor> VerifiedDoctors { get; set; } = new HashSet<Doctor>();

    }
}
