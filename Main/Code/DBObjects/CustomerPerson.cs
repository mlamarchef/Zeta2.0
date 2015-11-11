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

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public class CustomerPerson :
		Base,
		ILockable
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load an object by a given ID.
		/// </summary>
		public static CustomerPerson GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerPersonByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerPerson o = new CustomerPerson();
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
		public static CustomerPerson[] GetForCompany(
			CustomerCompany parentObject )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetCustomerPersonByCustomerCompanyID",
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
					CustomerPerson o = new CustomerPerson();
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
					return (CustomerPerson[])result.ToArray(
						typeof( CustomerPerson ) );
				}
			}
		}

		public static CustomerPerson GetByCrmReplicationUniqueID(
			Guid crmReplicationUniqueID )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerPersonByCrmReplicationUniqueID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CrmReplicationUniqueID", crmReplicationUniqueID )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerPerson o = new CustomerPerson();
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

		public static CustomerPerson GetForCrmPerson(
			Crm.CrmPerson crmPerson )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerPersonFromCrmPerson",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@PersonID", crmPerson.ID )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerPerson o = new CustomerPerson();
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
		public CustomerPerson()
		{
		}

		/// <summary>
		/// Use this version for displaying in lists etc.
		/// </summary>
		public override string ToString()
		{
			return string.Format(
				"{0}, {1}",
				lastName,
				firstName ).Replace( "  ", " " );
		}

		public void Store()
		{
			using ( AdoNetSqlUpdater upd = new AdoNetSqlUpdater(
						"GetCustomerPersonByID",
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
						"CustomerPersons" );
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
				"DeleteCustomerPersonByID",
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

				sb.AppendFormat( "{0}\r\n", this.Title );
				sb.AppendFormat( "{0}, {1}\r\n", this.LastName, this.FirstName );
				sb.AppendFormat( "{0}\r\n", this.Department );
				sb.AppendFormat( "{0}\r\n", this.Position );
				sb.AppendFormat( "{0}\r\n", this.Address1 );
				sb.AppendFormat( "{0}\r\n", this.Address2 );
				sb.AppendFormat( "{0}\r\n", this.EMail );
				sb.AppendFormat( "{0} {1}\r\n", this.Zip, this.City );

				return TrimAndRemoveEmptyLines( sb.ToString() );
			}
		}

		/// <summary>
		/// Get the image key, depending on the state.
		/// </summary>
		public string SmallImageKey
		{
			get
			{
				return "PersonCard.gif";
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
					"{0} {1} {2}",
					this.Salutation,
					this.FirstName,
					this.LastName ).Trim();
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
				vcard.Name = string.Format(
					"{0}, {1}",
					this.LastName,
					this.FirstName ).Trim();
				vcard.PreferedInternetEmailAddress = this.EMail;

				CustomerCompany company = Company;
				if ( company == null )
				{
					vcard.Organization = string.Empty;
				}
				else
				{
					vcard.Organization = company.VCard.FullName;
				}

				return vcard;
			}
		}

		public int CompanyID
		{
			get
			{
				return companyID;
			}
			set
			{
				companyID = value;
			}
		}

		public string Salutation
		{
			get
			{
				switch ( Gender )
				{
					case GenderType.Female:
						return "Ms.";
					case GenderType.Male:
						return "Mr.";
					default:
						return string.Empty;
				}
			}
		}

		public string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				lastName = value;
			}
		}

		public GenderType Gender
		{
			get
			{
				return gender;
			}
			set
			{
				gender = value;
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

		public CustomerCompany Company
		{
			get
			{
				return CustomerCompany.GetByID( companyID );
			}
		}

		public string Department
		{
			get
			{
				return department;
			}
			set
			{
				department = value;
			}
		}

		public string Position
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
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

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		public enum GenderType
		{
			Unknown,
			Female,
			Male
		}

		private int companyID;
		private string firstName;
		private string lastName;
		private string address1;
		private string address2;
		private GenderType gender = GenderType.Unknown;
		private string zip;
		private string city;
		private string country;
		private string state;
		private string phone;
		private string fax;
		private string mobile;
		private string email;
		private string www;
		private string title;
		private string department;
		private string position;
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
				DBHelper.ReadField( out companyID, row["CompanyID"] );
				DBHelper.ReadField( out firstName, row["FirstName"] );
				DBHelper.ReadField( out lastName, row["LastName"] );
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
				DBHelper.ReadField( out title, row["Title"] );
				DBHelper.ReadField( out department, row["Department"] );
				DBHelper.ReadField( out position, row["Position"] );
				DBHelper.ReadField( out crmReplicationUniqueID, row["crmReplicationUniqueID"] );

				string gender;
				DBHelper.ReadField( out gender, row["Gender"] );

				this.gender = (GenderType)Enum.Parse(
					typeof( GenderType ),
					gender,
					true );
			}
		}

		protected override void Store(
			DataRow row )
		{
			base.Store( row );

			if ( row != null )
			{
				row["CompanyID"] = DBHelper.WriteField( companyID );
				row["FirstName"] = DBHelper.WriteField( firstName );
				row["LastName"] = DBHelper.WriteField( lastName );
				row["Gender"] = DBHelper.WriteField( gender.ToString() );
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
				row["title"] = DBHelper.WriteField( title );
				row["Department"] = DBHelper.WriteField( department );
				row["Position"] = DBHelper.WriteField( position );
				row["crmReplicationUniqueID"] = DBHelper.WriteField( crmReplicationUniqueID );
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