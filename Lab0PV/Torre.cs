namespace Xadrez
{
    public class Torre : Peca
    {
        public Torre(bool corBranca, Posicao posicao) : base(corBranca, posicao)
        {
        }

        public override string ToString()
        {
            return "T" + base.ToString();
        }

        // Nível 3
        public override string GetNome()
        {
            return "Torre";
        }

        // Nível 4
        public override void Deslocar(int dx, int dy)
        {
            if (dx != 0 && dy != 0)
                return;
            SetX((char)(GetX() + dx));
            SetY(GetY() + dy);
        }

        // Desafio
        public override string GetSimbolo()
        {
            return "T";
        }
    }
}