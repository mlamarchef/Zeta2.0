using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ZetaLib.Windows.Common;

using DBObjects = ZetaHelpDesk.Main.Code.DBObjects;
using Forms = ZetaHelpDesk.Main.Forms;

namespace ZetaHelpDesk.Main.Forms
{
	public partial class UserLoginForm :
		Code.FormBase
	{
		public UserLoginForm()
		{
			InitializeComponent();
		}

		public DBObjects.User User
		{
			get
			{
				return user;
			}
		}

		private DBObjects.User user = null;

		private void UserLoginForm_Load( object sender, EventArgs e )
		{
			CenterToScreen();

			UpdateUI();
		}

		private void UserLoginForm_FormClosing( 
			object sender, 
			FormClosingEventArgs e )
		{
			if ( this.DialogResult == DialogResult.OK )
			{
				DBObjects.User user;

				Cursor = Cursors.WaitCursor;
				try
				{
					user =
						DBObjects.User.GetByUserNameAndPassword(
						textBox1.Text.Trim(),
						textBox2.Text );
				}
				finally
				{
					Cursor = Cursors.WaitCursor;
				}

				if ( user==null )
				{
					MessageBox.Show(
						this,
						"Unknown username or wrong password. Please verify that you entered the correct information and try again.",
						"Error during login",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error );

					this.DialogResult = DialogResult.None;
					e.Cancel = true;
				}
				else
				{
					this.user = user;
				}
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			Close();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			Close();
		}

		private void textBox1_TextChanged( object sender, EventArgs e )
		{
			UpdateUI();
		}

		private void UpdateUI()
		{
			button1.Enabled = textBox1.Text.Trim().Length > 0;
		}
	}
}