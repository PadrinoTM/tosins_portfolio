using System;

namespace MyVidly.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Role { get; set; }    
        public DateTime StartYear { get; set; } 
        public DateTime EndYear { get; set; }
        public string UserId { get; set; }



    }
}
