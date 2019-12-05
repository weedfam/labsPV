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

        public override string Nome
        {
            get
            {
                return "Rainha";
            }
        }

        public override string Simbolo
        {
            get
            {
                return "D";
            }
        }

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}