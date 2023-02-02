using AutoMapper;
namespace Helpers.ObjectsUtils
{
    public static class MapperObject
    {
        public static IMapper mapper = new MapperConfiguration(cfg => { }).CreateMapper();
        public static IMapper mapperWithConstructor = new MapperConfiguration(cfg => { cfg.ShouldUseConstructor = ci => !ci.IsPrivate; }).CreateMapper();
    }
}
