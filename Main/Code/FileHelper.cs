using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace ZetaHelpDesk.Main.Code
{
	class FileHelper
	{
		/// <summary>
		/// Singleton access.
		/// </summary>
		public FileHelper Current
		{
			get
			{
				lock ( typeof( FileHelper ) )
				{
					if ( current == null )
					{
						current = new FileHelper();
					}

					return current;
				}
			}
		}

		public string GetTemporaryFilePath()
		{
			string tempFilePath = Path.GetTempFileName();

			temporaryFilePaths.Add( tempFilePath );
			return tempFilePath;
		}

		/// <summary>
		/// Destructor.
		/// </summary>
		~FileHelper()
		{
			foreach ( string filePath in temporaryFilePaths )
			{
				File.Delete( filePath );
			}
		}

		private ArrayList temporaryFilePaths = new ArrayList();
		private FileHelper current = null;
	}
}
