using IEXSharp.Model;
using System.Threading.Tasks;
using IEXSharp.Model.Crypto;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Service.V2.Crypto
{
	public interface ICryptoService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-book"/>
		/// <cost MessageCost="700" />
		/// </summary>
		/// <value>700</value>
		/// <returns></returns>
		Task<IEXResponse<CryptoBookResponse>> BookAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<CryptoPriceResponse>> PriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<CryptoQuote>> QuoteAsync(string symbol);
	}
}