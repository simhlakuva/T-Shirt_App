using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace TShirt_App
{
   
    public class Customer
    {
    [PrimaryKey, AutoIncrement]
    public int CustomerId{ get; set; }
    public string ShippingAddress { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
        //public string Gender { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Orders> Orders { get; set; }

    public Customer( genderList, colorList, sizeList, string address, string firstName, string lastName)
    {
       // IdNumber = idNumber;
       
        FirstName = firstName;
        LastName = lastName;
        //Gender = gender;
        ShippingAddress = address;

            Orders = new List<Order>();

    }

    public Orders PlaceNewOrder()
    {
        Order bankAccount = new Order();
        Orders.Add(bankAccount);

        return order;
    }
}
}