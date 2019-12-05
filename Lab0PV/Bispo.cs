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

        public override string GetNome()
        {
            return "Bispo";
        }

        // Desafio
        public override string GetSimbolo()
        {
            return "B";
        }

        public override void Deslocar(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}