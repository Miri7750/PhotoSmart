﻿namespace PhotoSmart.Api.PostModels
{
    public class UserPostModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? BornTown { get; set; }
        public string? CurrentTown { get; set; }
        public string? ProfilePicture { get; set; }
        public string? RegisteredOn { get; set; }
         

    }
}
