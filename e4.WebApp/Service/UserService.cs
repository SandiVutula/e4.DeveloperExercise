using e4.WebApp.Model;
using System.Xml.Linq;

namespace e4.WebApp.Service
{
    public class UserService
    {
        private readonly string _xmlFilePath;

        public UserService(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            if (File.Exists(_xmlFilePath))
            {
                XElement usersXml = XElement.Load(_xmlFilePath);
                users = (from user in usersXml.Elements("User")
                         select new User
                         {
                             Name = user.Element("Name").Value,
                             Surname = user.Element("Surname").Value,
                             Cellphone = user.Element("Cellphone").Value
                         }).ToList();
            }

            return users;
        }

        public void AddUser(User user)
        {
            XElement usersXml = XElement.Load(_xmlFilePath);
            usersXml.Add(new XElement("User",
                new XElement("Name", user.Name),
                new XElement("Surname", user.Surname),
                new XElement("Cellphone", user.Cellphone)));
            usersXml.Save(_xmlFilePath);
        }

        public void EditUser(User user)
        {
            XElement usersXml = XElement.Load(_xmlFilePath);
            XElement userXml = (from u in usersXml.Elements("User")
                                where u.Element("Cellphone").Value == user.Cellphone
                                select u).FirstOrDefault();
            if (userXml != null)
            {
                userXml.Element("Name").Value = user.Name;
                userXml.Element("Surname").Value = user.Surname;
                usersXml.Save(_xmlFilePath);
            }
        }

        public void DeleteUser(string cellphone)
        {
            XElement usersXml = XElement.Load(_xmlFilePath);
            XElement userXml = (from user in usersXml.Elements("User")
                                where user.Element("Cellphone").Value == cellphone
                                select user).FirstOrDefault();
            if (userXml != null)
            {
                userXml.Remove();
                usersXml.Save(_xmlFilePath);
            }
        }
    }

}
