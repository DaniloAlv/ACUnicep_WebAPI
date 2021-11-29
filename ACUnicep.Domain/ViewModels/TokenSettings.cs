namespace ACUnicep.Domain.ViewModels
{
    public class TokenSettings
    {
        public string SecretKey { get; set; }
        public int ExpireIn { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
