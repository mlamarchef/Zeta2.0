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

	public partial class ReportControlBillableProjectTasks :
		UserControl,
		IReportControl
	{
		#region IReportControl Members

		public string ReportName
		{
			get
			{
				return "Billable project tasks";
			}
		}

		public string ReportDescription
		{
			get
			{
				return "Displays a list of billable projects and tasks for a given month.";
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

		public ReportControlBillableProjectTasks()
		{
			InitializeComponent();
		}

		private void UpdateUI()
		{
		}

		private void ReportControlBillableProjectTasks_Load( 
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

				DBObjects.Project[] projects =
					DBObjects.Project.GetProjectsWithUnbilledBillableProjectTasks(
					forMonth );

				if ( projects != null )
				{
					webBrowser.DocumentText =
						MakeHtmlFromContentHtml( 
						GenerateHtmlReport(
						forMonth, 
						projects ) );
				}
				else
				{
					webBrowser.DocumentText =
						MakeHtmlFromContentHtml(
						@"<p>There are no billable tasks in the given time span.</p>" );
				}
			}
		}

		private string GenerateHtmlReport(
			DateTime forMonth,
			DBObjects.Project[] projects )
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat(
				"<h1>Billable tasks</h1>"
				 );

			foreach ( DBObjects.Project project in projects )
			{
				DBObjects.ProjectTask[] tasks = 
					project.GetUnbilledBillableTasks( forMonth );

				sb.AppendFormat(
					"<h2>Project {0}</h2>",
					project.Name );

				if ( tasks != null )
				{
					sb.AppendFormat(
						"<ul>"
						 );

					foreach ( DBObjects.ProjectTask task in tasks )
					{
						sb.AppendFormat(
							"<li>{0} ({1}): {2}, {3}</li>",
							task.Date.ToShortDateString(),
							project.AssignedToUser,
							task.Name,
							task.DurationTimeSpan.ToString() );
					}

					sb.AppendFormat(
						"</ul>"
						);
				}
			}

			return sb.ToString();
		}

		private void markAsBilledButton_Click( object sender, EventArgs e )
		{
			if ( MessageBox.Show(
				this,
				"Do you really want to mark the tasks as billed?",
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

					DBObjects.Project[] projects =
						DBObjects.Project.GetProjectsWithUnbilledBillableProjectTasks(
						forMonth );

					if ( projects != null )
					{
						foreach ( DBObjects.Project project in projects )
						{
							DBObjects.ProjectTask[] tasks =
								project.GetUnbilledBillableTasks( forMonth );

							if ( tasks != null )
							{
								foreach ( DBObjects.ProjectTask task in tasks )
								{
									task.WasBilled = true;
									task.Store();
								}
							}
						}
					}
				}

				MessageBox.Show(
					this,
					"The tasks were successfully marked as billed.",
					"zeta HelpDesk",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information );
			}
		}

		/// <summary>
		/// Append HTML tags.
		/// </summary>
		public static string MakeHtmlFromContentHtml(
			string contentHtml )
		{
			string pre =
				@"<html>
					<head>
						<style type='text/css'>
							body { font: 8pt/12pt verdana }
							h1 { font: 13pt/15pt verdana; font-weight: bold }
							h2 { font: 8pt/12pt verdana; font-weight: bold }
							a:link { color: red }
							a:visited { color: maroon }
						</style>
					</head>
					<body>";
			string post =
				@"</body></html>";

			return pre + contentHtml + post;
		}
	}

	/////////////////////////////////////////////////////////////////////////
}