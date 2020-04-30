using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.StockFundamentals.Request;
using VSLee.IEXSharpTest.Cloud;

namespace IEXSharpTest.Cloud_V2_
{
	public class StockFundamentalsTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk,  TestGlobal.sk, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase("AAPL", null, Period.Quarter, 1)]
		[TestCase("FB", null, Period.Quarter, 2)]
		public async Task BalanceSheetAsyncTest(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.BalanceSheetAsync(symbol, field, period, last);
			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.balancesheet);
			Assert.GreaterOrEqual(response.Data.balancesheet.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "currentCash", Period.Quarter, 1)]
		[TestCase("FB", "currentCash", Period.Quarter, 2)]
		public async Task BalanceSheetWithFieldAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.BalanceSheetAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", null, Period.Quarter, 1)]
		[TestCase("AAPL", null, Period.Annual, 2)]
		public async Task CashFlowAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.CashFlowAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "reportDate", Period.Annual, 1)]
		[TestCase("AAPL", "reportDate", Period.Quarter, 2)]
		public async Task CashFlowFieldAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.CashFlowAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", DividendRange.OneMonth)]
		[TestCase("AAPL", DividendRange.OneYear)]
		[TestCase("AAPL", DividendRange.TwoYears)]
		[TestCase("AAPL", DividendRange.ThreeMonths)]
		[TestCase("AAPL", DividendRange.FiveYears)]
		[TestCase("AAPL", DividendRange.SixMonths)]
		[TestCase("AAPL", DividendRange.Next)]
		[TestCase("AAPL", DividendRange.Ytd)]
		public async Task DividendAsyncTest(string symbol, DividendRange range)
		{
			var response = await sandBoxClient.StockFundamentals.DividendAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		public async Task EarningTodayAsyncTest()
		{
			var response = await sandBoxClient.StockFundamentals.EarningTodayAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", null, 1)]
		[TestCase("FB", null, 2)]
		public async Task EarningAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.StockFundamentals.EarningAsync(symbol, field, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "consensusEPS", 1)]
		[TestCase("AAPL", "announceTime", 2)]
		public async Task EarningFieldAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.StockFundamentals.EarningAsync(symbol, field, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", null, 1)]
		[TestCase("FB", null, 2)]
		public async Task FinancialAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.StockFundamentals.FinancialAsync(symbol, field, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.financials.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "grossProfit", 1)]
		[TestCase("FB", "grossProfit", 2)]
		public async Task FinancialFieldAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.StockFundamentals.FinancialAsync(symbol, field, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "costOfRevenue", Period.Quarter, 1)]
		[TestCase("AAPL", "costOfRevenue", Period.Annual, 2)]
		public async Task IncomeStatementFieldAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.IncomeStatementAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
		[Test]
		[TestCase("AAPL", null, Period.Annual, 1)]
		[TestCase("FB",  null, Period.Quarter, 2)]
		public async Task IncomeStatementAsyncTest(string symbol, string field, Period period, int last)
		{
			var response = await sandBoxClient.StockFundamentals.IncomeStatementAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.income);
			Assert.AreEqual(last, response.Data.income.Count);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task GivenAnnualPeriod_IncomeStatementAsync_ShouldReturnOneStatementPerYear(string symbol)
		{
			const Period period = Period.Annual;
			const int upToXStatements = 2;

			var response = await sandBoxClient.StockFundamentals.IncomeStatementAsync(symbol, null, period, upToXStatements);

			var firstStatementReportYear = response.Data.income.ElementAt(0).reportDate.Substring(0, 4);
			var secondStatementReportYear = response.Data.income.ElementAt(1).reportDate.Substring(0, 4);

			Assert.That(firstStatementReportYear != secondStatementReportYear);
		}

		[Test]
		[TestCase("AAPL", SplitRange.OneMonth)]
		[TestCase("AAPL", SplitRange.OneYear)]
		[TestCase("AAPL", SplitRange.TwoYears)]
		[TestCase("AAPL", SplitRange.ThreeMonths)]
		[TestCase("AAPL", SplitRange.FiveYears)]
		[TestCase("AAPL", SplitRange.SixMonths)]
		[TestCase("AAPL", SplitRange.Next)]
		[TestCase("AAPL", SplitRange.Ytd)]
		public async Task SplitAsyncTest(string symbol, SplitRange range)
		{
			var response = await sandBoxClient.StockFundamentals.SplitAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}
	}
}
