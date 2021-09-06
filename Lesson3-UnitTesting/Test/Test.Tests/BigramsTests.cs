using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Tests
{
    [TestFixture]
    class BigramsTests
    {

        [Test]
        public void TestCanCountSingleBigram()
        {
            // arrange
            var bigramCounter = new BigramCounter();

            // act
            var results = bigramCounter.Count("se");


            // assert
            Assert.That(results, Has.Count.EqualTo(1));
        }

        [Test]
        public void WhenMoreThanOneBiagram_AllAreCounted()
        {
            // arrange
            var bigramCounter = new BigramCounter();

            // act
            var results = bigramCounter.Count("see ");


            // assert
            Assert.That(results, Has.Count.EqualTo(3));
        }


        [Test]
        public void CanReturnCountOfABigramInString()
        {
            // arrange
            var bigramCounter = new BigramCounter();

            // act
            var results = bigramCounter.Count("see ");


            // assert
            Assert.That(results["se"], Is.EqualTo(1));
        }


        [Test]
        public void CanReturnCountOfABigramInString2()
        {
            // arrange
            var bigramCounter = new BigramCounter();

            // act
            var results = bigramCounter.Count("see ");


            // assert
            Assert.That(results["ee"], Is.EqualTo(1));
            Assert.That(results.Values, Has.All.EqualTo(1));
        }

        [Test]
        public void SpacesAreTreatedAsUnderscore()
        {
            // arrange
            var bigramCounter = new BigramCounter();

            // act
            var results = bigramCounter.Count("  ");


            // assert
            Assert.That(results, Has.Count.EqualTo(1));
            Assert.That(results["__"], Is.EqualTo(1));
        }

        [Test]
        public void When5Es_TheCountIsEqualTo4()
        {
            // arrange
            var bigramCounter = new BigramCounter();

            // act
            var result = bigramCounter.Count("eeeee");

            // assert
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result["ee"], Is.EqualTo(4));

        }
    }
}
