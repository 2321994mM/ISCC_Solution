using AutoMapper;
using ISCC.Application.DTOs;
using ISCC.Domain.Entities;

namespace ISCC.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Payment, PaymentDto>()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));

        CreateMap<CreatePaymentRequest, Payment>()
            .ForMember(d => d.Status, opt => opt.MapFrom(_ => Domain.Enums.PaymentStatus.Pending));

        CreateMap<Inspection, InspectionDto>()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));

        CreateMap<CreateInspectionRequest, Inspection>()
            .ForMember(d => d.Status, opt => opt.MapFrom(_ => Domain.Enums.InspectionStatus.Scheduled));

        CreateMap<Employer, EmployerDto>();
        CreateMap<CreateEmployerRequest, Employer>();

        CreateMap<Client, ClientDto>();
        CreateMap<CreateClientRequest, Client>();

        CreateMap<Certificate, CertificateDto>()
            .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type.ToString()));

        CreateMap<CreateCertificateRequest, Certificate>();
    }
}
