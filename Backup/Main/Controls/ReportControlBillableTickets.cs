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

	using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class ReportControlBillableTickets :
		UserControl,
		IReportControl
	{
		#region IReportControl Members

		public string ReportName
		{
			get
			{
				return "Billable tickets";
			}
		}

		public string ReportDescription
		{
			get
			{
				return "Displays a list of billable tickets for a given month.";
			}
		}

		public bool IsInstantiable
		{
			get
			{
				return true;
			}
		}

		public bool IsUnderDevelopment
		{
			get
			{
				return false;
			}
		}

		#endregion

		public ReportControlBillableTickets()
		{
			InitializeComponent();
		}

		private void UpdateUI()
		{
		}

		private void ReportControlBillableTickets_Load( 
			object sender, 
			EventArgs e )
		{
			DateTime date = DateTime.Now.AddMonths( -1 );

			monthComboBox.SelectedItem = StringHelper.AddZerosPrefix( date.Month, 2 );
			yearComboBox.SelectedItem = date.Year.ToString();

			UpdateUI();
		}

		private void showButton_Click( 
			object sender, 
			EventArgs e )
		{
			using ( new ZetaLib.Windows.Common.WaitCursor( ParentForm ) )
			{
				DateTime forMonth = new DateTime(
					Convert.ToInt32( yearComboBox.Text ),
					Convert.ToInt32( monthComboBox.Text ),
					1 );

				DBObjects.CustomerCompany[] companies =
					DBObjects.CustomerCompany.GetCustomersWithUnbilledBillableTickets(
					forMonth );

				if ( companies != null )
				{
					webBrowser.DocumentText =
						ReportControlBillableProjectTasks.MakeHtmlFromContentHtml(
						GenerateHtmlReport(
						forMonth,
						companies ) );
				}
				else
				{
					webBrowser.DocumentText =
						ReportControlBillableProjectTasks.MakeHtmlFromContentHtml(
						@"<p>There are no billable tickets in the given time span.</p>" );
				}
			}
		}

		private string GenerateHtmlReport(
			DateTime forMonth,
			DBObjects.CustomerCompany[] companies )
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat(
				"<h1>Billable tickets</h1>"
				 );

			foreach ( DBObjects.CustomerCompany company in companies )
			{
				DBObjects.Ticket[] tickets =
					DBObjects.Ticket.GetUnbilledBillableForCustomerCompany( 
					company,
					forMonth );

				sb.AppendFormat(
					"<h2>Company {0}</h2>",
					company.Name1 );

				if ( tickets != null )
				{
					sb.AppendFormat(
						"<ul>"
						 );

					foreach ( DBObjects.Ticket ticket in tickets )
					{
						sb.AppendFormat(
							"<li>{0} ({1}): {2}, {3}</li>",
							ticket.DateCreated.ToShortDateString(),
							ticket.AssignedToUser,
							ticket.Title,
							ticket.EventDurationTimeSpan.ToString() );
					}

					sb.AppendFormat(
						"</ul>"
						);
				}
			}

			return sb.ToString();
		}

		private void markAsBilledButton_Click( 
			object sender, 
			EventArgs e )
		{
			if ( MessageBox.Show(
				this,
				"Do you really want to mark the tickets as billed?",
				"zeta HelpDesk",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
			{
				using ( new ZetaLib.Windows.Common.WaitCursor( ParentForm ) )
				{
					DateTime forMonth = new DateTime(
						Convert.ToInt32( yearComboBox.Text ),
						Convert.ToInt32( monthComboBox.Text ),
						1 );

					DBObjects.CustomerCompany[] companies =
						DBObjects.CustomerCompany.GetCustomersWithUnbilledBillableTickets(
						forMonth );

					if ( companies != null )
					{
						foreach ( DBObjects.CustomerCompany company in companies )
						{
							DBObjects.Ticket[] tickets =
								DBObjects.Ticket.GetUnbilledBillableForCustomerCompany(
								company,
								forMonth );

							if ( tickets != null )
							{
								foreach ( DBObjects.Ticket ticket in tickets )
								{
									ticket.WasBilled = true;
									ticket.Store();
								}
							}
						}
					}
				}

				MessageBox.Show(
					this,
					"The tickets were successfully marked as billed.",
					"zeta HelpDesk",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information );
			}
		}
	}

	/////////////////////////////////////////////////////////////////////////
}