using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.EF;

namespace ClassLibrary1
{
    public class DataAccess
    {
        public IEnumerable<Person> GetAll()
        {
            var mdl = new Model1Container();
            
            IEnumerable<Person> p = from x in mdl.PersonSet select x;
            return p;
        }

        public void RemoveAll()
        {
            var mdl = new Model1Container();
            IEnumerable<Skill> skill = from x in mdl.SkillSet select x;

            foreach (var s in skill)
            {
                mdl.DeleteObject(s);
            } 
            
            IEnumerable<Person> pers = from x in mdl.PersonSet select x;

            foreach (var p in pers)
            {
                mdl.DeleteObject(p);
            }
            mdl.SaveChanges();
        }

        public void Insert()
        {
            var mdl = new Model1Container();

            Skill s = new Skill();
            s.Id = 1;
            s.Name = "Dev";

            Person p = new Person();
            p.Skill.Add(s);
            p.Id = 1;
            p.Name = "Niklas2";
            p.Age = 35;
            
            mdl.PersonSet.AddObject(p);
            mdl.SaveChanges();
        }
    }
}
