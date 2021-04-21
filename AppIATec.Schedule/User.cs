using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Schedule.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Sex Sex { get; private set; }
        public EventType Type { get; set; }

        public User(string name, string email, string login, string password, DateTime birthDate, Sex sex, EventType type)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentException(nameof(name));
            Email = email ?? throw new ArgumentException(nameof(email));
            Login = login ?? throw new ArgumentException(nameof(login));
            Password = password ?? throw new ArgumentException(nameof(password));
            BirthDate = birthDate;
            Sex = sex;
            Type = type;
        }

        public void UpdateUser(string name, string email, string login, string password, DateTime birthDate, Sex sex, EventType type)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            BirthDate = birthDate;
            Sex = sex;
            Type = type;
        }
    }
}
