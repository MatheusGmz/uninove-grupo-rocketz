using System;
using System.ComponentModel.DataAnnotations;

namespace Login.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public byte Age { get; set; }
        public bool Deleted { get; set; }
    }
}
