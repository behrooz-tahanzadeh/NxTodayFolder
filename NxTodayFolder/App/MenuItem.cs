using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.btapp.NxTodayFolder.App
{
    class MenuItem
    {
        public static string KeyValue()
        {
            string output = AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("\\", "\\\\");

            output = '"' + output + "NxTodayFolder.exe\" \"%V\"";

            return output;
        }
    }//eoc
}//eons
