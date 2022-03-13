namespace PosudbaKnjiga.Models
{
    public class knjiznica
    {
        public List<knjiga> knjige { get; set; }
    }


    public class knjiga
    {
        public int oznaka { get; set; }
        public string naziv { get; set; }
        public string autor { get; set; }
        public string posudio { get; set; }
    }
}
