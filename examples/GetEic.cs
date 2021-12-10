using System;

namespace CRM.Flexie.Fiskalizimi.examples
{
    public class GetEic
    {
        public string GetEicCode()
        {
            try
            {
                Fiskalizimi fiskalizmi = new Fiskalizimi("Tw8Yewd1U0d4hViNzGrbLliRlteKTMBT");
                string eic = fiskalizmi
                    .GetEInvoiceCodeAsync("cc8d08a4-e46e-4442-a2c5-6e8073c05fc9")
                    .Result;

                return eic;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
