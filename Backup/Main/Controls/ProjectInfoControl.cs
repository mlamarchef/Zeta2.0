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
	/// Information panel about a project.
	/// </summary>
	public partial class ProjectInfoControl : 
		UserControl
	{
		public ProjectInfoControl()
		{
			InitializeComponent();
			SetProject( null );
		}

		public void SetProject(
			DBObjects.Project project )
		{
			this.project = project;

			if ( project == null || project.IsEmpty )
			{
				infoPanel.Visible = false;
			}
			else
			{
				infoPanel.Visible = true;

				dateCreatedInfoLabel.Text = project.DateCreated.ToShortDateString();
				dueDateInfoLabel.Text =
					project.DueDate == DateTime.MinValue ? 
					string.Empty :
					project.DueDate.ToShortDateString();
				customerCompanyInfoLabel.Text = project.Company == null ? string.Empty : project.Company.ToString();
				taskCountInfoLabel.Text = project.TaskCount.ToString();
				assignedToInfoLabel.Text = project.AssignedToUser.ToString();
				isCompletedInfoLabel.Text = project.IsCompleted ? "Yes" : "No";

				titleInfoTextBox.Text = project.Name;
				descriptionInfoBox.Text = project.Description;

				// --

				DBObjects.Project.TimeSpans spans =
					project.CalculatedTimeSpans;

				billableDurationInfoLabel.Text = spans.BillableDuration.ToString();
				completedBillableDurationInfoLabel.Text = spans.CompletedBilledDuration.ToString();
				completedDurationInfoLabel.Text = spans.CompletedDuration.ToString();
				completedUnbillableDurationInfoLabel.Text = spans.CompletedUnbilledDuration.ToString();
				totalDurationInfoLabel.Text = spans.TotalDuration.ToString();
			}
		}

		private DBObjects.Project project;
	}

	/////////////////////////////////////////////////////////////////////////
}