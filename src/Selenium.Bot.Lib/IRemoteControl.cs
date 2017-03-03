using Selenium.Bot.Lib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selenium.Bot
{
	/// <summary>
	/// blocked means browser or selenium cannot do it - I cannot do that Dave
	/// failed means exception, unexpected result - Something has happened that I could not have anticpated
	///
	/// </summary>
	public enum RequestState : byte { Success, Blocked, Failed };

	public interface IRemoteControl
	{
		Task<ServiceState> ServiceState();

		Task<ReqResult> OpenBrowser();

		Task<ReqResult> CloseBrowser();

		Task<ReqResult> Forward();

		Task<ReqResult> Back();

		Task<ReqResult> Nav(Nav urlOrWebsiteName);

		Task<ReqResult> Search(Search query);

		Task<ReqResult> SelectResult(Select selectedResult);
	}
}
