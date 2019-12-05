namespace Xadrez
{
    public abstract class Peca : IMover
    {

        private bool corBranca;
        private Posicao posicao;

        // Desafio
        private string simbolo = "";

        public Peca(bool corBranca, Posicao posicao)
        {
            this.corBranca = corBranca;
            if (posicao != null)
            {
                this.posicao = posicao;
            }
            else
            {
                this.posicao = new Posicao();
            }
        }

        public bool IsBranca()
        {
            return corBranca;
        }

        public Posicao GetPosicao()
        {
            return new Posicao(posicao.GetX(), posicao.GetY());
        }

        public void SetPosicao(char x, int y)
        {
            posicao.SetX(x);
            posicao.SetY(y);
        }

        public void SetPosicao(Posicao posicao)
        {
            posicao.SetX(posicao.GetX());
            posicao.SetY(posicao.GetY());
        }

        public void SetX(char x)
        {
            posicao.SetX(x);
        }

        public void SetY(int y)
        {
            posicao.SetY(y);
        }

        public char GetX()
        {
            return posicao.GetX();
        }

        public int GetY()
        {
            return posicao.GetY();
        }

        public override string ToString()
        {
            return posicao.ToString();
        }

        // Nível 3
        public virtual string GetNome()
        {
            return "desconhecida";
        }


        // Nível 4
        public abstract void Deslocar(int dx, int dy);

        // desafio
        public virtual string GetSimbolo()
        {
            return simbolo;
        }
    }
}