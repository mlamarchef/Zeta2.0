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

	using ZetaLib.Windows.Common;

	using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;
	using ZetaHelpDesk.Main.Properties;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class ProjectEditForm : 
		Code.FormBase
	{
		public ProjectEditForm(
			DBObjects.Project item )
		{
			this.item = item;

			InitializeComponent();
		}

		private DBObjects.Project item = null;

		public DBObjects.Project Item
		{
			get
			{
				return item;
			}
		}

		private void ProjectEditForm_Load( 
			object sender, 
			EventArgs e )
		{
			FormHelper.RestoreState( this );
			FormHelper.RestoreState( projectTaskListView );
			RestoreState( splitContainer1 );
			CenterToParent();

			// Remove for now by code.
			tabControl1.TabPages.Remove( advancedTabPage );

			FillAssignToUserList();
			FillCustomerCompanyList();

			UpdateInfoPanel();

			// --

			LoadItem();
			RestoreProjectTaskListFilter();

			// --

			UpdateUI();
		}

		/// <summary>
		/// Load from the database object to the controls.
		/// </summary>
		private void LoadItem()
		{
			if ( item.Company != null )
			{
				foreach ( object o in customerCompanyComboBox.Items )
				{
					if ( o is DBObjects.CustomerCompany &&
						( o as DBObjects.CustomerCompany ).ID == item.CustomerCompanyID )
					{
						customerCompanyComboBox.SelectedItem = o;
						break;
					}
				}
			}

			if ( item.AssignedToUser != null )
			{
				foreach ( object o in assignedToUserComboBox.Items )
				{
					if ( o is DBObjects.User &&
						( o as DBObjects.User ).SamName == item.AssignedToUserSamName )
					{
						assignedToUserComboBox.SelectedItem = o;
						break;
					}
				}
			}

			nameTextBox.Text = item.Name;
			descriptionTextBox.Text = item.Description;
			remarksTextBox.Text = item.Remarks;
			isCompletedCheckBox.Checked = item.IsCompleted;

			dueDateDateTimePicker.Checked =
				item.DueDate > DateTime.MinValue;
		}

		private void UpdateUI()
		{
			editCustomerCompanyButton.Enabled =
				customerCompanyComboBox.Items.Count > 0 &&
				customerCompanyComboBox.SelectedItem != null &&
				customerCompanyComboBox.SelectedItem is DBObjects.CustomerCompany;

			deleteToolStripMenuItem.Enabled =
				editticketeventToolStripMenuItem.Enabled =
				projectTaskListView.Items.Count > 0 &&
				projectTaskListView.SelectedItems.Count > 0 &&
				projectTaskListView.SelectedItems[0].Tag is DBObjects.ProjectTask;

			if ( string.IsNullOrEmpty( nameTextBox.Text.Trim() ) )
			{
				Text = "Edit project - zeta HelpDesk";
			}
			else
			{
				Text = string.Format(
					"{0} - edit project - zeta HelpDesk",
					nameTextBox.Text.Trim() );
			}

			createdLabel.Text = string.Format(
				"{0} by {1}",
				item.DateCreated,
				item.UserCreated );
			modifiedLabel.Text = string.Format(
				"{0} by {1}",
				item.DateModified,
				item.UserModified );
		}

		private void FillCustomerCompanyList()
		{
			customerCompanyComboBox.Items.Clear();

			customerCompanyComboBox.Items.Add(
				"(Please select a customer)" );

			DBObjects.CustomerCompany[] companies =
				DBObjects.CustomerCompany.GetAll();

			if ( companies != null )
			{
				foreach ( DBObjects.CustomerCompany company in companies )
				{
					customerCompanyComboBox.Items.Add( company );
				}
			}

			customerCompanyComboBox.SelectedIndex = 0;
		}

		private void FillAssignToUserList()
		{
			assignedToUserComboBox.Items.Clear();

			DBObjects.User currentUser =
				DBObjects.User.CurrentUser;

			DBObjects.User[] users =
				DBObjects.User.GetAll();

			if ( users != null )
			{
				foreach ( DBObjects.User user in users )
				{
					assignedToUserComboBox.Items.Add( user );
				}
			}

			assignedToUserComboBox.SelectedIndex = 0;
		}

		private void SelectCustomerCompany(
			DBObjects.CustomerCompany company )
		{
			foreach ( object item in customerCompanyComboBox.Items )
			{
				if ( item is DBObjects.CustomerCompany )
				{
					DBObjects.CustomerCompany companyItem =
						item as DBObjects.CustomerCompany;

					if ( company.ID == companyItem.ID )
					{
						customerCompanyComboBox.SelectedItem = item;
						break;
					}
				}
			}
		}

		private void Store()
		{
			item.Name = nameTextBox.Text;
			item.Description = descriptionTextBox.Text;
			item.AssignedToUserSamName =
				( (DBObjects.User)assignedToUserComboBox.SelectedItem ).SamName;
			item.Remarks = remarksTextBox.Text;
			item.IsCompleted = isCompletedCheckBox.Checked;

			if ( customerCompanyComboBox.SelectedItem is DBObjects.CustomerCompany )
			{
				item.CustomerCompanyID =
					( customerCompanyComboBox.SelectedItem as DBObjects.CustomerCompany ).ID;
			}
			else
			{
				item.CustomerCompanyID = 0;
			}

			if ( dueDateDateTimePicker.Checked )
			{
				item.DueDate = dueDateDateTimePicker.Value;
			}
			else
			{
				item.DueDate = DateTime.MinValue;
			}

			item.Store();

			// --
			// Notify parent.

			MainForm mainForm = Owner as MainForm;

			mainForm.RefillProjectList();
		}

		private void FillProjectTaskList()
		{
			projectTaskListView.Items.Clear();

			projectTaskListGetInfo.ProjectID = item.ID;
			DBObjects.ProjectTask[] projectTasks = DBObjects.ProjectTask.Get(
				projectTaskListGetInfo );

			if ( projectTasks != null )
			{
				foreach ( DBObjects.ProjectTask projectTask in projectTasks )
				{
					AddProjectTaskToList( projectTask );
				}
			}
		}

		private void ProjectEditForm_FormClosing( 
			object sender, 
			FormClosingEventArgs e )
		{
			FormHelper.SaveState( projectTaskListView );
			FormHelper.SaveState( this );
			SaveState( splitContainer1 );
		}

		/// <summary>
		/// Update the read-only panel for information about a ticket event.
		/// </summary>
		private void UpdateInfoPanel()
		{
			if ( projectTaskListView.SelectedItems.Count > 0 )
			{
				DBObjects.ProjectTask info =
					projectTaskListView.SelectedItems[0].Tag as
					DBObjects.ProjectTask;

				projectTaskInfoControl.SetProjectTask( info );
			}
			else
			{
				projectTaskInfoControl.SetProjectTask( null );
			}
		}

		private void AddProjectTaskToList(
			DBObjects.ProjectTask projectTask )
		{
			ListViewItem listViewItem = new ListViewItem(
				new string[]
				{
					string.Empty,
					string.Empty,
					string.Empty
				} );

			listViewItem.Tag = projectTask;
			projectTaskListView.Items.Add( listViewItem );

			UpdateProjectTaskInList( projectTask );
		}

		private void UpdateProjectTaskInList(
			DBObjects.ProjectTask projectTask )
		{
			// --
			// Search.

			ListViewItem listViewItem = null;

			foreach ( ListViewItem item in projectTaskListView.Items )
			{
				// Search by reference instead of ID, since the item can be unsafed
				// and has an ID of zero.
				if ( item.Tag == projectTask )
				{
					listViewItem = item;
					break;
				}
			}

			// --

			listViewItem.Text = projectTask.Date.ToShortDateString();
			listViewItem.SubItems[1].Text = projectTask.Name;
			listViewItem.SubItems[2].Text = projectTask.DurationTimeSpan.ToString();

			listViewItem.ImageKey = projectTask.SmallImageKey;
		}

		private void newToolStripMenuItem_Click( object sender, EventArgs e )
		{
			neweventToolStripMenuItem_Click( null, null );
		}

		private void toolStripMenuItem1_Click( object sender, EventArgs e )
		{
			Store();
		}

		private void saveToolStripMenuItem_Click( object sender, EventArgs e )
		{
			Store();
			Close();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			dueDateDateTimePicker.Value = DateTime.Now;
		}

		private void editCustomerCompanyButton_Click( object sender, EventArgs e )
		{
			DBObjects.CustomerCompany item =
				customerCompanyComboBox.SelectedItem as
				DBObjects.CustomerCompany;

			CustomerCompanyEditForm form = new CustomerCompanyEditForm( item );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				int index = customerCompanyComboBox.SelectedIndex;
				FillCustomerCompanyList();
				customerCompanyComboBox.SelectedIndex = index;
				UpdateUI();
			}
		}

		private void newCustomerCompanyButton_Click( object sender, EventArgs e )
		{
			DBObjects.CustomerCompany company = new DBObjects.CustomerCompany();

			CustomerCompanyEditForm form = new CustomerCompanyEditForm( company );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				FillCustomerCompanyList();
				SelectCustomerCompany( company );
			}
		}

		private void customerCompanyComboBox_SelectedIndexChanged( object sender, EventArgs e )
		{
			UpdateUI();
		}

		private void titleTextBox_TextChanged( object sender, EventArgs e )
		{
			UpdateUI();
		}

		private void projectTaskListView_SelectedIndexChanged( object sender, EventArgs e )
		{
			UpdateInfoPanel();
			UpdateUI();
		}

		private void projectTaskListView_SizeChanged( object sender, EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
								projectTaskListView,
								new double[]
				{
					0.20,
					0.60,
					0.20
				} );
			}
		}

		private void projectTaskListView_DoubleClick( object sender, EventArgs e )
		{
			editticketeventToolStripMenuItem_Click( null, null );
		}

		private void editticketeventToolStripMenuItem_Click( object sender, EventArgs e )
		{
			DBObjects.ProjectTask evt = projectTaskListView.SelectedItems[0].Tag as
				DBObjects.ProjectTask;

			ProjectTaskEditForm form = new ProjectTaskEditForm( item, evt );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				FillProjectTaskList();
				UpdateInfoPanel();
			}
		}

		private void neweventToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// Must store parent before adding child.
			Store();

			DBObjects.ProjectTask task = new DBObjects.ProjectTask();
			task.ProjectID = item.ID;

			ProjectTaskEditForm form = new ProjectTaskEditForm( item, task );
			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				FillProjectTaskList();
			}
		}

		private void deleteToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if ( projectTaskListView.SelectedItems.Count > 0 )
			{
				DBObjects.ProjectTask projectTask =
					projectTaskListView.SelectedItems[0].Tag as
					DBObjects.ProjectTask;

				if ( projectTask.UserSamNameCreated == DBObjects.User.CurrentUser.SamName )
				{
					if ( MessageBox.Show(
						this,
						"Do you really want to delete this task permanently?",
						"zeta HelpDesk",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
					{
						projectTask.Delete();
						FillProjectTaskList();
					}
				}
				else
				{
					MessageBox.Show(
						this,
						"You cannot delete the task, because you are not the creator of the task.",
						"zeta HelpDesk",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation );
				}
			}
		}

		private DBObjects.ProjectTask.ProjectTaskGetInformation projectTaskListGetInfo =
			new DBObjects.ProjectTask.ProjectTaskGetInformation();

		private void PersistProjectTaskListFilter()
		{
			/*
			projectTaskListGetInfo.PastFilterTexts.Clear();
			foreach ( string s in filterProjectsToolStripComboBox.Items )
			{
				projectListGetInfo.PastFilterTexts.Add( s );
			}
			*/

			FormHelper.SerializeValue(
				"ProjectEditForm.projectTaskListGetInfo",
				projectTaskListGetInfo );
		}

		private void RestoreProjectTaskListFilter()
		{
			using ( new WaitCursor( this ) )
			{
				object o = FormHelper.DeserializeValue(
					"ProjectEditForm.projectTaskListGetInfo" );
				if ( o is DBObjects.ProjectTask.ProjectTaskGetInformation )
				{
					projectTaskListGetInfo = o as
						DBObjects.ProjectTask.ProjectTaskGetInformation;
				}

				/*
				filterProjectsToolStripComboBox.Items.Clear();
				foreach ( string s in projectListGetInfo.PastFilterTexts )
				{
					filterProjectsToolStripComboBox.Items.Add( s );
				}
				*/

				toolStripButton2.Checked =
					projectTaskListGetInfo.ProjectTaskStateGetType ==
					DBObjects.ProjectTask.ProjectTaskStateGetType.AllProjectTasks;

				FillProjectTaskList();
				UpdateUI();
			}
		}


		private void toolStripButton2_Click( object sender, EventArgs e )
		{
			toolStripButton2.Checked = !toolStripButton2.Checked;

			if ( !toolStripButton2.Checked )
			{
				projectTaskListGetInfo.ProjectTaskStateGetType =
					DBObjects.ProjectTask.ProjectTaskStateGetType.UnbilledProjectTasks;
			}
			else
			{
				projectTaskListGetInfo.ProjectTaskStateGetType =
					DBObjects.ProjectTask.ProjectTaskStateGetType.AllProjectTasks;
			}

			FillProjectTaskList();
			PersistProjectTaskListFilter();

			UpdateUI();
		}

		private void newToolStripButton_Click( object sender, EventArgs e )
		{
			neweventToolStripMenuItem_Click( null, null );
		}

		private void toolStripButton1_Click( object sender, EventArgs e )
		{
			saveToolStripMenuItem_Click( null, null );
		}

		private void saveToolStripButton_Click( object sender, EventArgs e )
		{
			toolStripMenuItem1_Click( null, null );
		}

		private void printToolStripButton_Click( object sender, EventArgs e )
		{
			Item.PrintComplete();
		}

		private void printToolStripMenuItem_Click( object sender, EventArgs e )
		{
			printToolStripMenuItem_Click( null, null );
		}

		private void printPreviewToolStripMenuItem_Click( object sender, EventArgs e )
		{
			printToolStripMenuItem_Click( null, null );
		}
	}
}