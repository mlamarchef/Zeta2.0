namespace ZetaHelpDesk.Main
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.IO;
	using System.Configuration;
	using System.Diagnostics;
	using System.Data;
	using System.Xml;
	using System.Text;
	using System.Globalization;
	using System.Reflection;
	using System.Windows.Forms;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	using ZetaHelpDesk.Main.Code;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Encapsulates the values read from the configuration files/sections.
	/// </summary>
	class ApplicationConfiguration
	{
		#region Static member.
		// ------------------------------------------------------------------

		/// <summary>
		/// Get a global instance.
		/// </summary>
		public static ApplicationConfiguration Current
		{
			get
			{
				lock ( typeof( ApplicationConfiguration ) )
				{
					if ( current == null )
					{
						current = new ApplicationConfiguration();

						XmlNode section = ConfigurationManager.GetSection(
							"zetaHelpDesk" ) as XmlNode;
						current.LoadFromXml( section );
					}

					return current;
				}
			}
		}

		private static ApplicationConfiguration current;

		// ------------------------------------------------------------------
		#endregion

		#region Public routines.
		// ------------------------------------------------------------------

		/// <summary>
		/// Call once to ensure this class is initialized.
		/// </summary>
		public void Initialize()
		{
			CleanupKeepAlives();
		}

		/// <summary>
		/// Store settings.
		/// </summary>
		public void Finish()
		{
			StoreLocalSettings();
		}

		public void LoadLocalSettings()
		{
			// Load the dynamic configuration.
			if ( File.Exists( LocalSettingsFilePath ) )
			{
				XmlDocument doc = new XmlDocument();
				doc.Load( LocalSettingsFilePath );

				XmlNode root = doc.SelectSingleNode( "root" );
				if ( root != null )
				{
					LocalSettings.LoadFromXml( root );
				}
			}
		}

		public void StoreLocalSettings()
		{
			XmlDocument doc = new XmlDocument();

			string pi = string.Format(
				"version=\"1.0\" encoding=\"{0}\"",
				Encoding.UTF8.WebName );
			doc.AppendChild(
				doc.CreateProcessingInstruction( "xml", pi ) );

			XmlElement root = doc.CreateElement( "root" );

			doc.AppendChild( root );
			LocalSettings.StoreToXml( root );

			doc.Save( LocalSettingsFilePath );
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		/// <summary>
		/// The settings for the local user.
		/// </summary>
		public readonly LocalSettings LocalSettings = new LocalSettings();

		/// <summary>
		/// Managing locks.
		/// </summary>
		public readonly LockManager LockManager = new LockManager();

		/// <summary>
		/// The delta in seconds between 2 keep alives.
		/// </summary>
		public int KeepAliveSeconds
		{
			get
			{
				return 60;
			}
		}

		/// <summary>
		/// The base path of the data folder.
		/// </summary>
		public string DataFolderBasePath;

		/// <summary>
		/// Find out the main form.
		/// </summary>
		public int MainWindowHandle
		{
			get
			{
				if ( mainWindowHandle == 0 )
				{
					FormCollection forms = Application.OpenForms;

					if ( forms == null )
					{
						return 0;
					}
					else
					{
						foreach ( Form form in forms )
						{
							if ( form is Main.Forms.MainForm )
							{
								mainWindowHandle = form.Handle.ToInt32();
							}
						}

						return mainWindowHandle;
					}
				}
				else
				{
					return mainWindowHandle;
				}
			}
		}

		/// <summary>
		/// Cached version.
		/// </summary>
		private int mainWindowHandle = 0;

		// ------------------------------------------------------------------
		#endregion

		#region Private member.
		// ------------------------------------------------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		private ApplicationConfiguration()
		{
			keepAliveTimer = new System.Timers.Timer( KeepAliveSeconds * 1000 );
			keepAliveTimer.Enabled = false;
			keepAliveTimer.Elapsed += new System.Timers.ElapsedEventHandler(keepAliveTimer_Elapsed);
		}

		/// <summary>
		/// Loads the content this class form the given configuration node.
		/// </summary>
		private void LoadFromXml( 
			XmlNode node )
		{
			if ( node!=null )
			{
				XmlHelper.ReadAttribute(
					out DataFolderBasePath,
					node.Attributes["dataFolderBasePath"] );

				DataFolderBasePath = 
					LogCentral.ExpandFilePathMacros(
					DataFolderBasePath );

				if ( DataFolderBasePath.IndexOf( '~' )==0 )
				{
					string tilde = LogCentral.Current.ConfigurationFilePath;
					tilde = Path.GetDirectoryName( tilde );

					tilde = tilde.TrimEnd( '\\' );

					DataFolderBasePath = DataFolderBasePath.Replace( "~", tilde );
				}

				DataFolderBasePath = Path.GetFullPath( DataFolderBasePath.TrimEnd( '\\' ) );
			}

			// Start and call once (this IS important, because
			// otherwise the first lock will be recognized only 
			// after KeepAliveSeconds seconds.
			keepAliveTimer.Enabled = true;
			keepAliveTimer_Elapsed( null, null );

			LoadLocalSettings();
		}

		private System.Timers.Timer keepAliveTimer;

		/// <summary>
		/// Delete old entries.
		/// </summary>
		private void CleanupKeepAlives()
		{
			// --
			// Remove all old.

			// Delete by date only, ignore any user- or computer-settings.
			DateTime date = DateTime.Now.AddMinutes( 30 );

			/*
			string formattedDate = string.Format(
				"#{0}/{1}/{2}#",
				date.ToString( "MM" ),
				date.ToString( "dd" ),
				date.ToString( "yyyy" ) );

			AdoNetSqlHelper.ExecuteNonQuery(
				string.Format(
				@"DELETE 
				FROM [KeepAlives] 
				WHERE [LastDate]<{0}",
				formattedDate
				) );
			*/
			AdoNetSqlHelper.ExecuteNonQuery(
				@"DELETE 
				FROM [KeepAlives] 
				WHERE [LastDate]<@LastDate",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@LastDate", date )
				) );

			// --
			// Remove all on my computer with invalid
			// window handles.
	
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				@"SELECT * 
				FROM [KeepAlives] 
				WHERE [UserWorkstationName]=@UserWorkstationName",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@UserWorkstationName", Environment.MachineName )
				) );

			if ( table!=null )
			{
				string deletes = string.Empty;

				foreach ( DataRow row in table.Rows )
				{
					int id;
					int windowHandle;

					DBHelper.ReadField( out id, row["ID"] );
					DBHelper.ReadField( out windowHandle, row["MainWindowHandle"] );

					if ( !LockGuard.IsWindow( windowHandle ) )
					{
						if ( deletes.Length>0 )
						{
							deletes += ",";
						}

						deletes += id.ToString();
					}
				}

				if ( deletes.Length>0 )
				{
					AdoNetSqlHelper.ExecuteNonQuery(
						string.Format(
						@"DELETE
						FROM [KeepAlives]
						WHERE [ID] IN ({0})",
						deletes ) );
				}
			}
		}

		/// <summary>
		/// Event handler that is called when the timer elapses.
		/// </summary>
		private void keepAliveTimer_Elapsed(
			object sender, 
			System.Timers.ElapsedEventArgs e )
		{
			lock ( this )
			{
				using ( AdoNetSqlUpdater upd = new AdoNetSqlUpdater(
					@"SELECT *
					FROM [KeepAlives]
					WHERE [Username]=@UserName
					AND [UserDomainName]=@UserDomainName
					AND [UserWorkstationName]=@UserWorkstationName
					AND [MainWindowHandle]=@MainWindowHandle
					",
					new AdoNetSqlParamCollection(
					AdoNetSqlParamCollection.CreateParameter( "@UserName", System.Environment.UserName, DbType.String, System.Environment.UserName.Length ),
					AdoNetSqlParamCollection.CreateParameter( "@UserDomainName", System.Environment.UserDomainName, DbType.String, System.Environment.UserDomainName.Length ),
					AdoNetSqlParamCollection.CreateParameter( "@UserWorkstationName", System.Environment.MachineName, DbType.String, System.Environment.MachineName.Length ),
					AdoNetSqlParamCollection.CreateParameter( "@MainWindowHandle", MainWindowHandle, DbType.Int32 )
					) ) )
				{
					DataRow row = upd.CheckGetOrAddNewRow();

					row["LastDate"] = DBHelper.WriteField( DateTime.Now );
					row["Username"] = DBHelper.WriteField( System.Environment.UserName );
					row["UserDomainName"] = DBHelper.WriteField( System.Environment.UserDomainName );
					row["UserWorkstationName"] = DBHelper.WriteField( System.Environment.MachineName );
					row["MainWindowHandle"] = DBHelper.WriteField( MainWindowHandle );

					upd.Update( AdoNetSqlUpdater.IdentityControl.DontGet );
				}
			}	 
		}

		/// <summary>
		/// The path to the settings file for the local user.
		/// </summary>
		private string LocalSettingsFilePath
		{
			get
			{
				string path = Path.GetDirectoryName(
					Assembly.GetExecutingAssembly().Location ).TrimEnd( '\\' ) + "\\";

				path += "Settings.config";
				return path;
			}
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Read the configuration.
	/// See http://support.microsoft.com/?kbid=309045.
	/// </summary>
	internal class ApplicationConfigurationSectionHandler :
		IConfigurationSectionHandler
	{
		#region IConfigurationSectionHandler member.
		// ------------------------------------------------------------------

		/// <summary>
		/// Creates an instance of this class.
		/// </summary>
		public object Create(
			object parent,
			object configContext,
			XmlNode section )
		{
			return section;
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}