using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixpanel.Data.Extensions
{
    public static class DateTimeExtension
    {
        public static double ToUnixTimestamp(this DateTime dateTime)
        {
            var unixEpoch = new DateTime(1970, 1, 1);

            if (dateTime < unixEpoch) return 0;

            return Math.Floor(dateTime.Subtract(unixEpoch).TotalSeconds);
        }
    }
}
