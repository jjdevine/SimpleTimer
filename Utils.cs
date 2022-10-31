using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTimer
{
    class Utils
    {
        public static int[] ParseTime(String text)
        {
            int[] result = new int[2];
            var tokens = text.Split(':');
            int minutes = Int32.Parse(tokens[0]);
            int seconds = Int32.Parse(tokens[1]);

            result[0] = minutes;
            result[1] = seconds;
            return result;
        }
    }
}
