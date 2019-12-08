using System;
using AutoMapper;
using StudVoice.BLL.Mappings;

namespace StudVoice.XUnitTest
{
    public class MapperFixture : IDisposable
    {
        /// <summary>
        /// Automapper configuration
        /// </summary>
        public IMapper Mapper { get; } = new MapperConfiguration(c =>
        {
            c.AddProfile(new RoleProfile());
            c.AddProfile(new UserProfile());
            c.AddProfile(new RoleProfile());
        }).CreateMapper();

        public void Dispose()
        {
        }
    }
}
