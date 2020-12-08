using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace T_Shirt_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Gender
            var genderList = new List<string>();
            genderList.Add("Male");
            genderList.Add("Female");
            genderList.Add("Prefer Not To Say");
            

            var genderpicker = new Picker { Title = "Gender"};
            genderpicker.ItemsSource = genderList;


            //List for t-shirt color
            var tshirtSizeList = new List<string>();
            tshirtSizeList.Add("XSmall");
            tshirtSizeList.Add("Small");
            tshirtSizeList.Add("Medium");
            tshirtSizeList.Add("Large");
            tshirtSizeList.Add("XLarge");
            tshirtSizeList.Add("XXLarge");
            

            var sizepicker = new Picker { Title = "Select a size" };
            sizepicker.ItemsSource = tshirtSizeList;

            //Drop Down List for the color of the t-shirt
            var colorList = new List<string>();
            colorList.Add("Black");
            colorList.Add("White");
            colorList.Add("Blue");
            colorList.Add("Pink");
            colorList.Add("Red");
            colorList.Add("Mustard Yellow");
            colorList.Add("Navy");

            var colorpicker = new Picker { Title = "Select a color"};
            colorpicker.ItemsSource = colorList;

            

            private void submit_Clicked(object sender, EventArgs e)
            {

                //decimal EnterWithdrawAmount = 0;
                string firstName = FirstName.Text.ToString();
                string lastName = LastName.Text.ToString();
                string address = shippingAddress.Text.ToString();
                string gender = genderList.ToString();
                string color = colorList.ToString();
                string size = tshirtSizeList.ToString();




               var placeOrder = (firstName, lastName, DateTime.Now, address, gender, color, size);
            }
        }
    }
}
