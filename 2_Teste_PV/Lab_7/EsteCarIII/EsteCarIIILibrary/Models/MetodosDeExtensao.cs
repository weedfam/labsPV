using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsteCarIIILibrary.Models;

namespace EsteCarIIILibrary
{
    public static class MetodosDeExtensao
    {
        
        public static String ListaMarcas(this List<Marca> Marcas)
        {
            StringBuilder stb = new StringBuilder("{");
            String virgula="";
            foreach (Marca marca in Marcas) {
                stb.Append(virgula + marca.Designacao);
                virgula = (virgula == "")?  ", ": virgula; // ou mais simples virgula=", ";
            }
            stb.Append("}");
            return stb.ToString();
        }
    }
}
