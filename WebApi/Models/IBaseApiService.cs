using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Response;

namespace WebApi.Models
{
	/// <summary>
	/// interface to define API Functions
	/// </summary>
	public interface IBaseApiService
	{
		ResTaskData GetTaskList(string sText);
		ResTaskData TaskSave(Task ctask);
		Boolean TaskDelete(int id);
	}
}