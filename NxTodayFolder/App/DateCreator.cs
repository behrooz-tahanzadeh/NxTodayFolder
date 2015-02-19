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
        public static string jalaliDate()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;

            String output = pc.GetYear(dt) + "" + pc.GetMonth(dt).ToString("00") + "" + pc.GetDayOfMonth(dt).ToString("00");

            return output;
        }//eof

    }//eoc
}//eons