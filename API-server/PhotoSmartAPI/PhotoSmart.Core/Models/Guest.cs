using PhotoSmart.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Guest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int EventId { get; set; }

    public string? FirstName { get; set; } 

    public string? LastName { get; set; }

    public string? FaceUrl { get; set; } // נתוני פנים של האורח (כמו תמונה)

    public byte[]? Face { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
}