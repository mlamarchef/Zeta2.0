namespace ZetaHelpDesk.Main.Code.DBObjects
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Data;
	using System.Data.OleDb;
	using System.Collections.Generic;
	using System.Text;
	using System.Collections;
	using System.Collections.Specialized;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;
	using System.Diagnostics;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////
	
	public class CustomerCompany :
		Base,
		ILockable	
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load all.
		/// </summary>
		public static CustomerCompany[] GetCustomersWithUnbilledBillableTickets(
			DateTime forMonth )
		{
			DateTime startDate = new DateTime( forMonth.Year, forMonth.Month, 1 );
			DateTime endDate = startDate.AddMonths( 1 );

			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllCustomerCompaniesWithUnbilledBillableTickets",
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
					CustomerCompany o = new CustomerCompany();
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
					return (CustomerCompany[])result.ToArray(
						typeof( CustomerCompany ) );
				}
			}
		}

		public static CustomerCompany GetByCrmReplicationUniqueID(
			Guid crmReplicationUniqueID )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerCompanyByCrmReplicationUniqueID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CrmReplicationUniqueID", crmReplicationUniqueID )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerCompany o = new CustomerCompany();
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
		/// Load an object by a given ID.
		/// </summary>
		public static CustomerCompany GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerCompanyByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerCompany o = new CustomerCompany();
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
		/// Load all.
		/// </summary>
		public static CustomerCompany[] GetAll()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllCustomerCompanies",
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
					CustomerCompany o = new CustomerCompany();
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
					return (CustomerCompany[])result.ToArray(
						typeof( CustomerCompany ) );
				}
			}
		}

		/// <summary>
		/// Load all that have a ticket associated.
		/// </summary>
		public static CustomerCompany[] GetAllWithTickets()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllCustomerCompaniesWithTickets",
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
					CustomerCompany o = new CustomerCompany();
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
					return (CustomerCompany[])result.ToArray(
						typeof( CustomerCompany ) );
				}
			}
		}

		/// <summary>
		/// Defines how the query for customers is driven.
		/// </summary>
		public enum CustomerCompanyGetType
		{
			/// <summary>
			/// Return all customers.
			/// </summary>
			AllCustomers,

			/// <summary>
			/// Return only customers that have one or more tickets associated.
			/// </summary>
			CustomersWithTickets,

			/// <summary>
			/// Return only customers that have one or more tickets associated.
			/// Only for which the current user has tickets.
			/// </summary>
			CustomersWithTicketsForOwn
		}

		/// <summary>
		/// Multiple information about a query for customer companies.
		/// </summary>
		[Serializable]
		public class CustomerCompanyGetInformation
		{
			public CustomerCompanyGetType CustomerGetType = 
				CustomerCompanyGetType.CustomersWithTickets;

			public bool IsFilterTextActive;
			public string FilterText;

			public StringCollection PastFilterTexts = new StringCollection();

			public string UserSamName =
				User.CurrentUser == null ? string.Empty : User.CurrentUser.SamName;

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
		}

		/// <summary>
		/// Load all that have a ticket associated.
		/// </summary>
		/// <param name="getInfo"></param>
		public static CustomerCompany[] Get(
			CustomerCompanyGetInformation getInfo )
		{
			DataTable table = null;

			if ( getInfo.CustomerGetType == 
				CustomerCompanyGetType.CustomersWithTickets )
			{
				table = AdoNetSqlHelper.ExecuteTable(
					"GetAllCustomerCompaniesWithTickets",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@FilterText", getInfo.IsFilterTextActive?getInfo.FilterText:string.Empty )
					) );
			}
			else if ( getInfo.CustomerGetType ==
				CustomerCompanyGetType.CustomersWithTicketsForOwn )
			{
				table = AdoNetSqlHelper.ExecuteTable(
					"GetAllCustomerCompaniesWithTickets",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@FilterText", getInfo.IsFilterTextActive ? getInfo.FilterText : string.Empty ),
					AdoNetSqlParamCollection.CreateParameter( "@UserSamName", getInfo.UserSamName )
					) );
			}
			else if ( getInfo.CustomerGetType ==
				CustomerCompanyGetType.AllCustomers )
			{
				table = AdoNetSqlHelper.ExecuteTable(
					"GetAllCustomerCompanies",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@FilterText",
					getInfo.IsFilterTextActive ? getInfo.FilterText : string.Empty )
					) );
			}
			else
			{
				Debug.Assert( false );
			}

			if ( table == null )
			{
				return null;
			}
			else
			{
				ArrayList result = new ArrayList();

				foreach ( DataRow row in table.Rows )
				{
					CustomerCompany o = new CustomerCompany();
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
					return (CustomerCompany[])result.ToArray(
						typeof( CustomerCompany ) );
				}
			}
		}

		public static CustomerCompany GetForCrmAddress( 
			Crm.CrmAddress crmAddress )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerCompanyFromCrmAddress",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@AddressID", crmAddress.ID )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerCompany o = new CustomerCompany();
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

		// ------------------------------------------------------------------
		#endregion

		#region Public methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		public CustomerCompany()
		{
		}

		/// <summary>
		/// Use this version for displaying in lists etc.
		/// </summary>
		public override string ToString()
		{
			return string.Format(
				"{0} {1}, {2}",
				name1,
				name2,
				city ).Replace( "  ", " " );
		}

		public void Store()
		{
			using ( AdoNetSqlUpdater upd = new AdoNetSqlUpdater(
						"GetCustomerCompanyByID",
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
						"CustomerCompanies" );
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
				"DeleteCustomerCompanyByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			id = 0;
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		public string DetailedInformation
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.AppendFormat( "{0}\r\n", this.Name1 );
				sb.AppendFormat( "{0}\r\n", this.Name2 );
				sb.AppendFormat( "{0}\r\n", this.Address1 );
				sb.AppendFormat( "{0}\r\n", this.Address2 );
				sb.AppendFormat( "{0} {1}\r\n", this.Zip, this.City );
				sb.AppendFormat( "{0}\r\n", this.Country );
				sb.AppendFormat( "{0}\r\n", this.Www );

				return sb.ToString();
			}
		}

		/// <summary>
		/// Export as a v-card.
		/// </summary>
		public VCard VCard
		{
			get
			{
				VCard vcard = new VCard();

				vcard.BusinessFax = this.Fax;
				vcard.BusinessTel = this.Phone;
				vcard.CellTelVoice = this.Mobile;
				vcard.FullName = string.Format(
					"{0} {1}", 
					this.Name1, 
					this.Name2 ).Trim();
				vcard.HomeAddress = string.Format(
					"{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}",
					this.Address1,
					this.Address2,
					this.Zip,
					this.City,
					this.State,
					this.Country ).Trim();
				vcard.HomeTelFax = string.Empty;
				vcard.HomeTelVoice = string.Empty;
				vcard.Name = this.Name1;
				vcard.Organization = this.Name1;
				vcard.PreferedInternetEmailAddress = this.EMail;

				return vcard;
			}
		}

		public CustomerCompanyProperty[] Properties
		{
			get
			{
				return CustomerCompanyProperty.GetForCustomerCompany( this );
			}
		}

		/// <summary>
		/// Get the image key, depending on the state.
		/// </summary>
		public string SmallImageKey
		{
			get
			{
				return "PersonsCard.gif";
			}
		}

		public string Name1
		{
			get
			{
				return name1;
			}
			set
			{
				name1 = value;
			}
		}

		public string Name2
		{
			get
			{
				return name2;
			}
			set
			{
				name2 = value;
			}
		}

		public string Address1
		{
			get
			{
				return address1;
			}
			set
			{
				address1 = value;
			}
		}

		public string Address2
		{
			get
			{
				return address2;
			}
			set
			{
				address2 = value;
			}
		}

		public string Zip
		{
			get
			{
				return zip;
			}
			set
			{
				zip = value;
			}
		}

		public string City
		{
			get
			{
				return city;
			}
			set
			{
				city = value;
			}
		}

		public string Country
		{
			get
			{
				return country;
			}
			set
			{
				country = value;
			}
		}

		public string State
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

		public string Phone
		{
			get
			{
				return phone;
			}
			set
			{
				phone = value;
			}
		}

		public string Fax
		{
			get
			{
				return fax;
			}
			set
			{
				fax = value;
			}
		}

		public string Mobile
		{
			get
			{
				return mobile;
			}
			set
			{
				mobile = value;
			}
		}

		public string EMail
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}

		public string Www
		{
			get
			{
				return www;
			}
			set
			{
				www = value;
			}
		}

		public Guid CrmReplicationUniqueID
		{
			get
			{
				return crmReplicationUniqueID;
			}
			set
			{
				crmReplicationUniqueID = value;
			}
		}

		public CustomerCompanySupportContract SupportContract
		{
			get
			{
				return CustomerCompanySupportContract.GetForCustomerCompany( this );
			}
		}

		public CustomerPerson[] Persons
		{
			get
			{
				return CustomerPerson.GetForCompany( this );
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private string name1;
		private string name2;
		private string address1;
		private string zip;
		private string address2;
		private string city;
		private string country;
		private string state;
		private string phone;
		private string fax;
		private string mobile;
		private string email;
		private string www;
		private Guid crmReplicationUniqueID = Guid.NewGuid();
				 
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
				DBHelper.ReadField( out name1, row["Name1"] );
				DBHelper.ReadField( out name2, row["Name2"] );
				DBHelper.ReadField( out address1, row["Address1"] );
				DBHelper.ReadField( out address2, row["Address2"] );
				DBHelper.ReadField( out zip, row["Zip"] );
				DBHelper.ReadField( out city, row["City"] );
				DBHelper.ReadField( out country, row["Country"] );
				DBHelper.ReadField( out state, row["State"] );
				DBHelper.ReadField( out phone, row["Phone"] );
				DBHelper.ReadField( out fax, row["Fax"] );
				DBHelper.ReadField( out mobile, row["Mobile"] );
				DBHelper.ReadField( out email, row["EMail"] );
				DBHelper.ReadField( out www, row["Www"] );
				DBHelper.ReadField( out crmReplicationUniqueID, row["crmReplicationUniqueID"] );
			}
		}

		protected override void Store(
			DataRow row )
		{
			base.Store( row );

			if ( row != null )
			{
				row["Name1"] = DBHelper.WriteField( name1 );
				row["Name2"] = DBHelper.WriteField( name2 );
				row["Address1"] = DBHelper.WriteField( address1 );
				row["Address2"] = DBHelper.WriteField( address2 );
				row["Zip"] = DBHelper.WriteField( zip );
				row["City"] = DBHelper.WriteField( city );
				row["Country"] = DBHelper.WriteField( country );
				row["State"] = DBHelper.WriteField( state );
				row["Phone"] = DBHelper.WriteField( phone );
				row["Fax"] = DBHelper.WriteField( fax );
				row["Mobile"] = DBHelper.WriteField( mobile );
				row["EMail"] = DBHelper.WriteField( email );
				row["Www"] = DBHelper.WriteField( www );
				row["crmReplicationUniqueID"] = DBHelper.WriteField( crmReplicationUniqueID );
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
