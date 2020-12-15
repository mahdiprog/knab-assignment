using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace CryptoRate.Application.UnitTests.Mappings
{
    public class MappingTestsFixture
    {
        public MappingTestsFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile(new Profile(Assembly.GetExecutingAssembly()));
            });

            Mapper = ConfigurationProvider.CreateMapper();
        }

        public AutoMapper.IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }
    }
}
