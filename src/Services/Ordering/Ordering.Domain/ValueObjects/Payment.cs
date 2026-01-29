namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration {  get; } = default!;
        public string CVV { get; } = default!;
        public int Paymentmethod { get; } = default!;

        protected Payment() { }

        private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentmethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            CVV = cvv;
            Paymentmethod = paymentmethod;
        }

        public static Payment Of(string cardName, string cardNumber, string expiration, 
                                 string cvv, int paymentmethod)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(cardName);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(cardNumber);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(expiration);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

            return new Payment(cardName, cardNumber, expiration, cvv, paymentmethod);
        }
    }
}
