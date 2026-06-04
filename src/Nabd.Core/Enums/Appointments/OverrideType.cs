using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Core.Enums.Appointments
{
    public enum OverrideType
    {
        [Description("متاح")]
        Available = 1,

        [Description("غير متاح")]
        Unavailable = 2
    }
}
