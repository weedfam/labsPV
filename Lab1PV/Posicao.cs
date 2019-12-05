namespace Xadrez
{
    public class Posicao
    {
        private const char xInicial = 'a';
        private const int yInicial = 1;

        public char X { get; set; } = xInicial;
        public int Y { get; set; } = yInicial;

        public Posicao(char x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Posicao() : this ( xInicial, yInicial)
        {
        }

        public override string ToString()
        {
            return "" + X + Y;
        }
    }
}