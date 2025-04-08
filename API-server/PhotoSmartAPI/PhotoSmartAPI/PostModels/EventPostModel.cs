namespace PhotoSmart.Api.PostModels
{
    public class EventPostModel
    {
        public string Title { get; set; } = null!; // כותרת האירוע

        public string? Description { get; set; } // תיאור האירוע (אופציונלי)

        public DateTime? EventDate { get; set; } // תאריך האירוע (אופציונלי)
    }

}
