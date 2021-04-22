using AutoBogus;
using AutoBogus.Conventions;
using Bogus;
using IdGen;
using System;
using System.Collections.Generic;

namespace Sample.AzureSearchLoadTests
{
    static class DataGenerator
    {
        private static readonly IdGenerator _generator;
        private static readonly Random _rnd = new Random(1554);
        private static readonly Faker<Order> _documentsGenerator;

        static DataGenerator()
        {
            var epoch = new DateTime(2021, 4, 21, 0, 0, 0, DateTimeKind.Utc);
            var options = new IdGeneratorOptions(timeSource: new DefaultTimeSource(epoch));
            _generator = new IdGenerator(0, options);

            Randomizer.Seed = new Random(1573307);
            AutoFaker.Configure(builder =>
            {
                builder
                    .WithRepeatCount((a) => a.Faker.Random.Number(2, 30))
                    .WithConventions(b => {
                        b.ProductDescription.Aliases("Description");
                        b.ProductName.Aliases("Name");
                    });
            });

            _documentsGenerator = new AutoFaker<Order>()
                .RuleFor(d => d.Id, f => _generator.CreateId().ToString())
                .RuleFor(d => d.ClosingText, f => f.Lorem.Sentence(5, 15))
                .RuleFor(d => d.OpeningText, f => f.Lorem.Sentence(2, 20))
                .RuleFor(d => d.OrderCode, f => f.Commerce.Ean13())

                .RuleFor(d => d.PurchaserTaxId, f => f.Finance.Iban())
                .RuleFor(d => d.PurchaserVatId, f => f.Finance.Iban())
                .RuleFor(d => d.PurchaserWeb, f => f.Internet.Url())

                .RuleFor(d => d.PurchaserBusinessName, f => f.Company.CompanyName())
                .RuleFor(d => d.PurchaserCity, f => f.Address.City())
                .RuleFor(d => d.PurchaserContactName, f => f.Name.FullName())
                .RuleFor(d => d.PurchaserCountry, f => f.Address.Country())
                .RuleFor(d => d.PurchaserEmail, f => f.Person.Email)
                .RuleFor(d => d.PurchaserPhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(d => d.PurchaserPostCode, f => f.Address.ZipCode())
                .RuleFor(d => d.PurchaserStreet, f => f.Address.StreetAddress())

                .RuleFor(d => d.PurchaserPostalAddressBusinessName, f => f.Company.CompanyName())
                .RuleFor(d => d.PurchaserPostalAddressCity, f => f.Address.City())
                .RuleFor(d => d.PurchaserPostalAddressContactName, f => f.Name.FullName())
                .RuleFor(d => d.PurchaserPostalAddressCountry, f => f.Address.Country())
                .RuleFor(d => d.PurchaserPostalAddressPostCode, f => f.Address.ZipCode())
                .RuleFor(d => d.PurchaserPostalAddressStreet, f => f.Address.StreetAddress())

                .RuleFor(d => d.SupplierBusinessName, f => f.Company.CompanyName())
                .RuleFor(d => d.SupplierCity, f => f.Address.City())
                .RuleFor(d => d.SupplierContactName, f => f.Name.FullName())
                .RuleFor(d => d.SupplierCountry, f => f.Address.Country())
                .RuleFor(d => d.SupplierEmail, f => f.Person.Email)
                .RuleFor(d => d.SupplierPhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(d => d.SupplierPostCode, f => f.Address.ZipCode())
                .RuleFor(d => d.SupplierStreet, f => f.Address.StreetAddress())

                .RuleFor(d => d.SupplierPostalAddressBusinessName, f => f.Company.CompanyName())
                .RuleFor(d => d.SupplierPostalAddressCity, f => f.Address.City())
                .RuleFor(d => d.SupplierPostalAddressContactName, f => f.Name.FullName())
                .RuleFor(d => d.SupplierPostalAddressCountry, f => f.Address.Country())
                .RuleFor(d => d.SupplierPostalAddressPostCode, f => f.Address.ZipCode())
                .RuleFor(d => d.SupplierPostalAddressStreet, f => f.Address.StreetAddress())

                .RuleFor(d => d.SupplierTaxId, f => f.Finance.Iban())
                .RuleFor(d => d.SupplierVatId, f => f.Finance.Iban())
                .RuleFor(d => d.SupplierWeb, f => f.Internet.Url());
        }

        public static int RandomCount()
            => _rnd.Next(20, 300);

        public static IEnumerable<Order> GenerateDocuments(int count)
        {
            return _documentsGenerator.Generate(count);
        }
    }
}
