using System;

namespace Xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(bool corBranca, Posicao posicao) : base(corBranca, posicao)
        {
        }

        public override string ToString()
        {
            return "C" + base.ToString();
        }

        public override string Nome
        {
            get
            {
                return "Cavalo";
            }
        }

        // Desafio
        public override string Simbolo
        {
            get
            {
                return "C";
            }
        }

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}