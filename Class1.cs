﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


public class OrderDatabase
{
    private SQLiteConnection _database;
	
	public OrderDatabase()
	{
		CreateTable<Customer>();
		CreateTable<Orders>();

            var path = GetDbPath();
            _database = new SQLiteConnection(path);

            _database.CreateTable<Orders>();
            _database.CreateTable<Customer>();
            

            SeedDatabase();
        }

        public string GetDbPath()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banking.db");
            return path;
        }

        public void SeedDatabase()
        {
            if (_database.Table<Bank>().Count() == 0)
            {

                Bank fnb = new Bank("First National Bank", 4324, "Kenilworth");
                Customer myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
                fnb.AddCustomer(myNewCustomer);

                _database.Insert(myNewCustomer);
                _database.Insert(fnb);
                _database.UpdateWithChildren(fnb);

                var account = myNewCustomer.ApplyForBankAccount();
                _database.Insert(account);
                _database.UpdateWithChildren(myNewCustomer);
            }
        }

        public Customer GetCustomerByIdNumber(string saIdNumber)
        {
            var customer = _database.Table<Customer>().Where(x => x.IdNumber == saIdNumber).FirstOrDefault();

            if (customer != null)
            {
                _database.GetChildren(customer, true);
            }

            return customer;
        }

        public List<Transaction> GetTransactions(BankAccount account)
        {
            return _database.Table<Transaction>().Where(x => x.BankAccountId == account.BankAccountId).ToList();
        }

        public BankAccount GetCurrectAccount(Customer customer)
        {
            var account = _database.Table<BankAccount>().Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();

            _database.GetChildren(account, true);

            return account;
        }

        public void SaveTransaction(BankAccount account, Transaction trans)
        {
            _database.Insert(trans);

            _database.UpdateWithChildren(account);
        }

    }
}
	}
}
