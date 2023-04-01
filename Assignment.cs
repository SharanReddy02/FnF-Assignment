using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpbasics
{
    internal class Assignment
    {
        static void Main(string[] args)
        {
            //OddEven();
            //Calc();
            DateValidation();
            //dynamicArray();
        }
        
        //Dynamic array creation program
        static void dynamicArray()
        {
            Console.WriteLine("Enter the Size of the Array");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Data type for the Array in CTS");

            Type dataType = Type.GetType(Console.ReadLine());
            Array array = Array.CreateInstance(dataType, size);
            Console.WriteLine("Lets enter the values for the array");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the value for the position {i} of the data type {dataType.Name}");
                var input = Console.ReadLine();
                array.SetValue(Convert.ChangeType(input, dataType), i);
            }
            Console.WriteLine("All the values are set, now lets read them!!");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
        
        //Date validation program

        private static void DateValidation()
        {
            Console.WriteLine("enter the date in mm/dd/yyyy format");
            string date = Console.ReadLine();
            try
            {
                string[] dateparts = date.Split('/');
                DateTime validDate = new DateTime(Convert.ToInt32(dateparts[2]),
                    Convert.ToInt32(dateparts[0]), Convert.ToInt32(dateparts[1]));
                Console.WriteLine("true");
            }
            catch
            {
                Console.WriteLine("false");
            }
        }
        
        //Calculator program
        private static void Calc()
        {
            Console.WriteLine("Enter 2 numbers:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you want to perform an Operation : Yes/No");
            String s = Console.ReadLine();
            while (s != "No") { 
            if(s == "Yes")
            {
                Console.WriteLine("Enter the operator +,-,*,/");
                var op = Console.ReadLine();
                if(op == "+")
                {
                    Console.WriteLine("ur answer is: "+(a+b));
                }else if(op == "-")
                {
                    Console.WriteLine("ur answer is: "+(a-b));
                }else if (op == "*")
                {
                    Console.WriteLine("ur answer is:"+(a*b));
                }else if((op == "/"))
                {
                    Console.WriteLine("ur answer is:" + (a / b));
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
                Console.WriteLine("Do you want to perform an Operation : Yes/No");
                s = Console.ReadLine();
            }
        }
        
        //Program to check Odd/Even
        private static void OddEven()
        {
            int[] arr = { 3, 6, 8, 1, 20 };
            Console.WriteLine("Even numbers:");
            foreach(int i in arr)
            {
                if(i%2 == 0)
                {
                    Console.Write(i+" ");
                }
            }
            Console.WriteLine("Odd numbers:");
            foreach (int i in arr)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i+" ");
                }
            }
        }
    }
}
