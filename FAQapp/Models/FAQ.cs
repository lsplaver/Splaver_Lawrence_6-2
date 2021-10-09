using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FAQapp.Models
{
    public class FAQ
    {
        public int FAQId { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        [DataType(DataType.Date)]
        public string YearFormed { get; set; }
        [Url]
        public string BandWebsite { get; set; }
        [Url]
        public string SecondLink { get; set; }
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
