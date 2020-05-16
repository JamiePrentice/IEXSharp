using System.Collections.Generic;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class FinancialResponse
	{
		public string symbol { get; set; }
		public List<Financial> financials { get; set; }
	}
}