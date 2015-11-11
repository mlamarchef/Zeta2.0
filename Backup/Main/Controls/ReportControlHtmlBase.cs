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

	public partial class ReportControlHtmlBase :
		UserControl,
		IReportControl
	{
		public ReportControlHtmlBase()
		{
			InitializeComponent();
		}

		protected WebBrowser WebBrowser
		{
			get
			{
				return webBrowser;
			}
		}

		#region IReportControl Members

		public string ReportName
		{
			get
			{
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		public string ReportDescription
		{
			get
			{
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		public bool IsInstantiable
		{
			get
			{
				return false;
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