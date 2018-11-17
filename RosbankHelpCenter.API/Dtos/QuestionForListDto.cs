using System;
using System.Collections.Generic;
using RosbankHelpCenter.API.Models;

namespace RosbankHelpCenter.API.Dtos
{
    public class QuestionForListDto
    {
        public int Id { get; set; }
        public string Theme {get; set;}
        public string SubTheme {get; set;}
        public string Quest {get; set;}
        public string Answer {get; set;}
        public Staff StaffMail {get; set;}
        public int IndexOfPop { get; set; }
    }
}