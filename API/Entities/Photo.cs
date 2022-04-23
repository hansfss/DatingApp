using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]//Photo class will be stored as a table called "Photos"
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public AppUser AppUser { get; set; }//define AppUser inside Photo to correctly link Photo and AppUser when performing dotnet migration
        public int AppUserId { get; set; }
    }
}