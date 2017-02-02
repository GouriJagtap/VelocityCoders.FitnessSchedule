using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelocityCoders.FitnessSchedule.WebForms.Models
{
    public class GymDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set;}
        public string WebSite { get; set; }
        //public DateTime CreateDate { get; set; }
    }
}