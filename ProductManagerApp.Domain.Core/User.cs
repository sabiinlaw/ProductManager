﻿namespace ProductManagerApp.Domain.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
    }
}
