﻿using System;
using System.Collections.Generic;
using System.Text;
using StudVoice.DAL.Repositories.InterfacesRepositories;

namespace StudVoice.DAL.Repositories.ImplementedRepositories
{
    public class FacultyRepository : BaseRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(StudVoiceDBContext context) : base(context)
        {
        }
    }
}
