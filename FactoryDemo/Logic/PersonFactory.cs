using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryDemo
{
    public class PersonFactory
    {
        public PersonFactory(IDatabase database)
        {
            db = database;
        }
        private IDatabase db;

        public Person CreateNewPerson(int id)
        {
            bool alreadyExists = db.PersonIdAlreadyExists(id);

            if(alreadyExists)
            {
                throw new BusinessException(string.Format("Person id={0} already exists", id));
            }
            return new Person(id);
        }

        public Person GetExistingPerson(int id)
        {
            Person existing = db.GetExistingPerson(id);
            
            if(existing == null)
            {
                throw new BusinessException(string.Format("Person id={0} does not exist", id));                
            }
            return existing;
        }

    }
}
