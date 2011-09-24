using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
	public class TaxCalculator
	{
		private readonly IList<TaxInterval> taxIntervals;
		public TaxCalculator(IList<TaxInterval> taxIntervals)
		{
			this.taxIntervals = taxIntervals;
		}

		public double Calculate(double amount)
		{
			return Math.Round(taxIntervals.Sum(t => t.Calculate(amount)), 1);
		}
	}
}
