using System.Collections.Generic;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Model.StockFundamentals.Response
{
	public class CashFlowResponse
	{
		public string symbol { get; set; }
		public List<Cashflow> cashflow { get; set; }
	}
}