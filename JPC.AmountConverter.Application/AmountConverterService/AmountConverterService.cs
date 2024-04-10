using JPC.AmountConverter.Application.Shared.Dto;

namespace JPC.AmountConverter.Application.AmountConverterService
{
    /// <summary>
    /// Amount Converter Service
    /// </summary>
    public class AmountConverterService : IAmountConverterService
    {
        private static readonly string[] Ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] Teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        /// <summary>
        /// Amount Converter Constructor
        /// </summary>
        public AmountConverterService()
        {
        }

        /// <summary>
        /// This method converts the decimal amount in words
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AmountConverterResponseDto> GetAmountToWords(decimal amount, CancellationToken cancellationToken)
        {
            var convertedAmount = await ConvertAmountToWords(amount, cancellationToken);
            return new AmountConverterResponseDto()
            {
                Amount = amount,
                Words = convertedAmount
            };
        }

        /// <summary>
        /// Convert string
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private async Task<string> ConvertAmountToWords(decimal amount, CancellationToken cancellationToken)
        {
            if (amount < 0 || amount > 999999999.99m)
                throw new ArgumentOutOfRangeException("Amount must be between 0 and 999,999,999.99");

            int dollars = (int)amount;
            int cents = (int)((amount - dollars) * 100);

            string dollarsInWords = await ConvertToWords(dollars, cancellationToken);
            string centsInWords = await ConvertToWords(cents, cancellationToken);

            string result = $"{dollarsInWords} dollars";

            if (!string.IsNullOrEmpty(centsInWords))
                result += $" and {centsInWords} cents";

            return result;
        }

        /// <summary>
        /// Convert a number into words
        /// </summary>
        /// <param name="number"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<string> ConvertToWords(int number, CancellationToken cancellationToken)
        {
            if (number == 0)
                return "Zero";

            if (number < 10)
                return Ones[number];

            if (number < 20)
                return Teens[number - 10];

            if (number < 100)
                return $"{Tens[number / 10]} {Ones[number % 10]}";

            if (number < 1000)
                return $"{Ones[number / 100]} Hundred {await ConvertToWords(number % 100, cancellationToken)}";

            if (number < 1000000)
                return $"{await ConvertToWords(number / 1000, cancellationToken)} Thousand {await ConvertToWords(number % 1000, cancellationToken)}";

            return $"{await ConvertToWords(number / 1000000, cancellationToken)} Million {await ConvertToWords(number % 1000000, cancellationToken)}";
        }
    }
}
