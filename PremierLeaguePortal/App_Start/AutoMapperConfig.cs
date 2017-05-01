using AutoMapper;
using PremierLeaguePortal.Areas.Administration.Models;
using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Player, PlayerViewModel>();
            });
        }
    }
}