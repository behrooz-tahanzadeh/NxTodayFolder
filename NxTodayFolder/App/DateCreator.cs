using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ir.btapp.NxTodayFolder.App
{
    class DateCreator
    {
        public static string getDate(string format = null)
        {
            DateTime output;

            if (UserOption.Default.DATE_TYPE == "J")
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = DateTime.Now;
                output = new DateTime(pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            }
            else
            {
                output = DateTime.Now;
            }

            if (format == null)
                return output.ToString(UserOption.Default.DATE_FORMAT);
            else
                return output.ToString(format);
        }//eof

    }//eoc
}//eons