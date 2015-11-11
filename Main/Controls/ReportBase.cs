namespace ZetaHelpDesk.Main.Controls
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Collections.Generic;
	using System.Text;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Interface implemented by a report control.
	/// </summary>
	public interface IReportControl :
		IDisposable
	{
		#region Interface member.
		// ------------------------------------------------------------------

		string ReportName
		{
			get;
		}

		string ReportDescription
		{
			get;
		}

		bool IsInstantiable
		{
			get;
		}

		bool IsUnderDevelopment
		{
			get;
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Use this class for storing information
	/// about a control to create, e.g. in the Tag
	/// property of a list view item.
	/// </summary>
	public class ReportControlInformation
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public ReportControlInformation(
			IReportControl control,
			Type controlType )
		{
			this.reportName = control.ReportName;
			this.reportDescription = control.ReportDescription;
			this.controlType = controlType;
		}

		public string ReportName
		{
			get
			{
				return reportName;
			}
			set
			{
				reportName = value;
			}
		}

		public string ReportDescription
		{
			get
			{
				return reportDescription;
			}
			set
			{
				reportDescription = value;
			}
		}

		public Type ControlType
		{
			get
			{
				return controlType;
			}
			set
			{
				controlType = value;
			}
		}

		/// <summary>
		/// Create the control instance to show on a form.
		/// </summary>
		public IReportControl CreateInstance()
		{
			if ( cachedControl == null )
			{
				cachedControl =
					Activator.CreateInstance( controlType ) as IReportControl;
			}

			return cachedControl;
		}

		private Type controlType;
		private string reportDescription;
		private string reportName;
		private IReportControl cachedControl;
	}

	/////////////////////////////////////////////////////////////////////////
}