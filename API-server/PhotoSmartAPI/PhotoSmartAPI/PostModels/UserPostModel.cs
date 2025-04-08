namespace PhotoSmart.Api.PostModels
{
    public class UserPostModel
    {
    public string FirstName { get; set; } = null!; // שם פרטי של המשתמש

 
    public string LastName { get; set; } = null!; // שם משפחה של המשתמש

 
    public string Email { get; set; } = null!; // כתובת דוא"ל של המשתמש

    public string Password { get; set; } = null!; // סיסמת המשתמש

    }
}
