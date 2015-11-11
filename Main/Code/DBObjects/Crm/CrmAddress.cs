namespace ZetaHelpDesk.Main.Code.DBObjects.Crm
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

	public class CrmAddress : 
		Base
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Add non-existing and update existing companies and persons.
		/// </summary>
		public static void ReplicateAllAddressesAndPersonsToHelpDesk()
		{
			AddNewCrmAllNewAddressesAndPersons();
			UpdateCrmAllExistingAddressesAndPersons();
		}

		/// <summary>
		/// Add non-existing companies and persons.
		/// </summary>
		private static void AddNewCrmAllNewAddressesAndPersons()
		{
			AdoNetSqlHelper.ExecuteNonQuery(
				"AddNewCrmAllNewAddressesAndPersons",
				new AdoNetSqlParamCollection() );
		}

		/// <summary>
		/// Update all existing companies and persons.
		/// </summary>
		private static void UpdateCrmAllExistingAddressesAndPersons()
		{
			AdoNetSqlHelper.ExecuteNonQuery(
				"UpdateExistingCrmAllAddressesAndPersons",
				new AdoNetSqlParamCollection() );
		}

		public static CrmAddress GetByCrmReplicationUniqueID(
			Guid crmReplicationUniqueID )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCrmAddressByCrmReplicationUniqueID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CrmReplicationUniqueID", crmReplicationUniqueID )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CrmAddress o = new CrmAddress();
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
		public static CrmAddress GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCrmAddressByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CrmAddress o = new CrmAddress();
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
		public static CrmAddress[] GetAll()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllCrmAddresses",
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
					CrmAddress o = new CrmAddress();
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
					return (CrmAddress[])result.ToArray(
						typeof( CrmAddress ) );
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
		public CrmAddress()
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

		/// <summary>
		/// The result of a replication.
		/// </summary>
		public enum ReplicationResult
		{
			/// <summary>
			/// Updated an existing item.
			/// </summary>
			UpdatedExisting,

			/// <summary>
			/// Added a new item.
			/// </summary>
			AddedNew
		}

		/// <summary>
		/// Either adds new or updates existing.
		/// </summary>
		public ReplicationResult ReplicateToHelpDesk()
		{
			if ( ExistsInHelpDesk )
			{
				UpdateExistingCrmToHelpDesk();
				return ReplicationResult.UpdatedExisting;
			}
			else
			{
				AddNewCrmToHelpDesk();
				return ReplicationResult.AddedNew;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		/// <summary>
		/// Check whether a corresponding record exists.
		/// </summary>
		public bool ExistsInHelpDesk
		{
			get
			{
				return HelpDeskCompany != null;
			}
		}

		/// <summary>
		/// Get the corresponding company, if any.
		/// </summary>
		public CustomerCompany HelpDeskCompany
		{
			get
			{
				return CustomerCompany.GetForCrmAddress( this );
			}
		}

		public string DetailedInformation
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.AppendFormat( "{0}\r\n", this.Name1 );
				sb.AppendFormat( "{0}\r\n", this.Name2 );
				sb.AppendFormat( "{0}\r\n", this.Address1 );
				sb.AppendFormat( "{0} {1}\r\n", this.Zip, this.City );
				sb.AppendFormat( "{0}\r\n", this.Country );
				sb.AppendFormat( "{0}\r\n", this.Www );

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
				return "PersonsCard.gif";
			}
		}

		public string Name1
		{
			get
			{
				return name1;
			}
		}

		public string Name2
		{
			get
			{
				return name2;
			}
		}

		public string Address1
		{
			get
			{
				return address1;
			}
		}

		public string Zip
		{
			get
			{
				return zip;
			}
		}

		public string City
		{
			get
			{
				return city;
			}
		}

		public string Country
		{
			get
			{
				return country;
			}
		}

		public string Phone
		{
			get
			{
				return phone;
			}
		}

		public string Fax
		{
			get
			{
				return fax;
			}
		}

		public string Mobile
		{
			get
			{
				return mobile;
			}
		}

		public string EMail
		{
			get
			{
				return email;
			}
		}

		public string Www
		{
			get
			{
				return www;
			}
		}

		public Guid CrmReplicationUniqueID
		{
			get
			{
				return crmReplicationUniqueID;
			}
		}

		public CrmPerson[] Persons
		{
			get
			{
				return CrmPerson.GetForAddress( this );
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
		private string city;
		private string country;
		private string phone;
		private string fax;
		private string mobile;
		private string email;
		private string www;
		private Guid crmReplicationUniqueID;

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
				DBHelper.ReadField( out address1, row["Strasse"] );
				DBHelper.ReadField( out zip, row["PLZ"] );
				DBHelper.ReadField( out city, row["Ort"] );
				DBHelper.ReadField( out country, row["Land"] );
				DBHelper.ReadField( out phone, row["Telefon"] );
				DBHelper.ReadField( out fax, row["Fax"] );
				DBHelper.ReadField( out mobile, row["TelefonMobil"] );
				DBHelper.ReadField( out email, row["EMail1"] );
				DBHelper.ReadField( out www, row["Website"] );
				DBHelper.ReadField( out crmReplicationUniqueID, row["CrmReplicationUniqueID"] );
			}
		}

		/// <summary>
		/// Add non-existing company to ZetaHelpDesk.
		/// </summary>
		private void AddNewCrmToHelpDesk()
		{
			AdoNetSqlHelper.ExecuteNonQuery(
				"AddNewCrmAddressAsCustomerCompany",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CrmAddressReplicationUniqueID", this.CrmReplicationUniqueID ) ) );
		}

		/// <summary>
		/// Update an existing company in ZetaHelpDesk.
		/// </summary>
		private void UpdateExistingCrmToHelpDesk()
		{
			AdoNetSqlHelper.ExecuteNonQuery(
				"UpdateExistingCrmAddressAsCustomerCompany",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CrmAddressReplicationUniqueID", this.CrmReplicationUniqueID ) ) );
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}
