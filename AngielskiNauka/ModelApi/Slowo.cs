namespace AngielskiNauka.ModelApi
{
    public class Fiszka
    {
        public int Id { get; set; }
        public string Ang { get; set; }
        public string Pol { get; set; }
        public string[] Odpowiedzi { get; set; }
        /// <summary>
        /// nie umiem
        /// </summary>
        public int Mniej { get; set; }
        /// <summary>
        /// do nauki
        /// </summary>
        public int Rowna { get; set; }
        /// <summary>
        /// powtarzam
        /// </summary>
        public int Wiecej { get; set; }
    }
    public class Slowo
    {
        public int Id { get; set; }
        public string Ang { get; set; }
        public string Pol { get; set; }

        public string[] Odpowiedzi { get; set; }
        public DateTime Data { get; set; }
        public Stan stan { get; set; }
        public int Postep { get; set; }
        public int Poziom { get; set; }
    }
    public class WordPair
    {
        public string En { get; set; }
        public string Pl { get; set; }
    }
    public class Quiz
    {
        public int Id { get; set; }
        public string Ang { get; set; }
        public string Pol { get; set; }

        public string[] Odpowiedzi { get; set; }

        public int Poziom { get; set; }

        public Stan stan { get; set; }
   
    }
}