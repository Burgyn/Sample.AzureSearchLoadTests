using System;
using System.Collections.Generic;

namespace Sample.AzureSearchLoadTests
{
    public class Order
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public string OrderCode { get; set; }

        public double TotalPrice { get; set; }

        public string SupplierRegistrationId { get; set; }

        public string SupplierTaxId { get; set; }

        public string SupplierVatId { get; set; }

        public string SupplierPhoneNumber { get; set; }

        public string SupplierEmail { get; set; }

        public string SupplierWeb { get; set; }

        public string SupplierBusinessName { get; set; }

        public string SupplierContactName { get; set; }

        public string SupplierStreet { get; set; }

        public string SupplierPostCode { get; set; }

        public string SupplierCity { get; set; }

        public string SupplierCountry { get; set; }

        public string SupplierPostalAddressBusinessName { get; set; }

        public string SupplierPostalAddressContactName { get; set; }

        public string SupplierPostalAddressStreet { get; set; }

        public string SupplierPostalAddressPostCode { get; set; }

        public string SupplierPostalAddressCity { get; set; }

        public string SupplierPostalAddressCountry { get; set; }

        public long PurchaserId { get; set; }

        public string PurchaserRegistrationId { get; set; }

        public string PurchaserTaxId { get; set; }

        public string PurchaserVatId { get; set; }

        public string PurchaserPhoneNumber { get; set; }

        public string PurchaserEmail { get; set; }

        public string PurchaserWeb { get; set; }

        public string PurchaserBusinessName { get; set; }

        public string PurchaserContactName { get; set; }

        public string PurchaserStreet { get; set; }

        public string PurchaserPostCode { get; set; }

        public string PurchaserCity { get; set; }

        public string PurchaserCountry { get; set; }

        public string PurchaserPostalAddressBusinessName { get; set; }

        public string PurchaserPostalAddressContactName { get; set; }

        public string PurchaserPostalAddressStreet { get; set; }

        public string PurchaserPostalAddressPostCode { get; set; }

        public string PurchaserPostalAddressCity { get; set; }

        public string PurchaserPostalAddressCountry { get; set; }

        public DateTime IssueDate { get; set; }

        public string OpeningText { get; set; }

        public string ClosingText { get; set; }

        public List<OrderItem> Items { get; set; }

        public DateTimeOffset CreatedTimestamp { get; set; }

        public string Iban { get; set; }

        public string Swift { get; set; }

        public string VariableSymbol { get; set; }
    }
}
