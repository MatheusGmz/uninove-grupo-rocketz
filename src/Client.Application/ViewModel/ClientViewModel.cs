using System;
using System.ComponentModel.DataAnnotations;

namespace Login.Application.ViewModel
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        [EmailAddress(ErrorMessage = "This is not a valid e-mail")]
        public string Email { get; set; }
        public byte Age { get; set; }
        public bool Deleted { get; set; }
    }
}
