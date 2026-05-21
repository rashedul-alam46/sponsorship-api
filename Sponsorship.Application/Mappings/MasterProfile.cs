using AutoMapper;
using Sponsorship.Application.DTOs;
using Sponsorship.Domain.Entities;

namespace Sponsorship.Application.Mappings;

public class MasterProfile : Profile
{
    public MasterProfile()
    {
        // SponsorshipRequest mappings
        CreateMap<SponsorshipRequests, SponsorshipRequestReadDto>();
        CreateMap<SponsorshipRequestCreateDto, SponsorshipRequests>();
        CreateMap<SponsorshipRequestUpdateDto, SponsorshipRequests>();


        // WorkflowHistory mappings
        CreateMap<WorkflowHistories, WorkflowHistoryReadDto>();
        CreateMap<WorkflowHistoryCreateDto, WorkflowHistories>();
    }
}
