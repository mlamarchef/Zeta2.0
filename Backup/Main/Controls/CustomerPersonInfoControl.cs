namespace ZetaHelpDesk.Main.Controls
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Drawing;
	using System.Data;
	using System.Text;
	using System.Windows.Forms;
	using System.Diagnostics;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Information panel about a person.
	/// </summary>
	public partial class CustomerPersonInfoControl : 
		UserControl
	{
		public CustomerPersonInfoControl()
		{
			InitializeComponent();
			SetCustomerPerson( null );
		}

		public void SetCustomerPerson(
			DBObjects.CustomerPerson person )
		{
			this.person = person;

			if ( person == null || person.IsEmpty )
			{
				infoPanel.Visible = false;
			}
			else
			{
				infoPanel.Visible = true;

				nameInfoLabel.Text = string.Format(
					"{0}, {1}",
					person.LastName,
					person.FirstName );
				phoneInfoLabel.Text = person.Phone;
				faxInfoLabel.Text = person.Fax;
				mobileInfoLabel.Text = person.Mobile;

				if ( string.IsNullOrEmpty( person.EMail ) )
				{
					emailInfoLinkLabel.Visible = false;
				}
				else
				{
					emailInfoLinkLabel.Visible = true;
					emailInfoLinkLabel.Text = person.EMail;
				}
			}
		}

		private DBObjects.CustomerPerson person;

		private void emailInfoLinkLabel_LinkClicked( 
			object sender, 
			LinkLabelLinkClickedEventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = "mailto:" + person.EMail;

			Process.Start( info );
		}
	}

	/////////////////////////////////////////////////////////////////////////
}