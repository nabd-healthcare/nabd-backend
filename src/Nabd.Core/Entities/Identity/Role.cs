using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nabd.Core.Enums.Identity;

namespace Nabd.Core.Entities.Identity
{
    public class Role : IdentityRole<Guid>
	{
		public UserRole UserRole { get; set; }
	}
}
