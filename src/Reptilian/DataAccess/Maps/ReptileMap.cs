using FluentNHibernate.Mapping;

namespace Reptilian.DataAccess.Maps
{
    public class ReptileMap : ClassMap<Reptile>
    {
        public ReptileMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Breed);
        }
    }
}