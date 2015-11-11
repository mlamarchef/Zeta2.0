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
	using ZetaLib.Core.Common;
	using System.Diagnostics;
	using System.Collections;
	using System.IO;
	using System.Reflection;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public partial class ErrorForm :
		Code.FormBase
	{
		public ErrorForm(
			Exception e )
		{
			InitializeComponent();

			// Set message.
			this.exception = e;
			textBox1.Text = e.Message;
		}

		private void ErrorForm_Load(
			object sender,
			EventArgs e )
		{
			ErrorFormShowingCount++;
			FormHelper.RestoreState( this );
			CenterToScreen();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Abort;
			Close();
		}

		private void ErrorForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			ErrorFormShowingCount--;
			FormHelper.SaveState( this );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			button3.ContextMenuStrip.Show(
				button3,
				new Point( 0, button3.Height ) );
		}

		private void executeSQLQueryToolStripMenuItem_Click( object sender, EventArgs e )
		{
			SqlForm form = new SqlForm();
			form.ShowDialog( this );
		}

		private void contextMenuStrip1_Opening( object sender, CancelEventArgs e )
		{
			UpdateUI();
		}

		private void UpdateUI()
		{
			executeSQLQueryToolStripMenuItem.Enabled = 
				reportThisErrorToolStripMenuItem.Enabled =
				ErrorFormShowingCount <= 1;
		}

		private static int ErrorFormShowingCount
		{
			get
			{
				lock ( typeof( ErrorForm ) )
				{
					return errorFormShowingCount;
				}
			}
			set
			{
				lock ( typeof( ErrorForm ) )
				{
					errorFormShowingCount = value;
				}
			}
		}

		private static int errorFormShowingCount = 0;

		private void openApplicationConfigurationFileForEditingToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.FileName =
				LogCentral.ExpandFilePathMacros(
				string.Format(
				"${{Environment.SystemDirectory}}\\notepad.exe" ) );
			info.Arguments =
				string.Format(
				"\"{0}\"",
				LogCentral.Current.ConfigurationFilePath );

			info.UseShellExecute = false;

			Process.Start( info );
		}

		private void reportThisErrorToolStripMenuItem_Click(
			object sender,
			EventArgs e )
		{
			if ( MessageBox.Show(
				this,
				"Do you want to send the error message to zeta software now?\r\n\r\nPlease note: You must be connected to the internet.",
				"zeta HelpDesk",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
			{
				using ( new ZetaLib.Windows.Common.WaitCursor( this ) )
				{
					ZetaUploader.Communication ws =
						new ZetaUploader.Communication();

					ZetaUploader.SendFileInformation sendInfo =
						new ZetaUploader.SendFileInformation();
					sendInfo.EMailSubject = "[zeta HelpDesk] Error occured";
					sendInfo.FileName = "ZetaHelpDeskError.zip";
					sendInfo.ReceiverEMailAddresses =
						new string[]
						{
							"uwe.keim@zeta-software.de"
						};

					CompressionHelper.CompressStringsInfo compressInfo = 
						new CompressionHelper.CompressStringsInfo();

					compressInfo.AddString(
						LogCentral.MakeTraceMessage(
						exception ),
						"ZetaHelpDeskError.txt" );
					compressInfo.AddString(
						LoggingInformation.All,
						"EnvironmentInfo.txt" );

					sendInfo.FileContent = 
						CompressionHelper.CompressStrings( 
						compressInfo );

					ws.SendFileEx( sendInfo );

					reportThisErrorToolStripMenuItem.Enabled = false;
					MessageBox.Show(
						this,
						"The error message was successfully sent to zeta software. Thank you!",
						"zeta HelpDesk",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information );
				}
			}
		}

		private Exception exception = null;

		private void sendLogfilesToZetaSoftwareToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if ( MessageBox.Show(
				this,
				"Do you want to send the zeta HelpDesk logfiles to zeta software now?\r\n\r\nPlease note: You must be connected to the internet.",
				"zeta HelpDesk",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
			{
				using ( new ZetaLib.Windows.Common.WaitCursor( this ) )
				{
					string[] logFilePaths = GetLogFilesPaths();

					if ( logFilePaths == null || logFilePaths.Length <= 0 )
					{
						MessageBox.Show(
							this,
							"No logfiles were found.",
							"zeta HelpDesk",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information );
					}
					else
					{
						ZetaUploader.Communication ws =
							new ZetaUploader.Communication();

						ArrayList tempLogFilePaths = new ArrayList();

						int index = 1;
						foreach ( string logFilePath in logFilePaths )
						{
							string tempLogFilePath =
								Path.Combine(
								Path.GetTempPath(),
								StringHelper.AddZerosPrefix( index, 2 ) + "-" +
								Guid.NewGuid() + ".log" );

							File.Copy(
								logFilePath,
								tempLogFilePath );

							tempLogFilePaths.Add( tempLogFilePath );

							index++;
						}

						try
						{
							ws.SendFile(
								"zeta HelpDesk logfiles.zip",
								CompressionHelper.CompressFiles(
								(string[])tempLogFilePaths.ToArray( typeof( string ) ) ),
								"uwe.keim@zeta-software.de",
								"Logfile(s) for zeta HelpDesk" );
						}
						finally
						{
							foreach ( string tempLogFilePath in tempLogFilePaths )
							{
								if ( File.Exists( tempLogFilePath ) )
								{
									File.Delete( tempLogFilePath );
								}
							}
						}

						MessageBox.Show(
							this,
							"The logfiles were successfully sent to zeta software.",
							"zeta HelpDesk",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information );
					}
				}
			}
		}

		private string[] GetLogFilesPaths()
		{
			return Directory.GetFiles(
				Path.GetDirectoryName(
				Assembly.GetExecutingAssembly().Location ),
				"*.log" );
		}
	}
}