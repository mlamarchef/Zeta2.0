namespace ZetaHelpDesk.Main.Code.DBObjects
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Data;
	using System.Data.OleDb;
	using System.Collections.Generic;
	using System.Text;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;
	using System.IO;
	using System.Diagnostics;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public abstract class Base
	{
		#region Static routines.
		// ------------------------------------------------------------------
		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		public virtual bool IsEmpty
		{
			get
			{
				return id <= 0;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Field properties.
		// ------------------------------------------------------------------

		public virtual int ID
		{
			get
			{
				return id;
			}
		}

		public DateTime DateCreated
		{
			get
			{
				return dateCreated;
			}
		}

		public string UserSamNameCreated
		{
			get
			{
				return userSamNameCreated;
			}
		}

		public User UserCreated
		{
			get
			{
				return User.GetBySamName( userSamNameCreated );
			}
		}

		public DateTime DateModified
		{
			get
			{
				return dateModified;
			}
		}

		public string UserSamNameModified
		{
			get
			{
				return userSamNameModified;
			}
		}

		public User UserModified
		{
			get
			{
				return User.GetBySamName( userSamNameModified );
			}
		}

		public string Remarks
		{
			get
			{
				return remarks;
				/*
				if ( hasRemarks )
				{
					return remarks;
				}
				else
				{
					throw new ApplicationException( "No remarks available for this object." );
				}
				 */
			}
			set
			{
				remarks = value;
				/*
				if ( hasRemarks )
				{
					remarks = value;
				}
				else
				{
					throw new ApplicationException( "No remarks available for this object." );
				}
				 */ 
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Printing.
		// ------------------------------------------------------------------

		public void PrintComplete()
		{
			string html = PrintToHtml();

			string htmlFilePath =
				Path.Combine(
				Path.GetTempPath(),
				Guid.NewGuid().ToString( "N" ) + ".html" );

			if ( File.Exists( htmlFilePath ) )
			{
				File.Delete( htmlFilePath );
			}

			using ( StreamWriter fs = new StreamWriter(
				htmlFilePath,
				false,
				Encoding.Unicode ) )
			{
				fs.Write( html );
			}

			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = htmlFilePath;
			startInfo.UseShellExecute = true;

			Process.Start( startInfo );

			// Remember to cleanup upon exit.
			Forms.MainForm.Current.AddTempFileToDelete( htmlFilePath );
		}

		protected virtual string PrintToHtml()
		{
			throw new NotImplementedException(
				"Don't call PrintToHtml() directly. Must override." );
		}

		protected string GetPrintingHtmlFramework(
			string title,
			string bodyContentHtml )
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat( "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\">\r\n" );
			sb.AppendFormat( "<html>\r\n" );

			sb.AppendFormat( "	<head>\r\n" );
			sb.AppendFormat( "		<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-16\" />\r\n" );
			sb.Append( "		<title>{Title} - zeta HelpDesk</title>\r\n".Replace( "{Title}", title ) );
			sb.Append(
				@"<style type='text/css'>
						code         { font-family: Courier New, Courier; font-size: 10pt; color: #800000; line-height:130% }
						pre          { font-family: Courier New, Courier; font-size: 10pt; color: #800000; background-color: #EFEFEF; line-height:130% }

						h1           { font-family: Verdana; font-size: 18pt; font-weight: bold; margin-top:24pt; }
						h2           { font-family: Verdana; font-size: 14pt; font-weight: bold; margin-top: 21pt }
						h3           { font-family: Verdana; font-size: 12pt; font-weight: bold; margin-top: 18pt }
						h4           { font-family: Verdana; font-size: 10pt; font-weight: bold; margin-top: 15pt }
						p            { font-family: Verdana; font-size: 10pt; line-height: 130% }
						ul			 { font-family: Verdana; font-size: 10pt; margin-left: 12pt; line-height: 130%; }
						li           { font-family: Verdana; font-size: 10pt; line-height: 130%; text-indent:0pt; margin-bottom: 5pt; }

						small		 { font-family: Verdana; font-size: 8pt; line-height: 130%; }
						big		 	 { font-family: Verdana; font-size: 12pt; line-height: 130%; }

						th           { font-family: Verdana; font-size: 10pt; line-height: 130%; font-weight: bold; }
						td           { font-family: Verdana; font-size: 10pt; line-height: 130%; }
						table        { border-width: 0; }

						table.data th   { text-align:left; padding:4px; background-color: #DCDCDC; }
						table.data td   { padding:4px; background-color: #EFEFEF; }

						table.dataTicket th   { text-align:left; padding:4px; background-color: #8bfa41; }
						table.dataTicket td   { padding:4px; background-color: #dbffb7; }

						table.dataTicketEvent th   { text-align:left; padding:4px; background-color: #99ccff; }
						table.dataTicketEvent td   { padding:4px; background-color: #d9ecff; }
					</style>" );
			sb.AppendFormat( "	</head>\r\n" );

			sb.AppendFormat( "	<body>\r\n" );

			// --
			// The main ticket.

			sb.Append( "		<h1>{Title}</h1>\r\n".Replace( "{Title}", title ) );

			sb.Append( bodyContentHtml + "\r\n" );

			sb.AppendFormat( "	</body>\r\n" );

			sb.Append( "</html>\r\n" );

			return sb.ToString();
		}

		// ------------------------------------------------------------------
		#endregion

		#region Protected routines.
		// ------------------------------------------------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		protected Base()
		{
			// Avoid recursion.
			if ( !( this is User ) )
			{
				DBObjects.User user = DBObjects.User.CurrentUser;

				if ( user != null )
				{
					userSamNameCreated = user.SamName;
					userSamNameModified = user.SamName;
				}
			}
		}

		protected virtual void Load(
			DataRow row )
		{
			if ( row != null )
			{
				DataColumnCollection columns = row.Table.Columns;

				if ( columns.Contains( "ID" ) )
				{
					DBHelper.ReadField( out id, row["ID"] );
				}
				if ( columns.Contains( "DateCreated" ) )
				{
					DBHelper.ReadField( out dateCreated, row["DateCreated"] );
				}
				if ( columns.Contains( "UserSamNameCreated" ) )
				{
					DBHelper.ReadField( out userSamNameCreated, row["UserSamNameCreated"] );
				}
				if ( columns.Contains( "DateModified" ) )
				{
					DBHelper.ReadField( out dateModified, row["DateModified"] );
				}
				if ( columns.Contains( "UserSamNameModified" ) )
				{
					DBHelper.ReadField( out userSamNameModified, row["UserSamNameModified"] );
				}

				if ( columns.Contains( "Remarks" ) )
				{
					DBHelper.ReadField( out remarks, row["Remarks"] );
					/*
					hasRemarks = true;
					 */
				}
				else
				{
					/*
					hasRemarks = false;
					 */
				}
			}
		}

		protected virtual void Store(
			DataRow row )
		{
			DBObjects.User user = DBObjects.User.CurrentUser;

			if ( user != null )
			{
				userSamNameModified = user.SamName;
			}

			dateModified = DateTime.Now;

			// --

			if ( row != null )
			{
				DataColumnCollection columns = row.Table.Columns;

				if ( columns.Contains( "DateCreated" ) )
				{
					row["DateCreated"] = DBHelper.WriteField( dateCreated );
				}
				if ( columns.Contains( "UserSamNameCreated" ) )
				{
					row["UserSamNameCreated"] = DBHelper.WriteField( userSamNameCreated );
				}
				if ( columns.Contains( "DateModified" ) )
				{
					row["DateModified"] = DBHelper.WriteField( dateModified );
				}
				if ( columns.Contains( "UserSamNameModified" ) )
				{
					row["UserSamNameModified"] = DBHelper.WriteField( userSamNameModified );
				}
				if ( columns.Contains( "Remarks" ) )
				{
					row["Remarks"] = DBHelper.WriteField( remarks );
				}
			}
		}

		/// <summary>
		/// Helper for trimming.
		/// </summary>
		protected string TrimAndRemoveEmptyLines(
			string s )
		{
			if ( string.IsNullOrEmpty( s ) )
			{
				return s;
			}
			else
			{
				s = s.Replace( "\n\n", "\n" );
				s = s.Replace( "\n\n", "\n" );
				s = s.Replace( "\r", "\r" );
				s = s.Replace( "\r", "\r" );
				s = s.Replace( "\r\n", "\r\n" );
				s = s.Replace( "\r\n", "\r\n" );

				s = s.Replace( "  ", " " );
				s = s.Replace( "  ", " " );

				s = s.Trim();

				return s;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		protected int id = 0;
		protected DateTime dateCreated = DateTime.Now;
		protected string userSamNameCreated = null;
		protected DateTime dateModified = DateTime.Now;
		protected string userSamNameModified = null;

		/*
		private bool hasRemarks = false;
		*/
		private string remarks = null;

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}