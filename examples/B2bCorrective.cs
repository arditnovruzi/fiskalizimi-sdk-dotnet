using System;
using System.Collections.Generic;

namespace CRM.Flexie.Fiskalizimi.examples
{
    public class B2bCorrective
    {
        public string GetInvoiceJsonPayload()
        {
            Invoice invoice = new Invoice()
            {
                InvoiceType = Fx.CORRECTIVE_INVOICE,
                ReferenceInvoiceNslf = "2F8B9AC75A4CE1935C3B6A613A3ABCB9",
                ReferenceInvoiceDateTimeIssued = "2021-12-30T14:51:21+01:00",

                BusinessProcess = Fx.BUSINESS_PROCESS_P1,
                PaymentMethod = Fx.PAYMENT_METHOD_BANK,
                Currency = "ALL",
                CurrencyRate = 1,
                VatTotal = -40.00,
                TotalBeforeVat = -200.00,
                TotalAfterVat = -240.00,

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
                        Qty = -1,
                        QtyUnit = "Cope",
                        QtyUnitUblCode = "XPP",
                        Price = 100,
                        VatRate = Fx.VAT_20,
                        TotalBeforeVat = -100,
                        TotalAfterVat = -120,
                        VatTotal = -20
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
