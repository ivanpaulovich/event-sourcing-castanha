namespace MyAccountAPI.Producer.Infrastructure.Mappings
{
    using MyAccountAPI.Producer.Application.Responses;
    using AutoMapper;
    using MyAccountAPI.Producer.Application.UseCases.CloseAccount;
    using MyAccountAPI.Domain.Model.Accounts;

    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<Account, AccountResponse>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CurrentBalance, opt => opt.MapFrom(src => src.CurrentBalance.Value));

            CreateMap<Debit, TransactionResponse>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.Value))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate));

            CreateMap<Credit, TransactionResponse>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.Value))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate));

            CreateMap<Account, CloseResponse>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
