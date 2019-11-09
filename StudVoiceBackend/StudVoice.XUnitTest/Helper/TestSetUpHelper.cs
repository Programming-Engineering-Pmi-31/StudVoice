using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudVoice.DAL;

namespace StudVoice.XUnitTest.Helper
{
    public static class TestSetUpHelper
    {
        public static StudVoiceDBContext CreateDbContext()
        {
            return new StudVoiceDBContext(
                new DbContextOptionsBuilder<StudVoiceDBContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .EnableSensitiveDataLogging()
                    .Options
            );
        }
    }
}
