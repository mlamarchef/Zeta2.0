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

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class CustomerPersonEditForm :
		Code.FormBase
	{
		#region Public methods.
		// ------------------------------------------------------------------

		public CustomerPersonEditForm(
			DBObjects.CustomerCompany parentItem,
			DBObjects.CustomerPerson item )
		{
			this.parentItem = parentItem;
			this.item = item;

			InitializeComponent();
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		public DBObjects.CustomerCompany ParentItem
		{
			get
			{
				return parentItem;
			}
		}

		public DBObjects.CustomerPerson Item
		{
			get
			{
				return item;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private methods.
		// ------------------------------------------------------------------

		private void FillGenderList()
		{
			genderComboBox.Items.Clear();

			Array states = Enum.GetValues(
				typeof( DBObjects.CustomerPerson.GenderType ) );

			foreach ( DBObjects.CustomerPerson.GenderType state in states )
			{
				genderComboBox.Items.Add( state );
			}
		}

		private void Store()
		{
			item.CompanyID = parentItem.ID;

			item.Remarks = remarksTextBox.Text;

			item.FirstName = name1TextBox.Text;
			item.LastName = name2TextBox.Text;
			item.Address1 = address1TextBox.Text;
			item.Address2 = address2TextBox.Text;
			item.Title = titleTextBox.Text;
			item.Department = departmentTextBox.Text;
			item.Position = positionTextBox.Text;
			item.Zip = zipTextBox.Text;
			item.City = cityTextBox.Text;
			item.Country = countryComboBox.Text;
			item.State = stateComboBox.Text;

			item.Phone = phoneTextBox.Text;
			item.Fax = faxTextBox.Text;
			item.Mobile = mobileTextBox.Text;
			item.EMail = emailTextBox.Text;
			item.Www = wwwTextBox.Text;

			item.Gender = (DBObjects.CustomerPerson.GenderType)Enum.Parse(
				typeof( DBObjects.CustomerPerson.GenderType ),
				genderComboBox.SelectedItem.ToString(),
				true );

			item.Store();
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

			string name1 = name1TextBox.Text.Trim();
			string name2 = name2TextBox.Text.Trim();

			string name = name2;
			if ( name2.Length > 0 && name1.Length > 0 )
			{
				name += ", ";
			}
			name += name1;

			if ( string.IsNullOrEmpty( name ) )
			{
				Text = "Edit customer person - zeta HelpDesk";
			}
			else
			{
				Text = string.Format(
					"{0} - Edit customer person - zeta HelpDesk",
					name.Trim() );
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private DBObjects.CustomerCompany parentItem = null;
		private DBObjects.CustomerPerson item = null;

		// ------------------------------------------------------------------
		#endregion

		#region Handler.
		// ------------------------------------------------------------------

		private void button2_Click( 
			object sender, 
			EventArgs e )
		{
			Store();
		}
		private void CustomerPersonEditForm_Load( 
			object sender, 
			EventArgs e )
		{
			FormHelper.RestoreState( this );
			CenterToParent();

			// Remove for now by code.
			tabControl1.TabPages.Remove( advancedTabPage );

			FillGenderList();
			FillCountryComboBox( countryComboBox );

			remarksTextBox.Text = item.Remarks;

			name1TextBox.Text = item.FirstName;
			name2TextBox.Text = item.LastName;
			address1TextBox.Text = item.Address1;
			address2TextBox.Text = item.Address2;
			titleTextBox.Text = item.Title;
			departmentTextBox.Text = item.Department;
			positionTextBox.Text = item.Position;
			zipTextBox.Text = item.Zip;
			cityTextBox.Text = item.City;
			countryComboBox.Text = item.Country;
			stateComboBox.Text = item.State;
			genderComboBox.SelectedItem = item.Gender;

			phoneTextBox.Text = item.Phone;
			faxTextBox.Text = item.Fax;
			mobileTextBox.Text = item.Mobile;
			emailTextBox.Text = item.EMail;
			wwwTextBox.Text = item.Www;

			UpdateUI();
		}

		private void CustomerPersonEditForm_FormClosing(
			object sender,
			FormClosingEventArgs e )
		{
			FormHelper.SaveState( this );
		}

		private void name1TextBox_TextChanged(
			object sender,
			EventArgs e )
		{
			UpdateUI();
		}

		private void cmdEMail_Click( 
			object sender, 
			EventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = "mailto:" + emailTextBox.Text;

			Process.Start( info );
		}

		private void cmdWww_Click( 
			object sender, 
			EventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.UseShellExecute = true;
			info.FileName = wwwTextBox.Text;

			Process.Start( info );
		}

		private void cmdExportVCard_Click( 
			object sender, 
			EventArgs e )
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

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}