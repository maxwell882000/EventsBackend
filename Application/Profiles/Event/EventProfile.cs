using AutoMapper;
using EventsBookingBackend.Application.Models.Event.Responses;

namespace EventsBookingBackend.Application.Profiles.Event;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Domain.Event.Entities.Event, GetAllEventsResponse>()
            .ForMember(e => e.WorkDay,
                opt => opt.MapFrom(e => e.Building.WorkDay!.Day))
            .ForMember(e => e.NextTime,
                opt => opt.MapFrom(e => e.Building.NextTime))
            .ForMember(e => e.IsOpen,
                opt => opt.MapFrom(e => e.Building.IsOpen))
            .ForMember(e => e.Image,
                opt => opt.MapFrom(e => e.PreviewImage))
            .ForMember(e => e.Address,
                opt => opt.MapFrom(e => e.Building.Address))
            .ForMember(e => e.Coordinates,
                opt => opt.MapFrom(e => e.Building.LatLong))
            .ForMember(e => e.Mark,
                opt => opt.MapFrom(e => e.AggregatedReviews!.OverallMark))
            .ForMember(e => e.ReviewCount,
                opt => opt.MapFrom(e => e.AggregatedReviews!.ReviewCount))
            .ForMember(e => e.CategoryId,
                opt => opt.MapFrom(e => e.CategoryId))
            .ForMember(e => e.IsLiked, opt => opt.MapFrom(e => e.LikedEvents.Count > 0));

        CreateMap<Domain.Event.Entities.Event, GetEventDetailResponse>()
            .ForMember(e => e.WorkHours,
                opt => opt.MapFrom(e => e.Building.WorkHours))
            .ForMember(e => e.WorkDay,
                opt => opt.MapFrom(e => e.Building.WorkDay!.Day))
            .ForMember(e => e.NextTime,
                opt => opt.MapFrom(e => e.Building.NextTime))
            .ForMember(e => e.IsOpen,
                opt => opt.MapFrom(e => e.Building.IsOpen))
            .ForMember(e => e.Image,
                opt => opt.MapFrom(e => e.PreviewImage))
            .ForMember(e => e.Address,
                opt => opt.MapFrom(e => e.Building.Address))
            .ForMember(e => e.Coordinates,
                opt => opt.MapFrom(e => e.Building.LatLong))
            .ForMember(e => e.Mark,
                opt => opt.MapFrom(e => e.AggregatedReviews!.OverallMark))
            .ForMember(e => e.ReviewCount,
                opt => opt.MapFrom(e => e.AggregatedReviews!.ReviewCount))
            .ForMember(e => e.CategoryId,
                opt => opt.MapFrom(e => e.CategoryId))
            .ForMember(e => e.IsLiked, opt => opt.MapFrom(e => e.LikedEvents.Count > 0));
    }
}