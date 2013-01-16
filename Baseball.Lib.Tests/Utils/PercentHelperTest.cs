using Baseball.Lib.Utils;
using NUnit.Framework;

namespace Baseball.Lib.Tests.Utils
{
    [TestFixture]
    public class PercentHelperTest
    {
        [Test]
        public void AtBatsIsZeroAverageWillBeZero()
        {
            Assert.AreEqual(0, PercentHelper.CalculateAverage(atBats: 0, hits: 0));
        }
        
        [Test]
        public void CalculatesAverage()
        {
            Assert.AreEqual(.5, PercentHelper.CalculateAverage(atBats: 4, hits: 2));
        }
        
        [Test]
        public void AverageRoundedToThreeDecimalPlaces()
        {
            Assert.AreEqual(.667, PercentHelper.CalculateAverage(atBats: 3, hits: 2));
        }
        
        [Test]
        public void AtBatsAndWalksAreZeroOnBasePercentageWillBeZero()
        {
            Assert.AreEqual(0, PercentHelper.CalculateOnBasePercentage(atBats: 0, hits: 0, walks: 0));
        }
        
        [Test]
        public void CalculatesOnBasePercentage()
        {
            Assert.AreEqual(.5, PercentHelper.CalculateOnBasePercentage(atBats: 3, hits: 1, walks: 1));
        }
        
        [Test]
        public void OnBasePercentageRoundedToThreeDecimalPlaces()
        {
            Assert.AreEqual(.667, PercentHelper.CalculateOnBasePercentage(atBats: 2, hits: 1, walks: 1));
        }
    }
}