namespace ZetaHelpDesk.Main.Code.DBObjects
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Data;
	using System.Data.OleDb;
	using System.Collections;
	using System.Collections.Generic;
	using System.Text;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public class User :
		Base,
		ILockable
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Returns the currently logged on user or null if none logged on.
		/// </summary>
		public static User CurrentUser
		{
			get
			{
				return currentUser;
			}
			set
			{
				currentUser = value;
			}
		}

		private static User currentUser = null;

		public static User GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetUserByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				User o = new User();
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

		public static User GetByUserNameAndPassword(
			string samName,
			string password )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetUserBySamNameAndPassword",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@SamName", samName ),
				AdoNetSqlParamCollection.CreateParameter( "@Password", password )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				User o = new User();
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

		public static User GetByDomainNameAndSamName(
			string domainName,
			string samName )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetUserByDomainNameAndSamName",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@SamName", samName ),
				AdoNetSqlParamCollection.CreateParameter( "@DomainName", domainName )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				User o = new User();
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

		public static User GetByRow(
			DataRow row )
		{
			User o = new User();
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

		public static User GetBySamName(
			string samName )
		{
			if ( string.IsNullOrEmpty( samName ) )
			{
				return null;
			}
			else
			{
				DataRow row = AdoNetSqlHelper.ExecuteRow(
					"GetUserBySamName",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@SamName", samName )
					) );

				if ( row == null )
				{
					return null;
				}
				else
				{
					User o = new User();
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
		}

		public static User GetByEMail(
			string emailAddress )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetUserByEMailAddress",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@EMailAddress", emailAddress )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				User o = new User();
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
		public static User[] GetAll()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllUsers",
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
					User o = new User();
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
					return (User[])result.ToArray(
						typeof( User ) );
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Use this version for displaying in lists etc.
		/// </summary>
		public override string ToString()
		{
			return string.Format(
				"{0}, {1}",
				lastName,
				firstName );
		}

		public void Store()
		{
			using ( AdoNetSqlUpdater upd = new AdoNetSqlUpdater(
						"GetUserByID",
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
						"Users" );
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
				"DeleteUserByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			id = 0;
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------
		
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

		public string SamName
		{
			get
			{
				return samName;
			}
			set
			{
				samName = value;
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
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

		public string DomainName
		{
			get
			{
				return domainName;
			}
			set
			{
				domainName = value;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private methods.
		// ------------------------------------------------------------------

		protected override void Load(
			DataRow row )
		{
			base.Load( row );

			DBHelper.ReadField( out firstName, row["FirstName"] );
			DBHelper.ReadField( out lastName, row["LastName"] );
			DBHelper.ReadField( out samName, row["SamName"] );
			DBHelper.ReadField( out password, row["Password"] );
			DBHelper.ReadField( out email, row["EMail"] );
			DBHelper.ReadField( out domainName, row["DomainName"] );
		}

		protected override void Store(
			DataRow row )
		{
			base.Store( row );

			if ( row != null )
			{
				row["FirstName"] = DBHelper.WriteField( firstName );
				row["LastName"] = DBHelper.WriteField( lastName );
				row["SamName"] = DBHelper.WriteField( samName );
				row["Password"] = DBHelper.WriteField( password );
				row["EMail"] = DBHelper.WriteField( email );
				row["DomainName"] = DBHelper.WriteField( domainName );
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private string firstName;
		private string lastName;
		private string samName;
		private string password;
		private string email;
		private string domainName;

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