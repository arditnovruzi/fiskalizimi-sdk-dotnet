# .NET SDK - Flexie CRM fiskalizimi solution

**Fiskalizimi .NET SDK** allows you to talk and generate your e-invoices programmatically from your own solution to Flexie CRM fiskalizimi automation platform.

## Installation

Clone this repo into your own environment

```bash
git clone https://github.com/flexie-crm/fiskalizimi-sdk-dotnet.git
Copy as a new project within your Visual Studio Solution
```

Fiskalizimi PHP .NET is using Newtonsoft.Json, JWT and System.ComponentModel.Annotations dependences. Target frameworks are netstandard 2.0 and netstandard 2.1 


## Usage in your own project/solution
Below it's just a simple example on how to use it, you would find more in the examples folder

```cs
using CRM.Flexie.Fiskalizimi;

...

// New invoice object, for B2B scenario using Bank Payment
Invoice invoice = new Invoice()
{
    // Invoice Details
    InvoiceType = "b2b",
    BusinessProcess = "P1",
    PaymentMethod = "ACCOUNT",
    PaymentType = "NONCASH",
    Currency = "ALL",
    CurrencyRate = 1,
    VatTotal = 40.00,
    TotalBeforeVat = 200.00,
    TotalAfterVat = 240.00,

    // Customer Details, in this case using tax identifier
    ClientName = "John Doe",
    ClientNuis = "M01315009J",
    ClientAddress = "ZIP ... 12345",
    ClientCity = "Tirane",
    ClientCountryCode = "ALB",

    // Bank Details
    BankName = "Some Random Bank",
    BankSwift = "ALBALL",
    BankIban = "AL00010001111111111111111111"
};


// You can send additional data to Flexie CRM in case you have a full subscription
// and want to create integrations or getting deeper with your financial data
// invoice.FlexieWorkflowAdditionalData = new Dictionary<string, object>()
// {
//     { "CustomData", "Some costom data" }
// };

List<Dictionary<string, object>> items = new();

// Obviously here would be your own items
foreach (var fakeItem in new int[] { 1, 2 })
{
    try
    {
        InvoiceItem item = new InvoiceItem()
        {
            // Use your own ERP or financial platform item ID/Code/BarCode/Whatever 
            ItemCode = System.Guid.NewGuid().ToString(),
            Item = "Artikulli " + System.Guid.NewGuid().ToString(),
            Qty = 1,
            QtyUnit = "Cope",
            QtyUnitUblCode = "XPP",
            Price = 100,
            VatRate = "0.20",
            TotalBeforeVat = 100,
            TotalAfterVat = 120,
            VatTotal = 20
        };

        items.Add(item.ToDictionary());
    }
    catch (Exception ex)
    {
        // It might trigger an exception in case invoice item values are not validated
        Console.WriteLine(ex.Message);
    }
}

invoice.Items = items;

try
{
    // Initialize main fiskalizimi object with your own Flexie CRM KEY
    // The current key is for DEMO purpose and you can try right away
    // and also operates in the TEST environment of Fiskalizimi service 
    Fiskalizimi fiskalizmi = new("Tw8Yewd1U0d4hViNzGrbLliRlteKTMBT");

    // Send it to Flexie CRM to finalize the Fiskalizimi process,
    // there are also optional ToJSON() and ToDictionary() methods on Invoice object.
    Invoice invoiceData = fiskalizmi.NewInvoice(invoice);

    // invoiceData would have the full invoice object, including
    // 1. nslf 
    // 2. nivf
    // 3. qr code url
    // 4. vat group to print on invoice
    Console.WriteLine(invoiceData.ToJSON());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)
