namespace Homework_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessNumbers();

        }

        static void ProcessNumbers() {
            Console.WriteLine("Enter array length:");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var arrayLength)) { 
                int[] mainArray = new int[arrayLength];
                for (int i = 0; i < arrayLength; i++) {
                    Console.Write($"Enter element {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int number))
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
       
    }
}
