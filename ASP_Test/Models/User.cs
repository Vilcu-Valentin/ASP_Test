﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}


