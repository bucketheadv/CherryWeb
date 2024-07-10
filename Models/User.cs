using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CherryWeb.Models
{
    [Table(name: "t_user")]
    public class User : BasePo
    {
        [Key]
        public long? Id { get; set; }

        [Column(name:"username")]
        public string? Username { get; set; }
    }
}