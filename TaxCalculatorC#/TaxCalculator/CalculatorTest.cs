using System.Collections.Generic;
using NUnit.Framework;

namespace TaxCalculator
{
	[TestFixture]
	public class CalculatorTest
	{
		private TaxCalculator calculator;

		[SetUp]
		public void LoadCalculator()
		{
			calculator = new TaxCalculator(new List<TaxInterval>
			                               	{
			                               		new TaxInterval(0, 5070, 10),
			                               		new TaxInterval(5070, 8660, 14),									
			                               		new TaxInterval(8660, 14070, 23),
			                               		new TaxInterval(14070, 21240, 30),
			                               		new TaxInterval(21240, 40230, 33),
			                               		new TaxInterval(40230, decimal.MaxValue, 45)
			                               	});
		}

		[Test]
		public void BetweenZeroAndFirstThresHold()
		{
			var amount = calculator.Calculate(5000);
			Assert.That(amount, Is.EqualTo(500));
		}

		[Test]
		public void BetweenFirstAndSecondThresHold()
		{
			var amount = calculator.Calculate(5800);
			Assert.That(amount, Is.EqualTo(609.2));
		}

		[Test]
		public void BetweenSecondAndThirdThresHold()
		{
			var amount = calculator.Calculate(9000);
			Assert.That(amount, Is.EqualTo(1087.8));
		}

		[Test]
		public void BetweenThirdAndFinalThresHold()
		{
			var amount = calculator.Calculate(15000);
			Assert.That(amount, Is.EqualTo(2532.9));
		}

		[Test]
		public void OverFinalThresHold()
		{
			var amount = calculator.Calculate(50000);
			Assert.That(amount, Is.EqualTo(15068.1));
		}

		[Test]
		public void ExactlyOnThresHold()
		{
			var amount = calculator.Calculate(5070);
			Assert.That(amount, Is.EqualTo(507));
		}

		[Test]
		public void ExactlyOnThresHoldPlus1()
		{
			var amount = calculator.Calculate(5071);
			Assert.That(amount, Is.EqualTo(507.14));
		}

		[Test]
		public void ExactlyOnThresHoldMinus1()
		{
			var amount = calculator.Calculate(5069);
			Assert.That(amount, Is.EqualTo(506.9));
		}
	}
}