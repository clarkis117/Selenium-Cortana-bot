using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Bot.Lib
{
	public class JsonContent : StringContent
	{
		public JsonContent(Object obj) : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
		{

		}
	}
}
