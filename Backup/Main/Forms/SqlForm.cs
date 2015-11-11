using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ZetaLib.Core.Common;
using ZetaLib.Windows.Common;
using ZetaHelpDesk.Main.Code;
using ZetaLib.Core.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;

namespace ZetaHelpDesk.Main.Forms
{
	public partial class SqlForm : 
		FormBase
	{
		public SqlForm()
		{
			InitializeComponent();
		}

		private void SqlForm_Load(
			object sender,
			EventArgs e )
		{
			RestoreState( this );
			CenterToParent();

			connectionStringComboBox.Text =
				FormHelper.RestoreValue(
				"Main.Forms.SqlForm.connectionStringComboBox.Text" ) as string;
			sqlQueryTextBox.Text =
				FormHelper.RestoreValue(
				"Main.Forms.SqlForm.sqlQueryTextBox.Text" ) as string;

			// Initially select default.
			if ( connectionStringComboBox.Text.Trim().Length <= 0 )
			{
				connectionStringComboBox.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// The connection string to use.
		/// </summary>
		private string effectiveConnectionString
		{
			get
			{
				string itemZero = connectionStringComboBox.Items[0] as string;
				if ( itemZero==null )
				{
					itemZero = string.Empty;
				}
				itemZero = itemZero.Trim().ToLower();

				if ( connectionStringComboBox.Text.Trim().ToLower()==
					itemZero )
				{
					return ZetaLib.Core.LibraryConfiguration.Current.Database.ConnectionString;
				}
				else
				{
					return connectionStringComboBox.Text.Trim();
				}
			}
		}

		private void SqlForm_FormClosing(
			object sender,
			FormClosingEventArgs e )
		{
			SaveState( this );

			FormHelper.SaveValue(
				"Main.Forms.SqlForm.connectionStringComboBox.Text",
				connectionStringComboBox.Text );
			FormHelper.SaveValue(
				"Main.Forms.SqlForm.sqlQueryTextBox.Text",
				sqlQueryTextBox.Text );
		}

		private void UpdateUI()
		{
			buttonSaveQuery.Enabled =
				buttonExecuteQuery.Enabled =
				sqlQueryTextBox.Text.Trim().Length > 0/* &&
				connectionStringComboBox.Text.Trim().Length > 0*/;
		}

		private class ExecuteQueryResult
		{
			public enum ResultType
			{
				Success,
				ZetaCommand
			}

			public ExecuteQueryResult(
				string message,
				ResultType resultType )
			{
				this.message = message;
				this.resultType = resultType;
			}

			private string message;

			public string Message
			{
				get
				{
					return message;
				}
				set
				{
					message = value;
				}
			}
			private ResultType resultType;

			public ResultType ResultType1
			{
				get
				{
					return resultType;
				}
				set
				{
					resultType = value;
				}
			}
		}

		private void buttonExecuteQuery_Click(
			object sender,
			EventArgs e )
		{
			resultTextBox.Text = string.Empty;

			ArrayList results;
			DataSet ds = null;

			using ( new ZetaLib.Windows.Common.WaitCursor( this ) )
			{
				ds = ExecuteQuery(
					effectiveConnectionString,
					sqlQueryTextBox.Text.Trim(),
					out results );
			}

			bool hasErrors = false;
			foreach ( object o in results )
			{
				if ( o is Exception )
				{
					hasErrors = true;
					break;
				}
			}

			if ( hasErrors )
			{
				MessageBox.Show(
					this,
					"Errors occured during execution of the SQL query.\r\n\r\nPlease review the output for details.",
					"zeta HelpDesk",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error );

				resultTextBox.AppendTextAsRtf(
					string.Format(
					"{0}. The SQL query was executed with errors.\r\n",
					DateTime.Now ),
					RtfColor.Red );
			}
			else
			{
				MessageBox.Show(
					this,
					"The SQL query was successfully executed.",
					"zeta HelpDesk",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information );

				resultTextBox.AppendTextAsRtf(
					string.Format(
					"{0}. The SQL query was successfully executed.\r\n",
					DateTime.Now ),
					RtfColor.Black );
			}

			// --

			int index = 1;
			foreach ( object o in results )
			{
				if ( o is Exception )
				{
					Exception x = o as Exception;

					resultTextBox.AppendTextAsRtf(
						string.Format(
						"[{0}/{1}] ##### ERROR: {2}\r\n",
						index,
						results.Count,
						x.Message ),
						RtfColor.Red );
				}
				else
				{
					Debug.Assert( o is ExecuteQueryResult );
					ExecuteQueryResult s = o as ExecuteQueryResult;

					RtfColor color;
					switch ( s.ResultType1 )
					{
						default:
						case ExecuteQueryResult.ResultType.Success:
							color = RtfColor.Black;
							break;
						case ExecuteQueryResult.ResultType.ZetaCommand:
							color = RtfColor.Green;
							break;
					}

					resultTextBox.AppendTextAsRtf(
						string.Format(
						"[{0}/{1}] {2}\r\n",
						index,
						results.Count,
						s.Message ),
						color );
				}

				index++;
			}

			// --

			resultTextBox.Select( 0, 0 );

			if ( ds == null || ds.Tables.Count<=0 )
			{
				tabControl1.SelectedTab = resultTextTabPage;
			}
			else
			{
				resultDataGridView.DataSource = ds.Tables[0];

				tabControl1.SelectedTab = resultGridTabPage;
			}
		}

		private DataSet ExecuteQuery(
			string connectionString,
			string sql,
			out ArrayList results )
		{
			string originalConnectionString = connectionString;
			sql = "\n" + sql + "\n";

			results = new ArrayList();

			string batchSeparator = "GO";

			Regex regex = new Regex(
			   @"(\n\s*" + batchSeparator + @"\s*\n)(?!\s*\*\/)",
			   RegexOptions.IgnoreCase |
			   RegexOptions.Singleline |
			   RegexOptions.Compiled );

			string[] strings = regex.Split( sql );

			DataSet ds = null;
			for ( int i = 0; i < strings.Length; i++ )
			{
				string s = strings[i];

				if ( (!regex.IsMatch( s )) && (s != string.Empty) )
				{
					try
					{
						string zetaCommandStart = "<zeta:connectionString>";
						string zetaCommandEnd = "</zeta:connectionString>";

						int indexZetaCommandStart = s.IndexOf( zetaCommandStart );
						int indexZetaCommandEnd = s.IndexOf( zetaCommandEnd );

						// Change the connection string.
						if ( indexZetaCommandStart >= 0 &&
							indexZetaCommandEnd > indexZetaCommandStart )
						{
							string command =
								s.Substring(
								indexZetaCommandStart + zetaCommandStart.Length,
								indexZetaCommandEnd - (indexZetaCommandStart + zetaCommandStart.Length) );

							connectionString = command;

							results.Add(
								new ExecuteQueryResult(
								string.Format(
								"Changed connection string to '{0}'.",
								command ),
								ExecuteQueryResult.ResultType.ZetaCommand ) );

							s = s.Remove(
								indexZetaCommandStart,
								(indexZetaCommandEnd + zetaCommandEnd.Length) -
								indexZetaCommandStart ).Trim();
						}

						if ( s.Length>0 )
						{
							ds = AdoNetSqlHelper.Execute(
								connectionString,
								s );

							results.Add(
								new ExecuteQueryResult(
								"Success.",
								ExecuteQueryResult.ResultType.Success ) );
						}
					}
					catch ( SqlException x )
					{
						results.Add( x );
						LogCentral.Current.LogError(
							"Caught SQL exception.",
							x );
					}
				}
			}

			return ds;
			/*
			return AdoNetSqlHelper.Execute(
				connectionString,
				sql );
			 */

			/*if ( returnsResult )*/
			{
		//		return AdoNetSqlHelper.Execute(
		//			connectionString,
		//			sql );
			}
			/*else
			{
				AdoNetSqlHelper.ExecuteNonQuery(
					connectionString,
					sql );
				return null;
			}
			 */

			/*
			using ( SqlConnection conn = new SqlConnection( connectionString ) )
			{
				conn.Open();

				SqlCommand cmd = new SqlCommand( sql, conn );

				// Apply command timeouts, if any.
				AdoNetSqlHelper.CheckSetCommandTimeout( cmd );

				AdoNetSqlHelper.TraceSql( sql, true, null );
				try
				{
					cmd.ExecuteNonQuery();
				}
				catch ( Exception x )
				{
					AdoNetSqlHelper.TraceSqlError( sql, x );
					throw;
				}
				AdoNetSqlHelper.TraceSql( sql, false, null );
			}
			 */
		}

		private void connectionStringComboBox_SelectedIndexChanged( 
			object sender, 
			EventArgs e )
		{
			UpdateUI();
		}

		private void sqlQueryTextBox_TextChanged( 
			object sender,
			EventArgs e )
		{
			UpdateUI();
		}

		private void connectionStringComboBox_TextChanged(
			object sender,
			EventArgs e )
		{
			UpdateUI();
		}

		private void buttonLoadQuery_Click(
			object sender,
			EventArgs e )
		{
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.AddExtension = true;
			dialog.DefaultExt = ".sql";
			dialog.DereferenceLinks = true;
			dialog.ValidateNames = true;

			string initialFolderPath =
				FormHelper.RestoreValue(
				"Main.Forms.SqlForm.LoadQuery.InitialFolderPath" )
				as string;

			if ( !string.IsNullOrEmpty( initialFolderPath ) &&
				Directory.Exists( initialFolderPath ) )
			{
				dialog.InitialDirectory = initialFolderPath;
			}

			// --

			if ( dialog.ShowDialog( this ) == DialogResult.OK )
			{
				using ( StreamReader sr = new StreamReader(
					dialog.FileName, Encoding.Unicode, true ) )
				{
					sqlQueryTextBox.Text = sr.ReadToEnd();
				}

				FormHelper.SaveValue(
					"Main.Forms.SqlForm.LoadQuery.InitialFolderPath",
					Path.GetDirectoryName( dialog.FileName ) );
			}
		}

		private void buttonSaveQuery_Click( 
			object sender,
			EventArgs e )
		{
			SaveFileDialog dialog = new SaveFileDialog();

			dialog.AddExtension = true;
			dialog.DefaultExt = ".sql";
			dialog.DereferenceLinks = true;
			dialog.FileName = Guid.NewGuid().ToString() + ".sql";
			dialog.ValidateNames = true;
			dialog.OverwritePrompt = true;

			string initialFolderPath =
				FormHelper.RestoreValue(
				"Main.Forms.SqlForm.LoadQuery.InitialFolderPath" )
				as string;

			if ( !string.IsNullOrEmpty( initialFolderPath ) &&
				Directory.Exists( initialFolderPath ) )
			{
				dialog.InitialDirectory = initialFolderPath;
			}

			// --

			if ( dialog.ShowDialog( this ) == DialogResult.OK )
			{
				using ( StreamWriter sw = new StreamWriter(
					dialog.FileName, false, Encoding.Unicode ) )
				{
					sw.Write( sqlQueryTextBox.Text.Trim() );
				}

				FormHelper.SaveValue(
					"Main.Forms.SqlForm.LoadQuery.InitialFolderPath",
					Path.GetDirectoryName( dialog.FileName ) );
			}
		}

		private void SqlForm_KeyPress( 
			object sender, 
			KeyPressEventArgs e )
		{
		}
	}

	/*
	public class RtfHelper
	{
		public RtfHelper(
			RichTextBox rtf )
		{
			this.rtf = rtf;
		}

		public void AppendTextAsRtf( 
			string _text, 
			Font _font,
			RtfColor _textColor, RtfColor _backColor )
		{
			// Move carret to the end of the text
			rtf.Select( this.TextLength, 0 );

			InsertTextAsRtf( _text, _font, _textColor, _backColor );
		}

		/// Appends the text using the current font, text, and highlight colors.
		public void AppendTextAsRtf( string _text )
		{
			AppendTextAsRtf( _text, rtf.Font );
		}

		/// Appends the text using the given font, and 
		/// current text and highlight colors.
		public void AppendTextAsRtf( string _text, Font _font )
		{
			AppendTextAsRtf( _text, _font, textColor );
		}

		/// Appends the text using the given font and text color, and the current
		/// highlight color.
		public void AppendTextAsRtf( string _text, Font _font, RtfColor _textColor )
		{
			AppendTextAsRtf( _text, _font, _textColor, highlightColor );
		}

		public void InsertTextAsRtf( 
			string _text, 
			Font _font,
			RtfColor _textColor, 
			RtfColor _backColor )
		{

			StringBuilder _rtf = new StringBuilder();

			// Append the RTF header
			_rtf.Append( RTF_HEADER );

			// Create the font table from the font passed in and append it to the
			// RTF string
			_rtf.Append( GetFontTable( _font ) );

			// Create the color table from the colors passed in and append it to the
			// RTF string
			_rtf.Append( GetColorTable( _textColor, _backColor ) );

			// Create the document area from the text to be added as RTF and append
			// it to the RTF string.
			_rtf.Append( GetDocumentArea( _text, _font ) );

			rtf.SelectedRtf = _rtf.ToString();
		}

		/// Inserts the text using the current font, text, and highlight colors.
		public void InsertTextAsRtf( string _text )
		{
			InsertTextAsRtf( _text, this.Font );
		}


		/// Inserts the text using the given font, and current text and highlight
		/// colors.
		public void InsertTextAsRtf( string _text, Font _font )
		{
			InsertTextAsRtf( _text, _font, textColor );
		}


		/// Inserts the text using the given font and text color, and the current
		/// highlight color.
		public void InsertTextAsRtf( string _text, Font _font,
		  RtfColor _textColor )
		{
			InsertTextAsRtf( _text, _font, _textColor, highlightColor );
		}

		private RichTextBox rtf;
	}
	 */
}