using JPC.AmountConverter.Application.Shared.Dto;

namespace JPC.AmountConverter.Application.AmountConverterService
{
    /// <summary>
    /// Amount Converter Interface
    /// </summary>
    public interface IAmountConverterService
    {
        /// <summary>
        /// This method converts the decimal amount in words using Rapid API
        /// Rapid API is used and I included the keys and api endpoint here for configuration (located in appsettings.json)
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AmountConverterResponseDto> GetAmountToWords(decimal amount, CancellationToken cancellationToken);
    }
}
