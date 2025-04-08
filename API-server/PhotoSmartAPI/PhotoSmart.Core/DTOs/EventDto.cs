using PhotoSmart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.DTOs
{
    public class EventDto
{
    public int Id { get; set; } // מזהה ייחודי של האירוע
    public int UserId { get; set; }

    public string Title { get; set; } = null!; // כותרת האירוע

    public string? Description { get; set; } // תיאור האירוע (אופציונלי)

    public DateTime? EventDate { get; set; } // תאריך האירוע (אופציונלי)

   // public string User { get; set; } = null!; // שם המשתמש שיצר את האירוע
}

}
