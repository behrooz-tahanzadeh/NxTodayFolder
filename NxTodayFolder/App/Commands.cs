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
        CO("\t4: About NxTodayFolder!");
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
        catch(UnauthorizedAccessException)
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
        CO("Today is " + DateCreator.jalaliDate()+"\n");
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
}//eoc
}//eons
