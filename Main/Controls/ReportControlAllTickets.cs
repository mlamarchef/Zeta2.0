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

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class ReportControlAllTickets :
		ReportControlHtmlBase,
		IReportControl
	{
		public ReportControlAllTickets()
		{
			InitializeComponent();
		}

		#region IReportControl Members

		public new string ReportName
		{
			get
			{
				return "All Tickets";
			}
		}

		public new string ReportDescription
		{
			get
			{
				return "Displays a list of all tickets.";
			}
		}

		public new bool IsInstantiable
		{
			get
			{
				return true;
			}
		}

		public new bool IsUnderDevelopment
		{
			get
			{
				return true;
			}
		}

		#endregion

		private void ReportControlAllTickets_Load( 
			object sender, 
			EventArgs e )
		{
			WebBrowser.DocumentText = "<html><body><h1>All Tickets</h1><p>All tickets.</p></body></html>";
		}
	}

	/////////////////////////////////////////////////////////////////////////
}