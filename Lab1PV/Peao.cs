namespace Xadrez
{
    public class Peao : Peca
    {
        public Peao(bool corBranca, Posicao posicao) : base(corBranca, posicao)
        {
        }

        public override string Nome
        {
            get
            {
                return "Peão";
            }
        }

        public override void Deslocar(int dx, int dy)
        {
            Y += dy;
        }

        public static Peao operator ++(Peao peao)
        {
            peao.Deslocar(0, 1);
            return peao;
        }

        public override string Simbolo
        {
            get
            {
                return "P";
            }
        }
    }
}