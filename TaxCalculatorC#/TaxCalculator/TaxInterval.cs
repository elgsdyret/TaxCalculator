namespace TaxCalculator
{
	public class TaxInterval
	{
		private readonly double start;
		private readonly double end;
		private readonly double rate;

		public TaxInterval(double start, double end, double rate)
		{
			this.start = start;
			this.end = end;
			this.rate = rate;
		}

		public double Calculate(double amount)
		{
			if (amount < start)
				return 0.0;

			var amountWithinThresHold = 0.0;			
			if (amount < end)			
				amountWithinThresHold = amount - start;
			
			if (amount > end)			
				amountWithinThresHold = end - start;			

			return (amountWithinThresHold * rate) / 100;
		}
	}
}