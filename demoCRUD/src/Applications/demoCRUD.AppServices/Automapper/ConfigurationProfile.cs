using AutoMapper;
using Domain.Model.Entities;

namespace demoCRUD.AppServices.Automapper
{
    /// <summary>
    /// EntityProfile
    /// </summary>
    public class ConfigurationProfile : Profile
    {
        /// <summary>
        /// ConfigurationProfile
        /// </summary>
        public ConfigurationProfile()
        {
            CreateMap<Entity, DrivenAdapters.Mongo.Entities.Entity>();
            CreateMap<DrivenAdapters.Mongo.Entities.Entity, Entity>();
        }
    }
}