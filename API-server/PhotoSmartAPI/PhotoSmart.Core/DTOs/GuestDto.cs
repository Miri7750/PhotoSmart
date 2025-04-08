using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.DTOs
{
    public class GuestDto
{
    public int Id { get; set; } // מזהה ייחודי של האורח

    public string? FirstName { get; set; } // שם פרטי של האורח

    public string? LastName { get; set; }  // שם משפחה של האורח

    public string FaceUrl { get; set; }=null!; // נתוני פנים של האורח (כמו תמונה)
    public byte[]? Face { get; set; }

}

}
