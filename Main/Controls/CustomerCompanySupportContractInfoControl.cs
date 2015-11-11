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

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Information about a support contract of a customer.
	/// </summary>
	public partial class CustomerCompanySupportContractInfoControl :
		UserControl
	{
		#region Public methods.
		// ------------------------------------------------------------------

		public CustomerCompanySupportContractInfoControl()
		{
			InitializeComponent();
		}

		public void SetCustomerCompany(
			DBObjects.CustomerCompany company )
		{
			this.company = company;

			DBObjects.CustomerCompanySupportContract contract = null;
			if ( company != null )
			{
				contract = company.SupportContract;
			}

			if ( contract == null )
			{
				descriptionLabel.Text = string.Empty;
				validFromLabel.Text = string.Empty;
				validToLabel.Text = string.Empty;

				statusLabel.Text = "The customer company has no support contract.";
				statusPictureBox.Image =
					statusImageList.Images["SupportContractGray.gif"];
			}
			else
			{
				descriptionLabel.Text = contract.Description;
				validFromLabel.Text = contract.StartDate == DateTime.MinValue ? string.Empty : contract.StartDate.ToShortDateString();
				validToLabel.Text = contract.EndDate == DateTime.MinValue ? string.Empty : contract.EndDate.ToShortDateString();

				if ( contract.StartDate > DateTime.Now )
				{
					statusLabel.Text = "The support contract is not yet valid.";
					statusPictureBox.Image =
						statusImageList.Images["SupportContractYellow.gif"];
				}
				else if ( contract.EndDate == DateTime.MinValue ||
					contract.EndDate >= DateTime.Now )
				{
					statusLabel.Text = "The support contract is valid.";
					statusPictureBox.Image =
						statusImageList.Images["SupportContractGreen.gif"];
				}
				else if ( contract.EndDate < DateTime.Now )
				{
					statusLabel.Text =
						string.Format(
						"The support contract has expired since {0} days.",
						( DateTime.Now - contract.EndDate ).TotalDays );
					statusPictureBox.Image =
						statusImageList.Images["SupportContractRed.gif"];
				}
				else
				{
					statusLabel.Text = "The state of the support contract is undefined.";
					statusPictureBox.Image =
						statusImageList.Images["SupportContractYellow.gif"];
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private DBObjects.CustomerCompany company;

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}