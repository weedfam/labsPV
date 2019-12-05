using System;

namespace Xadrez
{
    public class Rainha : Peca
    {
        public Rainha(bool corBranca, Posicao posicao) : base(corBranca, posicao)
        {
        }

        public override string ToString()
        {
            return "D" + base.ToString();
        }

        public override string GetNome()
        {
            return "Rainha";
        }

        public override string GetSimbolo()
        {
            return "D";
        }

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}