namespace Domain.Helpers.VAT
{
    public static class VatHelper
    {
        public static decimal ApplyVAT(decimal price) => price * VAT.VAT_RATE;
    }
}
