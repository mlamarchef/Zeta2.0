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

	using ZetaLib.Windows.Common;

	using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;
	using System.Diagnostics;
	using System.IO;
	using ZetaHelpDesk.Main.Properties;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class CustomerCompanyEditForm :
		Code.FormBase
	{
		public CustomerCompanyEditForm(
			DBObjects.CustomerCompany item )
		{
			this.item = item;

			InitializeComponent();
		}

		private DBObjects.CustomerCompany item = null;

		public DBObjects.CustomerCompany Item
		{
			get
			{
				return item;
			}
		}

		private void CustomerCompanyEditForm_Load( 
			object sender, 
			EventArgs e )
		{
			FormHelper.RestoreState( this );
			RestoreState( mainTicketsSplitContainer );
			CenterToParent();
			personsListView_Resize( null, null );

			// Remove for now by code.
			tabControl1.TabPages.Remove( advancedTabPage );

			customerCompanySupportContractInfoControl.SetCustomerCompany( item );

			FillCountryComboBox( countryComboBox );

			remarksTextBox.Text = item.Remarks;

			name1TextBox.Text = item.Name1;
			name2TextBox.Text = item.Name2;
			address1TextBox.Text = item.Address1;
			address2TextBox.Text = item.Address2;
			zipTextBox.Text = item.Zip;
			cityTextBox.Text = item.City;
			countryComboBox.Text = item.Country;
			stateComboBox.Text = item.State;

			phoneTextBox.Text = item.Phone;
			faxTextBox.Text = item.Fax;
			mobileTextBox.Text = item.Mobile;
			emaiTextBox.Text = item.EMail;
			wwwTextBox.Text = item.Www;

			FillPersonsList();
			UpdateUI();
		}

		private void FillPersonsList()
		{
			personsListView.Items.Clear();

			DBObjects.CustomerPerson[] persons = item.Persons;

			if ( persons!=null )
			{
				foreach( DBObjects.CustomerPerson person in persons )
				{
					ListViewItem listViewItem = new ListViewItem(
						new string[]
						{
							person.LastName + ", " + person.FirstName
						} );

					listViewItem.ImageIndex = 0;
					listViewItem.Tag = person;

					personsListView.Items.Add( listViewItem );
				}
			}
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

			if ( string.IsNullOrEmpty( name1TextBox.Text.Trim() ) )
			{
				Text = "Edit customer company - zeta HelpDesk";
			}
			else
			{
				Text = string.Format(
					"{0} - edit customer company - zeta HelpDesk",
					name1TextBox.Text.Trim() );
			}
		}

		private void Store()
		{
			item.Remarks = remarksTextBox.Text;
			
			item.Name1 = name1TextBox.Text;
			item.Name2 = name2TextBox.Text;
			item.Address1 = address1TextBox.Text;
			item.Address2 = address2TextBox.Text;
			item.Zip = zipTextBox.Text;
			item.City = cityTextBox.Text;
			item.Country = countryComboBox.Text;
			item.State = stateComboBox.Text;

			item.Phone = phoneTextBox.Text;
			item.Fax = faxTextBox.Text;
			item.Mobile = mobileTextBox.Text;
			item.EMail = emaiTextBox.Text;
			item.Www = wwwTextBox.Text;

			item.Store();

			// --
			// Notify parent.

			MainForm mainForm = Owner as MainForm;

			mainForm.RefillCustomerCompanyList();
			mainForm.RefillTicketCustomerCompanyTree();
		}

		private void saveToolStripMenuItem_Click( 
			object sender, 
			EventArgs e )
		{
			Store();
		}

		private void newToolStripMenuItem_Click( 
			object sender, 
			EventArgs e )
		{
			// Must store parent before adding child.
			Store();

			DBObjects.CustomerPerson person = 
				new DBObjects.CustomerPerson();

			CustomerPersonEditForm form = 
				new CustomerPersonEditForm( item, person );

			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				FillPersonsList();
			}
		}

		private void personsListView_DoubleClick( 
			object sender, 
			EventArgs e )
		{
			DBObjects.CustomerPerson person =
				personsListView.SelectedItems[0].Tag as
				DBObjects.CustomerPerson;

			CustomerPersonEditForm form = 
				new CustomerPersonEditForm( item, person );

			if ( form.ShowDialog( this ) == DialogResult.OK )
			{
				FillPersonsList();
			}
		}

		private void CustomerCompanyEditForm_FormClosing( 
			object sender, 
			FormClosingEventArgs e )
		{
			FormHelper.SaveState( this );
			SaveState( mainTicketsSplitContainer );
		}

		private void personsListView_Resize( 
			object sender, 
			EventArgs e )
		{
			if ( Settings.Default.AutoSizeListViewColumns )
			{
				FormHelper.SizeListView(
								personsListView,
								new double[]
				{
					0.99
				} );
			}
		}

		private void name1TextBox_TextChanged( 
			object sender, 
			EventArgs e )
		{
			UpdateUI();
		}

		private void exitToolStripMenuItem_Click( 
			object sender, 
			EventArgs e )
		{
			Close();
			this.DialogResult = DialogResult.OK;
		}

		private void toolStripButton1_Click( object sender, EventArgs e )
		{
			Store();
			Close();
			this.DialogResult = DialogResult.OK;
		}

		private void cmdEMail_Click( object sender, EventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = "mailto:" + emaiTextBox.Text;

			Process.Start( info );
		}

		private void cmdWww_Click( object sender, EventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = wwwTextBox.Text;

			Process.Start( info );
		}

		private void personsListView_SelectedIndexChanged( 
			object sender, 
			EventArgs e )
		{
			if ( personsListView.SelectedItems.Count > 0 )
			{
				DBObjects.CustomerPerson person =
					personsListView.SelectedItems[0].Tag as
					DBObjects.CustomerPerson;

				customerPersonInfoControl.SetCustomerPerson(
					person );
			}
			else
			{
				customerPersonInfoControl.SetCustomerPerson(
					null );
			}
		}

		private void cmdExportVCard_Click( object sender, EventArgs e )
		{
			string path = Path.Combine(
				Path.GetTempPath(),
				Guid.NewGuid().ToString( "N" ) + ".vcf" );

			item.VCard.SaveToFile( path );

			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = path;

			Process.Start( info );
		}
	}

	/////////////////////////////////////////////////////////////////////////
}