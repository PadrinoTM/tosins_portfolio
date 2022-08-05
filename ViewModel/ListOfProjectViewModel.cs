using System;
using System.Collections.Generic;


namespace MyVidly.ViewModel
{
    public class ListOfProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectLink { get; set; }
        public DateTime Year { get; set; } = DateTime.Now;
    }
}
