﻿using System;
using System.Collections.Generic;
namespace PBL2_BookStoreManagement.DTO
{
    class Invoice
    {
        public string InvoiceID { get; set; }
        public string CustomerID { get; set; }
        public List<Cart> Items { get; set; } // Changed to List<Cart>
        public DateTime DateCreated { get; set; }
        public double TotalAmount { get; set; }

        public Invoice(string invoiceID, string customerID, DateTime dateCreated, List<Cart> items, double totalAmount)
        {
            InvoiceID = invoiceID;
            CustomerID = customerID;
            Items = items;
            DateCreated = dateCreated;
            TotalAmount = totalAmount;
        }
    }
}
