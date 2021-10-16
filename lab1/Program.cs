using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch
            {
                Console.WriteLine("Something Went Wrong");
            }
            finally
            {
                Console.WriteLine("End Of Program");
            }
        }

        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Welcome to my game of math");
                Console.WriteLine("Enter a number greater than zero");
                int userInput = Convert.ToInt32(Console.ReadLine());
                int[] userArray = new int[userInput];
                userArray = Populate(userArray);
                int arraySum = GetSum(userArray);
                Console.WriteLine($"The sum of the array is {arraySum}");
                int arrayProdunt = GetProduct(userArray, arraySum);
                decimal arrayQuotient = GetQuotient(arrayProdunt);

            }
            catch(FormatException)
            {
                Console.WriteLine("Incorrect Format");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverFlow");
            }
        }

        static int[] Populate(int[] arr)
        {
            for(int i=0; i < arr.Length; i++)
            {
                Console.WriteLine($"Please enter a number {i + 1}/{arr.Length}");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }

        static int GetSum(int[] arr)
        {
            int sum = 0;
            foreach(int i in arr)
            {
                sum += i;
            }
            if(sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }
            return sum;
        }
        static int GetProduct(int[] arr, int arraySum)
        {
            Console.WriteLine($"select a random number between 1 and {arr.Length}");
            int index = Convert.ToInt32(Console.ReadLine());
            if(index > arr.Length)
            {
                throw new IndexOutOfRangeException();
            }
            int product = arraySum * arr[index];
            Console.WriteLine($"{arraySum} * {arr[index]} = {product}");
            return product;
        }
        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine($"enter a number to divide the product {product} by");
                int userInput = Convert.ToInt32(Console.ReadLine());
                decimal quotient = Decimal.Divide(product, userInput);
                Console.WriteLine($"{product} / {userInput} = {quotient}");
                return quotient;
            }
            catch(DivideByZeroException)
            {
                return 0;
            }
        }
    }
}
