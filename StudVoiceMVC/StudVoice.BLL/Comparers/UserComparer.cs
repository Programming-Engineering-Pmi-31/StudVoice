using System.Collections.Generic;
using StudVoice.BLL.DTOs;

namespace StudVoice.BLL.Comparers
{
    public class UserComparer : IEqualityComparer<UserDTO>
    {
        /// <summary>
        /// Determines whether two objects of this type are equal.
        /// Id and Role.Id properties were ignored, because they are 
        /// assigned automatically by database.
        /// Password is also ignored, because password hash is saved
        /// to database, not password.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(UserDTO x, UserDTO y)
        {
            return x != null && y != null
                             && x.Name == y.Name
                             && x.MiddleName == y.MiddleName
                             && x.Surname == y.Surname
                             && x.UserName == y.UserName
                             && x.Role.Name == y.Role.Name;
        }

        public int GetHashCode(UserDTO obj)
        {
            return obj.GetHashCode();
        }
    }
}