namespace PremierLeaguePortal
{
    using AutoMapper;
    using PremierLeaguePortal.Areas.Administration.Models;
    using PremierLeaguePortal.Models;
    public class AutoMapperConfig
    {
        //public static IMapper Mapper;
        public static void RegisterMappings()
        {
            Mapper.Initialize(expression =>
            {
                //expression.CreateMap<Player, PlayerViewModel>().ReverseMap();
                expression.CreateMap<Blog, BlogViewModel>().ReverseMap();
                //expression.CreateMap<Wheel, WheelViewModel>();

                //expression.CreateMap<Tyre, ProductViewModel>()
                //    .ForMember(pvm => pvm.Size, p => p.MapFrom(t => t.Size))
                //    .ForMember(pvm => pvm.Height, p => p.MapFrom(t => t.Height))
                //    .ForMember(pvm => pvm.Width, p => p.MapFrom(t => t.Width));
                //expression.CreateMap<Wheel, ProductViewModel>()
                //    .ForMember(pvm => pvm.Size, p => p.MapFrom(t => t.Size))
                //    .ForMember(pvm => pvm.PCD, p => p.MapFrom(w => w.PCD));

                //expression.CreateMap<EditProductBindingModel, Product>();
                //expression.CreateMap<Order, OrderViewModel>();
                //expression.CreateMap<NewTyreBindingModel, Tyre>().ForMember(t => t.ImageUrl, tv => tv.Ignore());
                //expression.CreateMap<NewWheelBindingModel, Wheel>().ForMember(t => t.ImageUrl, tv => tv.Ignore());
                //expression.CreateMap<User, UserViewModel>();
            });
        }
    }
}