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

	/// <summary>
	/// Encapsulates a database object.
	/// </summary>
	public class CustomerCompanySupportContract :
		Base,
		ILockable
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load an object by a given ID.
		/// </summary>
		public static CustomerCompanySupportContract GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerCompanySupportContractByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerCompanySupportContract o = new CustomerCompanySupportContract();
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
		/// Load for the given parent.
		/// </summary>
		public static CustomerCompanySupportContract GetForCustomerCompany(
			CustomerCompany parentObject )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerCompanySupportContractByCustomerCompanyCrmReplicationUniqueID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@CrmReplicationUniqueID", parentObject.CrmReplicationUniqueID )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerCompanySupportContract o = new CustomerCompanySupportContract();
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
		public static CustomerCompanySupportContract[] GetAll()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllCustomerCompanySupportContracts",
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
					CustomerCompanySupportContract o = new CustomerCompanySupportContract();
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
					return (CustomerCompanySupportContract[])result.ToArray(
						typeof( CustomerCompanySupportContract ) );
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
		public CustomerCompanySupportContract()
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
						"GetCustomerCompanySupportContractByID",
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
						"CustomerCompanySupportContracts" );
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
				"DeleteCustomerCompanySupportContractByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			id = 0;
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		public CustomerCompany Company
		{
			get
			{
				return CustomerCompany.GetByCrmReplicationUniqueID( 
					crmReplicationUniqueID );
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

		public DateTime StartDate
		{
			get
			{
				return startDate;
			}
			set
			{
				startDate = value;
			}
		}
 
		public DateTime EndDate
		{
			get
			{
				return endDate;
			}
			set
			{
				endDate = value;
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

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private Guid crmReplicationUniqueID;
		private DateTime startDate;
		private DateTime endDate;
		private string description;
				 
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
				DBHelper.ReadField( out crmReplicationUniqueID, row["CrmReplicationUniqueID"] );
				DBHelper.ReadField( out startDate, row["StartDate"] );
				DBHelper.ReadField( out endDate, row["EndDate"] );
				DBHelper.ReadField( out description, row["Description"] );
			}
		}

		protected override void Store(
			DataRow row )
		{
			base.Store( row );

			if ( row != null )
			{
				row["CrmReplicationUniqueID"] = DBHelper.WriteField( crmReplicationUniqueID );
				row["StartDate"] = DBHelper.WriteField( startDate );
				row["EndDate"] = DBHelper.WriteField( endDate );
				row["Description"] = DBHelper.WriteField( description );
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