using EventsBookingBackend.Application.Models.Common;

namespace EventsBookingBackend.Application.Models.Review.Responses;

public class GetReviewsByEventResponse
{
    public double Mark { get; set; }
    public int ReviewCount { get; set; }
    public UserReviewDto? OwnReview { get; set; }
    public List<UserReviewDto> UserReviews { get; set; }

    public class UserReviewDto
    {
        public string Name { get; set; }
        public int Mark { get; set; }
        public FileDto Avatar { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}