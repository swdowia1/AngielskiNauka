namespace AngielskiNauka
{


    public class ConfigGlobal
    {
        private readonly IConfiguration _configuration;

        public ConfigGlobal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Ile()
        {
            string myValue = _configuration["Ile"];
            return int.Parse(myValue);
        }
    }
}
