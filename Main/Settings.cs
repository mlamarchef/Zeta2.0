namespace ZetaHelpDesk.Main.Properties
{
	#region Using directives.
	// ----------------------------------------------------------------------
	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////
	
	/// <summary>
	/// Handle Setting events.
	/// </summary>
	internal sealed partial class Settings
	{
		#region Public methods.
		// ------------------------------------------------------------------

		public Settings()
		{
			this.SettingChanging += this.SettingChangingEventHandler;
			this.SettingsSaving += this.SettingsSavingEventHandler;
		}

		// ------------------------------------------------------------------
		#endregion

		#region Handler.
		// ------------------------------------------------------------------

		private void SettingChangingEventHandler( 
			object sender, 
			System.Configuration.SettingChangingEventArgs e )
		{
		}

		private void SettingsSavingEventHandler( 
			object sender, 
			System.ComponentModel.CancelEventArgs e )
		{
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}