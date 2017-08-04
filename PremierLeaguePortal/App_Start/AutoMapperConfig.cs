namespace PremierLeaguePortal
{
    using AutoMapper;
    using PremierLeaguePortal.Areas.Administration.Models;
    using PremierLeaguePortal.Models;
    using PremierLeaguePortal.Utils.MailService;

    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(expression =>
            {
                //expression.CreateMap<Player, PlayerViewModel>().ReverseMap();
                expression.CreateMap<Blog, BlogViewModel>().ReverseMap();
                expression.CreateMap<Blog, HomeViewModel>()
                .ForMember(i => i.HeaderImage, h => h.MapFrom(hi => hi.HeaderImage))
                .ForMember(i => i.ApplicationUser, h => h.MapFrom(hi => hi.ApplicationUser))
                .ReverseMap();
                expression.CreateMap<ApplicationUser, UserRoleViewModel>().ReverseMap();

                expression.CreateMap<EmailMessage, EmailViewModel>().ReverseMap();

            });
        }
    }
}