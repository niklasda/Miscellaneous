using System;

namespace FactoryDemo
{
    public interface IDatabase
    {
        Person GetExistingPerson(int id);
        bool PersonIdAlreadyExists(int id);
    }
}
