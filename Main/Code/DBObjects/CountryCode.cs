namespace ZetaHelpDesk.Main.Code.DBObjects
{
	#region Using directives.
	// ----------------------------------------------------------------------

	using System;
	using System.Data;
	using System.Data.OleDb;
	using System.Collections.Generic;
	using System.Text;
	using System.Collections;

	using ZetaLib.Core.Common;
	using ZetaLib.Core.Data;

	// ----------------------------------------------------------------------
	#endregion

	/////////////////////////////////////////////////////////////////////////

	public class CountryCode :
		Base,
		ILockable
	{
		#region Static methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Load an object by a given ID.
		/// </summary>
		public static CountryCode GetByID(
			int id )
		{
			DataRow row = AdoNetSqlHelper.ExecuteRow(
				"GetCountryCodeByID",
				new AdoNetSqlParamCollection(
				AdoNetSqlParamCollection.CreateParameter( "@ID", id )
				) );

			if ( row == null )
			{
				return null;
			}
			else
			{
				CountryCode o = new CountryCode();
				o.Load( row );

				if ( o.IsEmpty )
				{
					return null;
				}
				else
				{
					return o;
				}
			}
		}

		/// <summary>
		/// Load all.
		/// </summary>
		public static CountryCode[] GetAll()
		{
			DataTable table = AdoNetSqlHelper.ExecuteTable(
				"GetAllCountryCodes",
				new AdoNetSqlParamCollection(
				) );

			if ( table == null )
			{
				return null;
			}
			else
			{
				ArrayList result = new ArrayList();

				foreach ( DataRow row in table.Rows )
				{
					CountryCode o = new CountryCode();
					o.Load( row );

					if ( !o.IsEmpty )
					{
						result.Add( o );
					}
				}

				if ( result.Count <= 0 )
				{
					return null;
				}
				else
				{
					return (CountryCode[])result.ToArray(
						typeof( CountryCode ) );
				}
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public methods.
		// ------------------------------------------------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		public CountryCode()
		{
		}

		/// <summary>
		/// Use this version for displaying in lists etc.
		/// </summary>
		public override string ToString()
		{
			return NameEN;
		}

		// ------------------------------------------------------------------
		#endregion

		#region Public properties.
		// ------------------------------------------------------------------

		public string Code2
		{
			get
			{
				return code2;
			}
			set
			{
				code2 = value;
			}
		}

		public string Code3
		{
			get
			{
				return code3;
			}
			set
			{
				code3 = value;
			}
		}

		public string Tld
		{
			get
			{
				return tld;
			}
			set
			{
				tld = value;
			}
		}

		public string NameDE
		{
			get
			{
				return nameDE;
			}
			set
			{
				nameDE = value;
			}
		}

		public string NameEN
		{
			get
			{
				return nameEN;
			}
			set
			{
				nameEN = value;
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region Private variables.
		// ------------------------------------------------------------------

		private string code2;
		private string code3;
		private string tld;
		private string nameDE;
		private string nameEN;
		private bool isEUMember;
		private bool isEurope;
		private bool isEuroCurrency;
				 
		// ------------------------------------------------------------------
		#endregion

		#region Private routines.
		// ------------------------------------------------------------------

		protected override void Load(
			DataRow row )
		{
			base.Load( row );

			if ( row != null )
			{
				DBHelper.ReadField( out code2, row["Code2"] );
				DBHelper.ReadField( out code3, row["Code3"] );
				DBHelper.ReadField( out tld, row["TLD"] );
				DBHelper.ReadField( out nameDE, row["NameDE"] );
				DBHelper.ReadField( out nameEN, row["NameEN"] );
				DBHelper.ReadField( out isEUMember, row["IsEUMember"] );
				DBHelper.ReadField( out isEuroCurrency, row["IsEuroCurrency"] );
				DBHelper.ReadField( out isEurope, row["IsEurope"] );
			}
		}

		// ------------------------------------------------------------------
		#endregion

		#region ILockable members.
		// ------------------------------------------------------------------

		public LockGuard Lock()
		{
			return new LockGuard( GetType(), ID );
		}

		// ------------------------------------------------------------------
		#endregion
	}

	/////////////////////////////////////////////////////////////////////////
}