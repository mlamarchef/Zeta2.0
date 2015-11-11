namespace ZetaHelpDesk.Main.Code.DBObjects
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Data;
	using System.Data.OleDb;
	using System.Text;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Specialized;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Encapsulates a database object.
	/// </summary>
	public class Project :
		Base,
		ILockable
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load an object by a given ID.
		/// </summary>
		public static Project GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetProjectByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				Project o = new Project();
				o.Load( row );

				if ( o.IsEmpty )
				{
					return null;
				}
				else
				{
					return o;
				}
			}
		}

		/// <summary>
		/// Load all for the given parent.
		/// </summary>
		public static Project[] GetForCustomerCompany(
			CustomerCompany parentObject )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetProjectsByCustomerCompanyID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", parentObject.ID )
				) );

			if ( table == null )
			{
				return null;
			}
			else
			{
				ArrayList result = new ArrayList();

				foreach ( DataRow row in table.Rows )
				{
					Project o = new Project();
					o.Load( row );

					if ( !o.IsEmpty )
					{
						result.Add( o );
					}
				}

				if ( result.Count <= 0 )
				{
					return null;
				}
				else
				{
					return (Project[])result.ToArray(
						typeof( Project ) );
				}
			}
		}

		/// <summary>
		/// Load all.
		/// </summary>
		public static Project[] GetAll()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllProjects",
				new AdoNetSqlParamCollection(
				) );

			if ( table == null )
			{
				return null;
			}
			else
			{
				ArrayList result = new ArrayList();

				foreach ( DataRow row in table.Rows )
				{
					Project o = new Project();
					o.Load( row );

					if ( !o.IsEmpty )
					{
						result.Add( o );
					}
				}

				if ( result.Count <= 0 )
				{
					return null;
				}
				else
				{
					return (Project[])result.ToArray(
						typeof( Project ) );
				}
			}
		}

		/// <summary>
		/// Load all.
		/// </summary>
		public static Project[] GetProjectsWithUnbilledBillableProjectTasks(
			DateTime forMonth )
		{
			DateTime startDate = new DateTime( forMonth.Year, forMonth.Month, 1 );
			DateTime endDate = startDate.AddMonths( 1 );

			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllProjectsWithUnbilledBillableProjectTasks",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@StartDate", startDate ),
				AdoNetSqlParamCollection.CreateParameter( "@EndDate", endDate )
				) );

			if ( table == null )
			{
				return null;
			}
			else
			{
				ArrayList result = new ArrayList();

				foreach ( DataRow row in table.Rows )
				{
					Project o = new Project();
					o.Load( row );

					if ( !o.IsEmpty )
					{
						result.Add( o );
					}
				}

				if ( result.Count <= 0 )
				{
					return null;
				}
				else
				{
					return (Project[])result.ToArray(
						typeof( Project ) );
				}
			}
		}

		/// <summary>
		/// Defines how a query for projects is executed.
		/// </summary>
		public enum ProjectOwnerGetType
		{
			/// <summary>
			/// All projects are returnes.
			/// </summary>
			AllProjects,

			/// <summary>
			/// Projects for a given user are returned.
			/// </summary>
			OwnProjects
		}

		/// <summary>
		/// Defines how a query for projects is executed.
		/// </summary>
		public enum ProjectStateGetType
		{
			/// <summary>
			/// All projects are returned.
			/// </summary>
			AllProjects,

			/// <summary>
			/// Only open projects are returned.
			/// </summary>
			OpenProjects
		}

		/// <summary>
		/// Multiple information about a query for projects.
		/// </summary>
		[Serializable]
		public class ProjectGetInformation
		{
			#region Public variables.

			public ProjectOwnerGetType ProjectOwnerGetType =
				ProjectOwnerGetType.OwnProjects;

			public ProjectStateGetType ProjectStateGetType =
				ProjectStateGetType.OpenProjects;

			public bool IsFilterTextActive;
			public string FilterText = null;

			public StringCollection PastFilterTexts = new StringCollection();

			public string UserSamName =
				User.CurrentUser == null ? string.Empty : User.CurrentUser.SamName;

			#endregion

			#region Public properties.

			public User User
			{
				get
				{
					return User.GetBySamName( UserSamName );
				}
				set
				{
					if ( value == null || value.IsEmpty )
					{
						UserSamName = string.Empty;
					}
					else
					{
						UserSamName = value.SamName;
					}
				}
			}

			#endregion

			#region Public methods.

			public void Normalize()
			{
			}

			#endregion
		}

		/// <summary>
		/// Queries for projects with complex information.
		/// </summary>
		/// <param name="getInfo"></param>
		/// <returns></returns>
		public static Project[] Get(
			ProjectGetInformation getInfo )
		{
			getInfo.Normalize();

			DataTable table = table = AdoNetSqlHelper.ExecuteTable(
				"GetProjectsByInfo",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@OwnerType", getInfo.ProjectOwnerGetType.ToString() ),
				AdoNetSqlParamCollection.CreateParameter( "@StateType", getInfo.ProjectStateGetType.ToString() ),
				AdoNetSqlParamCollection.CreateParameter( "@UserSamName", getInfo.UserSamName ),
				AdoNetSqlParamCollection.CreateParameter( "@FilterText",
				getInfo.IsFilterTextActive ? getInfo.FilterText : string.Empty )
				) );

			if ( table == null )
			{
				return null;
			}
			else
			{
				ArrayList result = new ArrayList();

				foreach ( DataRow row in table.Rows )
				{
					Project o = new Project();
					o.Load( row );

					if ( !o.IsEmpty )
					{
						result.Add( o );
					}
				}

				if ( result.Count <= 0 )
				{
					return null;
				}
				else
				{
					return (Project[])result.ToArray(
						typeof( Project ) );
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		public Project()
		{
		}

		/// <summary>
		/// Use this version for displaying in lists etc.
		/// </summary>
		public override string ToString()
		{
			return base.ToString();
		}

		public void Store()
		{
			using ( AdoNetSqlUpdater upd = new AdoNetSqlUpdater(
						"GetProjectByID",
						new AdoNetSqlParamCollection(
						AdoNetSqlParamCollection.CreateParameter( "@ID", ID, DbType.Int32 )
						) ) )
			{
				DataRow row;
				if ( upd.Row == null )
				{
					row = upd.AddNewRow();
					Store( row );
					id = upd.Update(
						AdoNetSqlUpdater.IdentityControl.Get,
						"Projects" );
				}
				else
				{
					row = upd.Row;
					Store( row );
					upd.Update( AdoNetSqlUpdater.IdentityControl.DontGet );
				}
			}
		}

		/// <summary>
		/// Delete from database.
		/// </summary>
		public void Delete()
		{
			AdoNetSqlHelper.ExecuteNonQuery(
				"DeleteProjectByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			id = 0;
		}

		// ------------------------------------------------------------------
		#endregion

		#region Printing.
		// ------------------------------------------------------------------

		/// <summary>
		/// Generate a complete HTML-Document with the ticket and all events.
		/// Use this when printing.
		/// </summary>
		/// <returns>Returns the string of the complete HTML document.</returns>
		protected override string PrintToHtml()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat( "<p>Printed {0}</p>\r\n", DateTime.Now );

			sb.AppendFormat( "<p><table class=dataTicket width='100%'>" );

			sb.AppendFormat( "<tr><th nowrap>Name</th><td width='100%'><b>{0}</b></td></tr>\r\n", this.Name );
			sb.AppendFormat( "<tr><th nowrap>Date created</th><td width='100%'>{0}</td></tr>\r\n", this.DateCreated.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Due date</th><td width='100%'>{0}</td></tr>\r\n", this.DueDate == DateTime.MinValue ? string.Empty : this.DueDate.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Customer company</th><td width='100%'>{0}</td></tr>\r\n", this.Company == null ? string.Empty : this.Company.ToString() );
			sb.AppendFormat( "<tr><th nowrap># of tasks</th><td width='100%'>{0}</td></tr>\r\n", this.TaskCount.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Assigned to</th><td width='100%'>{0}</td></tr>\r\n", this.AssignedToUser.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Is completed</th><td width='100%'>{0}</td></tr>\r\n", this.IsCompleted ? "Yes" : "No" );

			DBObjects.Project.TimeSpans spans =
				this.CalculatedTimeSpans;

			sb.AppendFormat( "<tr><th nowrap>Total duration</th><td width='100%'>{0}</td></tr>\r\n", spans.TotalDuration.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Completed duration</th><td width='100%'>{0}</td></tr>\r\n", spans.CompletedDuration.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Billable duration</th><td width='100%'>{0}</td></tr>\r\n", spans.BillableDuration.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Complete billable duration</th><td width='100%'>{0}</td></tr>\r\n", spans.CompletedBilledDuration.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Complete unbillable duration</th><td width='100%'>{0}</td></tr>\r\n", spans.CompletedUnbilledDuration.ToString() );

			sb.AppendFormat( "<tr><td colspan=2>{0} &nbsp;</td></tr>\r\n",
				HtmlHelper.FormatMultiLine( this.Description ) );

			sb.AppendFormat( "</table></p>" );


			// --
			// The ticket events.

			ProjectTask[] projectTasks = Tasks;

			sb.AppendFormat( "<h2>Project Tasks</h2>\r\n" );

			if ( projectTasks == null )
			{
				sb.AppendFormat( "<p>The project contains no tasks.</p>\r\n" );
			}
			else
			{
				int index = 0;
				foreach ( ProjectTask projectTask in projectTasks )
				{
					sb.AppendFormat( "<p><b>Task number {0}:</b><br /><table class=dataTicketEvent width='100%'>",
						index + 1 );

					sb.AppendFormat( "<tr><th nowrap>Name</th><td width='100%'><b>{0}</b></td></tr>\r\n", projectTask.Name );
					sb.AppendFormat( "<tr><th nowrap>Date created</th><td width='100%'>{0}</td></tr>\r\n", projectTask.DateCreated.ToString() );
					sb.AppendFormat( "<tr><th nowrap>Duration</th><td>{0}</td></tr>\r\n", projectTask.DurationTimeSpan.ToString() );
					sb.AppendFormat( "<tr><th nowrap>Is completed</th><td>{0}</td></tr>\r\n", projectTask.IsCompleted ? "Yes" : "No" );
					sb.AppendFormat( "<tr><th nowrap>Is billable</th><td>{0}</td></tr>\r\n", projectTask.IsBillable ? "Yes" : "No" );
					sb.AppendFormat( "<tr><th nowrap>Was billed</th><td>{0}</td></tr>\r\n", projectTask.WasBilled ? "Yes" : "No" );

					if ( projectTask.HasAttachment )
					{
						sb.AppendFormat( "<tr><th nowrap>Attachment</th><td>{0}</td></tr>\r\n", projectTask.AttachmentUserReadableFileName );
					}

					sb.AppendFormat( "<tr><td colspan=2>{0} &nbsp;</td></tr>\r\n",
						HtmlHelper.FormatMultiLine( projectTask.Description.Trim() ) );

					sb.AppendFormat( "</table></p>" );

					index++;
				}
			}

			// --

			return GetPrintingHtmlFramework(
				string.Format(
				"zeta HelpDesk Project '{0}'",
				this.Name ),
				sb.ToString() );
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		/// <summary>
		/// Get the image key, depending on the state.
		/// </summary>
		public string SmallImageKey
		{
			get
			{
				return "Project.gif";
			}
		}

		public int CustomerCompanyID
		{
			get
			{
				return customerCompanyID;
			}
			set
			{
				customerCompanyID = value;
			}
		}

		public CustomerCompany Company
		{
			get
			{
				return CustomerCompany.GetByID( CustomerCompanyID );
			}
			set
			{
				if ( value == null || value.IsEmpty )
				{
					CustomerCompanyID = 0;
				}
				else
				{
					CustomerCompanyID = value.ID;
				}
			}
		}

		public ProjectTask[] Tasks
		{
			get
			{
				return ProjectTask.GetForProject( this );
			}
		}

 		public ProjectTask[] GetUnbilledBillableTasks(
			DateTime forMonth  )
		{
			return ProjectTask.GetAllUnbilledBillableProjectTasksByProject( 
				this, 
				forMonth );
		}

		public int TaskCount
		{
			get
			{
				ProjectTask[] tasks = Tasks;

				if ( tasks == null )
				{
					return 0;
				}
				else
				{
					return tasks.Length;
				}
			}
		}

		public string Category
		{
			get
			{
				return category;
			}
			set
			{
				category = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
			}
		}

		public DateTime DueDate
		{
			get
			{
				return dueDate;
			}
			set
			{
				dueDate = value;
			}
		}

		public bool IsCompleted
		{
			get
			{
				return isCompleted;
			}
			set
			{
				isCompleted = value;
			}
		}

		public string AssignedToUserSamName
		{
			get
			{
				return assignedToUserSamName;
			}
			set
			{
				assignedToUserSamName = value;
			}
		}

		public User AssignedToUser
		{
			get
			{
				return User.GetBySamName( assignedToUserSamName );
			}
		}

		/// <summary>
		/// Calculated several significant values.
		/// </summary>
		public class TimeSpans
		{
			public TimeSpan TotalDuration;
			public TimeSpan CompletedDuration;
			public TimeSpan BillableDuration;
			public TimeSpan CompletedBilledDuration;
			public TimeSpan CompletedUnbilledDuration;
		}

		/// <summary>
		/// Calculate several significant values.
		/// </summary>
		public TimeSpans CalculatedTimeSpans
		{
			get
			{
				TimeSpans result = new TimeSpans();

				ProjectTask[] tasks = Tasks;

				if ( Tasks != null )
				{
					foreach ( ProjectTask task in Tasks )
					{
						result.TotalDuration += task.DurationTimeSpan;

						if ( task.IsBillable )
						{
							result.BillableDuration += task.DurationTimeSpan;

							if ( task.IsCompleted )
							{
								result.CompletedBilledDuration += task.DurationTimeSpan;
							}
							else
							{
								result.CompletedUnbilledDuration += task.DurationTimeSpan;
							}
						}

						if ( task.IsCompleted )
						{
							result.CompletedDuration += task.DurationTimeSpan;
						}
					}
				}

				return result;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private int customerCompanyID;
		private string category;
		private string name;
		private string description;
		private DateTime dueDate;
		private bool isCompleted;
		private string assignedToUserSamName = User.CurrentUser.SamName;

		// ------------------------------------------------------------------
		#endregion

		#region Private routines.
		// ------------------------------------------------------------------

		protected override void Load(
			DataRow row )
		{
			base.Load( row );

			if ( row != null )
			{
				DBHelper.ReadField( out customerCompanyID, row["CustomerCompanyID"] );
				DBHelper.ReadField( out category, row["Category"] );
				DBHelper.ReadField( out name, row["Name"] );
				DBHelper.ReadField( out description, row["Description"] );
				DBHelper.ReadField( out dueDate, row["DueDate"] );
				DBHelper.ReadField( out isCompleted, row["IsCompleted"] );
				DBHelper.ReadField( out assignedToUserSamName, row["AssignedToUserSamName"] );
			}
		}

		protected override void Store(
			DataRow row )
		{
			base.Store( row );

			if ( row != null )
			{
				row["CustomerCompanyID"] = DBHelper.WriteField( customerCompanyID );
				row["Category"] = DBHelper.WriteField( category );
				row["Name"] = DBHelper.WriteField( name );
				row["Description"] = DBHelper.WriteField( description );
				row["DueDate"] = DBHelper.WriteField( dueDate );
				row["IsCompleted"] = DBHelper.WriteField( isCompleted );
				row["AssignedToUserSamName"] = DBHelper.WriteField( assignedToUserSamName );
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region ILockable Members

		public LockGuard Lock()
		{
			return new LockGuard( GetType(), ID );
		}

		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}