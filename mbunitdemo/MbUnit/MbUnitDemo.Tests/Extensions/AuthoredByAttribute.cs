using MbUnit.Framework;

namespace MbUnitDemo.Tests.Extensions
{
    public class AuthoredByNiklasAttribute : AuthorAttribute
    {
        public AuthoredByNiklasAttribute()
            : base("Niklas Dahlman", "nd@nida.se")
        {
        }
    }

    public class AuthoredByDotwayAttribute : AuthorAttribute
    {
        public AuthoredByDotwayAttribute()
            : base("Dotway:Niklas", "niklas.dahlman@dotway.se", "http://dotway.se")
        {
        }
    }
}