using NUnit.Framework;

namespace TDDProblems.IntegerRange
{
    [TestFixture]
    public class IntegerRangeTest
    {
        [Test]
        public void Should_return_maximum_and_minimum_value()
        {
            var range = new IntegerRange(1, 2);

            Assert.That(range.Min, Is.EqualTo(1));
            Assert.That(range.Max, Is.EqualTo(2));
        }

        [Test]
        public void Should_check_if_supplied_value_is_in_range()
        {
            var range = new IntegerRange(1, 5);

            Assert.That(range.IsInRange(1));
            Assert.That(range.IsInRange(3));
            Assert.That(range.IsInRange(5));
            Assert.That(!range.IsInRange(0));
            Assert.That(!range.IsInRange(6));
        }

        [Test]
        public void Should_intersect_subset_ranges()
        {
            var range1 = new IntegerRange(1, 5);
            var range2 = new IntegerRange(2, 4);
            var intersection = range1.Intersect(range2);

            Assert.That(intersection.Min, Is.EqualTo(2));
            Assert.That(intersection.Max, Is.EqualTo(4));
        }

        [Test]
        public void Should_intersect_partially_overlapping_ranges()
        {
            var range1 = new IntegerRange(1, 4);
            var range2 = new IntegerRange(2, 5);
            var intersection = range1.Intersect(range2);

            Assert.That(intersection.Min, Is.EqualTo(2));
            Assert.That(intersection.Max, Is.EqualTo(4));
        }

        [Test, ExpectedException]
        public void Should_not_intersect_non_overlapping_ranges()
        {
            var range1 = new IntegerRange(1, 4);
            var range2 = new IntegerRange(5, 8);
            range1.Intersect(range2);
        }

        [Test]
        public void Intersect_should_be_idempotent()
        {
            var range1 = new IntegerRange(1, 4);
            var range2 = new IntegerRange(2, 5);

            Assert.That(range1.Intersect(range2), Is.EqualTo(range2.Intersect(range1)));
        }
    }
}