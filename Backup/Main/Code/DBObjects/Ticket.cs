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
	using System.IO;
	using System.Diagnostics;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public class Ticket :
		Base,
		ILockable
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load an object by a given ID.
		/// </summary>
		public static Ticket GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetTicketByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				Ticket o = new Ticket();
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
		/// Get all distinct group names of all tickets of one customer.
		/// </summary>
		public static string[] GetDistinctGroupNamesForCustomerCompany(
			CustomerCompany parentObject )
		{
			int companyID = 0;
			if ( parentObject != null )
			{
				companyID = parentObject.ID;
			}

			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetDistinctGroupNamesByCustomerCompanyID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CustomerCompanyID", companyID )
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
					string v;
					DBHelper.ReadField( out v, row[0] );

					result.Add( v );
				}

				if ( result.Count <= 0 )
				{
					return null;
				}
				else
				{
					return (string[])result.ToArray(
						typeof( string ) );
				}
			}
		}

		/// <summary>
		/// Load all for the given parent.
		/// </summary>
		public static Ticket[] GetUnbilledBillableForCustomerCompany(
			CustomerCompany parentObject,
			DateTime forMonth )
		{
			DateTime startDate = new DateTime( forMonth.Year, forMonth.Month, 1 );
			DateTime endDate = startDate.AddMonths( 1 );

			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetUnbilledBillableTicketsByCustomerCompanyID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CustomerCompanyID", parentObject.ID ),
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
					Ticket o = new Ticket();
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
					return (Ticket[])result.ToArray(
						typeof( Ticket ) );
				}
			}
		}

		/// <summary>
		/// Load all for the given parent.
		/// </summary>
		public static Ticket[] GetForCustomerCompany(
			CustomerCompany parentObject )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetTicketsByCustomerCompanyID",
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
					Ticket o = new Ticket();
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
					return (Ticket[])result.ToArray(
						typeof( Ticket ) );
				}
			}
		}

		/// <summary>
		/// Load all for the given parent.
		/// </summary>
		public static Ticket[] GetForCustomerCompanyAssignedToUser(
			CustomerCompany parentObject,
			User user )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetTicketsForCustomerCompanyAssignedToUser",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", parentObject.ID ),
				AdoNetSqlParamCollection.CreateParameter( "@UserSamName", user.SamName )
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
					Ticket o = new Ticket();
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
					return (Ticket[])result.ToArray(
						typeof( Ticket ) );
				}
			}
		}

		/// <summary>
		/// Load all for the given parent.
		/// </summary>
		public static Ticket[] GetForCustomerPerson(
			CustomerPerson parentObject )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"SELECT * FROM [Tickets] WHERE [CustomerPersonID]=@ID",
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
					Ticket o = new Ticket();
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
					return (Ticket[])result.ToArray(
						typeof( Ticket ) );
				}
			}
		}

		/// <summary>
		/// Load all.
		/// </summary>
		public static Ticket[] GetAll()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllTickets",
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
					Ticket o = new Ticket();
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
					return (Ticket[])result.ToArray(
						typeof( Ticket ) );
				}
			}
		}

		public static Ticket[] GetAssignedToUser(
			User user )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetTicketsAssignedToUserSamName",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@UserSamName", user.SamName )
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
					Ticket o = new Ticket();
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
					return (Ticket[])result.ToArray(
						typeof( Ticket ) );
				}
			}
		}

		public static Ticket[] GetAssignedToUser(
			User user,
			TicketEvent.TicketEventState state )
		{
			if ( user == null )
			{
				return null;
			}
			else
			{
				DataTable table = AdoNetSqlHelper.ExecuteTable(
					"GetTicketsAssignedToUserSamNameWithState",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@UserSamName", user.SamName ),
					AdoNetSqlParamCollection.CreateParameter( "@State", state.ToString() )
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
						Ticket o = new Ticket();
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
						return (Ticket[])result.ToArray(
							typeof( Ticket ) );
					}
				}
			}
		}

		/// <summary>
		/// Defines how a query for tickets is executed.
		/// </summary>
		public enum TicketOwnerGetType
		{
			/// <summary>
			/// All tickets are returnes.
			/// </summary>
			AllTickets,

			/// <summary>
			/// Tickets for a given user are returned.
			/// </summary>
			OwnTickets
		}

		/// <summary>
		/// Defines how a query for tickets is executed.
		/// </summary>
		public enum TicketStateGetType
		{
			/// <summary>
			/// All tickets are returned.
			/// </summary>
			AllTickets,

			/// <summary>
			/// Only open tickets are returned.
			/// </summary>
			OpenTickets
		}

		/// <summary>
		/// Multiple information about a query for tickets.
		/// </summary>
		[Serializable]
		public class TicketGetInformation
		{
			#region Public variables.

			public TicketOwnerGetType TicketOwnerGetType = 
				TicketOwnerGetType.OwnTickets;

			public TicketStateGetType TicketStateGetType = 
				TicketStateGetType.OpenTickets;

			public bool IsFilterTextActive;
			public string FilterText = null;

			public StringCollection PastFilterTexts = new StringCollection();

			public string UserSamName = 
				User.CurrentUser==null?string.Empty:User.CurrentUser.SamName;

			public int CompanyID = 0;

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

			public CustomerCompany Company
			{
				get
				{
					return CustomerCompany.GetByID( CompanyID );
				}
				set
				{
					if ( value == null || value.IsEmpty )
					{
						CompanyID = 0;
					}
					else
					{
						CompanyID = value.ID;
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
		/// Queries for tickets with comlex information.
		/// </summary>
		/// <param name="getInfo"></param>
		/// <returns></returns>
		public static Ticket[] Get(
			TicketGetInformation getInfo )
		{
			getInfo.Normalize();

			DataTable table = table = AdoNetSqlHelper.ExecuteTable(
				"GetTicketsByInfo",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CustomerCompanyID", getInfo.Company.ID ),
				AdoNetSqlParamCollection.CreateParameter( "@OwnerType", getInfo.TicketOwnerGetType.ToString() ),
				AdoNetSqlParamCollection.CreateParameter( "@StateType", getInfo.TicketStateGetType.ToString() ),
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
					Ticket o = new Ticket();
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
					return (Ticket[])result.ToArray(
						typeof( Ticket ) );
				}
			}
		}

		public static Ticket[] SearchSimple(
			string searchText )
		{
			DataTable table = table = AdoNetSqlHelper.ExecuteTable(
				"SearchSimpleForTickets",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@SearchText", searchText )
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
					Ticket o = new Ticket();
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
					return (Ticket[])result.ToArray(
						typeof( Ticket ) );
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
		public Ticket()
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
						"GetTicketByID",
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
						"Tickets" );
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
				"DeleteTicketByID",
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

			sb.AppendFormat( "<tr><th nowrap>Title</th><td width='100%'><b>{0}</b></td></tr>\r\n", this.Title );
			sb.AppendFormat( "<tr><th nowrap>State</th><td width='100%'>{0}</td></tr>\r\n", Code.MiscHelper.GetEnumDescription( this.State ) );
			sb.AppendFormat( "<tr><th nowrap>Group</th><td width='100%'>{0}</td></tr>\r\n", this.GroupName );
			sb.AppendFormat( "<tr><th nowrap>Date created</th><td width='100%'>{0}</td></tr>\r\n", this.DateCreated.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Date closed</th><td width='100%'>{0}</td></tr>\r\n", this.TicketClosedDate==DateTime.MinValue?string.Empty:this.TicketClosedDate.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Open duration</th><td width='100%'>{0}</td></tr>\r\n", this.OpenDurationTimeSpan.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Customer company</th><td width='100%'>{0}</td></tr>\r\n", this.CustomerCompany == null ? string.Empty : this.CustomerCompany.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Customer person</th><td width='100%'>{0}</td></tr>\r\n", this.CustomerPerson == null ? string.Empty : this.CustomerPerson.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Event duration</th><td width='100%'>{0}</td></tr>\r\n", this.EventDurationTimeSpan.ToString() );
			sb.AppendFormat( "<tr><th nowrap># of events</th><td width='100%'>{0}</td></tr>\r\n", this.EventCount.ToString() );
			sb.AppendFormat( "<tr><th nowrap>Assigned to</th><td width='100%'>{0}</td></tr>\r\n", this.AssignedToUser.ToString() );

			sb.AppendFormat( "<tr><td colspan=2>{0} &nbsp;</td></tr>\r\n",
				HtmlHelper.FormatMultiLine( this.Description ) );

			sb.AppendFormat( "</table></p>" );


			// --
			// The ticket events.

			TicketEvent[] ticketEvents = Events;

			sb.AppendFormat( "<h2>Ticket Events</h2>\r\n" );

			if ( ticketEvents == null )
			{
				sb.AppendFormat( "<p>The ticket contains no events.</p>\r\n" );
			}
			else
			{
				int index = 0;
				foreach ( TicketEvent ticketEvent in ticketEvents )
				{
					sb.AppendFormat( "<p><b>Ticket number {0}:</b><br /><table class=dataTicketEvent width='100%'>",
						index+1 );

					sb.AppendFormat( "<tr><th nowrap>Date</th><td width='100%'>{0}</td></tr>\r\n", ticketEvent.EventDate.ToString() );
					sb.AppendFormat( "<tr><th nowrap>Duration</th><td>{0}</td></tr>\r\n", ticketEvent.DurationTimeSpan.ToString() );
					sb.AppendFormat( "<tr><th nowrap>Contact type</th><td>{0}</td></tr>\r\n", Code.MiscHelper.GetEnumDescription( ticketEvent.ContactType ));
					sb.AppendFormat( "<tr><th nowrap>Customer person</th><td>{0}</td></tr>\r\n", ticketEvent.CustomerPerson == null ? string.Empty : ticketEvent.CustomerPerson.ToString() );

					if ( ticketEvent.HasAttachment )
					{
						sb.AppendFormat( "<tr><th nowrap>Attachment</th><td>{0}</td></tr>\r\n", ticketEvent.AttachmentUserReadableFileName );
					}

					sb.AppendFormat( "<tr><td colspan=2>{0} &nbsp;</td></tr>\r\n",
						HtmlHelper.FormatMultiLine( ticketEvent.Description.Trim() ) );

					sb.AppendFormat( "</table></p>" );

					index++;
				}
			}

			// --

			return GetPrintingHtmlFramework(
				string.Format(
				"zeta HelpDesk Ticket '{0}'",
				Title ),
				sb.ToString() );
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
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

		public CustomerCompany CustomerCompany
		{
			get
			{
				return CustomerCompany.GetByID( customerCompanyID );
			}
		}

		public CustomerPerson CustomerPerson
		{
			get
			{
				return CustomerPerson.GetByID( customerPersonID );
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

		public TicketEvent[] Events
		{
			get
			{
				return TicketEvent.GetForTicket( this );
			}
		}

		/// <summary>
		/// Get the total time span that this ticket is/was open.
		/// </summary>
		public TimeSpan OpenDurationTimeSpan
		{
			get
			{
				DateTime date1;
				DateTime date2 = dateCreated;

				if ( state == TicketEvent.TicketEventState.ClosedResolved ||
					state == TicketEvent.TicketEventState.ClosedUnresolved )
				{
					date1 = ticketClosedDate;
				}
				else
				{
					// Not yet closed.
					date1 = DateTime.Now;
				}

				// --
				// Remove seconds and miliseconds.

				date1 = date1.AddSeconds( -date1.Second );
				date2 = date2.AddSeconds( -date2.Second );

				date1 = date1.AddMilliseconds( -date1.Millisecond );
				date2 = date2.AddMilliseconds( -date2.Millisecond );

				/*
				date1 = date1.AddTicks( -date1.Ticks );
				date2 = date2.AddTicks( -date2.Ticks );
				*/

				TimeSpan span = date1 - date2;
				TimeSpan ticks = new TimeSpan( span.Ticks % 10000 );

				span = span.Add( -ticks );

				return span;
			}
		}

		public TimeSpan EventDurationTimeSpan
		{
			get
			{
				DateTime one = DateTime.MinValue;
				DateTime two = one.AddMinutes( EventDuration );

				return two - one;
			}
		}

		public DateTime TicketDueDate
		{
			get
			{
				return ticketDueDate.Date;
			}
			set
			{
				ticketDueDate = value.Date;
			}
		}

		/// <summary>
		/// Get the image key, depending on the state.
		/// </summary>
		public string SmallImageKey
		{
			get
			{
				if ( state == TicketEvent.TicketEventState.ClosedResolved )
				{
					return "TicketClosedResolved.gif";
				}
				else if (state == TicketEvent.TicketEventState.ClosedUnresolved )
				{
					return "TicketClosedUnresolved.gif";
				}
				else if ( state == TicketEvent.TicketEventState.ClosedPostponed )
				{
					return "TicketClosedPostponed.gif";
				}
				else if ( state == TicketEvent.TicketEventState.Open )
				{
					if ( ticketDueDate > DateTime.MinValue )
					{
						if ( ticketDueDate <= DateTime.Now )
						{
							return "TicketOpenOvertime.gif";
						}
						else
						{
							return "TicketOpen.gif";
						}
					}
					else
					{
						return "TicketOpen.gif";
					}
				}
				else
				{
					return null;
				}
			}
		}

		public int EventCount
		{
			get
			{
				TicketEvent[] events = Events;

				if ( events == null )
				{
					return 0;
				}
				else
				{
					return events.Length;
				}
			}
		}

		/// <summary>
		/// The total sum of all child events.
		/// </summary>
		public int EventDuration
		{
			get
			{
				object o = AdoNetSqlHelper.ExecuteValue(
					"SELECT SUM([Duration]) FROM [TicketEvents] WHERE [TicketID]=@ID",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@ID", id )
					) );

				if ( o == null )
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32( o );
				}
			}
		}

		public DBObjects.TicketEvent.TicketEventState State
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

		public DateTime TicketClosedDate
		{
			get
			{
				return ticketClosedDate;
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

		public string GroupName
		{
			get
			{
				return groupName;
			}
			set
			{
				groupName = value;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private string title;
		private string description;
		private int customerCompanyID;
		private int customerPersonID;
		private DateTime ticketDueDate = DateTime.MinValue;
		private DateTime ticketClosedDate = DateTime.MinValue;
		private TicketEvent.TicketEventState state = TicketEvent.TicketEventState.Open;
		private string assignedToUserSamName = User.CurrentUser.SamName;
		private bool isBillable = false;
		private bool wasBilled = false;
		private string groupName;

		private TicketEvent.TicketEventState stateAfterLoading = 
			TicketEvent.TicketEventState.Open;

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
				DBHelper.ReadField( out title, row["Title"] );
				DBHelper.ReadField( out description, row["Description"] );
				DBHelper.ReadField( out customerCompanyID, row["CustomerCompanyID"] );
				DBHelper.ReadField( out customerPersonID, row["CustomerPersonID"] );
				DBHelper.ReadField( out ticketClosedDate, row["TicketClosedDate"] );
				DBHelper.ReadField( out ticketDueDate, row["TicketDueDate"] );
				DBHelper.ReadField( out assignedToUserSamName, row["AssignedToUserSamName"] );
				DBHelper.ReadField( out isBillable, row["IsBillable"] );
				DBHelper.ReadField( out wasBilled, row["WasBilled"] );
				DBHelper.ReadField( out groupName, row["GroupName"] );

				string state;
				DBHelper.ReadField( out state, row["State"] );
				this.state = (TicketEvent.TicketEventState)Enum.Parse(
					typeof( TicketEvent.TicketEventState ),
					state,
					true );

				// If "forgot" to set the closed date, set here.
				if ( this.state == TicketEvent.TicketEventState.ClosedResolved ||
					this.state == TicketEvent.TicketEventState.ClosedUnresolved )
				{
					if ( ticketClosedDate == DateTime.MinValue )
					{
						ticketClosedDate = dateModified;
					}
				}

				// Remember to detect a state change on safing.
				stateAfterLoading = this.state;
			}
		}

		protected override void Store(
			DataRow row )
		{
			base.Store( row );

			if ( row != null )
			{
				// Detect a state change to closed.
				if ( (state == TicketEvent.TicketEventState.ClosedResolved ||
					state == TicketEvent.TicketEventState.ClosedUnresolved) &&
					stateAfterLoading==TicketEvent.TicketEventState.Open)
				{
					ticketClosedDate = DateTime.Now;
				}

				row["Title"] = DBHelper.WriteField( title );
				row["Description"] = DBHelper.WriteField( description );
				row["CustomerCompanyID"] = DBHelper.WriteField( customerCompanyID );
				row["CustomerPersonID"] = DBHelper.WriteField( customerPersonID );
				row["TicketClosedDate"] = DBHelper.WriteField( ticketClosedDate );
				row["TicketDueDate"] = DBHelper.WriteField( ticketDueDate );
				row["AssignedToUserSamName"] = DBHelper.WriteField( assignedToUserSamName );
				row["State"] = DBHelper.WriteField( state.ToString() );
				row["AssignedToUserSamName"] = DBHelper.WriteField( assignedToUserSamName );
				row["IsBillable"] = DBHelper.WriteField( isBillable );
				row["WasBilled"] = DBHelper.WriteField( wasBilled );
				row["GroupName"] = DBHelper.WriteField( groupName );
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