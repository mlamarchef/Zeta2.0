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
	/// Information panel about a project task.
	/// </summary>
	public partial class ProjectTaskInfoControl : 
		UserControl
	{
		public ProjectTaskInfoControl()
		{
			InitializeComponent();
			SetProjectTask( null );
		}

		public void SetProjectTask(
			DBObjects.ProjectTask projectTask )
		{
			this.projectTask = projectTask;

			if ( projectTask == null || projectTask.IsEmpty )
			{
				infoPanel.Visible = false;
			}
			else
			{
				infoPanel.Visible = true;

				dateCreatedInfoLabel.Text = projectTask.DateCreated.ToShortDateString();
				isCompletedInfoLabel.Text = projectTask.IsCompleted ? "Yes" : "No";
				wasBilledInfoLabel.Text = projectTask.WasBilled ? "Yes" : "No";
				isBillableInfoLabel.Text = projectTask.IsBillable ? "Yes" : "No";
				durationInfoLabel.Text = projectTask.DurationTimeSpan.ToString();

				titleInfoTextBox.Text = projectTask.Name;
				descriptionInfoBox.Text = projectTask.Description;

				if ( projectTask.HasAttachment )
				{
					attachmentLinkLabel.Visible = true;

					toolTip1.SetToolTip(
						attachmentLinkLabel,
						projectTask.AttachmentUserReadableFileName );
				}
				else
				{
					attachmentLinkLabel.Visible = false;
				}
			}
		}

		private DBObjects.ProjectTask projectTask;

		private void attachmentLinkLabel_LinkClicked( 
			object sender, 
			LinkLabelLinkClickedEventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = projectTask.AttachmentFilePath;

			Process.Start( info );
		}
	}

	/////////////////////////////////////////////////////////////////////////
}