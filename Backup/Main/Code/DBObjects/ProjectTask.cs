namespace ZetaHelpDesk.Main.Code.DBObjects
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.IO;
	using System.Data;
	using System.Data.OleDb;
	using System.Collections.Generic;
	using System.Text;
	using System.Collections;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Encapsulates a database object.
	/// </summary>
	public class ProjectTask :
		Base,
		ILockable
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load all.
		/// </summary>
		public static ProjectTask[] GetAllUnbilledBillableProjectTasksByProject(
			Project project,
			DateTime forMonth )
		{
			DateTime startDate = new DateTime( forMonth.Year, forMonth.Month, 1 );
			DateTime endDate = startDate.AddMonths( 1 );

			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllUnbilledBillableProjectTasksByProjectID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ProjectID", project.ID ),
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
					ProjectTask o = new ProjectTask();
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
					return (ProjectTask[])result.ToArray(
						typeof( ProjectTask ) );
				}
			}
		}

		/// <summary>
		/// Load an object by a given ID.
		/// </summary>
		public static ProjectTask GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetProjectTaskByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				ProjectTask o = new ProjectTask();
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
		public static ProjectTask[] GetForProject(
			Project parentObject )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetProjectTasksByProjectID",
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
					ProjectTask o = new ProjectTask();
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
					return (ProjectTask[])result.ToArray(
						typeof( ProjectTask ) );
				}
			}
		}

		/// <summary>
		/// Load all.
		/// </summary>
		public static ProjectTask[] GetAll()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllProjectTasks",
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
					ProjectTask o = new ProjectTask();
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
					return (ProjectTask[])result.ToArray(
						typeof( ProjectTask ) );
				}
			}
		}

		/// <summary>
		/// Defines how a query for project tasks is executed.
		/// </summary>
		public enum ProjectTaskStateGetType
		{
			/// <summary>
			/// All project tasks are returned.
			/// </summary>
			AllProjectTasks,

			/// <summary>
			/// Only open project tasks are unbilled.
			/// </summary>
			UnbilledProjectTasks
		}

		/// <summary>
		/// Multiple information about a query for project tasks.
		/// </summary>
		[Serializable]
		public class ProjectTaskGetInformation
		{
			#region Public variables.

			public ProjectTaskStateGetType ProjectTaskStateGetType =
				ProjectTaskStateGetType.UnbilledProjectTasks;

			public int ProjectID;

			#endregion

			#region Public properties.

			public Project Project
			{
				get
				{
					return Project.GetByID( ProjectID );
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
		public static ProjectTask[] Get(
			ProjectTaskGetInformation getInfo )
		{
			getInfo.Normalize();

			DataTable table = table = AdoNetSqlHelper.ExecuteTable(
				"GetProjectTasksByInfo",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ProjectID", getInfo.ProjectID ),
				AdoNetSqlParamCollection.CreateParameter( "@StateType", getInfo.ProjectTaskStateGetType.ToString() )
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
					ProjectTask o = new ProjectTask();
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
					return (ProjectTask[])result.ToArray(
						typeof( ProjectTask ) );
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
		public ProjectTask()
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
						"GetProjectTaskByID",
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
						"ProjectTasks" );
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
				"DeleteProjectTaskByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			id = 0;
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
				if ( HasAttachment )
				{
					return "ProjectTaskClip.gif";
				}
				else
				{
					return "ProjectTask.gif";
				}
			}
		}

		public Project Project
		{
			get
			{
				return Project.GetByID( ProjectID );
			}
			set
			{
				if ( value == null || value.IsEmpty )
				{
					ProjectID = 0;
				}
				else
				{
					ProjectID = value.ID;
				}
			}
		}

		public int ProjectID
		{
			get
			{
				return projectID;
			}
			set
			{
				projectID = value;
			}
		}

		public string AttachmentFileName
		{
			get
			{
				return attachmentFileName;
			}
			set
			{
				attachmentFileName = value;
			}
		}

		public string AttachmentUserReadableFileName
		{
			get
			{
				if ( !string.IsNullOrEmpty( temporaryAttachmentFilePath ) )
				{
					return Path.GetFileName( temporaryAttachmentFilePath );
				}
				else
				{
					return attachmentUserReadableFileName;
				}
			}
		}

		public bool HasAttachment
		{
			get
			{
				return
					!string.IsNullOrEmpty( attachmentFileName ) &&
					File.Exists( AttachmentFilePath );
			}
		}

		/// <summary>
		/// The complete path.
		/// To import, simply assign the path to import from to
		/// this property.
		/// </summary>
		public string AttachmentFilePath
		{
			get
			{
				if ( !string.IsNullOrEmpty( temporaryAttachmentFilePath ) )
				{
					return temporaryAttachmentFilePath;
				}
				else
				{
					return
						Path.Combine(
						Path.Combine(
						ApplicationConfiguration.Current.DataFolderBasePath,
						"Attachments" ),
						attachmentFileName );
				}
			}
			set
			{
				temporaryAttachmentFilePath = value;
			}
		}

		public string AttachmentDescription
		{
			get
			{
				return attachmentDescription;
			}
			set
			{
				attachmentDescription = value;
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

		public DateTime Date
		{
			get
			{
				return date;
			}
			set
			{
				date = value;
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

		public bool WasBilled
		{
			get
			{
				return wasBilled;
			}
			set
			{
				wasBilled = value;
			}
		}

		public bool IsBillable
		{
			get
			{
				return isBillable;
			}
			set
			{
				isBillable = value;
			}
		}

		public TimeSpan DurationTimeSpan
		{
			get
			{
				DateTime one = DateTime.MinValue;
				DateTime two = one.AddMinutes( Duration );

				return two - one;
			}
			set
			{
				Duration = Convert.ToInt32( value.TotalMinutes );
			}
		}

		public int Duration
		{
			get
			{
				return duration;
			}
			set
			{
				duration = value;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private int projectID;
		private string name;
 		private string description;
		private DateTime dueDate;
		private DateTime date = DateTime.Now;
		private bool isCompleted;
		private bool wasBilled;
		private bool isBillable = true;
		private int duration;
		private string attachmentUserReadableFileName;
		private string attachmentFileName;
		private string attachmentDescription;
		private string temporaryAttachmentFilePath = null;

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
				DBHelper.ReadField( out projectID, row["ProjectID"] );
				DBHelper.ReadField( out name, row["Name"] );
				DBHelper.ReadField( out description, row["Description"] );
				DBHelper.ReadField( out dueDate, row["DueDate"] );
				DBHelper.ReadField( out date, row["Date"] );
				DBHelper.ReadField( out isCompleted, row["IsCompleted"] );
				DBHelper.ReadField( out wasBilled, row["WasBilled"] );
				DBHelper.ReadField( out isBillable, row["IsBillable"] );
				DBHelper.ReadField( out duration, row["Duration"] );
				DBHelper.ReadField( out attachmentFileName, row["AttachmentFileName"] );
				DBHelper.ReadField( out attachmentUserReadableFileName, row["AttachmentUserReadableFileName"] );
				DBHelper.ReadField( out attachmentDescription, row["AttachmentDescription"] );
			}
		}

		protected override void Store(
			DataRow row )
		{
			base.Store( row );

			if ( row != null )
			{
				row["ProjectID"] = DBHelper.WriteField( projectID );
				row["Name"] = DBHelper.WriteField( name );
				row["Description"] = DBHelper.WriteField( description );
				row["DueDate"] = DBHelper.WriteField( dueDate );
				row["Date"] = DBHelper.WriteField( date );
				row["IsCompleted"] = DBHelper.WriteField( isCompleted );
				row["WasBilled"] = DBHelper.WriteField( wasBilled );
				row["IsBillable"] = DBHelper.WriteField( isBillable );
				row["Duration"] = DBHelper.WriteField( duration );

				// --
				// Attachment handling.

				if ( !string.IsNullOrEmpty( temporaryAttachmentFilePath ) )
				{
					// Remember filename.
					attachmentUserReadableFileName =
						Path.GetFileName( temporaryAttachmentFilePath );

					temporaryAttachmentFilePath =
						temporaryAttachmentFilePath.ToLower();

					string temporaryAttachmentFolderPath =
						Path.GetDirectoryName( temporaryAttachmentFilePath );

					string currentAttachmentFilePath = AttachmentFilePath;
					currentAttachmentFilePath =
						currentAttachmentFilePath.ToLower();

					string currentAttachmentFolderPath =
						Path.GetDirectoryName( currentAttachmentFilePath );

					// --

					string attachmentFilePath =
						Path.Combine(
						ApplicationConfiguration.Current.DataFolderBasePath,
						"Attachments" );

					if ( !string.IsNullOrEmpty( attachmentFileName ) )
					{
						attachmentFilePath =
							Path.Combine(
							attachmentFilePath,
							attachmentFileName );
					}

					// Delete any old.
					if ( !string.IsNullOrEmpty( attachmentFilePath ) &&
						File.Exists( attachmentFilePath ) )
					{
						// Never delete if the same.
						if ( temporaryAttachmentFilePath !=
							AttachmentFilePath.ToLower() )
						{
							File.Delete( currentAttachmentFilePath );
						}
					}

					// Copy new.
					attachmentFileName =
						Guid.NewGuid().ToString() +
						Path.GetExtension( temporaryAttachmentFilePath );
					currentAttachmentFilePath =
						Path.Combine(
						Path.Combine(
						ApplicationConfiguration.Current.DataFolderBasePath,
						"Attachments" ),
						attachmentFileName );

					File.Copy(
						temporaryAttachmentFilePath,
						currentAttachmentFilePath,
						true );

					// Reset.
					temporaryAttachmentFilePath = null;
				}

				// --

				row["AttachmentFileName"] = DBHelper.WriteField( attachmentFileName );
				row["AttachmentUserReadableFileName"] = DBHelper.WriteField( attachmentUserReadableFileName );
				row["AttachmentDescription"] = DBHelper.WriteField( attachmentDescription );

				if ( !string.IsNullOrEmpty( attachmentFileName ) )
				{
					row["AttachmentFileExtension"] = DBHelper.WriteField(
						Path.GetExtension( attachmentFileName ).Trim( '.' ).Trim().ToLower() );
				}
				else
				{
					row["AttachmentFileExtension"] = DBHelper.WriteField( string.Empty );
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region ILockable members.
		// ------------------------------------------------------------------

		public LockGuard Lock()
		{
			return new LockGuard( GetType(), ID );
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}