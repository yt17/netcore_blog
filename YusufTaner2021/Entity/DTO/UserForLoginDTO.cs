using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;

namespace Entity.DTO
{
    public class UserForLoginDTO: IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
