namespace TaxCalculator
{
	public class TaxInterval
	{
		private readonly decimal start;
		private readonly decimal end;
		private readonly decimal rate;

		public TaxInterval(decimal start, decimal end, decimal rate)
		{
			this.start = start;
			this.end = end;
			this.rate = rate;
		}

		public decimal Calculate(decimal amount)
		{
			var amountWithinThresHold = decimal.Zero;
			if (amount < start)
				return amountWithinThresHold;
						
			if (amount <= end)			
				amountWithinThresHold = amount - start;
			
			if (amount > end)			
				amountWithinThresHold = end - start;			

			return (amountWithinThresHold * rate) / 100;
		}
	}
}