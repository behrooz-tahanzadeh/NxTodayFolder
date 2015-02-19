using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ir.btapp.NxTodayFolder.App;
using Microsoft.Win32;
using System.IO;

namespace ir.btapp.NxTodayFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                while (true)
                {
                    Console.WriteLine("Please enter an option:\n\t1.Add to context menu\t2.Get today date\t3.About\t4.exit!");
                    String input = Console.ReadLine();

                    switch (input.Trim())
                    {
                        case "1":
                            RegistryKey regCmd = Registry.ClassesRoot.CreateSubKey("Directory\\background\\shell\\NxTodayFolder\\command", RegistryKeyPermissionCheck.ReadWriteSubTree);
                            if (regCmd != null)
                                regCmd.SetValue("", MenuItem.KeyValue());
                            break;
                        case "2":
                            Console.WriteLine(DateCreator.jalaliDate());
                            break;
                        case "3":
                            Console.WriteLine("Developed by Behrooz Tahanzadeh (b-tz.com)");
                            break;
                        case "4":
                            Environment.Exit(1);
                            break;
                    }
                }//eo while
            }
            else //if arguments were provided
            {
                //Console.WriteLine(args[0]);
                String path = args[0] + '\\' + DateCreator.jalaliDate();


                if (Directory.Exists(path))
                {
                    System.Diagnostics.Process.Start(@path);
                }
                else
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }//eoc
}//eons