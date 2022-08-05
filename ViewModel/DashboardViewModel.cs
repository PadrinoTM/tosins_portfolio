using System.Collections.Generic;
using MyVidly.Models;

namespace MyProfile.ViewModel
{
    public class DashboardViewModel
    {
        public ICollection<Project> Projects { get; set; }
        public ICollection<Skills> Skill { get; set; }
        public ICollection<Experience> Experiences { get; set; }
    }
}
