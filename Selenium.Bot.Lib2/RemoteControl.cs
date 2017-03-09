using Newtonsoft.Json;
using Selenium.Bot.Lib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Selenium.Bot.Lib
{
	public class RemoteControl : IRemoteControl
	{
		private HttpClient _client;

		public RemoteControl(string host)
		{
			_client = new HttpClient();

			_client.BaseAddress = new Uri(host);

			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
			return BaseLogic(_client.PostAsync("OpenBrowser", new StringContent("")));
		}

		public Task<ReqResult> Search(Search term)
		{
			return BaseLogic(_client.PostAsync("Search", new JsonContent(term)));
		}

		public Task<ReqResult> SelectResult(Select result)
		{
			return BaseLogic(_client.PostAsync("SelectResult", new JsonContent(result)));
		}

		public async Task<ServiceState> ServiceState()
		{
			var result = await _client.GetAsync("ServiceState");

			if (!result.IsSuccessStatusCode)
				throw new Exception("Error Retrieving Service State");

			var state = JsonConvert.DeserializeObject<ServiceState>(await result.Content.ReadAsStringAsync());

			return state;
		}

		public Task<ReqResult> Nav(Nav urlOrWebsiteName)
		{
			return BaseLogic(_client.PostAsync("Nav", new JsonContent(urlOrWebsiteName)));
		}
	}
}
