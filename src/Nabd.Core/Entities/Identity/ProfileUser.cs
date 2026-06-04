using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Enums.Identity;

namespace Nabd.Core.Entities.Identity
{
    public abstract class ProfileUser : User
	{
		public DateTime? BirthDate { get; set; }
		public Gender? Gender { get; set; }
		public string? ProfileImageUrl { get; set; }
	}
}
