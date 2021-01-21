using DBFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstDemo.Service
{
    public class Services
    {

        public user GetUserById(int id)
        {
            user result = new user();
            
                using (UserDBEntities4 DBUser = new UserDBEntities4())
                {
                    
                    result = DBUser.users.FirstOrDefault(c => c.ID == id);
                }

            return result;
        }

        public List<user> GetUsers()
        {
            List<user> result = new List<user>();

            using (UserDBEntities4 DBUser = new UserDBEntities4())
            {

                result = DBUser.users.Select(c => c).ToList(); 
            }
            return result;
        }
        public string Delete(int id)
        {
            string result = "";
            try
            {
                using (UserDBEntities4 DBUser = new UserDBEntities4())
                {
                    user data = DBUser.users.FirstOrDefault(d => d.ID == id);
                    DBUser.users.Remove(data);
                    var res =  DBUser.SaveChanges();
                    if (res == 1)
                    {
                        result = "Success";
                    }
                    else
                    {
                        result = "Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            return result;
        }

        public string UpdateUser(user user)
        {
            string result = "";
            try
            {
                using (UserDBEntities4 DBUser = new UserDBEntities4())
                {
                    user data = DBUser.users.FirstOrDefault(d => d.ID == user.ID);

                    data.FirstName = user.FirstName;
                    data.LastName = user.LastName;
                    data.MiddleName = user.MiddleName;
                    data.Contact = user.Contact;

                    var res = DBUser.SaveChanges();
                    if (res == 1)
                    {
                        result = "Success";
                    }
                    else
                    {
                        result = "Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string Insert_data(user _user)
        {
            string result = "";
            try
            {
                using (UserDBEntities4 DBUser = new UserDBEntities4())
                {
                    var user = DBUser.users.FirstOrDefault(d => d.FirstName == _user.FirstName && d.LastName == _user.LastName);
                    if (user != null) //if name exist update data
                    {
                        result = "User already Exists!";
                    }
                    else
                    {
                       
                        DBUser.users.Add(_user);
                        var res = DBUser.SaveChanges();
                        if (res == 1)
                        {
                            result = "Success";
                        }
                        else
                        {
                            result = "Failed"; 
                        }
                        
                    }

                }

            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            return result;
        }
    }
}