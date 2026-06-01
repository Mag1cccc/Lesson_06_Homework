namespace Homework_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ProcessNumbers();

            // Contact();

            // CountElementsAndSum();

            GetTopNResults();
        }

        #region Task 1
        static void ProcessNumbers() {
            Console.WriteLine("Enter array length:");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var arrayLength)) { 
                var mainArray = new int[arrayLength];
                for (int i = 0; i < arrayLength; i++) {
                    Console.Write($"Enter element {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out var number))
                    {
                        mainArray[i] = number;
                    }
                   
                }

                List<int> evenNumbers = new List<int>();
                List<int> oddNumbers= new List<int>();

                foreach (var item in mainArray)
                {
                    if (item % 2 == 0) {
                        evenNumbers.Add(item);
                    } else
                    {
                        oddNumbers.Add(item);
                    }
                }

                Console.WriteLine("Even numbers array: ");
                foreach (var item in evenNumbers)
                {
                    Console.Write($"{item} ");
                }

                Console.WriteLine();

                Console.WriteLine("Odd numbers array: ");
                foreach (var item in oddNumbers) {
                    Console.Write($"{item} ");
                }

            }
           
        }
        #endregion


        #region Task 2
        static void Contact()
        {
            Dictionary<int, string> user = new Dictionary<int, string>();
            while (true) {
                Console.WriteLine("----------------------------");
                Console.WriteLine("1 - Add contact");
                Console.WriteLine("2 - Delete contact");
                Console.WriteLine("3 - Update contact");
                Console.WriteLine("4 - Show all contacts");
                Console.WriteLine("0 - Exit");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Choose option: ");
                Console.ResetColor();

                var input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        Console.Write("Enter contact name: ");
                        var userName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(userName) || userName.Any(char.IsDigit))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid name!");
                            Console.ResetColor();
                            break;
                        }

                        Console.Write("Enter contact number: ");
                        var contactNumber = Console.ReadLine()?.Trim();
                      
                        if (contactNumber?.Length >= 9)
                        {

                            if (int.TryParse(contactNumber, out var number))
                            {
                                if (!user.ContainsKey(number))
                                {
                                    user.Add(number, userName);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Contact added successfully.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("This number already exists.");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Only numbers are allowed.");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Number must be at least 9 digits.");
                            Console.ResetColor();
                        }

                        break;

                    case "2":
                        Console.Write("Enter contact number to delete: ");
                        contactNumber = Console.ReadLine()?.Trim();
                        if (int.TryParse(contactNumber, out var deleteNumber))
                        {
                            if (user.ContainsKey(deleteNumber))
                            {
                                user.Remove(deleteNumber);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Contact deleted successfully.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Contact not found.");
                                Console.ResetColor();
                            }
                        }
                        else 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Only numbers are allowed.");
                            Console.ResetColor();
                        }
                        break;

                    case "3":
                        Console.Write("Enter contact number to update: ");
                        var contactNumberToUpdate = Console.ReadLine()?.Trim();
                        if (int.TryParse(contactNumberToUpdate, out var updateNumber))
                        {
                            if (user.ContainsKey(updateNumber))
                            {
                                Console.Write("Enter new contact name: ");
                                var newUserName = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newUserName) && !newUserName.Any(char.IsDigit))
                                {
                                    if(user.ContainsValue(newUserName))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("This name already exists.");
                                        Console.ResetColor();
                                        break;
                                    }
                                    else
                                    {

                                        user[updateNumber] = newUserName;

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Contact updated successfully.");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid name!");
                                    Console.ResetColor();
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Only numbers are allowed.");
                            Console.ResetColor();
                        }
                        break;

                    case "4":
                        if (user.Count == 0 )
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("No contacts found.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;

                            Console.WriteLine("--- CONTACT LIST ---");

                            foreach (var item in user)
                            {
                                Console.WriteLine($"Number: {item.Key}, Name: {item.Value}");
                            }

                            Console.WriteLine("--------------------");

                            Console.ResetColor();
                        }
                        break;

                    case "0":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Goodbye!");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ResetColor();
                        break;
                }

            }
        }
        #endregion


        #region Task 3

        static void CountElementsAndSum()
        {
            Console.WriteLine("Enter array length:");
            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out var arrayLength)) {
                var mainArray = new int[arrayLength];
                for (int i = 0; i < arrayLength; i++)
                {
                    Console.Write($"Enter element {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out var number))
                    {
                        mainArray[i] = number;
                    }
                }

                var result = mainArray
                            .GroupBy(x => x)
                            .Select(g => new
                            {
                                Number = g.Key,
                                Count = g.Count(),
                                sum = g.Key * g.Count()
                            });
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Number} appears {item.Count} times sum {item.sum}");
                }
                
            }
        }

        #endregion

        #region Task 4

        static void GetTopNResults() {
            Console.WriteLine("Enter top N: ");
            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out var number))
            {
                var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                var topNResults = numbers
                                        .OrderByDescending(x => x)
                                        .Take(number)
                                        .OrderBy(x => x);

                foreach (var item in topNResults)
                {
                    Console.Write(item + " ");
                }
            } 
            else
            {

                Console.WriteLine("Please enter a valid number.");
            }
        }

        #endregion

    }
}
