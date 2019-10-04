using System;
using System.Collections.Generic;
using FizzBuzzer;
namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var constraintList = new List<(int divisor, string output)>()
                {(divisor: 3, output: "fizz"), (divisor: 5, output: "buzz")};

            foreach (var s in FizzBuzzerImplementation.DoFizzBuzz(constraintList,int.MaxValue))
            {
                Console.WriteLine(s);
            }
        }
    }
}
