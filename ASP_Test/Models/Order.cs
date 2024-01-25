using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; }
}

