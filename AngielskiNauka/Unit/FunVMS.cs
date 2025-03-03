
namespace AngielskiNauka.Unit
{
    public class FunVMS : IFunVMS
    {
        public List<string> GetDataCacheOrder()
        {
            return new List<string>();
        }

        public void SendMail()
        {
            File.WriteAllText("aa.txt", "aaaa");
        }
    }
}
