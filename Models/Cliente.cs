using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EstCarII.Models
{
    public class Cliente : IdentityUser
    {
        [PersonalData, Required]
        public string Nome { get; set; }
    }
}
