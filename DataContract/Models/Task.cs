using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract.Models
{
	/// <summary>
	/// store task detail
	/// </summary>
	public class Task
	{
		public int TaskId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime TaskDate { get; set; }
		public decimal EstimatedCost { get; set; }
		public int PriorityID { get; set; }
	}
}
