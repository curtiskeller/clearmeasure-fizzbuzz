using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FizzBuzzer
{
    public static class FizzBuzzerImplementation
    {
        public static IEnumerable<string> DoFizzBuzz(List<(int divisor, string output)> constraints = null, int upperBound = 100)
        {
            if (constraints is null || !constraints.Any() || upperBound <= 0)
                yield return null;

            var constraintMap = BuildConstraintMap(constraints);

            for (var i = 1; i <= upperBound; i++)
            {
                yield return HandleOne(i, constraintMap);
            }
        }

        public static Dictionary<int, string> BuildConstraintMap(IEnumerable<(int divisor, string output)> constraints)
        {
            var map = new Dictionary<int, string>();
            if (constraints is null)
                return map;

            foreach (var (divisor, output) in constraints)
            {
                if (map.ContainsKey(divisor))
                    map[divisor] = map[divisor] + output;
                else
                {
                    map.Add(divisor, output);
                }
            }

            return map;
        }

        public static string HandleOne(int number, Dictionary<int, string> constraintMap)
        {
            var meetsAtLeastOneConstraint = false;
            var output = "";
            foreach (var kvp in constraintMap.Where(kvp => number % kvp.Key == 0))
            {
                meetsAtLeastOneConstraint = true;
                output +=  kvp.Value;
            }

            if (!meetsAtLeastOneConstraint)
                output += number;

            return output;
        }
    }
}
