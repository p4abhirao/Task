using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;
using WebApi.Models.Response;

namespace WebApi.Controllers
{
    public class BaseAPIController : ApiController
    {
		/// <summary>
		/// implementing dependency injection by injecting interface to a constructor
		/// </summary>
		private IBaseApiService _IBPS;

		public BaseAPIController(IBaseApiService IBPS)
		{
			_IBPS = IBPS;
		}

		/// <summary>
		/// Get te task list to populate
		/// </summary>
		/// <param name="sText"></param>
		/// <returns></returns>
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		[Route("api/Task/TaskList")]
		public ResTaskData GetTaskList(string sText)
		{
			return _IBPS.GetTaskList(sText);	
		}

		/// <summary>
		/// Save/Edit Task Data
		/// </summary>
		/// <param name="ctask"></param>
		/// <returns></returns>
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		[Route("api/Task/TaskSave")]
		[HttpPost]
		public ResTaskData TaskSave([FromBody]Task ctask)
		{
			return _IBPS.TaskSave(ctask);
		}

		/// <summary>
		/// Delete Selected Task
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		[Route("api/Task/TaskDelete")]
		public Boolean TaskDelete(int id)
		{
			return _IBPS.TaskDelete(id);
		}
	}
}
