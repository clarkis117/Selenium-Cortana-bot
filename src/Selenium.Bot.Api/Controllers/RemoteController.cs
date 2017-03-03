using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Selenium.Bot;
using Selenium.Bot.Lib.DTOs;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Selenium.Rc.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	public class RemoteController : Controller, IRemoteControl
	{
		private const string driverLocation = "./";

		private const string bing = "http://bing.com";

		private static EdgeDriverService _driverService;

		private static IWebDriver _driver;

		private static ServiceState _state;

		private static bool _disposed = true;

		[NonAction]
		private static void Setup()
		{
			_driverService = EdgeDriverService.CreateDefaultService(driverLocation);

			_driver = new EdgeDriver(_driverService);
		}

		[NonAction]
		private static void DriverDispose()
		{
			if (_driver != null)
			{
				_driver.Dispose();

				_driverService.Dispose();
			}
		}

		[NonAction]
		private static ServiceState GetService()
		{
			return new ServiceState()
			{

			};
		}

		[HttpGet]
		public async Task<ServiceState> ServiceState()
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public async Task<ReqResult> OpenBrowser()
		{
			try
			{
				if (_driver == null)
				{
					Setup();
				}

				_driver.Url = bing;

				return ReqResult.Success();
			}
			catch (Exception)
			{
				return ReqResult.Failed();
			}
		}

		[HttpPost]
		public async Task<ReqResult> CloseBrowser()
		{
			_driver.Close();

			DriverDispose();

			return ReqResult.Success();
		}

		[HttpPost]
		public async Task<ReqResult> Forward()
		{
			_driver.Navigate().Forward();


			return ReqResult.Success();
		}

		[HttpPost]
		public async Task<ReqResult> Back()
		{
			_driver.Navigate().Back();


			return ReqResult.Success();
		}

		[HttpPost]
		public async Task<ReqResult> Nav(Nav urlOrWebsiteName)
		{
			//todo url or name logic
			_driver.Navigate().GoToUrl(urlOrWebsiteName.urlOrName);

			return ReqResult.Success();
		}

		[HttpPost]
		public async Task<ReqResult> Search(Search query)
		{
			//check if I'm on bing
			//if not nav to bing
			//check if the two search input fields are there
			//if not fail

			return ReqResult.Success();
		}

		[HttpPost]
		public async  Task<ReqResult> SelectResult(Select selectedResult)
		{
			throw new NotImplementedException();
		}
	}
}
