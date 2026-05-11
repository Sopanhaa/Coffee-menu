using System;

class Program
{
    static void Main()
    {
        // DRINK MENU 
        // We store drink names and prices separately using arrays
        string[] drinkNames = {
            "Iced Americano",
            "Hot Latte",
            "Iced Latte",
            "Cappuccino",
            "Green Tea",
            "Mocha",
            "Chocolate",
            "Caramel Latte",
            "Matcha Latte",
            "Milk Tea"
        };

        int[] drinkPrices = {
            6000,
            8000,
            8500,
            8000,
            7500,
            9000,
            7000,
            9500,
            9000,
            6500
        };

        // ORDER STORAGE 
        // These arrays store what the customer ordered
        string[] orderNames  = new string[100];
        int[]    orderQtys   = new int[100];
        int[]    orderPrices = new int[100];
        int[]    orderTotals = new int[100];

        // This counts how many items have been ordered so far
        int orderCount = 0;

        // MAIN LOOP
        // The program keeps running until the user chooses to exit
        bool running = true;

        while (running)
        {
            // Clear the screen and show the main menu
            Console.Clear();
            Console.WriteLine("COFFEE SHOP ORDER     ");
            Console.WriteLine("");
            Console.WriteLine("1. Add Drink");
            Console.WriteLine("2. View Order");
            Console.WriteLine("3. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            // OPTION 1: ADD A DRINK 
            if (choice == "1")
            {
                // Keep adding drinks until the user says no
                bool addMore = true;

                while (addMore)
                {
                    Console.Clear();
                    Console.WriteLine("        ADD DRINK         ");

                    // Show all drinks with numbers
                    for (int i = 0; i < drinkNames.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + drinkNames[i] + " - " + drinkPrices[i] + " KHR");
                    }

                    Console.WriteLine("==========================");
                    Console.Write("Enter drink number: ");

                    // Read which drink the user wants
                    int drinkNumber = Convert.ToInt32(Console.ReadLine());

                    // Check if the drink number is valid
                    if (drinkNumber < 1 || drinkNumber > drinkNames.Length)
                    {
                        Console.WriteLine("Invalid! Please pick a number from the menu.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("Enter quantity: ");
                        int qty = Convert.ToInt32(Console.ReadLine());

                        // Quantity must be at least 1
                        if (qty <= 0)
                        {
                            Console.WriteLine("Quantity must be more than 0!");
                            Console.ReadLine();
                        }
                        else
                        {
                            // Arrays start at index 0, so we subtract 1
                            int index = drinkNumber - 1;

                            // Get the selected drink's name and price
                            string name  = drinkNames[index];
                            int    price = drinkPrices[index];
                            int    total = price * qty;

                            // Save this order into our order arrays
                            orderNames[orderCount]  = name;
                            orderPrices[orderCount] = price;
                            orderQtys[orderCount]   = qty;
                            orderTotals[orderCount] = total;

                            // Move to the next slot in the arrays
                            orderCount++;

                            // Show a summary of what was added
                            Console.WriteLine();
                            Console.WriteLine("✓ Drink added!");
                            Console.WriteLine("  Drink : " + name);
                            Console.WriteLine("  Qty   : " + qty);
                            Console.WriteLine("  Total : " + total + " KHR");
                        }
                    }

                    // Ask if the user wants to add another drink
                    Console.WriteLine();
                    Console.Write("Add another drink? (y/n): ");
                    string again = Console.ReadLine();

                    // If the user types "y" or "Y", keep looping
                    if (again == "y" || again == "Y")
                    {
                        addMore = true;
                    }
                    else
                    {
                        addMore = false;
                    }
                }
            }

            // OPTION 2: VIEW ORDER
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("       VIEW ORDER         ");

                // If nothing has been ordered yet
                if (orderCount == 0)
                {
                    Console.WriteLine("No drinks ordered yet.");
                }
                else
                {
                    int grandTotal = 0;

                    // PadRight() forces each column to have a fixed width so they line up
                    Console.WriteLine(
                        "No. | " +
                        "Drink Name".PadRight(15) + " | " +
                        "Qty".PadRight(4) + " | " +
                        "Price".PadRight(10) + " | " +
                        "Total"
                    );
                    Console.WriteLine(new string('-', 51)); // prints 51 dashes

                    // Loop through all orders and print each one
                    for (int i = 0; i < orderCount; i++)
                    {
                        Console.WriteLine(
                            (i + 1) + ".  | " +
                            orderNames[i].PadRight(15) + " | " +
                            orderQtys[i].ToString().PadRight(4) + " | " +
                            (orderPrices[i] + " KHR").PadRight(10) + " | " +
                            orderTotals[i] + " KHR"
                        );

                        // Add this item's total to the grand total
                        grandTotal = grandTotal + orderTotals[i];
                    }

                    Console.WriteLine(new string('-', 51));
                    Console.WriteLine("GRAND TOTAL: " + grandTotal + " KHR");
                }

                Console.WriteLine();
                Console.WriteLine("Press Enter to go back...");
                Console.ReadLine();
            }

            // OPTION 3: EXIT 
            else if (choice == "3")
            {
                running = false; // This stops the while loop
                Console.WriteLine("Thank you!");
            }

            // WRONG INPUT
            else
            {
                Console.WriteLine("Invalid option! Please enter 1, 2, or 3.");
                Console.WriteLine("Press Enter to try again...");
                Console.ReadLine();
            }
        }
    }
}

