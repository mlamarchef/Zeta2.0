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

	public class CrmPerson : 
		Base
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load an object by a given ID.
		/// </summary>
		public static CrmPerson GetByID(
			string id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCrmPersonByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CrmPerson o = new CrmPerson();
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
		public static CrmPerson[] GetForAddress(
			CrmAddress parentObject )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetCrmPersonByCrmAddressID",
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
					CrmPerson o = new CrmPerson();
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
					return (CrmPerson[])result.ToArray(
						typeof( CrmPerson ) );
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
		public CrmPerson()
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

		public override bool IsEmpty
		{
			get
			{
				return string.IsNullOrEmpty( this.id );
			}
		}

		/// <summary>
		/// Either adds new or updates existing.
		/// </summary>
		public CrmAddress.ReplicationResult ReplicateToHelpDesk()
		{
			if ( ExistsInHelpDesk )
			{
				UpdateExistingCrmToHelpDesk();
				return CrmAddress.ReplicationResult.UpdatedExisting;
			}
			else
			{
				AddNewCrmToHelpDesk();
				return CrmAddress.ReplicationResult.AddedNew;
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
		/// Get the corresponding person, if any.
		/// </summary>
		public CustomerPerson HelpDeskCompany
		{
			get
			{
				return CustomerPerson.GetForCrmPerson( this );
			}
		}

		public string DetailedInformation
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.AppendFormat( "{0}\r\n", this.Title );
				sb.AppendFormat( "{0}, {1}\r\n", this.LastName, this.FirstName );
				sb.AppendFormat( "{0}\r\n", this.Department );
				sb.AppendFormat( "{0}\r\n", this.Position );
				sb.AppendFormat( "{0}\r\n", this.EMail );
				sb.AppendFormat( "{0}\r\n", this.Remarks );

				return TrimAndRemoveEmptyLines( sb.ToString() );
			}
		}

		public new string ID
		{
			get
			{
				return this.id;
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

		public int ParentID
		{
			get
			{
				return parentID;
			}
		}

		public string FirstName
		{
			get
			{
				return firstName;
			}
		}

		public string LastName
		{
			get
			{
				return lastName;
			}
		}

		public CustomerPerson.GenderType Gender
		{
			get
			{
				return gender;
			}
		}

		public string Department
		{
			get
			{
				return department;
			}
		}

		public string Position
		{
			get
			{
				return position;
			}
		}

		public string Phone
		{
			get
			{
				return phone;
			}
		}

		public string EMail
		{
			get
			{
				return email;
			}
		}

		public string Title
		{
			get
			{
				return title;
			}
		}

		public Guid CrmReplicationUniqueID
		{
			get
			{
				return crmReplicationUniqueID;
			}
		}

		public CrmAddress Parent
		{
			get
			{
				return CrmAddress.GetByID( ParentID );
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private new string id;
		private int parentID;
		private string firstName;
		private string lastName;
		private string department;
		private string position;
		private CustomerPerson.GenderType gender = CustomerPerson.GenderType.Unknown;
		private string phone;
		private string email;
		private string title;
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
				DBHelper.ReadField( out id, row["ID"] );
				DBHelper.ReadField( out parentID, row["ParentID"] );
				DBHelper.ReadField( out firstName, row["Vorname"] );
				DBHelper.ReadField( out lastName, row["Nachname"] );
				DBHelper.ReadField( out department, row["Abteilung"] );
				DBHelper.ReadField( out position, row["Position"] );
				DBHelper.ReadField( out phone, row["Telefon"] );
				DBHelper.ReadField( out email, row["EMail"] );
				DBHelper.ReadField( out title, row["Titel"] );
				DBHelper.ReadField( out crmReplicationUniqueID, row["CrmReplicationUniqueID"] );

				string gender;
				DBHelper.ReadField( out gender, row["Geschlecht"] );

				this.gender = (CustomerPerson.GenderType)Enum.Parse(
					typeof( CustomerPerson.GenderType ),
					gender,
					true );
			}
		}

		/// <summary>
		/// Add non-existing person to ZetaHelpDesk.
		/// </summary>
		private void AddNewCrmToHelpDesk()
		{
			AdoNetSqlHelper.ExecuteNonQuery(
				"AddNewCrmPersonAsCustomerPerson",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CrmPersonReplicationUniqueID", this.CrmReplicationUniqueID ) ) );
		}

		/// <summary>
		/// Update an existing person in ZetaHelpDesk.
		/// </summary>
		private void UpdateExistingCrmToHelpDesk()
		{
			AdoNetSqlHelper.ExecuteNonQuery(
				"UpdateExistingCrmPersonAsCustomerPerson",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CrmPersonReplicationUniqueID", this.CrmReplicationUniqueID ) ) );
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}