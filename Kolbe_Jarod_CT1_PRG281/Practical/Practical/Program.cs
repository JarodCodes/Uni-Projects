using System;
using System.Collections.Generic;

namespace Practical
{
    class Program
    {
        enum MyMenu
        {
            ViewAll = 1,
            Senior,
            Unemployed,
            Search,
            Exit
        }
        static void Main(string[] args)
        {
            double total = 0;
            double TotalTracker(double val) 
            {
                return total += val;
            }
            
            bool inProgress = true;
            Citizen cit1 = new Citizen("Jarod", "Kolbe", 21, false);
            cit1.TrackGrant += new Tracker(TotalTracker);
            Citizen cit2 = new Citizen("Sandra", "Alber", 21, true);
            cit2.TrackGrant += new Tracker(TotalTracker);
            Citizen cit3 = new Citizen("Sam", "Wise", 16, false);
            cit3.TrackGrant += new Tracker(TotalTracker);
            Citizen cit4 = new Citizen("Kenny", "Jones", 62, true);
            cit4.TrackGrant += new Tracker(TotalTracker);
            cit1.generateCitizen();
            cit2.generateCitizen();
            cit3.generateCitizen();
            cit4.generateCitizen();
            List<Citizen> citizens = new List<Citizen>() { cit1, cit2, cit3, cit4 };
            citizens.Sort();

            while (inProgress == true)
            {
                Console.WriteLine("1. View all citizen details");
                Console.WriteLine("2. View only senior citizen details");
                Console.WriteLine("3. View only unemployed citizens details");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Exit\n");
                int selected = int.Parse(Console.ReadLine());

                MyMenu option = (MyMenu)selected;
                switch (option)
                {
                    case MyMenu.ViewAll:
                        Console.WriteLine("\nName\tSurname\tAge\tKids\tStatus\t\tAmount");
                        foreach (Citizen curCitizen in citizens)
                        {
                            Console.WriteLine(curCitizen.ToString());
                        }
                        Console.WriteLine("\n");
                        break;
                    case MyMenu.Senior:
                        Console.WriteLine("\nName\tSurname\tAge\tKids\tStatus\t\tAmount");
                        foreach (Citizen curCitizen in citizens)
                        {
                            if (curCitizen.Status == "Senior Citizen")
                            {
                                Console.WriteLine(curCitizen.ToString());
                            }
                        }
                        Console.WriteLine("\n");
                        break;
                    case MyMenu.Unemployed:
                        Console.WriteLine("\nName\tSurname\tAge\tKids\tStatus\t\tAmount");
                        foreach (Citizen curCitizen in citizens)
                        {
                            if (curCitizen.Status == "Unemployed")
                            {
                                Console.WriteLine(curCitizen.ToString());
                            }
                        }
                        Console.WriteLine("\n");
                        break;
                    case MyMenu.Search:
                        bool found = false;
                        Console.WriteLine("Insert Citizen name");
                        string name = Console.ReadLine();
                        try
                        {
                            Console.WriteLine("\nName\tSurname\tAge\tKids\tStatus\t\tAmount");
                            foreach (Citizen curCitizen in citizens)
                            {
                                if (curCitizen.Name == name)
                                {
                                    Console.WriteLine(curCitizen.ToString());
                                    found = true;
                                }
                            }
                            if (found == false)
                            {
                                throw (new NotFound("Citizen was not found"));
                            }
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine("Error: {0}", e.Message);
                        }
                        break;
                    case MyMenu.Exit:
                        inProgress = false;
                        break;
                    default:
                        Console.WriteLine("Please insert valid option");
                        break;
                }
            }
        }
    }
}
