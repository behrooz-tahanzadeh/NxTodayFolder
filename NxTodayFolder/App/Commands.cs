using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ir.btapp.NxTodayFolder.App
{
    class Commands
    {
        private static void CO(string str)
        {
            Console.WriteLine(str);
        }
        public static void Welcome()
        {
            CO("*********************");
            CO("**  NxTodayFolder  **");
            CO("*********************");
            CO("");
            CO("Please choose one of these options:");
            CO("\t1: Add/Update Context Menu Item");
            CO("\t2: Remove Context Menu Item");
            CO("\t3: Get Today's Date");
            CO("\t4: Change Calendar Type...");
            CO("\t5: Change Date Format...");
            CO("\t6: About NxTodayFolder!");
            CO("\t0: Exit Application");
            CO("");
        }//eof




        public static string GetUserChoice()
        {
            Console.Write("Your Choice: ");
            var input = Console.ReadLine();
            return input.Trim();
        }//eof




        public static void AddUpdateCMItem()
        {
            try
            {
                RegistryKey regCmd = Registry.ClassesRoot.CreateSubKey("Directory\\background\\shell\\NxTodayFolder\\command", RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (regCmd != null)
                    regCmd.SetValue("", MenuItem.KeyValue());

                CO("Context Menu Item Has been Added/Updated Successfully\n");
            }
            catch (UnauthorizedAccessException)
            {
                CO("Error: It's failed! It's a good idea to run this application as administrator...\n");
            }
        }//eof




        public static void RemoveCMItem()
        {
            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree("Directory\\background\\shell\\NxTodayFolder", false);
                CO("Context Menu Item Has been Removed Successfully\n");
            }
            catch (UnauthorizedAccessException)
            {
                CO("Error: It's failed! It's a good idea to run this application as administrator...\n");
            }
        }//eof




        public static void GetTodayDate()
        {
            CO("Today is " + DateCreator.getDate() + "\n");
        }//eof




        public static void AboutApp()
        {
            CO("-----------------------------------------------");
            CO("---------------  NxTodayFolder  ---------------");
            CO("-- Developed By Behrooz Tahanzadeh(b-tz.com) --");
            CO("------- At Next Office (nextoffice.ir) --------");
            CO("---------------- February 2015 ----------------");
            CO("-----------------------------------------------");
            CO("");
        }//eof




        public static void ChangeCalendarType()
        {
            CO("Calendar Type Is " + (UserOption.Default.DATE_TYPE == "J" ? "Jalali" : "Gregorian") + '.');
            CO("Choose One Of The Following Calendar Types:");
            CO("\tG: Gregorian");
            CO("\tJ: Jalali");
            CO("\tC: Cancel");

            switch (GetUserChoice())
            {
                case "g":
                case "G":
                    UserOption.Default.DATE_TYPE = "G";
                    UserOption.Default.Save();
                    CO("Calendar type is changed to Gregorian.");
                    break;
                case "j":
                case "J":
                    UserOption.Default.DATE_TYPE = "J";
                    UserOption.Default.Save();
                    CO("Calendar type is changed to Jalali.");
                    break;
                case "c":
                case "C":
                    break;
                default:
                    CO("Error: Invalid input. Please only choose one of the given options!");
                    break;
            }
        }//eof




        public static void ChangeDateFormat()
        {
            CO("Calendar Format Is " + UserOption.Default.DATE_FORMAT + " Which Will Print Date As " + DateCreator.getDate() + ".");
            CO("Please Choose One Of The Following Options Or Enter New Date Format:");
            CO("\tH: Help");
            CO("\tC: Cancel");

            string uc = GetUserChoice();

            switch (uc)
            {
                case "h":
                case "H":
                    break;
                case "c":
                case "C":
                    break;
                default:
                    try
                    {
                        //check format
                        DateCreator.getDate(uc);

                        UserOption.Default.DATE_FORMAT = uc;
                        UserOption.Default.Save();
                        CO("Calendar Format Is Changed To " + UserOption.Default.DATE_FORMAT + " Which Will Print Date As " + DateCreator.getDate() + ".");
                    }
                    catch (Exception)
                    {
                        CO("Error:Invalid format!");
                    }
                    break;
            }
        }//eof
    }//eoc
}//eons
