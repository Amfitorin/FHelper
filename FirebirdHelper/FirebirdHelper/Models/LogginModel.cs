using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FirebirdHelper.Helpers;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Win32;
using File = System.IO;

namespace FirebirdHelper.Models
{
	public class LogginModel : ModelBase
	{
		readonly string[] _extensions = new string[] { ".fdb", ".gdb", ".FDB", ".GDB" };
		string _path;
		public string Path 
		{
			get { return _path; }
			set
			{
				_path = value;
				FirePropertyChanged("Path");
				FirePropertyChanged("IsConnect");
			}
		}

		string _login;
		public string Login
		{
			get { return _login; }
			set
			{
				_login = value;
				FirePropertyChanged("Login");
				FirePropertyChanged("IsConnect");
			}
		}

		string _pass;
		public string Pass
		{
			get { return _pass; }
			set
			{
				_pass = value;
				FirePropertyChanged("Pass");
				FirePropertyChanged("IsConnect");
			}
		}

		public static string ConnectionString { get; set; }

		public bool IsConnect { get { return Pass != null && Login != null && _extensions.Contains(File.Path.GetExtension(Path)); } }

		public ICommand Connect
		{
			get 
			{
				return new UserCommand((o)=>
				{
					var builder = new FbConnectionStringBuilder();
					builder.Database = Path;
					builder.UserID = Login;
					builder.Password = Pass;
					ConnectionString = builder.ToString();				
				});
			}
		}

		public ICommand View
		{
			get
			{
				return new UserCommand(() =>
				{
					var dialog = new OpenFileDialog();
					dialog.InitialDirectory = @"C:\";
					dialog.Filter = ("DB files|*.fdb;*.gdb;*.FDB;*.GDB");
					if (dialog.ShowDialog().Value)
					{
						Path = dialog.FileName;
					}
				});
			}
		}
	}
}