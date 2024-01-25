using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class OrderProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
}
