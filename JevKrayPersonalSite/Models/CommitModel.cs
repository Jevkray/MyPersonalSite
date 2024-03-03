using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JevKrayPersonalSite.Models
{
    public class CommitModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        [Url]
        public string Link { get; set; }
    }
}
