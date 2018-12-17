using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataContract.Context;
using DataContract.Models;

namespace BLL
{
	public class BLLTask
	{
		private static BLLTask _Instance = new BLLTask();
		public static BLLTask Instance
		{
			get
			{
				return _Instance;
			}
		}

		private BLLTask()
		{

		}

		/// <summary>
		/// geting task list
		/// </summary>
		/// <returns></returns>
		public List<DataContract.Models.Task> GetTaskList(string stext)
		{
			using (var dbContext = new TaskPriorityContext())
			{
				return dbContext.Tasks.Where(dd => dd.Name == stext).ToList();
			}
		}


		/// <summary>
		/// save/update task data
		/// </summary>
		/// <param name="taskinfo"></param>
		/// <returns></returns>
		public DataContract.Models.Task TaskSave(DataContract.Models.Task taskinfo)
		{
			using (var dbContext = new TaskPriorityContext())
			{
				var t = dbContext.Tasks.Where(u => u.TaskId == taskinfo.TaskId).FirstOrDefault();
				if (t != null)
				{
					t.TaskId = taskinfo.TaskId;
					t.Name = taskinfo.Name;
					t.Description = taskinfo.Description;
					t.TaskDate = taskinfo.TaskDate;
					t.EstimatedCost = taskinfo.EstimatedCost;
					t.PriorityID = taskinfo.PriorityID;

					dbContext.Tasks.Attach(t);
					dbContext.Entry(t).State = EntityState.Modified;
					//--------------
				}
				else
				{
					dbContext.Tasks.Add(taskinfo);
				}

				//Save to DB
				try
				{
					dbContext.SaveChanges();
				}
				catch (DbEntityValidationException ex)
				{

				}
				catch (Exception ex)
				{ }

			}
			return taskinfo;
		}

		/// <summary>
		/// task Deleted for selected Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Boolean TaskDelete(int id)
		{
			bool bDel = true;
			using (var dbContext = new TaskPriorityContext())
			{
				var t = dbContext.Tasks.Where(u => u.TaskId == id).FirstOrDefault();
				if (t != null)
				{
					dbContext.Tasks.Attach(t);
					dbContext.Entry(t).State = EntityState.Deleted;
					
					//Save to DB
					try
					{
						dbContext.SaveChanges();
					}
					catch (DbEntityValidationException ex)
					{

					}
					catch (Exception ex)
					{ }
				}
			}
			return bDel;
		}
	}
}
