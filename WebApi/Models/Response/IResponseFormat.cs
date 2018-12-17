using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Response
{
	public interface IResponseFormat
	{
		int Success { get; set; }
		//object Output { get; set; }
		int StatusCode { get; set; }
		string StatusDesc { get; set; }
	}
}