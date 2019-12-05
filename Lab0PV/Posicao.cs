namespace Xadrez
{
    public class Posicao
    {
        private char x;
        private int y;

        private const char xInicial = 'a';
        private const int yInicial = 1;

        public Posicao(char x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Posicao()
        {
            this.x = xInicial;
            this.y = yInicial;
        }

        public override string ToString()
        {
            return "" + x + y;
        }

        public char GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void SetX(char x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }
    }
}