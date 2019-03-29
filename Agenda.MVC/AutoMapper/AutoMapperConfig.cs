using AutoMapper;

namespace Agenda.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void RegisterMappings()
        {
            var _mapper = new MapperConfiguration((mapper) =>
            {
                mapper.AddProfile<DomainToViewModel>();
                mapper.AddProfile<ViewModelToDomain>();
            });

            Mapper = _mapper.CreateMapper();
        }
    }
}