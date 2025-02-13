using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEstoqueRN.Model
{
    public static class Usuario
    {
        public static int IdUsuario { get; private set; }
        public static string NomeUsuario { get; private set; }
        public static string Cargo {  get; private set; }

        public static void DefinirUsuario(int id, string nome, string cargo)
        {
            IdUsuario = id;
            NomeUsuario = nome;
            Cargo = cargo;
        }
    }
}
