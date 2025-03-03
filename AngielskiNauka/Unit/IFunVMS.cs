namespace AngielskiNauka.Unit
{
    public interface IFunVMS
    {
        List<string> GetDataCacheOrder();
        string KeyTransalate(string v);
        void SendMail();
    }

}
