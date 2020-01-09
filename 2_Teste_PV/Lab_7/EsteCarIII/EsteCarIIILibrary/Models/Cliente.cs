using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EsteCarIIILibrary.Models
{
    public class Cliente : IdentityUser
    {
        [PersonalData, Required]
        public string Nome { get; set; }
    }
}
