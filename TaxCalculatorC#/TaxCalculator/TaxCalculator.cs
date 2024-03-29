﻿using System.Collections.Generic;
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

		public decimal Calculate(decimal amount)
		{
			return taxIntervals.Sum(t => t.Calculate(amount));
		}
	}
}
