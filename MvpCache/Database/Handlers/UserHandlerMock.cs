using System;
using System.Collections.Generic;
using nida.model;

namespace nida.database
{
    public class UserHandlerMock : IUserHandler
    {
        public List<MyChild> RetrieveChildren(int? parentId)
        {
            List<MyChild> users = new List<MyChild>();

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    MyChild myc = new MyChild(i, i, "i", 20 + i, i.ToString());

                    users.Add(myc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return users;
        }

        public List<MyChild> RetrieveChildren()
        {
            
            return RetrieveChildren(3);
        }

        //--

        public List<MyParent> RetrieveParents()
        {
            List<MyParent> users = new List<MyParent>();

            try
            {
                for (int i = 0; i < 5; i++)
                {
                   // int id = i;
                    MyParent myp = new MyParent(i, "Name" + 1, DateTime.Today, i.ToString(), 1);


                    users.Add(myp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
           
            return users;
        }

        //--

        public void Create(int id, string name)
        {
        }

        //--

        public void Delete(string id)
        {
        }
    }
}