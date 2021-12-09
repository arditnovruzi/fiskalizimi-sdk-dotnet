using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CRM.Flexie.Fiskalizimi
{
    public class Invoice
    {
        public string? OperatorCode { get; set; }

        public string? TcrCode { get; set; }

        public string? ClientName { get; set; }

        public string? ClientNuis { get; set; }

        public string? ClientId { get; set; }

        public string? ClientAddress { get; set; }

        public string? ClientCity { get; set; }

        public string? ClientCountryCode { get; set; }

        [RegularExpression("(b2b|b2c|auto|export)", ErrorMessage = "Allowed values in InvoiceType are b2b|b2c|auto|export")]
        public string? InvoiceType { get; set; }

        [RegularExpression("(AGREEMENT|DOMESTIC|ABROAD|SELF|OTHER)", ErrorMessage = "Allowed values in AutoInvoiceType are AGREEMENT|DOMESTIC|ABROAD|SELF|OTHER")]
        public string? AutoInvoiceType { get; set; }

        [Description("DueDate in days, date is calculated based on this integer for easy of use")]
        public int? DueDate { get; set; } = 1;

        public string? PeriodStart { get; set; }

        public string? PeriodEnd { get; set; }

        [RegularExpression("(ACCOUNT|BANKNOTE|CARD|CHECK|SVOUCHER|COMPANY|ORDER|FACTORING|COMPENSATION|TRANSFER|WAIVER|KIND|OTHER)", ErrorMessage = "Allowed values in PaymentMethod are ACCOUNT|BANKNOTE|CARD|CHECK|SVOUCHER|COMPANY|ORDER|FACTORING|COMPENSATION|TRANSFER|WAIVER|KIND|OTHER")]
        public string? PaymentMethod { get; set; }

        [RegularExpression("(CASH|NONCASH)", ErrorMessage = "Allowed values in PaymentType are CASH|NONCASH")]
        public string? PaymentType { get; set; }

        [RegularExpression("(P1|P2|P6)", ErrorMessage = "Allowed values in BusinessProcess are P1|P2|P6")]
        public string? BusinessProcess { get; set; } = "P1";

        public string? BankName { get; set; }

        public string? BankIban { get; set; }

        public string? BankSwift { get; set; }

        public string? Currency { get; set; } = "ALL";

        public double CurrencyRate { get; set; } = 1;

        [Required(ErrorMessage = "VatTotal is a required field.")]
        public double VatTotal { get; set; }

        [Required(ErrorMessage = "TotalBeforeVat is a required field.")]
        public double TotalBeforeVat { get; set; }

        [Required(ErrorMessage = "TotalAfterVat is a required field.")]
        public double TotalAfterVat { get; set; }

        [Required(ErrorMessage = "There can't be an invoice without invoice items, please provide at least one invoice item.")]
        public List<Dictionary<string, object>>? Items { get; set; }

        public string? WebhookCallback { get; set; }

        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email address in SendToEmail field.")]
        public string? SendToEmail { get; set; }

        public string? Errors { get; set; }

        protected Dictionary<string, object>? _enrich;

        internal void EnrichInvoice(Dictionary<string, object> additionalData)
        {
            _enrich = additionalData;
        }

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

            if (_enrich?.Count > 0)
            {
                _enrich.ToList().ForEach(x => invoiceMap.Add(x.Key, x.Value));
            }

            return JsonConvert.SerializeObject(invoiceMap, Formatting.Indented);
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

            if (_enrich?.Count > 0)
            {
                _enrich.ToList().ForEach(x => invoiceMap.Add(x.Key, x.Value));
            }

            return invoiceMap;
        }

    }
}
