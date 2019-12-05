namespace Xadrez
{
    // Nível 4 (Lab 1)
    public delegate void Funcao(Peca peca);

    public abstract class Peca : IMover
    {
        private Posicao posicao = new Posicao();

        public bool IsBranca { get; set; }
        public virtual string Nome { get { return "desconhecida"; } }
        public abstract string Simbolo { get; }

        // Nível 4 (Lab 1)
        public event Funcao Moved;

        public Posicao Posicao
        {
            get
            {
                return new Posicao(posicao.X, posicao.Y);
            }
        }

        public char X
        {
            get
            {
                return posicao.X;
            }
            set
            {
                if (posicao.X != value)
                {
                    posicao.X = value;
                    if (Moved != null)
                        Moved(this);
                }
            }
        }

        public int Y
        {
            get
            {
                return posicao.Y;
            }
            set
            {
                if (posicao.Y != value)
                {
                    posicao.Y = value;
                    if (Moved != null)
                        Moved(this);
                }
            }
        }

        public Peca(bool isBranca, Posicao posicao)
        {
            IsBranca = isBranca;
            this.posicao = posicao ?? new Posicao();
        }

        public override string ToString()
        {
            return posicao.ToString();
        }

        // Nível 4
        public abstract void Deslocar(int dx, int dy);
    }
}