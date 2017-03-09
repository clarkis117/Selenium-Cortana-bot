using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selenium.Bot.Lib.DTOs
{
    public class ReqResult
    {
		public RequestState State { get; }

		public string Message { get; set; }


		protected ReqResult(RequestState state)
		{
			State = state;
		}

		protected ReqResult(RequestState state, string message)
		{
			if (message == null)
				throw new ArgumentNullException(nameof(message));

			State = state;
			Message = message;
		}

		public static ReqResult Failed()
		{
			return new ReqResult(RequestState.Failed);
		}

		public static ReqResult Failed(string message)
		{
			return new ReqResult(RequestState.Failed);
		}

		public static ReqResult Success()
		{
			return new ReqResult(RequestState.Success);
		}

		public static ReqResult Success(string message)
		{
			return new ReqResult(RequestState.Success, message);
		}

		public static ReqResult Blocked()
		{
			return new ReqResult(RequestState.Blocked);
		}

		public static ReqResult Blocked(string message)
		{
			return new ReqResult(RequestState.Blocked, message);
		}
	}
}
