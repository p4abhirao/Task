using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using BLL;
using DataContract;
using WebApi.Models;
using WebApi.Models.Response;

namespace WebApi.Helper
{
	public class BaseApiValidator : IBaseApiService
	{
		/// <summary>
		/// Get te task list to populate
		/// </summary>
		/// <param name="sText"></param>
		/// <returns></returns>
		public ResTaskData GetTaskList(string sText)
		{
			ResTaskData rtd = new ResTaskData();
			rtd.Success = 0;
			rtd.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
			rtd.StatusDesc = "No Data Found";

			try
			{
				//fetching list of task
				var lTask = BLL.BLLTask.Instance.GetTaskList(sText);

				if (lTask != null && lTask.Count > 0)
				{
					foreach (var item in lTask)
					{
						Task t = new Task();
						t.TaskId = item.TaskId;
						t.Name = item.Name;
						t.Description = item.Description;
						t.TaskDate = item.TaskDate;
						t.EstimatedCost = item.EstimatedCost;
						t.PriorityID = item.PriorityID;
						rtd.listTaskinfo.Add(t);
					}

					rtd.Success = 1;
					rtd.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
					rtd.StatusDesc = "Success";
				}
			}
			catch (Exception ex)
			{
				BLL.ErrorLog.WriteLog("Service", "GetTaskList", ex, "Error");
			}
			return rtd;
		}

		/// <summary>
		/// Save/Edit Task Data
		/// </summary>
		/// <param name="ctask"></param>
		/// <returns></returns>
		public ResTaskData TaskSave(Task ctask)
		{
			ResTaskData rtd = new ResTaskData();
			DataContract.Models.Task t = new DataContract.Models.Task();
			rtd.Success = 0;
			rtd.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
			rtd.StatusDesc = "No Data Found";

			try
			{
				if (ctask != null)
				{
					t.Name = ctask.Name;
					t.Description = ctask.Description;
					t.TaskDate = ctask.TaskDate;
					t.EstimatedCost = ctask.EstimatedCost;
					t.PriorityID = ctask.PriorityID;

					var tinfo = BLL.BLLTask.Instance.TaskSave(t);
					if (tinfo != null)
					{
						rtd.Success = 1;
						rtd.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
						rtd.StatusDesc = "Success";
					}
				}
			}
			catch (Exception ex)
			{
				BLL.ErrorLog.WriteLog("Service", "TaskSave", ex, "Error");
			}
			return rtd;
		}
		

		/// <summary>
		/// Delete Selected Task
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Boolean TaskDelete(int id)
		{
			Boolean bDel = true;

			bDel = BLLTask.Instance.TaskDelete(id);

			return bDel;
		}
	}
}