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
        public override string Nome => "Torre";

        // Nível 4
        public override void Deslocar(int dx, int dy)
        {
            if (dx != 0 && dy != 0)
                return;
            X = (char)(X + dx);
            Y += dy;
        }

        // Desafio
        public override string Simbolo => "T";
    }
}