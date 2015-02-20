using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ir.btapp.NxTodayFolder.App;
using System.IO;

namespace ir.btapp.NxTodayFolder
{
class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Commands.Welcome();

            while (true) switch (Commands.GetUserChoice())
            {
                case "1":
                    Commands.AddUpdateCMItem();
                    break;
                case "2":
                    Commands.RemoveCMItem();
                    break;
                case "3":
                    Commands.GetTodayDate();
                    break;
                case "4":
                    Commands.AboutApp();
                    break;

                case "0":
                    Environment.Exit(1);
                    break;
            }
        }
        else //if arguments were provided
        {
            String path = args[0] + '\\' + DateCreator.jalaliDate();


            if (Directory.Exists(path))
                System.Diagnostics.Process.Start(@path);
            else
                Directory.CreateDirectory(path);
        }
    }//eof
}//eoc
}//eons