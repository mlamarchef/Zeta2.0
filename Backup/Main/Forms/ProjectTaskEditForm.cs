namespace ZetaHelpDesk.Main.Forms
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using System.Diagnostics;
	using System.IO;

	using ZetaLib.Windows.Common;

	using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class ProjectTaskEditForm : 
		Form
	{
		public ProjectTaskEditForm(
			DBObjects.Project parentItem,
			DBObjects.ProjectTask item )
		{
			this.parentItem = parentItem;
			this.item = item;

			InitializeComponent();
		}

		private DBObjects.Project parentItem = null;
		private DBObjects.ProjectTask item = null;

		private void Store()
		{
			item.ProjectID = parentItem.ID;

			item.Name = nameTextBox.Text;
			item.Description = descriptionTextBox.Text;
			item.Date = dateDateTimePicker.Value;
			item.DurationTimeSpan = durationControl.ValueTimeSpan;
			item.IsCompleted = isCompletedCheckBox.Checked;
			item.IsBillable = isBillableCheckBox.Checked;
			item.WasBilled = wasBilledCheckBox.Checked;

			item.Remarks = remarksTextBox.Text;
			item.AttachmentDescription = attachmentDescriptionTextBox.Text;

			item.Store();
		}

		private void ProjectTaskEditForm_Load( object sender, EventArgs e )
		{
			FormHelper.RestoreState( this );
			CenterToParent();

			// Remove for now by code.
			tabControl1.TabPages.Remove( advancedTabPage );

			nameTextBox.Text = item.Name;
			descriptionTextBox.Text = item.Description;
			dateDateTimePicker.Value = item.Date;
			durationControl.ValueTimeSpan = item.DurationTimeSpan;

			isCompletedCheckBox.Checked = item.IsCompleted;
			isBillableCheckBox.Checked = item.IsBillable;
			wasBilledCheckBox.Checked = item.WasBilled;

			remarksTextBox.Text = item.Remarks;
			attachmentDescriptionTextBox.Text = item.AttachmentDescription;

			UpdateUI();
		}

		private void UpdateUI()
		{
			createdLabel.Text = string.Format(
				"{0} by {1}",
				item.DateCreated,
				item.UserCreated );
			modifiedLabel.Text = string.Format(
				"{0} by {1}",
				item.DateModified,
				item.UserModified );

			if ( string.IsNullOrEmpty( item.AttachmentUserReadableFileName ) )
			{
				attachmentTextBox.Text = "(none)";
				cmdOpenAttachment.Enabled = false;
			}
			else
			{
				attachmentTextBox.Text = item.AttachmentUserReadableFileName;
				cmdOpenAttachment.Enabled = true;
			}
		}

		private void ProjectTaskEditForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			FormHelper.SaveState( this );
		}

		private void okButton_Click( object sender, EventArgs e )
		{
			Store();
		}

		private void cmdSelectAttachment_Click( 
			object sender, 
			EventArgs e )
		{
			OpenFileDialog open = new OpenFileDialog();
			open.CheckFileExists = true;
			open.CheckPathExists = true;
			open.AddExtension = true;
			open.DereferenceLinks = true;
			open.Multiselect = false;
			open.ValidateNames = true;
			open.Title = "Select attachment to add";

			string initialDirectory;
			object o = FormHelper.RestoreValue(
				"ProjectTaskEditForm.InitialDirectory" );
			if ( o != null )
			{
				initialDirectory = o.ToString();
			}
			else
			{
				initialDirectory = Environment.GetFolderPath(
					Environment.SpecialFolder.MyDocuments );
			}

			open.InitialDirectory = initialDirectory;

			// --

			if ( open.ShowDialog( this ) == DialogResult.OK )
			{
				string directoryPath = Path.GetDirectoryName(
					open.FileName );

				FormHelper.SaveValue(
					"ProjectTaskEditForm.InitialDirectory",
					directoryPath );

				// Remember.
				item.AttachmentFilePath = open.FileName;
				UpdateUI();
			}
		}

		private void cmdOpenAttachment_Click( 
			object sender, 
			EventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = item.AttachmentFilePath;

			Process.Start( info );
		}
	}
}