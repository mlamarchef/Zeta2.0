namespace ZetaHelpDesk.Main.Code
{
	#region Using directives.
	// ----------------------------------------------------------------------
	
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Text;
	using System.IO;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public class VCard
	{
		private Hashtable elements = new Hashtable();

		private void SetProperty( 
			string element, 
			string value )
		{
			if ( elements.ContainsKey( element ) )
			{
				elements[element] = value;
			}
			else
			{
				elements.Add( element, value );
			}
		}

		private string GetProperty( 
			string element )
		{
			if ( elements.ContainsKey( element ) )
			{
				return elements[element].ToString();
			}
			else
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// The full name.
		/// </summary>
		public string FullName
		{
			get
			{
				return GetProperty( "FN:" );
			}
			set
			{
				SetProperty( "FN:", value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get
			{
				return GetProperty( "N:" );
			}
			set
			{
				SetProperty( "N:", value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string BusinessTel
		{
			get
			{
				return GetProperty( "TEL;WORK:" );
			}
			set
			{
				SetProperty( "TEL;WORK:", value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string BusinessFax
		{
			get
			{
				return GetProperty( "TEL;FAX:" );
			}
			set
			{
				SetProperty( "TEL;FAX:", value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string HomeTelVoice
		{
			get
			{
				return GetProperty( "TEL;HOME;VOICE:" );
			}
			set
			{
				SetProperty( "TEL;HOME;VOICE:", value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string HomeTelFax
		{
			get
			{
				return GetProperty( "TEL;HOME;FAX:" );
			}
			set
			{
				SetProperty( "TEL;HOME;FAX:", value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CellTelVoice
		{
			get
			{
				return GetProperty( "TEL;CELL;VOICE:" );
			}
			set
			{
				SetProperty( "TEL;CELL;VOICE:", value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string HomeAddress
		{
			get
			{
				return GetProperty( "ADR;HOME:;;:" );
			}
			set
			{
				SetProperty( "ADR;HOME:;;", value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string PreferedInternetEmailAddress
		{
			get
			{
				return GetProperty( "EMAIL;PREF;INTERNET:" );
			}
			set
			{
				SetProperty( "EMAIL;PREF;INTERNET:", value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Organization
		{
			get
			{
				return GetProperty( "ORG:" );
			}
			set
			{
				SetProperty( "ORG:", value );
			}
		}

		/// <summary>
		/// Get the v-card as a string.
		/// </summary>
		/// <returns>Returns the v-card string.</returns>
		public override string ToString()
		{
			StringBuilder stb = new StringBuilder();
			stb.Append( "BEGIN:VCARD\r\n" );
			stb.Append( "VERSION:2.1\r\n" );

			foreach ( DictionaryEntry de in elements )
			{
				stb.Append( de.Key );
				stb.Append( de.Value );
				stb.Append( "\r\n" );
			}

			stb.Append( "END:VCARD\r\n" );
			return stb.ToString();
		}

		/// <summary>
		/// Export as a string.
		/// </summary>
		public string SaveToString()
		{
			return ToString();
		}

		/// <summary>
		/// Export as a stream.
		/// </summary>
		public Stream SaveToStream(
			Encoding encoding )
		{
			string raw = SaveToString();
			return new MemoryStream(
				encoding.GetBytes( raw ) );
		}

		/// <summary>
		/// Export as a stream, using the default encoding.
		/// </summary>
		public Stream SaveToStream()
		{
			return SaveToStream( Encoding.Default );
		}

		/// <summary>
		/// Export as a file.
		/// </summary>
		public void SaveToFile(
			string filePath )
		{
			if ( File.Exists( filePath ) )
			{
				File.Delete( filePath );
			}

			using ( Stream sourceStream = SaveToStream() )
			using ( FileStream destinationStream = new FileStream( 
				filePath, FileMode.Create, FileAccess.Write ) )
			{
				sourceStream.Seek( 0, SeekOrigin.Begin );
				byte[] buffer = new byte[sourceStream.Length];
				sourceStream.Read( buffer, 0, buffer.Length );

				destinationStream.Write( buffer, 0, buffer.Length );
			}
		}
	}
}