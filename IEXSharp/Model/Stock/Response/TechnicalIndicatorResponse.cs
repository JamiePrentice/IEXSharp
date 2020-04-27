﻿using System.Collections.Generic;

namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class TechnicalIndicatorsResponse
	{
		public IEnumerable<string> indicator { get; set; }
		public IEnumerable<Dictionary<string, string>> chart { get; set; }
	}
}