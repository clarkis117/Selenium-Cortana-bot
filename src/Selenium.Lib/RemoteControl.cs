using Newtonsoft.Json;
using Selenium.Lib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Selenium.Lib
{
	public class RemoteControl : IRemoteControl
	{
		private HttpClient _client;

		public RemoteControl(string host)
		{
			_client = new HttpClient();

			_client.BaseAddress = new Uri(host);
		}

		protected async Task<ReqResult> BaseLogic(Task<HttpResponseMessage> request)
		{
			try
			{
				var result = await request;

				if (!result.IsSuccessStatusCode)
					return ReqResult.Failed(await result.Content.ReadAsStringAsync());

				var netres = JsonConvert.DeserializeObject<ReqResult>(await result.Content.ReadAsStringAsync());

				if (netres == null)
					return ReqResult.Failed();
				else
					return netres;
			}
			catch (Exception)
			{
				return ReqResult.Failed();
			}
		}

		public Task<ReqResult> Back()
		{
			return BaseLogic(_client.PostAsync("Back", new StringContent("")));
		}

		public Task<ReqResult> CloseBrowser()
		{
			return BaseLogic(_client.PostAsync("CloseBrowser", new StringContent("")));
		}

		public Task<ReqResult> Forward()
		{
			return BaseLogic(_client.PostAsync("Forward", new StringContent("")));
		}

		public Task<ReqResult> OpenBrowser()
		{
			return _client.PostAsync("OpenBrowser", new StringContent(""));
		}

		public Task<ReqResult> Search(string term)
		{
			return _client.PostAsync("Search", new StringContent(term));
		}

		public Task<ReqResult> SelectResult(uint number)
		{
			return _client.PostAsync("SelectResult", new StringContent(number.ToString()));
		}

		public Task<ReqResult> SelectResult(string title)
		{
			return _client.PostAsync("SelectResult", new StringContent(""));
		}

		public Task<ReqResult> SelectResult(string website, int number)
		{
			return _client.PostAsync("SelectResult", new StringContent(""));
		}
	}
}
