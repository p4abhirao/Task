using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskApplication.Models
{
	public class Task
	{
		public int TaskId { get; set; }
		[Display(Name = "Name")]
		public string Name { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }
		[Display(Name = "Date")]
		public DateTime TaskDate { get; set; }
		[Display(Name = "Cost")]
		public decimal EstimatedCost { get; set; }
		public int PriorityID { get; set; }
		[Display(Name = "Priority")]
		public string PriorityName { get; set; }
	}

	public enum ePriorityType : int
	{
		P1 = 1,
		P2 = 2,
		P3 = 3,
	}
}