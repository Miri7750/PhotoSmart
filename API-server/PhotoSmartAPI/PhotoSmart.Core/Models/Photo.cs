using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhotoSmart.Core.Models;

public partial class Photo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int EventId { get; set; }

    public string Url { get; set; } = null!;

    public DateTime? UploadedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Event Event { get; set; } = null!;


    public virtual ICollection<Guest> Guests { get; set; } = new List<Guest>();
    public int UserId { get; set; }
}
