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
	using System.ComponentModel;
	using System.Reflection;
	using System.Reflection.Emit;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public class TicketEvent :
		Base,
		ILockable
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load an object by a given ID.
		/// </summary>
		public static TicketEvent GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetTicketEventByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				TicketEvent o = new TicketEvent();
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
		public static TicketEvent[] GetForTicket(
			Ticket parentObject )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetTicketEventsByTicketID",
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
					TicketEvent o = new TicketEvent();
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
					return (TicketEvent[])result.ToArray(
						typeof( TicketEvent ) );
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
		public TicketEvent()
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
						"GetTicketEventByID",
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
						"TicketEvents" );
				}
				else
				{
					row = upd.Row;
					Store( row );
					upd.Update(
						AdoNetSqlUpdater.IdentityControl.DontGet );
				}
			}
		}

		/// <summary>
		/// Delete from database.
		/// </summary>
		public void Delete()
		{
			AdoNetSqlHelper.ExecuteNonQuery(
				"DeleteTicketEventByID",
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
					return "EventClip.gif";
				}
				else 
				{
					return "Event.gif";
				}
			}
		}

		public Ticket Ticket
		{
			get
			{
				return Ticket.GetByID( ticketID );
			}
		}

		public int TicketID
		{
			get
			{
				return ticketID;
			}
			set
			{
				ticketID = value;
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

		public TicketEventState State
		{
			get
			{
				return state;
			}
			set
			{
				state = value;
			}
		}

		public DateTime EventDate
		{
			get
			{
				return eventDate;
			}
			set
			{
				eventDate = value;
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

		/// <summary>
		/// The duration in total minutes.
		/// </summary>
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

		public int CustomerPersonID
		{
			get
			{
				return customerPersonID;
			}
			set
			{
				customerPersonID = value;
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

		public CustomerPerson CustomerPerson
		{
			get
			{
				return CustomerPerson.GetByID( customerPersonID );
			}
		}

		public User AssignedToUser
		{
			get
			{
				return User.GetBySamName( assignedToUserSamName );
			}
		}

		public TicketEventContactType ContactType
		{
			get
			{
				return contactType;
			}
			set
			{
				contactType = value;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		/// <summary>
		/// The state of the ticket/event.
		/// </summary>
		public enum TicketEventState
		{
			/// <summary>
			/// Ticket is open.
			/// </summary>
			[Description("Open")]
			Open,

			/// <summary>
			/// Ticket is closed and was resolved.
			/// </summary>
			[Description("Closed as resolved")]
			ClosedResolved,

			/// <summary>
			/// Ticket is closed and was not resolved.
			/// </summary>
			[Description( "Closed as unresolved" )]
			ClosedUnresolved,

			/// <summary>
			/// Ticket is closed and the solution was postponed.
			/// </summary>
			[Description( "Closed as postponed" )]
			ClosedPostponed
		}

		/// <summary>
		/// How the contact was established for the ticket/event.
		/// </summary>
		public enum TicketEventContactType
		{
			/// <summary>
			/// Contacted by phone.
			/// </summary>
			[Description( "By phone" )]
			ByPhone,

			/// <summary>
			/// Contacted by e-mail.
			/// </summary>
			[Description( "By e-mail" )]
			ByEMail,

			/// <summary>
			/// Contacted otherwise.
			/// </summary>
			[Description( "Otherwise" )]
			Other,

			/// <summary>
			/// Contected by letter.
			/// </summary>
			[Description( "By letter" )]
			ByLetter,

			/// <summary>
			/// Contacted personally.
			/// </summary>
			[Description( "Personally" )]
			Personally
		}

		private int ticketID;
		private string description;
		private TicketEventState state = TicketEventState.Open;
		private TicketEventContactType contactType = TicketEventContactType.ByEMail;
		private string assignedToUserSamName = User.CurrentUser.SamName;
		private DateTime eventDate = DateTime.Now;
		private int duration;
		private int customerPersonID;
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
				DBHelper.ReadField( out ticketID, row["TicketID"] );
				DBHelper.ReadField( out description, row["Description"] );
				DBHelper.ReadField( out eventDate, row["EventDate"] );
				DBHelper.ReadField( out duration, row["Duration"] );
				DBHelper.ReadField( out attachmentFileName, row["AttachmentFileName"] );
				DBHelper.ReadField( out attachmentUserReadableFileName, row["AttachmentUserReadableFileName"] );
				DBHelper.ReadField( out attachmentDescription, row["AttachmentDescription"] );
				DBHelper.ReadField( out assignedToUserSamName, row["AssignedToUserSamName"] );
				DBHelper.ReadField( out customerPersonID, row["CustomerPersonID"] );

				string state;
				DBHelper.ReadField( out state, row["State"] );
				this.state = (TicketEventState)Enum.Parse(
					typeof( TicketEventState ),
					state,
					true );

				string contactType;
				DBHelper.ReadField( out contactType, row["ContactType"] );
				this.contactType = (TicketEventContactType)Enum.Parse(
					typeof( TicketEventContactType ),
					contactType,
					true );
			}
		}

		protected override void Store(
			DataRow row )
		{
			base.Store( row );

			if ( row != null )
			{
				row["TicketID"] = DBHelper.WriteField( ticketID );
				row["Description"] = DBHelper.WriteField( description );
				row["EventDate"] = DBHelper.WriteField( eventDate );
				row["Duration"] = DBHelper.WriteField( duration );
				row["State"] = DBHelper.WriteField( state.ToString() );
				row["AssignedToUserSamName"] = DBHelper.WriteField( assignedToUserSamName );
				row["CustomerPersonID"] = DBHelper.WriteField( customerPersonID );
				row["ContactType"] = DBHelper.WriteField( contactType.ToString() );

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

	/// <summary>
	/// Wrapping an TicketEvent.TicketEventState enum value.
	/// </summary>
	public class TicketEventStateWrapper
	{
		#region Public methods.
		// ------------------------------------------------------------------

		public TicketEventStateWrapper(
			TicketEvent.TicketEventState state )
		{
			this.state = state;
		}

		public override int GetHashCode()
		{
			return state.GetHashCode();
		}

		public override bool Equals(
			object obj )
		{
			TicketEventStateWrapper other = obj as TicketEventStateWrapper;
			if ( other == null )
			{
				return false;
			}
			else
			{
				return this.state.Equals( other.state );
			}
		}

		public override string ToString()
		{
			// Get the description.
			return Code.MiscHelper.GetEnumDescription( state );
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		public TicketEvent.TicketEventState State
		{
			get
			{
				return state;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private TicketEvent.TicketEventState state;

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Wrapping an TicketEvent.TicketEventContactType enum value.
	/// </summary>
	public class TicketEventContactTypeWrapper
	{
		#region Public methods.
		// ------------------------------------------------------------------

		public TicketEventContactTypeWrapper(
			TicketEvent.TicketEventContactType contactType )
		{
			this.contactType = contactType;
		}

		public override int GetHashCode()
		{
			return contactType.GetHashCode();
		}

		public override bool Equals(
			object obj )
		{
			TicketEventContactTypeWrapper other = obj as TicketEventContactTypeWrapper;
			if ( other == null )
			{
				return false;
			}
			else
			{
				return this.contactType.Equals( other.contactType );
			}
		}

		public override string ToString()
		{
			// Get the description.
			return Code.MiscHelper.GetEnumDescription( contactType );
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		public TicketEvent.TicketEventContactType ContactType
		{
			get
			{
				return contactType;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private TicketEvent.TicketEventContactType contactType;

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}