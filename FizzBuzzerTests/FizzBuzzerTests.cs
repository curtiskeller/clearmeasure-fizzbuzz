using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FizzBuzzUnitTests
{
    public class FizzBuzzerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DoFizzBuzz()
        {
            var constraintList = new List<(int divisor, string output)>()
                {(divisor: 3, output: "fizz"), (divisor: 5, output: "buzz")};
            var result = FizzBuzzer.FizzBuzzerImplementation.DoFizzBuzz(constraintList, 15).ToList();
            Assert.AreEqual(15, result.Count);
            Assert.AreEqual("fizz", result[2]);
            Assert.AreEqual("buzz", result[4]);
            Assert.AreEqual("7", result[6]);
            Assert.AreEqual("fizzbuzz",result[14]);
        }

        [Test]
        public void HandleOneWillPrintFizzBuzzFor15()
        {
            var constraintMap = new Dictionary<int, string> { { 3, "fizz" }, { 5, "buzz" } };
            Assert.IsTrue(FizzBuzzer.FizzBuzzerImplementation.HandleOne(15, constraintMap) == "fizzbuzz");
        }

        [Test]
        public void HandleOneWillPrintBuzzFor3()
        {
            var constraintMap = new Dictionary<int, string> { { 3, "fizz" }, { 5, "buzz" } };
            Assert.IsTrue(FizzBuzzer.FizzBuzzerImplementation.HandleOne(3, constraintMap) == "fizz");
        }
        [Test]
        public void HandleOneWillPrintFizzFor5()
        {
            var constraintMap = new Dictionary<int, string> { { 3, "fizz" }, { 5, "buzz" } };
            Assert.IsTrue(FizzBuzzer.FizzBuzzerImplementation.HandleOne(5, constraintMap) == "buzz");
        }
        [Test]
        public void HandleOneWillPrintNumberForNoConstraints()
        {
            var constraintMap = new Dictionary<int, string> ();
            Assert.IsTrue(FizzBuzzer.FizzBuzzerImplementation.HandleOne(5, constraintMap) == "5");
        }

        [Test]
        public void BuildsConstraintMapWithValidInput()
        {
            var constraintList = new List<(int divisor, string output)>()
                {(divisor: 3, output: "fizz"), (divisor: 5, output: "buzz")};

            var actualMap = FizzBuzzer.FizzBuzzerImplementation.BuildConstraintMap(constraintList);
            var expectedResult = new Dictionary<int, string> {{3, "fizz"}, {5, "buzz"}};            
            
            Assert.AreEqual(expectedResult, actualMap);
        }

        [Test]
        public void BuildsConstraintMapWithDuplicateInput()
        {
            var duplicatedConstraintList = new List<(int divisor, string output)>()
                {(divisor: 3, output: "fizz"), (divisor: 5, output: "buzz"), (divisor:5, output:"bizz")};
            var actualDuplicatedMap = FizzBuzzer.FizzBuzzerImplementation.BuildConstraintMap(duplicatedConstraintList);
            var expectedDuplicatedResult = new Dictionary<int, string> { { 3, "fizz" }, { 5, "buzzbizz" } };

            Assert.AreEqual(expectedDuplicatedResult, actualDuplicatedMap);
        }

        [Test]
        public void BuildsConstraintMapWithNullInput()
        {
            var nullMap = FizzBuzzer.FizzBuzzerImplementation.BuildConstraintMap(null);

            Assert.IsEmpty(nullMap);
        }

        [Test]
        public void BuildsConstraintMapWithNullConstraint()
        {
            var nullItemList = new List<(int divisor, string output)>()
                {(divisor: 3, output: null)};
            var nullItemMap = FizzBuzzer.FizzBuzzerImplementation.BuildConstraintMap(nullItemList);
            var expectedNullItemListResult = new Dictionary<int, string> { { 3, null } };

            Assert.AreEqual(expectedNullItemListResult, nullItemMap);
        }
    }
}