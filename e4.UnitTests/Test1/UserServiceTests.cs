using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using Xunit;
using e4.WebApp.Service;
using e4.WebApp.Model;

namespace e4.UnitTests.Test1
{
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly string _xmlFilePath;

        public UserServiceTests()
        {
            // Creating a temporary file for testing
            _xmlFilePath = Path.Combine(Path.GetTempPath(), "test-users.xml");
            File.Copy("Users.xml", _xmlFilePath, true);

            _userService = new UserService(_xmlFilePath);
        }

        [Fact]
        public void GetAllUsers_ReturnsAllUsers()
        {
            // Arrange: 
            _userService.AddUser(new User { Name = "Sandisiwe", Surname = "Vutula", Cellphone = "0870009993" });
            _userService.AddUser(new User { Name = "Donna", Surname = "Vutula", Cellphone = "0680009993" });

            // Act: 
            var result = _userService.GetAllUsers();

            // Assert: 
            Assert.Equal(2, result.Count);
            Assert.Equal("Sandisiwe", result[0].Name);
            Assert.Equal("Donna", result[1].Name);
        }

        [Fact]
        public void AddUser_AddsNewUser()
        {
            // Arrange:
            var newUser = new User { Name = "Mellie", Surname = "Vutula", Cellphone = "0870009993" };

            // Act:
            _userService.AddUser(newUser);

            // Assert:
            var usersXml = XElement.Load(_xmlFilePath);
            var addedUserXml = usersXml.Elements("User").FirstOrDefault(u => u.Element("Cellphone").Value == newUser.Cellphone);
            Assert.NotNull(addedUserXml);
            Assert.Equal(newUser.Name, addedUserXml.Element("Name").Value);
        }

        [Fact]
        public void EditUser_EditsExistingUser()
        {
            // Arrange:
            var existingUser = new User { Name = "Sandisiwe", Surname = "Buso", Cellphone = "0879958858" };
            _userService.AddUser(existingUser);

            // Act:
            existingUser.Name = "Bob";
            _userService.EditUser(existingUser);

            // Assert:
            var usersXml = XElement.Load(_xmlFilePath);
            var editedUserXml = usersXml.Elements("User").FirstOrDefault(u => u.Element("Cellphone").Value == existingUser.Cellphone);
            Assert.NotNull(editedUserXml);
            Assert.Equal(existingUser.Name, editedUserXml.Element("Name").Value);
        }

        [Fact]
        public void DeleteUser_DeletesExistingUser()
        {
            // Arrange: 
            var existingUser = new User { Name = "Sandisiwe", Surname = "Buso", Cellphone = "0879958858" };
            _userService.AddUser(existingUser);

            // Act:
            _userService.DeleteUser(existingUser.Cellphone);

            // Assert:
            var usersXml = XElement.Load(_xmlFilePath);
            var deletedUserXml = usersXml.Elements("User").FirstOrDefault(u => u.Element("Cellphone").Value == existingUser.Cellphone);

        }
    }
}