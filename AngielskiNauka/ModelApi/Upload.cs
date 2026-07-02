namespace AngielskiNauka.ModelApi
{
    public class Upload
    {
        

        public Upload(string line,int lp)
        {
           Linia = line;
           LP = lp;
            char[] separators = { ';', (char)8211, (char)45 };

            string[] kol = line.Split(separators,
                StringSplitOptions.RemoveEmptyEntries);
            
            if (kol.Length == 2)
            {
               
                ANG=kol[0].Trim();
                if (IsProbablyPolish(ANG))
                {
                    Uwaga="Prawdopodobnie polskie słowo w kolumnie angielskiej";
                }
                POL=kol[1].Trim();
            }
            else
            {
                Uwaga = "Niepoprawny format danych";
            }
        }
        bool IsProbablyPolish(string word)
        {
            if (word.Any(c => "ąćęłńóśźżĄĆĘŁŃÓŚŹŻ".Contains(c)))
                return true;

            return false;
        }
        public int LP { get; set; }
        public string ANG { get; set; }
        public string POL { get; set; }
        public string Uwaga { get; set; }
        public string Linia { get; set; }
    }
}
