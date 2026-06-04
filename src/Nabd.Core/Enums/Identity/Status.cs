using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Core.Enums.Identity
{
    public enum Status
    {
        [Description("نشط")]
        Active = 1,

        [Description("غير نشط مؤقتاً")]
        Inactive = 2,

        [Description("معلق")]
        Suspended = 3
    }
}
