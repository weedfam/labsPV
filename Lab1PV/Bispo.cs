using System;

namespace Xadrez
{
    public class Bispo : Peca
    {
        public Bispo(bool corBranca, Posicao posicao) : base(corBranca, posicao)
        {
        }

        public override string ToString()
        {
            return "B" + base.ToString();
        }

        public override string Nome
        {
            get
            {
                return "Bispo";
            }
        }

        public override string Simbolo
        {
            get
            {
                return "B";
            }
        }

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}