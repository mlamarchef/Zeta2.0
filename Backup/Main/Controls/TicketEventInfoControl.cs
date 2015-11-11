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

	public partial class TicketEventInfoControl : 
		UserControl
	{
		public TicketEventInfoControl()
		{
			InitializeComponent();
			SetTicketEvent( null );
		}

		public void SetTicketEvent(
			DBObjects.TicketEvent ticketEvent )
		{
			this.ticketEvent = ticketEvent;

			if ( ticketEvent == null || ticketEvent.IsEmpty )
			{
				infoPanel.Visible = false;
			}
			else
			{
				infoPanel.Visible = true;

				dateInfoLabel.Text = ticketEvent.EventDate.ToString();
				durationInfoLabel.Text = ticketEvent.DurationTimeSpan.ToString();
				contactTypeInfoLabel.Text = Code.MiscHelper.GetEnumDescription( ticketEvent.ContactType );
				customerPersonInfoLabel.Text = ticketEvent.CustomerPerson == null ? string.Empty : ticketEvent.CustomerPerson.ToString();
				descriptionInfoTextBox.Text = ticketEvent.Description;

				if ( ticketEvent.HasAttachment )
				{
					attachmentLinkLabel.Visible = true;

					toolTip1.SetToolTip(
						attachmentLinkLabel,
						ticketEvent.AttachmentUserReadableFileName );
				}
				else
				{
					attachmentLinkLabel.Visible = false;
				}
			}
		}

		private DBObjects.TicketEvent ticketEvent;

		private void attachmentLinkLabel_LinkClicked( 
			object sender, 
			LinkLabelLinkClickedEventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = ticketEvent.AttachmentFilePath;

			Process.Start( info );
		}
	}

	/////////////////////////////////////////////////////////////////////////
}