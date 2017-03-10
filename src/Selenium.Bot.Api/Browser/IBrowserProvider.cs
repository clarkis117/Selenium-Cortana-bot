using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Selenium.Bot.Api.Browser
{
	public interface IBrowserProvider
	{
		string Name { get; }

		FileInfo DriverExe { get; }

		IWebDriver WebDriver { get; }
	}
}
