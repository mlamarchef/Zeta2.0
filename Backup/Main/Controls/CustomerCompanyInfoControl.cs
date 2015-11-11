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
	/// Information panel about a customer.
	/// </summary>
	public partial class CustomerCompanyInfoControl : 
		UserControl
	{
		public CustomerCompanyInfoControl()
		{
			InitializeComponent();
			SetCustomerCompany( null );
		}

		public void SetCustomerCompany(
			DBObjects.CustomerCompany company )
		{
			this.company = company;

			customerCompanySupportContractInfoControl.SetCustomerCompany( 
				company );

			if ( company == null || company.IsEmpty )
			{
				infoPanel.Visible = false;
			}
			else
			{
				infoPanel.Visible = true;

				name1InfoLabel.Text = company.Name1;
				name2InfoLabel.Text = company.Name2;
				address1InfoLabel.Text = company.Address1;
				address2InfoLabel.Text = company.Address2;
				cityInfoLabel.Text = string.Format( "{0} {1}", company.Zip, company.City );
				phoneInfoLabel.Text = company.Phone;
				faxInfoLabel.Text = company.Fax;
				mobileInfoLabel.Text = company.Mobile;

				if ( string.IsNullOrEmpty( company.EMail ) )
				{
					emailInfoLinkLabel.Visible = false;
				}
				else
				{
					emailInfoLinkLabel.Visible = true;
					emailInfoLinkLabel.Text = company.EMail;
				}

				if ( string.IsNullOrEmpty( company.Www ) )
				{
					wwwInfoLabel.Visible = false;
				}
				else
				{
					wwwInfoLabel.Visible = true;
					wwwInfoLabel.Text = company.Www;
				}
			}
		}

		private DBObjects.CustomerCompany company;

		private void emailInfoLinkLabel_LinkClicked( 
			object sender,
			LinkLabelLinkClickedEventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = "mailto:" + company.EMail;

			Process.Start( info );
		}

		private void wwwInfoLabel_LinkClicked( 
			object sender,
			LinkLabelLinkClickedEventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = company.Www;

			Process.Start( info );
		}
	}

	/////////////////////////////////////////////////////////////////////////
}