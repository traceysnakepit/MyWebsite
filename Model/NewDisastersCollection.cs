using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Model
{
    public class NewDisastersCollection
    {
        [Key]
        public int did { get; set; }
        public string dname { get; set; }
        public DateTime dstart { get; set; }
        public DateTime dend { get; set; }
        public string ddescription { get; set; }
        public string daid { get; set; }
    }
}
