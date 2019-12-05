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

        public override string Nome
        {
            get
            {
                return "Rei";
            }
        }

        public override string Simbolo
        {
            get
            {
                return "R";
            }
        }

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}