namespace PassionPortal.Infrastracture.Configurations
{
    public class TokenConfiguration
    {
        public int ExpiresMinutes { get; set; }
        public required string RsaPublickKey { get; set; }
        public required string RsaPrivateKey { get; set; }
    }
}
