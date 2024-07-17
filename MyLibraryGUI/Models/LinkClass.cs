namespace MyLibrary.GUI.Models
{
    public class LinkClass
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public int? Bookid { get; set; }
        public int? Borrowerid { get; set; }
        public LoanClass Loanclass { get; set; }
    }
}
