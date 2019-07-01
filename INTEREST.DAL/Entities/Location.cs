using INTEREST.DAL.EF;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTEREST.DAL.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
    }
}
