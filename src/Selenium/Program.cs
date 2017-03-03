using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selenium
{
	public class Program
	{
		public const string ExeLoc = "./";

		public static void Main(string[] args)
		{
			EdgeOptions opts = new EdgeOptions();

			EdgeDriverService ser = EdgeDriverService.CreateDefaultService(ExeLoc);

			IWebDriver driver = new EdgeDriver(ser);

			driver.Url = "http://bing.com";

			var element = driver.FindElement(By.Id("sb_form_q"));

			element.SendKeys("What is a cortana skill? in C# \n\r");

			driver.Url = "http://google.com";
		}
	}
}
