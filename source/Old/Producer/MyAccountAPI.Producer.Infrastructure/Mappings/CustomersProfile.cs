namespace MyAccountAPI.Producer.Infrastructure.Mappings
{
    using MyAccountAPI.Producer.Application.Responses;
    using AutoMapper;
    using MyAccountAPI.Domain.Model.Customers;

    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, CustomerResponse>()
                    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Personnummer, opt => opt.MapFrom(src => src.PIN.Text))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Text));
        }
    }
}
