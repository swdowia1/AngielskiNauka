namespace AngielskiNauka.Unit
{
    public class FunVMS : IFunVMS
    {
        public List<string> GetDataCacheOrder()
        {
            return new List<string>();
        }

        public string KeyTransalate(string key)
        {

            Dictionary<string, string> tl = new Dictionary<string, string>();
            tl.Add("order-status-transport", "Status realizacji zamówienia");

            tl.Add("order-status-transport0", "Akceptacja zamówienia do realizacji");

            tl.Add("order-status-transport1", "Przyjęte do realizacji");

            tl.Add("order-status-transport2", "Zamówienie odrzucono");

            tl.Add("order-status-transport3", "Zamówienie wysłane");

            tl.Add("order-status-transport4", "Zamówienie wysłano usun");

            tl.Add("order-status-transport97", "Wysłane do dostawcy");

            tl.Add("order-status-transport98", "W trakcie przetwarzania");

            tl.Add("order-status-transport99", "Czekam na wysłanie");


            var tlma = tl[key];
            if (tlma == null)
            {
                return key;
            }
            else
                return tlma;

        }

        public void SendMail()
        {
            File.WriteAllText("aa.txt", "aaaa");
        }
    }
}
