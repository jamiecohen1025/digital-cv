using System;

namespace Assignment10
{
    class Restaurants
    {
        static void Main(string[] args)
        {
            Restaurants restaurant1 = new Restaurants();
            Restaurants restaurant2 = new Restaurants(4, true);
            Restaurants restaurant3 = new Restaurants(3, false);
            restaurant1.setMenuEasy();
            restaurant3.setMenuEasy();
            restaurant2.setMenu();
            restaurant1.restaurantDetails();
            restaurant2.restaurantDetails();
            restaurant3.restaurantDetails();
        }

        static int storeCounter = 1;
        string[] Menu;
        int StoreID;
        bool isOpen;

        Restaurants()
        {
            StoreID = storeCounter;
            storeCounter++;
            isOpen = true;
            Menu = new string[3];
        }

        Restaurants(int x, bool y)
        {
            StoreID = storeCounter;
            storeCounter++;
            isOpen = y;
            Menu = new string[x];
        }

        void setMenu()
        {
            Console.WriteLine("Your menu has {0} items.", Menu.Length);
            for (int i = 0; i < Menu.Length; i++)
            {
                Console.WriteLine("What is menu item number {0}", i + 1);
                Menu[i] = Console.ReadLine();
            }
        }

        void setMenuEasy()
        {
            Menu[0] = "Hamburger";
            Menu[1] = "Hot dog";
            Menu[2] = "Pizza";
        }

        void restaurantDetails()
        {
            Console.WriteLine("Your restaurant details include:");
            Console.WriteLine("\t The store ID is {0}.", StoreID);
            Console.WriteLine("\t the menu consists of the following:");
            for(int i =0; i<Menu.Length;i++)
            {
                Console.WriteLine("\t\t {0}",Menu[i]);
            }
            if (isOpen == true)
                Console.WriteLine("\t The restaurant is open.");
            else
            {
                Console.WriteLine("\t The restaurant is closed.");
            }
        }
    }
}
