using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CherryWeb.Models
{
    [Table(name: "user")] 
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string? Username { get; set; }
    }
}