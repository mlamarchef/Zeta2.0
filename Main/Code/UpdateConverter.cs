using System;
using System.Collections.Generic;
using System.Text;
using ZetaLib.Core.Data;
using System.Collections;
using ZetaLib.Core.Common;

namespace ZetaHelpDesk.Main.Code
{
	/// <summary>
	/// Manages upgrading the application/database.
	/// </summary>
	public class UpgradeConverter
	{
		#region Public members.
		// ------------------------------------------------------------------

		/// <summary>
		/// Query whether the database must be upgraded.
		/// </summary>
		public bool NeedUpgradeDatabase
		{
			get
			{
				int currentVersion = CurrentDatabaseVersion;
				int latestVersion = LatestDatabaseVersion;

				return currentVersion < latestVersion;
			}
		}

		/// <summary>
		/// Does the upgrade of the database (if required).
		/// </summary>
		public void UpgradeDatabase()
		{
			while ( NeedUpgradeDatabase )
			{
				int newVersion = DoUpgradeDatabase(
					CurrentDatabaseVersion,
					LatestDatabaseVersion );

				// Only set if meaningful value.
				if ( newVersion != 0 && newVersion > CurrentDatabaseVersion )
				{
					CurrentDatabaseVersion = newVersion;
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private helper.
		// ------------------------------------------------------------------

		/// <summary>
		/// Adjust this for upgrading.
		/// </summary>
		private int LatestDatabaseVersion
		{
			get
			{
				return 1;
			}
		}

		/// <summary>
		/// Get/set database versions.
		/// </summary>
		private int CurrentDatabaseVersion
		{
			get
			{
				return GetPersistInt(
					"UpgradeConverter.CurrentDatabaseVersion" );
			}
			set
			{
				SetPersistInt(
					"UpgradeConverter.CurrentDatabaseVersion",
					value );
			}
		}

		/// <summary>
		/// Convert the current web project to a newer version.
		/// </summary>
		private int DoUpgradeDatabase(
			int currentVersion,
			int latestVersion )
		{
			bool hasDone = false;

			int doneVersion = 0;
			int checkVersion = 0;

			// --
			// Lowest version first!
			// Latest version last!

			checkVersion = 1;
			if ( !hasDone && currentVersion < checkVersion )
			{
				ArrayList tableNames = new ArrayList(
					AdoNetSqlHelper.GetDatabaseTables() );

				if ( !tableNames.Contains( "Settings" ) )
				{
					AdoNetSqlHelper.ExecuteNonQuery(
						@"CREATE TABLE [Settings] 
						(
							[ID] int NOT NULL IDENTITY (1, 1),
							[UniqueID] uniqueidentifier NOT NULL ROWGUIDCOL DEFAULT (newid()),
							[Name] nvarchar(300) NOT NULL,
							[Value] nvarchar(2000) NULL
						) " );
				}

				hasDone = true;
				doneVersion = checkVersion;
			}

			// --

			// ...

			// --

			return doneVersion;
		}

		/// <summary>
		/// Helper for persistent value settings.
		/// </summary>
		private string GetPersistString(
			string name )
		{
			if ( HasSettingsTable )
			{
				object o = AdoNetSqlHelper.ExecuteValue(
					"SELECT * FROM [Settings] WHERE [Name]=@Name",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@Name", name ) ) );

				if ( o == null )
				{
					return null;
				}
				else
				{
					return o.ToString();
				}
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Helper for persistent value settings.
		/// </summary>
		private void SetPersistString(
			string name,
			string value )
		{
			if ( HasSettingsTable )
			{
				AdoNetSqlHelper.ExecuteNonQuery(
					"DELETE * FROM [Settings] WHERE [Name]=@Name",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@Name", name ) ) );

				AdoNetSqlHelper.ExecuteNonQuery(
					"INSERT INTO [Settings] ([Name], [Value]) VALUES ( @Name, @Value )",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@Name", name ),
					AdoNetSqlParamCollection.CreateParameter( "@Value", value == null ? string.Empty : value ) ) );
			}
		}

		/// <summary>
		/// Helper for persistent value settings.
		/// </summary>
		private int GetPersistInt(
			string name )
		{
			if ( HasSettingsTable )
			{
				object o = AdoNetSqlHelper.ExecuteValue(
					"SELECT [Value] FROM [Settings] WHERE [Name]=@Name",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@Name", name ) ) );

				if ( o == null || !ConvertHelper.IsInteger( o ) )
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32( o );
				}
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// Helper for persistent value settings.
		/// </summary>
		private void SetPersistInt(
			string name,
			int value )
		{
			if ( HasSettingsTable )
			{
				AdoNetSqlHelper.ExecuteNonQuery(
					"DELETE FROM [Settings] WHERE [Name]=@Name",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@Name", name ) ) );

				AdoNetSqlHelper.ExecuteNonQuery(
					"INSERT INTO [Settings] ([Name], [Value]) VALUES ( @Name, @Value )",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@Name", name ),
					AdoNetSqlParamCollection.CreateParameter( "@Value", value.ToString() ) ) );
			}
		}

		private bool HasSettingsTable
		{
			get
			{
				ArrayList tableNames = new ArrayList(
					AdoNetSqlHelper.GetDatabaseTables() );

				return tableNames.Contains( "Settings" );
			}
		}

		// ------------------------------------------------------------------
		#endregion
	}
}