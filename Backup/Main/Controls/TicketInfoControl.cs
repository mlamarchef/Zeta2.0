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
	/// Information panel about a ticket.
	/// </summary>
	public partial class TicketInfoControl : 
		UserControl
	{
		#region Public methods.
		// ------------------------------------------------------------------

		public TicketInfoControl()
		{
			InitializeComponent();
			SetTicket( null );
		}

		public void SetTicket(
			DBObjects.Ticket ticket )
		{
			this.ticket = ticket;

			if ( ticket == null || ticket.IsEmpty )
			{
				infoPanel.Visible = false;
			}
			else
			{
				infoPanel.Visible = true;

				dateCreatedInfoLabel.Text = ticket.DateCreated.ToString();
				groupInfoLabel.Text = ticket.GroupName;
				stateInfoLabel.Text = Code.MiscHelper.GetEnumDescription( ticket.State );
				durationInfoLabel.Text = ticket.EventDurationTimeSpan.ToString();
				eventCountInfoLabel.Text = ticket.EventCount.ToString();
				assignedToInfoLabel.Text = ticket.AssignedToUser.ToString();
				openDurationInfoLabel.Text = ticket.OpenDurationTimeSpan.ToString();
				ticketTitleInfoTextBox.Text = ticket.Title;
				ticketDescriptionInfoBox.Text = ticket.Description;

				customerPersonInfoLabel.Text = ticket.CustomerPerson == null ? string.Empty : ticket.CustomerPerson.ToString();
				customerCompanyInfoLabel.Text = ticket.CustomerCompany == null ? string.Empty : ticket.CustomerCompany.ToString();

				if ( ticket.TicketClosedDate == DateTime.MinValue )
				{
					dateClosedInfoLabel.Text = string.Empty;
				}
				else
				{
					dateClosedInfoLabel.Text =
						ticket.TicketClosedDate.ToString();
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private DBObjects.Ticket ticket;

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}