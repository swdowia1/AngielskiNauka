namespace AngielskiNauka.ModelApi
{
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