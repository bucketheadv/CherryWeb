using System.ComponentModel.DataAnnotations.Schema;

namespace CherryWeb.Models;

public class BasePo
{
    [Column(name:"create_time")]
    public DateTime createTime { get; set; }
    
    [Column(name:"update_time")]
    public DateTime updateTime { get; set; }
}