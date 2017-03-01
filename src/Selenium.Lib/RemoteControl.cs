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

		public Task Back()
		{
			return _client.PostAsync("back", new StringContent(""));
		}

		public Task CloseBrowser()
		{
			return _client.PostAsync("CloseBrowser", new StringContent(""));
		}

		public Task Forward()
		{
			return _client.PostAsync("Forward", new StringContent(""));
		}

		public Task OpenBrowser()
		{
			return _client.PostAsync("OpenBrowser", new StringContent(""));
		}

		public Task Search(string term)
		{
			return _client.PostAsync("Search", new StringContent(term));
		}

		public Task SelectResult(uint number)
		{
			return _client.PostAsync("SelectResult", new StringContent(number.ToString()));
		}

		public Task SelectResult(int number)
		{
			return _client.PostAsync("SelectResult", new StringContent(""));
		}
	}
}
