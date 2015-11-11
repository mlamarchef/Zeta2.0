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

	public class CustomerCompanyProperty :
		Base,
		ILockable
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load an object by a given ID.
		/// </summary>
		public static CustomerCompanyProperty GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerCompanyPropertyByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerCompanyProperty o = new CustomerCompanyProperty();
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
		/// Load an object by a given symbolic name.
		/// </summary>
		public static CustomerCompanyProperty GetBySymbolicName(
			string symbolicName )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCustomerCompanyPropertyBySymbolicName",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@SymbolicName", symbolicName )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CustomerCompanyProperty o = new CustomerCompanyProperty();
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
		public static CustomerCompanyProperty[] GetForCustomerCompany(
			CustomerCompany parentObject )
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetCustomerCompanyPropertyByCustomerCompanyID",
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
					CustomerCompanyProperty o = new CustomerCompanyProperty();
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
					return (CustomerCompanyProperty[])result.ToArray(
						typeof( CustomerCompanyProperty ) );
				}
			}
		}

		/// <summary>
		/// Load all.
		/// </summary>
		public static CustomerCompanyProperty[] GetAll()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllCustomerCompanyProperties",
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
					CustomerCompanyProperty o = new CustomerCompanyProperty();
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
					return (CustomerCompanyProperty[])result.ToArray(
						typeof( CustomerCompanyProperty ) );
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
		public CustomerCompanyProperty()
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
						"GetCustomerCompanyPropertyByID",
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
						"CustomerCompanyPropertys" );
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
				"DeleteCustomerCompanyPropertyByID",
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
				return CustomerCompany.GetByID( customerCompanyID );
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

		public string SymbolicName
		{
			get
			{
				return symbolicName;
			}
			set
			{
				symbolicName = value;
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

		public string Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}

		public Type DataType
		{
			get
			{
				return dataType;
			}
			set
			{
				dataType = value;
			}
		}

		public int OrderPosition
		{
			get
			{
				return orderPosition;
			}
			set
			{
				orderPosition = value;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return isReadOnly;
			}
			set
			{
				isReadOnly = value;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private int customerCompanyID;
		private string symbolicName;
		private string name;
		private string groupName;
 		private string value;
		private Type dataType;
		private int orderPosition;
		private bool isReadOnly;
				 
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
				DBHelper.ReadField( out symbolicName, row["SymbolicName"] );
				DBHelper.ReadField( out name, row["Name"] );
				DBHelper.ReadField( out groupName, row["GroupName"] );
				DBHelper.ReadField( out value, row["Value"] );
				DBHelper.ReadField( out orderPosition, row["OrderPosition"] );
				DBHelper.ReadField( out isReadOnly, row["IsReadOnly"] );

				string dataType;
				DBHelper.ReadField( out dataType, row["DataType"] );

				if ( string.IsNullOrEmpty( dataType ) )
				{
					this.dataType = typeof( string );
				}
				else
				{
					this.dataType = Type.GetType( dataType, true, true );
				}
			}
		}

		protected override void Store(
			DataRow row )
		{
			base.Store( row );

			if ( row != null )
			{
				row["CustomerCompanyID"] = DBHelper.WriteField( customerCompanyID );
				row["SymbolicName"] = DBHelper.WriteField( symbolicName );
				row["Name"] = DBHelper.WriteField( name );
				row["GroupName"] = DBHelper.WriteField( groupName );
				row["Value"] = DBHelper.WriteField( value );
				row["OrderPosition"] = DBHelper.WriteField( orderPosition );
				row["IsReadOnly"] = DBHelper.WriteField( isReadOnly );
				row["DataType"] = DBHelper.WriteField( dataType.ToString() );
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

	/////////////////////////////////////////////////////////////////////////////
}