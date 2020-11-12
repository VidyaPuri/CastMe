using System;
using System.Collections.Generic;
using static ZenProject.Core.Enums;

namespace ZenProject.Web.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public ProjectStatus Status { get; set; }
        public string Outfit { get; set; }
        public string Concept { get; set; }
        public string Location { get; set; }
        public string Lighting { get; set; }
        public string Composition { get; set; }
        public string Props { get; set; }
        public string Equipment { get; set; }
        public List<Talent> Talents { get; set; }
        public List<Staff> Staff { get; set; }
        public ProjectForm Form { get; set; }
        public string Other { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
