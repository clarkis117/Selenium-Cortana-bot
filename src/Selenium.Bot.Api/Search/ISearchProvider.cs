using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selenium.Bot.Api.Search
{
    public interface ISearchProvider
    {
		string Name { get; }

		string HomePage { get; }

		bool IsSearchPage(string url);

		bool CanSearch(IWebDriver driver);

		void Search(IWebDriver driver, string term);
	}
}
