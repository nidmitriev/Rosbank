namespace RosbankHelpCenter.API.Models
{
    public class Question
    {
         public int Id { get; set; }
        public bool Type {get; set; }
        public string Theme {get; set;}
        public string SubTheme {get; set;}
        public string Quest {get; set;}
        public string Answer {get; set;}
        public Staff StaffMail {get; set;}
        public int IndexOfPop { get; set; }
    }
}