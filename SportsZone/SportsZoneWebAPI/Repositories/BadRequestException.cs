using System;

namespace SportsZoneWebAPI.Repositories
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
