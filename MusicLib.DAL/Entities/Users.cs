﻿namespace MusicLib.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public Role? Role { get; set; }
        public int? RoleId { get; set; }
    }
}
