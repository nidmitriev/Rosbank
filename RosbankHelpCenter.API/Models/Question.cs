namespace RosbankHelpCenter.API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Theme {get; set;}
        public string SubTheme {get; set;}
        public string Quest {get; set;}
        public string Aswer {get; set;}
        public Staff StaffMail {get; set;}
    }
}