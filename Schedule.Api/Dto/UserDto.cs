using Schedule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schedule.Domain.Event;
using Schedule.Domain.User;

namespace Schedule.Api.Dto
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex? Sex { get; set; }
    }
}
