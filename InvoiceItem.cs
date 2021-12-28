using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Flexie.Fiskalizimi
{
    public class InvoiceItem
    {
        public string? ItemCode { get; set; }

        public string? Item { get; set; }

        public double Qty { get; set; }

        public double Price { get; set; }

        public string? QtyUnit { get; set; } = "Cope";

        public string? QtyUnitUblCode { get; set; } = "XPP";

        public double VatTotal { get; set; }

        [RegularExpression("(0.20|0.10|0.06|0.00|TYPE_1|TYPE_2|MARGIN_SCHEME)", ErrorMessage = "Allowed values in VatRate are 0.20|0.10|0.06|0.00|TYPE_1|TYPE_2|MARGIN_SCHEME")]
        public string? VatRate { get; set; }

        public double TotalBeforeVat { get; set; }

        public double TotalAfterVat { get; set; }

        public string ToJSON()
        {
            // Try to validate first 
            var validation = Fx.ValidateData(this);
            if (validation.Count > 0)
            {
                throw new Exception("Field validation failed with the following errors: " + String.Join(" - ", validation));
            }

            Dictionary<string, object> invoiceMap = new Dictionary<string, object>();

            foreach (var prop in GetType().GetProperties())
            {
                if (prop.GetValue(this) != null)
                {
                    string key = prop.Name;
                    invoiceMap[char.ToLower(key[0]) + key.Substring(1)] = prop.GetValue(this);
                }
            }

            return JsonConvert.SerializeObject(invoiceMap);
        }

        public Dictionary<string, object> ToDictionary()
        {
            // Try to validate first 
            var validation = Fx.ValidateData(this);
            if (validation.Count > 0)
            {
                throw new Exception("Field validation failed with the following errors: " + String.Join(" - ", validation));
            }

            Dictionary<string, object> invoiceMap = new Dictionary<string, object>();

            foreach (var prop in GetType().GetProperties())
            {
                if (prop.GetValue(this) != null)
                {
                    string key = prop.Name;
                    invoiceMap[char.ToLower(key[0]) + key.Substring(1)] = prop.GetValue(this);
                }
            }

            return invoiceMap;
        }
    }
}
