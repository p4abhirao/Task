namespace DataContract.Context
{
	using DataContract.Models;
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class TaskPriorityContext : DbContext
	{
		// Your context has been configured to use a 'TaskPriorityContext' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'DataContract.Context.TaskPriorityContext' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'TaskPriorityContext' 
		// connection string in the application configuration file.
		public TaskPriorityContext()
			: base("name=TaskPriorityContext")
		{
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }

		public virtual DbSet<Task> Tasks { get; set; }
	}

	
}