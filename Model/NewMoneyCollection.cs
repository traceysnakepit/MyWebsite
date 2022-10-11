using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Model
{
    public class NewMoneyCollection
    {
        [Key]
        public int mid { get; set; }
        public string mname { get; set; }
        public string mamount { get; set; }
        public DateTime mdate { get; set; }

    }
}
