using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixpanel.Data
{
    public enum MethodEnum
    {
        [Description("engage")]
        Engage,

        [Description("track")]
        Track
    }
}
