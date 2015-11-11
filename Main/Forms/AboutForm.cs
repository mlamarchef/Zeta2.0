namespace ZetaHelpDesk.Main.Forms
{
	#region Using directives.
	// ----------------------------------------------------------------------
	
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using System.Reflection;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class AboutForm :
		Code.FormBase
	{
		#region Public methods.
		// ------------------------------------------------------------------

		public AboutForm()
		{
			InitializeComponent();
		}

		// ------------------------------------------------------------------
		#endregion

		#region Handler.
		// ------------------------------------------------------------------

		private void linkLabel2_LinkClicked( 
			object sender, 
			LinkLabelLinkClickedEventArgs e )
		{
			System.Diagnostics.ProcessStartInfo info = 
				new System.Diagnostics.ProcessStartInfo();

			info.FileName = "http://www.zeta-producer.com/";
			info.UseShellExecute = true;
			
			System.Diagnostics.Process.Start( info );
		}

		private void AboutForm_Load( object sender, EventArgs e )
		{
			CenterToParent();

			// Version info.

			AssemblyName an = Assembly.GetExecutingAssembly().GetName();
			string path = Assembly.GetExecutingAssembly().Location;

			DateTime dt = System.IO.File.GetLastWriteTime( path );
			System.Version version = an.Version;

			versionLabel.Text = string.Format(
				"Version {0}, {1}",
				version,
				dt );
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}