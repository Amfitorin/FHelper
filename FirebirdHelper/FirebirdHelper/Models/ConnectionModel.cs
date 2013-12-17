using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FirebirdHelper.Helpers;

namespace FirebirdHelper.Models
{
	public class ConnectionModel
	{
		public ConnectionModel()
		{
		}


		public ICommand AddDatabase
		{
			get 
			{
				return new UserCommand(() =>
					{
						var window = new LoginWindow();
						window.Show();
					});
			}
		}
	}
}
