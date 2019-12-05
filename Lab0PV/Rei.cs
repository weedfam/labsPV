using System;

namespace Xadrez
{
    public class Rei : Peca
    {
        public Rei(bool corBranca, Posicao posicao) : base(corBranca, posicao)
        {
        }

        public override string ToString()
        {
            return "R" + base.ToString();
        }

        public override string GetNome()
        {
            return "Rei";
        }

        public override string GetSimbolo()
        {
            return "R";
        }

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}