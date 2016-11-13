using DataGen.Extensions.Collection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extentions.UnitTests
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [Test]
        public void IEnumerableEmptyIfNull_Null_ReturnsEmptyIEnumerable()
        {
            IEnumerable<int> collection = null;

            var actual = collection.EmptyIfNull();

            if (actual != null && actual.Count() == 0)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void IEnumerableEmptyIfNull_Collection_ReturnsCollection()
        {
            var collection = this.MakeIntCollection();

            var actual = collection.EmptyIfNull();

            if (actual != null && actual.Count() > 0)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void IEnumerableNext_Element_ReturnsNextElementFromEnumerator()
        {
            var collection = this.MakeIntCollection();

            var actual = collection.Next(x => x == 16);

            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IEnumerableNext_ElementDoesntExists_ThrowsInvalidOperationException()
        {
            var collection = this.MakeStringCollection();

            Assert.Throws<InvalidOperationException>(() => collection.Next(x => x == "twenty"));
        }

        [Test]
        public void IEnumerableNext_LastElement_ThrowsInvalidOperationException()
        {
            var collection = this.MakeStringCollection();

            Assert.Throws<InvalidOperationException>(() => collection.Next(x => x == "ten"));
        }

        [Test]
        public void IEnumerableNext_NullCollection_ThrowsArgumentNullException()
        {
            IEnumerable<string> collection = null;

            Assert.Throws<ArgumentNullException>(() => collection.Next(x => x == "twenty"));
        }

        [Test]
        public void IEnumerableNext_NullPredicate_ThrowsArgumentNullException()
        {
            var collection = this.MakeDateTimeCollection();

            Assert.Throws<ArgumentNullException>(() => collection.Next(null));
        }

        [Test]
        public void IEnumerablePrevious_Element_ReturnsPreviousElementFromEnumerator()
        {
            var collection = this.MakeDateTimeCollection();

            var actual = collection.Previous(x => x == new DateTime(2016, 3, 11));

            var expected = new DateTime(2016, 4, 14);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IEnumerablePrevious_ElementDoesntExists_ThrowsInvalidOperationException()
        {
            var collection = this.MakeIntCollection();

            Assert.Throws<InvalidOperationException>(() => collection.Previous(x => x == 13));
        }

        [Test]
        public void IEnumerablePrevious_FirstElement_ThrowsInvalidOperationException()
        {
            var collection = this.MakeIntCollection();

            Assert.Throws<InvalidOperationException>(() => collection.Previous(x => x == 1));
        }

        [Test]
        public void IEnumerablePrevious_NullCollection_ThrowsArgumentNullException()
        {
            IEnumerable<int> collection = null;

            Assert.Throws<ArgumentNullException>(() => collection.Previous(x => x == 10));
        }

        [Test]
        public void IEnumerablePrevious_NullPredicate_ThrowsArgumentNullException()
        {
            var collection = this.MakeDateTimeCollection();

            Assert.Throws<ArgumentNullException>(() => collection.Previous(null));
        }

        [Test]
        public void IEnumerablePage_PageTwoSizeFive_ReturnsFiveElementsWithOffsetOfFive()
        {
            var collection = this.MakeIntCollection();

            var actual = collection.Page(2, 5);

            var expected = new List<int>() { 19, 10, 11, 2, 15 };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IEnumerablePage_NullCollection_ThrowsArgumentNullException()
        {
            IEnumerable<int> collection = null;

            Assert.Throws<ArgumentNullException>(() => collection.Page(2, 4));
        }

        [Test]
        public void IEnumerablePage_PageZero_ThrowsArgumentOutOfRangeException()
        {
            IEnumerable<int> collection = this.MakeIntCollection();

            Assert.Throws<ArgumentOutOfRangeException>(() => collection.Page(0, 4));
        }

        [Test]
        public void IEnumerablePage_PageOutOfRangeSizeFive_ReturnsEmptyCollection()
        {
            var collection = this.MakeIntCollection();

            var actual = collection.Page(12, 5);

            var expected = new List<int>();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IEnumerableShuffle_ReturnsShuffledCollection()
        {
            var orderedCollection = this.MakeIntCollection().OrderBy(x => x).ToList();

            var shuffledCollection = orderedCollection.Shuffle().ToList();

            Assert.AreEqual(orderedCollection.Count, shuffledCollection.Count);

            var sameOrder = true;
            for (int i = 0; i < orderedCollection.Count; i++)
            {
               
                sameOrder = sameOrder && orderedCollection[i] == shuffledCollection[i];
            }
            Assert.IsFalse(sameOrder);
        }


        private IEnumerable<int> MakeIntCollection()
        {
            return new List<int>() { 1, 3, 4, 16, 8, 19, 10, 11, 2, 15, 9, 20, 23, 25, 5, 6, 7, 17 };
        }

        private IEnumerable<string> MakeStringCollection()
        {
            return new List<string>() { "one", "three", "four", "six", "eight", "nine", "ten" };
        }

        private IEnumerable<DateTime> MakeDateTimeCollection()
        {
            yield return new DateTime(2016, 1, 1);
            yield return new DateTime(2016, 4, 14);
            yield return new DateTime(2016, 3, 11);
            yield return new DateTime(2016, 5, 19);
            yield return new DateTime(2016, 6, 23);
        }
    }
}