using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZetaLib.Core.Common;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace ZetaHelpDesk.UpdateCopier
{
	public partial class MainForm : Form
	{
		public MainForm( string[] args )
		{
			this.commandLineArgs = args;
			InitializeComponent();
		}

		private string[] commandLineArgs;

		private void MainForm_Load( object sender, EventArgs e )
		{
			CenterToScreen();
			startTimer.Start();
		}

		private void startTimer_Tick( object sender, EventArgs e )
		{
			lock ( this )
			{
				startTimer.Stop();

				LogCentral.Current.LogInfo(
					string.Format(
					"Started updating."
					) );

				using ( new ZetaLib.Windows.Common.WaitCursor( this ) )
				{
					if ( commandLineArgs.Length < 1 )
					{
						throw new ApplicationException(
							"This application cannot be started directly. (Error: no command line arguments where passed.)" );
					}
					else
					{
						string sourceFolderPath =
							Path.GetDirectoryName(
							Assembly.GetExecutingAssembly().Location );
						// The parent is the correct folder.
						sourceFolderPath = Path.Combine(
							sourceFolderPath,
							".." );

						// Add all to work-around errors in former versions when
						// passing paths with spaces.
						string destinationFolderPath = string.Empty;
						foreach ( string c in commandLineArgs )
						{
							if ( destinationFolderPath.Length > 0 )
							{
								destinationFolderPath += " ";
							}

							destinationFolderPath += c;
						}

						destinationFolderPath =
							destinationFolderPath.Trim( '"', '\'' );

						LogCentral.Current.LogInfo(
							string.Format(
							"About to copy files from folder path '{0}' to folder path '{1}'.",
							sourceFolderPath,
							destinationFolderPath ) );

						string[] sourceFilePaths =
							Directory.GetFiles( sourceFolderPath );

						LogCentral.Current.LogInfo(
							string.Format(
							"About to copy {0} source files.",
							sourceFilePaths.Length ) );

						foreach ( string sourceFilePath in sourceFilePaths )
						{
							Application.DoEvents();

							string destinationFilePath =
								Path.Combine(
								destinationFolderPath,
								Path.GetFileName( sourceFilePath ) );

							LogCentral.Current.LogInfo(
								string.Format(
								"Copying file from '{0}' to '{1}'.",
								sourceFilePath,
								destinationFilePath ) );

							File.Copy( sourceFilePath, destinationFilePath, true );
						}

						// --
						// Launching EXE again.

						string destinationExeFilePath =
							Path.Combine(
							destinationFolderPath,
							"ZetaHelpDesk.Main.exe" );

						string arguments = "deletefolder=" + sourceFolderPath;

						LogCentral.Current.LogInfo(
							string.Format(
							"About to launch ZetaHelpDesk with file path '{0}' and arguments '{1}'.",
							destinationExeFilePath,
							arguments ) );

						// Also copy logfiles for later detecting errors better
						// and make them available for sending to zeta.
						CopyLogFiles( destinationFolderPath );

						ProcessStartInfo info = new ProcessStartInfo();
						info.FileName = destinationExeFilePath;
						info.Arguments = arguments;
						info.UseShellExecute = true;

						Process.Start( info );

						// --

						// Terminate myself.
						Application.Exit();
					}
				}
			}
		}

		private void CopyLogFiles(
			string destinationFolderPath )
		{
			string[] logFilePaths = GetLogFilesPaths();

			if ( logFilePaths != null && logFilePaths.Length > 0 )
			{
				foreach ( string logFilePath in logFilePaths )
				{
					string destinationFilePath =
						Path.Combine(
						destinationFolderPath,
						"UpdateCopier-" + Guid.NewGuid() + ".log" );

					LogCentral.Current.LogInfo(
						string.Format(
						"About to copy log file '{0}' to '{1}'.",
						logFilePath,
						destinationFilePath ) );

					// Actually copy.
					File.Copy( logFilePath, destinationFilePath );
				}
			}
			else
			{
				LogCentral.Current.LogInfo(
					"No log files to copy available." );
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