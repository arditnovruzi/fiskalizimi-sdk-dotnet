using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Flexie.Fiskalizimi
{
    internal class Endpoint
    {
        public const string FX_GET_CURRENCY_RATE = "https://flexie.io/currency";

        public static readonly Dictionary<string, string> FX_NEW_INVOICE = new Dictionary<string, string>()
        {
            { "url", "https://fatura.flexie.io/listener/063683f90a4a4b2af1cbb8093ec3cbd2/37703aa073a8fa95d622ec764d6c4bdc" },
            { "key", "0FlkkYB1RURvwhXehzfoOkBvrJjp0bgxTDKfESSqYpHw8szqGp" },
            { "secret", "VcZ2Z0BlWyOJp0tyjbocoWFFyPYh0tY2jRwbVHCjUeC5sDA0am" }
        };

        public static readonly Dictionary<string, string> FX_TCR_OPERATION = new Dictionary<string, string>()
        {
            { "url", "https://fatura.flexie.io/listener/2332f8d44096443d829f11311a5fac5c/6d9e245cd6670942da4f060d8dc30441" },
            { "key", "CsT0gw6ICQ1r9mNeeHna6VYYijKjeSkRleRCKXkmOmOXIBbWjz" },
            { "secret", "6pu5oNp97D1rvnGmZqkjN8FB6ochkvRrVlxj9WsgAuI5SosROM" }
        };

        public static readonly Dictionary<string, string> FX_NEW_TCR = new Dictionary<string, string>()
        {
            { "url", "https://fatura.flexie.io/listener/500297db6d691ff37b1441a4adda95af/132f636d5dcf4942bf8120246a38f88e" },
            { "key", "L1TyUloAw2uM6GO4QpIINFqWteyPmjrkxBt0u1Gdo5FhTEj0eH" },
            { "secret", "ofoTT3zCFTGeYXzhm29DMYiOdQx3MTAa9Y421DFGxmVwjvNFxX" },
        };

        public static readonly Dictionary<string, string> FX_EDIT_TCR = new Dictionary<string, string>()
        {
            { "url", "https://fatura.flexie.io/listener/97122cf0f7afd50c9577eda2dfe70d17/cc9910e4627bb40fa4ec435d38268df9" },
            { "key", "5dYQVxIWWq5snpUzL4vN93vDIrnAgNdFgorbVJMlkn1mmCNJ6b" },
            { "secret", "cL6q8bowJJZL0KMIf0WkUTUdF9RQvkBH5H8eTwLCgLngvaZLaW" }
        };

        public static readonly Dictionary<string, string> FX_VERIFY_NUIS = new Dictionary<string, string>()
        {
            { "url", "https://fatura.flexie.io/listener/1badf25a0acce9a818f80c89a731c866/6dd661d4a756c7df5c0afa1a97ea87fa" },
            { "key", "LHZOM4tx7K0umNuVAA2CqxakjlubosvddkaKmmWYgQdDFya46b" },
            { "secret", "2HoP3lUQ9vlwvBLICWlb52mkonfXXtceC8Wt9MgDOTUrRTMepH" }
        };

        public static readonly Dictionary<string, string> FX_GET_EIC = new Dictionary<string, string>()
        {
            { "url", "https://fatura.flexie.io/listener/9d974cbb3f6cb0f49831d66fdfa46101/d0868f01db5976c567c673d445bdbfca" },
            { "key", "zNWOTZIoiHmpChBmI5bk5AZfcD3pcyULlQAeQjD800yCh9Y0e9" },
            { "secret", "kjKjyWWBm9ahVv7vKXOo6OpErGNqH2z1mkkUhhwDrHUmd2SX0G" }
        };
    }
}
