using Selenium.Lib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selenium.Lib
{
	/// <summary>
	/// blocked means browser or selenium cannot do it - I cannot do that Dave
	/// failed means exception, unexpected result - Something has happened that I could not have anticpated
	/// 
	/// </summary>
	public enum RequestState : byte { Success, Blocked, Failed };

	public interface IRemoteControl
	{
		Task<bool> IsBrowserServiceUp();

		Task<ReqResult> OpenBrowser();

		Task<ReqResult> CloseBrowser();

		Task<ReqResult> Forward();

		Task<ReqResult> Back();

		Task<ReqResult> Nav(string urlOrWebsiteName);

		Task<ReqResult> Search(string term);

		Task<ReqResult> SelectResult(uint count);

		Task<ReqResult> SelectResult(string title);

		Task<ReqResult> SelectResult(string website, uint count = 1);
	}
}
