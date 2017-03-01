using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selenium.Lib
{
	public enum RequestState : byte { Success, Blocked, Failed };

	public interface IRemoteControl
	{
		Task<bool> IsBrowserServiceUp();

		Task<RequestState> OpenBrowser();

		Task<RequestState> CloseBrowser();

		Task<RequestState> Forward();

		Task<RequestState> Back();

		Task<RequestState> Search(string term);

		Task SelectResult(uint count);

		Task SelectResult(string title);

		Task SelectResult(string website, uint count = 1);
	}
}
