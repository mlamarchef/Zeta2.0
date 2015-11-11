namespace ZetaHelpDesk.Main.Code
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Configuration;
	using System.Data;
	using System.Data.OleDb;
	using System.Runtime.InteropServices;
	using System.Xml;

	using ZetaLib.Core.Common; 
	using ZetaLib.Core.Data;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Implement this interface if you want your object to be locked.
	/// </summary>
	public interface ILockable
	{
		#region Interface members.
		// ------------------------------------------------------------------

		/// <summary>
		/// Locks the object. Unlocks in the
		/// </summary>
		/// <returns>Returns a lock guard.</returns>
		LockGuard Lock();

		// ------------------------------------------------------------------
		#endregion
	}
	
	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Raised when trying to lock an already locked object.
	/// </summary>
	public class LockException :
		ApplicationException
	{
		#region Public routines.
		// ------------------------------------------------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		public LockException(
			string lockedByUsername ) :
			base()
		{
			this.lockedByUsername = lockedByUsername;
		}

		/// <summary>
		/// Get the message.
		/// </summary>
		public override string Message
		{
			get
			{
				if ( lockedByUsername == null ||
					lockedByUsername.Length <= 0 )
				{
					return string.Format(
						"You cannot edit this object, because it is currently being edited." );
				}
				else
				{
					return string.Format(
						"You cannot edit this object, because it is currently being edited by the user '{0}'.",
						lockedByUsername );
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private helper.
		// ------------------------------------------------------------------

		private string lockedByUsername = string.Empty;

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// An item to protect an editing section.
	/// </summary>
	public class LockGuard :
		IDisposable
	{
		#region Public member.
		// ------------------------------------------------------------------

		/// <summary>
		/// Constructor. Initializes a locking.
		/// </summary>
		public LockGuard(
			Type objectType,
			int objectID )
		{
			this.objectType = objectType;
			this.objectID = objectID;

			lockDate = DateTime.Now;

			userDomainName = System.Environment.UserDomainName;
			userName = System.Environment.UserName;
			userWorkstationName = System.Environment.MachineName;
			mainWindowHandle = ApplicationConfiguration.Current.MainWindowHandle;

			Lock();
		}

		// ------------------------------------------------------------------
		#endregion

		#region IDisposable member.
		// ------------------------------------------------------------------

		/// <summary>
		/// Pseudo-destructor. Finalizes a locking, releases lock.
		/// </summary>
		public void Dispose()
		{
			Unlock();
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private member.
		// ------------------------------------------------------------------

		private bool IsLocked
		{
			get
			{
				// TODO: Check whether is currently locked.
				return false;
			}
		}

		/// <summary>
		/// Mark as locked. Throws if already locked.
		/// </summary>
		private void Lock()
		{
			if ( true )
			{
				DateTime dt = DateTime.Now.AddSeconds( 
					-ApplicationConfiguration.Current.KeepAliveSeconds * 2 );

				DataRow row = AdoNetSqlHelper.ExecuteRow(
					@"SELECT * 
					FROM [Locks] L 
					WHERE L.[ObjectType]=@ObjectType
					AND L.[ObjectID]=@ObjectID
					AND L.[MainWindowHandle]=
					(
						SELECT [MainWindowHandle] 
						FROM [KeepAlives] K 
						WHERE K.[MainWindowHandle]=L.[MainWindowHandle] 
						AND K.[LastDate]>=@LastDate
					)",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@ObjectType", objectType.FullName ),
					AdoNetSqlParamCollection.CreateParameter( "@ObjectID", objectID ),
					AdoNetSqlParamCollection.CreateParameter( "@LastDate", dt ) ) );

				// Last chance, try window handle if on this machine.
				if ( row!=null )
				{
					string userName;
					string userWorkstationName;
					DBHelper.ReadField( out userName, row["UserName"] );
					DBHelper.ReadField( out userWorkstationName, row["UserWorkstationName"] );

					if ( userWorkstationName==Environment.MachineName )
					{
						int mainWindowHandle;
						DBHelper.ReadField( out mainWindowHandle, row["MainWindowHandle"] );

						if ( IsWindow( new IntPtr( mainWindowHandle ) ) )
						{
							throw new LockException( userName );
						}
						else
						{
							LogCentral.Current.LogDebug(
								string.Format(
								"Returned row is NON-NULL, window handle is on local machine and does not exist anymore. Not locked for '{0}', '{1}'.",
								objectType.FullName,
								objectID ) );
						}
					}
					else
					{
						throw new LockException( userName );
					}
				}
				else
				{
					LogCentral.Current.LogDebug(
						string.Format(
						"Returned row is NULL. Not locked for '{0}', '{1}'.",
						objectType.FullName,
						objectID ) );
				}
			}

			// --
			AdoNetSqlHelper.ExecuteNonQuery(
				@"DELETE
				FROM [Locks]
				WHERE [ObjectType]=@ObjectType
				AND [ObjectID]=@ObjectID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ObjectType", objectType.FullName ),
				AdoNetSqlParamCollection.CreateParameter( "@ObjectID", objectID )
				) );

			// --

			using ( AdoNetSqlUpdater upd = new AdoNetSqlUpdater(
						@"SELECT *
						FROM [Locks]
						WHERE [ObjectType]=@ObjectType
						AND [ObjectID]=@ObjectID",
						new AdoNetSqlParamCollection(
						AdoNetSqlParamCollection.CreateParameter( "@ObjectType", objectType.FullName, DbType.String ),
						AdoNetSqlParamCollection.CreateParameter( "@ObjectID", objectID, DbType.Int32 ) ) ) )
			{
				// If here, everything is OK. No other lock is set or lock is
				// invalid. Set new lock now.
				DataRow row = upd.CheckGetOrAddNewRow();

				row["LockDate"] = DBHelper.WriteField( lockDate );
				row["UserName"] = DBHelper.WriteField( userName );
				row["UserDomainName"] = DBHelper.WriteField( userDomainName );
				row["UserWorkstationName"] = DBHelper.WriteField( userWorkstationName );
				row["ObjectType"] = DBHelper.WriteField( objectType.FullName );
				row["ObjectID"] = DBHelper.WriteField( objectID );
				row["MainWindowHandle"] = DBHelper.WriteField( mainWindowHandle );

				upd.Update( AdoNetSqlUpdater.IdentityControl.DontGet );
			}
		}

		/// <summary>
		/// Checks whether a window handle is valid.
		/// </summary>
		[DllImport("user32.dll", EntryPoint="IsWindow")] 
		private static extern int IsWindowImport( 
			IntPtr hwnd );

		/// <summary>
		/// Checks whether a window handle is valid.
		/// </summary>
		public static bool IsWindow( 
			IntPtr hwnd )
		{
			return IsWindowImport( hwnd )!=0;
		}

		/// <summary>
		/// Checks whether a window handle is valid.
		/// </summary>
		public static bool IsWindow( 
			int hwnd )
		{
			return IsWindow( new IntPtr( hwnd ) );
		}

		/// <summary>
		/// Mark as unlocked.
		/// </summary>
		private void Unlock()
		{
			AdoNetSqlHelper.ExecuteNonQuery(
				@"DELETE 
				FROM [Locks]
				WHERE [ObjectType]=@ObjectType
				AND [ObjectID]=@ObjectID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ObjectType", objectType.FullName ),
				AdoNetSqlParamCollection.CreateParameter( "@ObjectID", objectID )
				) );
		}

		private Type objectType;
		private int objectID;
		private DateTime lockDate;
		private string userDomainName;
		private string userName;
		private string userWorkstationName;
		private int mainWindowHandle;

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Locking DB objects from concurrent editing.
	/// </summary>
	public class LockManager
	{
		#region Public routines.
		// ------------------------------------------------------------------
		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}