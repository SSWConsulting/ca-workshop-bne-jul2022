using AutoMapper;

namespace CaWorkshop.Application.Common.Mappings;

public interface IMapFrom<TEntity>
{
    void Mapping(Profile profile)
        => profile.CreateMap(typeof(TEntity), GetType());
}
