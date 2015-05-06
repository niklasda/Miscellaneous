using System;
using System.Collections.Generic;
using System.Configuration;
using InterSystems.Data.CacheClient;
using nida.model;

namespace nida.database
{
    public class UserHandlerCache : IUserHandler
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ODbConnection"].ConnectionString;

        public static bool IsAvailable()
        {
            UserHandlerCache handler = new UserHandlerCache();
            
            return handler.tryConnect();
        }

        private bool tryConnect()
        {
             CacheConnection cnCache = null;
             try
             {
                 cnCache = new CacheConnection(_connectionString);
                 cnCache.Open();
                 return true;
             }
             catch 
             {
                 return false;
             }
             finally
             {
                 if (cnCache != null)
                 {
                     cnCache.Close();
                 }
             }
        }


        public List<MyChild> RetrieveChildren(int? parentId)
        {
            List<MyChild> users = new List<MyChild>();

            CacheConnection cnCache = null;
            try
            {
                cnCache = new CacheConnection(_connectionString);
                cnCache.Open();

                CacheCommand cmd = Child.RetrieveAllChildren(cnCache);
                cmd.Parameters.Add("ParentId", parentId);
                CacheDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string id = rd.GetString(0);

                    using (Child c = Child.OpenId(cnCache, id))
                    {
                        MyChild myc = new MyChild(c.ChildId, c.ParentId, c.Name, c.Age, c.Id());

                        users.Add(myc);
                    }
                }
                rd.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (cnCache != null)
                {
                    cnCache.Close();
                }
            }
            return users;
        }

        public List<MyChild> RetrieveChildren()
        {
            List<MyChild> users = new List<MyChild>();

            CacheConnection cnCache = null;
            try
            {
                cnCache = new CacheConnection(_connectionString);
                cnCache.Open();

                CacheCommand cmd = Child.RetrieveAll(cnCache);
                CacheDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string id = rd.GetString(0);

                    using (Child c = Child.OpenId(cnCache, id))
                    {
                        MyChild myc = new MyChild(c.ChildId, c.ParentId, c.Name, c.Age, c.Id());

                        users.Add(myc);
                    }
                }
                rd.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (cnCache != null)
                {
                    cnCache.Close();
                }
            }
            return users;
        }

        //--

        public List<MyParent> RetrieveParents()
        {
            List<MyParent> users = new List<MyParent>();

            CacheConnection pcn = null;
            try
            {
                pcn = new CacheConnection(_connectionString);
                pcn.Open();

                CacheCommand cmd = Parent.RetrieveAll(pcn);
                CacheDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int id = rd.GetInt32(0);
                    using (Parent p = Parent.OpenId(pcn, id.ToString()))
                    {
                        MyParent myp = new MyParent(p.ParentId, p.Name, p.LastLogin, p.Id(), p.MyChildren.Count);

                        if (p.MyChildren != null)
                        {
                            //foreach (Child o in p.MyChildren)
                            //{
                            //    Child c = (Child)o;
                            //    MyChild myc = new MyChild(c.ChildId, c.ParentId, c.Name, c.Age, c.Id());
                            //    myp.Children.Add(myc);
                            //}
                        }
                        users.Add(myp);
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (pcn != null)
                {
                    pcn.Close();
                } 
            }
            return users;
        }

        //--

        public void Create(int id, string name)
        {
            CacheConnection cnCache = null;
            try
            {
                cnCache = new CacheConnection(_connectionString);
                cnCache.Open();

                Parent pare = new Parent(cnCache);

                pare.ParentId = id;
                pare.Name = name;
                pare.LastLogin = DateTime.Today;

                Child ch = new Child(cnCache);
                ch.Age = 33;
                ch.ChildId = id;
                ch.ParentId = id;
                ch.Name = "Niklas";
                ch.Save();

                pare.MyChildren.Add(ch);
                pare.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (cnCache != null)
                {
                    cnCache.Close();
                }
            }
        }

        //--

        public void Delete(string id)
        {
            CacheConnection cnCache = null;
            try
            {
                cnCache = new CacheConnection(_connectionString);
                cnCache.Open();

                Parent.DeleteId(cnCache, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (cnCache != null)
                {
                    cnCache.Close();
                }
            }
        }
    }
}