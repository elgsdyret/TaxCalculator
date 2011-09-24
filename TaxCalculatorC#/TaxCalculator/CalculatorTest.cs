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
			//						Tax Rate
			//Up to 5,070			10%
			//5,071 up to 8,660		14%
			//8,661 up to 14,070	23%
			//14,071 up to 21,240	30%
			//21,241 up to 40,230	33%
			//Higher than 40,230	45%
			calculator = new TaxCalculator(new List<TaxInterval>
			                               	{
			                               		new TaxInterval(0, 5070, 10),
			                               		new TaxInterval(5070, 8660, 14),									
			                               		new TaxInterval(8660, 14070, 23),
			                               		new TaxInterval(14070, 21240, 30),
			                               		new TaxInterval(21240, 40230, 33),
			                               		new TaxInterval(40230, double.PositiveInfinity, 45)
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
	}
}