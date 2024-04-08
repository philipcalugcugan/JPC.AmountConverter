namespace JPC.AmountConverter.Application.Shared.Dto
{
    /// <summary>
    /// This is the response of the request
    /// <example> Amount: 123.50 Words: one hundred twenty-three dollars and four hundred fifty cents</example>
    /// </summary>
    public class AmountConverterResponseDto
    {
        public decimal Amount { get; set; }
        public string Words { get; set; }
    }
}
