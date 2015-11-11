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

	public partial class ReportControlOpenTickets :
		UserControl,
		IReportControl
	{
		public ReportControlOpenTickets()
		{
			InitializeComponent();
		}

		#region IReportControl Members

		public string ReportName
		{
			get
			{
				return "Open tickets";
			}
		}

		public string ReportDescription
		{
			get
			{
				return "Shows a list of all open tickets.";
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
				return true;
			}
		}

		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}