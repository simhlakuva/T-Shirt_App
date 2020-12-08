using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace TShirt_App
{

	public class Orders
	{
	

		[ForeignKey(typeof(Customer))]
		public int OrderNumber { get; set; }


	}


}
