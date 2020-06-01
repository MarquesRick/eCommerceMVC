using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core.Model
{
    public class User
    {
        [_MapperTO("ID_USER")]
        public int id_user { get; set; }

        [Required]
        [_MapperTO("NOME_USER")]
        public string nome_user { get; set; }

        [Required]
        [_MapperTO("EMAIL")]
        public string email { get; set; }

        [Required]
        [_MapperTO("IDADE")]
        public int idade { get; set; }

        [_MapperTO("LOGIN")]
        public string login { get; set; }

        [_MapperTO("PASSWORD")]
        public string password { get; set; }

        [_MapperTO("ACTIVE")]
        public string active { get; set; }

        [_MapperTO("ATTEMPTS")]
        public int attempts { get; set; }

        [_MapperTO("BLOCKED")]
        public string blocked { get; set; }
        
        [_MapperTO("PROFILE_ID")]
        public int profile_id { get; set; }

        [_MapperTO("CHANGE_PASSWORD")]
        public int change_password { get; set; }
    }
}