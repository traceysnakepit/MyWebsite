using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Model
{
    public class NewGoodsCollection
    {
        [Key]
        public string gname
        {
            get; set;
        }
        public string gtotal
        {
            get; set;
        }
        public string gtype
        {
            get; set;
        }
        public string gdescription
        {
            get; set;
        }
        public DateTime gdate
        {
            get; set;
        }

    }
}
