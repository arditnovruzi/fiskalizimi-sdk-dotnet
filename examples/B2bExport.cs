using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Flexie.Fiskalizimi.examples
{
    public class B2bExport
    {
        public string GetInvoiceJsonPayload()
        {
            Invoice invoice = new Invoice()
            {
                InvoiceType = Fx.EXPORT_INVOICE,
                PaymentMethod = Fx.PAYMENT_METHOD_BANK,
                Currency = "EUR",
                CurrencyRate = 122.01,
                VatTotal = 0,
                TotalBeforeVat = 200.00,
                TotalAfterVat = 200.00,

                ClientName = "John Doe",
                ClientNuis = "M01315009J",
                ClientAddress = "ZIP ... 12345",
                ClientCity = "Tirane",
                ClientCountryCode = "ALB",

                BankName = "Some Random Bank",
                BankSwift = "ALBALL",
                BankIban = "AL00010001111111111111111111"
            };

            // You can send additional data to Flexie CRM in case you have a full subscription
            // and want to create integrations or getting deeper with your financial data
            // invoice.FlexieWorkflowAdditionalData = new Dictionary<string, object>()
            // {
            //    { "CustomData", "Some costom data" }
            // };

            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();

            foreach (var fakeItem in new int[] { 1, 2 })
            {
                try
                {
                    InvoiceItem item = new InvoiceItem()
                    {
                        ItemCode = System.Guid.NewGuid().ToString(),
                        Item = "Artikulli " + System.Guid.NewGuid().ToString(),
                        Qty = 1,
                        QtyUnit = "Cope",
                        QtyUnitUblCode = "XPP",
                        Price = 100,
                        VatRate = Fx.VAT_EXPORT_OF_GOODS,
                        TotalBeforeVat = 100,
                        TotalAfterVat = 100,
                        VatTotal = 0
                    };

                    items.Add(item.ToDictionary());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            invoice.Items = items;

            try
            {
                Fiskalizimi fiskalizmi = new Fiskalizimi("Tw8Yewd1U0d4hViNzGrbLliRlteKTMBT");
                Invoice invoiceData = fiskalizmi.NewInvoice(invoice);

                // You can also return a dictionary at this point
                // return invoiceData.ToDictionary();

                return invoiceData.ToJSON();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
