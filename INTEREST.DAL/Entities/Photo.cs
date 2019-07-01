using INTEREST.DAL.EF;
using System.ComponentModel.DataAnnotations;

namespace INTEREST.DAL.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string URL { get; set; }
    }
 }
