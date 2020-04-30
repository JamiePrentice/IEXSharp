using IEXSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VSLee.IEXSharp.Model.StockFundamentals.Request;
using VSLee.IEXSharp.Model.StockFundamentals.Response;

namespace IEXSharp.Service.V2.StockFundamentals
{
	public interface IStockFundamentalsService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
		/// Only included with paid subscription plans.
		/// Financial information is limited for some financial firms.
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<dynamic> BalanceSheetAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
		/// Only included with paid subscription plans.
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		Task<dynamic> CashFlowAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#dividends-basic"/>
		/// Basic dividends (as opposed to the advanced dividends in ICorporateActionsService)
		/// Dividends prior to last reported are only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<DividendResponse>>> DividendAsync(string symbol, DividendRange range);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#earnings"/>
		/// Earnings prior to last quarter are only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<dynamic> EarningAsync(string symbol, string field, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#earnings-today"/>
		/// Earnings prior to last quarter are only included with paid subscription plans
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<EarningTodayResponse>> EarningTodayAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#financials"/>
		/// Financial Firms report financials in a different format than our 3rd party processes therefore our data is limited
		/// Only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<dynamic> FinancialAsync(string symbol, string field, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#income-statement"/>
		/// Only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<dynamic> IncomeStatementAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#splits"/>
		/// Splits prior to last reported are only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SplitResponse>>> SplitAsync(string symbol, SplitRange range = SplitRange.OneMonth);
	}
}
