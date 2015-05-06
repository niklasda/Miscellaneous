using System;
namespace DependencyInjectionDemo
{
    /// <summary>
    /// The interface is placedin a common assembly so it can easily be shared
    /// </summary>
    public interface IDatabase
    {
        string GetVersion();
    }
}
