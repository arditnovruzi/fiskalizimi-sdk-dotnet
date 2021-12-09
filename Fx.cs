using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Flexie.Fiskalizimi
{
    public class Fx
    {
        public const string ASYNC = "async";
        public const string SYNC = "sync";
        public const string B2B = "b2b";
        public const string B2C = "b2c";
        public const string AUTO_INVOICE = "auto";
        public const string EXPORT_INVOICE = "export";

        public const string AUTO_INVOICE_AGREEMENT = "AGREEMENT";
        public const string AUTO_INVOICE_DOMESTIC = "DOMESTIC";
        public const string AUTO_INVOICE_ABROAD = "ABROAD";
        public const string AUTO_INVOICE_SELF = "SELF";
        public const string AUTO_INVOICE_OTHER = "OTHER";

        public const string PAYMENT_METHOD_BANK = "ACCOUNT";
        public const string PAYMENT_METHOD_CASH = "BANKNOTE";
        public const string PAYMENT_METHOD_CREDIT_CARD = "CARD";
        public const string PAYMENT_METHOD_CHECK = "CHECK";
        public const string PAYMENT_METHOD_SVOUCHER = "SVOUCHER";
        public const string PAYMENT_METHOD_COMPANY = "COMPANY";
        public const string PAYMENT_METHOD_ORDER = "ORDER";
        public const string PAYMENT_METHOD_FACTORING = "FACTORING";
        public const string PAYMENT_METHOD_COMPENSATION = "COMPENSATION";
        public const string PAYMENT_METHOD_TRANSFER = "TRANSFER";
        public const string PAYMENT_METHOD_WAIVER = "WAIVER";
        public const string PAYMENT_METHOD_KIND = "KIND";
        public const string PAYMENT_METHOD_OTHER = "OTHER";

        public const string BUSINESS_PROCESS_P1 = "P1";
        public const string BUSINESS_PROCESS_P2 = "P2";
        public const string BUSINESS_PROCESS_P6 = "P6";

        public const string VAT_20 = "0.20";
        public const string VAT_10 = "0.10";
        public const string VAT_6 = "0.06";
        public const string VAT_TYPE_1 = "TYPE_1";
        public const string VAT_TYPE_2 = "TYPE_2";
        public const string VAT_MARGIN = "MARGIN_SCHEME";

        public static List<ValidationResult> ValidateData(Object instance)
        {
            ValidationContext ctx = new ValidationContext(instance);
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateObject(instance, ctx, results, true);

            return results;
        }
    }
}
