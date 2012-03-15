using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 15), 600);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsIfEndTimeIsLessThanStartTime()
        {
            new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 10), 300);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsIfMilesIsNegative()
        {
            new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 15), -10);
        }

        [Test()]
        public void TestThatCanGetMilesFromFlight()
        {
            var target = new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 15), 333);
            Assert.AreEqual(target.Miles,333);
        }

        [Test()]
        public void TestIfFlightsAreEqual()
        {
            var flight1 = new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 15), 333);
            var flight2 = new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 15), 333);
            Assert.AreEqual(flight1, flight2);
        }

        [Test()]
        public void TestIfFlightsAreNotEqual()
        {
            var flight1 = new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 15), 333);
            var flight2 = new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 15), 323);
            Assert.AreNotEqual(flight1, flight2);
        }

        [Test()]
        public void TestFlightPriceOneDaySpread()
        {
            var flight = new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 15), 333);
            Assert.AreEqual(flight.getBasePrice(), 220);
        }

        [Test()]
        public void TestFlightPriceTenDaySpread()
        {
            var flight = new Flight(new DateTime(2012, 3, 14), new DateTime(2012, 3, 24), 333);
            Assert.AreEqual(flight.getBasePrice(), 400);
        }
	}
}
