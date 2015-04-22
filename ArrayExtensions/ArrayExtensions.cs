using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtensions
{
    static class ArrayExtensions
    {

        //Specific extension Method for String array
        public static string GetRandomForString(this string[] headline)
        {
            string str = "";
            Debug.Assert(headline != null, "array cannot be null");

            if (headline == null)
            {
                str = "";
            }
            else if ((int)headline.Length != 0)
            {
                int i = (new Random()).Next((int)headline.Length);
                str = string.Concat(i, " ", headline[i]);
            }
            else
            {
                str = "";
            }
            return str;
        }
        
        
        /// <summary>
        /// Generic Version can be used for any array type
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="headline"></param>
        /// <returns></returns>
        public static t GetRandom1 <t>( this t[] headline)
        {
            t str = default(t);
            Debug.Assert(headline != null, "array cannot be null");

            if (headline == null)
            {
                str = default(t); ;
            }
            else if ((int)headline.Length != 0)
            {
                int i = (new Random()).Next((int)headline.Length);
                str = headline[i];
            }
            else
            {
                str = default(t); ;
            }
            return str;
        }

    }
}
