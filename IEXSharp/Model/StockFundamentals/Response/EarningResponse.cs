using System.Collections.Generic;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Model.StockFundamentals.Response
{
	public class EarningResponse
	{
		public string symbol { get; set; }
		public List<Earning> earnings { get; set; }
	}
}