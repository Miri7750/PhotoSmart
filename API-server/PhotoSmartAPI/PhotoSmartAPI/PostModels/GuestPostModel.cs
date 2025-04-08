namespace PhotoSmart.Api.PostModels
{
    public class GuestPostModel
{
    public string? FirstName { get; set; } // שם פרטי של האורח

    public string? LastName { get; set; } // שם משפחה של האורח
    public byte[]? Face { get; set; }
   
    public string FaceUrl { get; set; } // נתוני פנים של האורח (כמו תמונה)
}

}
