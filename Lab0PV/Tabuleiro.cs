using System;

namespace Xadrez
{
    public class Tabuleiro
    {
        private Peca[,] tabuleiro;

        public Tabuleiro()
        {
            tabuleiro = new Peca[8, 8];

            for (int x = 0; x < 8; x++)
            {
                tabuleiro[x, 1] = new Peao(true, new Posicao((char)('a' + x), 2));
                tabuleiro[x, 6] = new Peao(false, new Posicao((char)('a' + x), 7));
            }
            int line = 1;
            bool isBranca = true;
            tabuleiro[0, 0] = new Torre(isBranca, new Posicao('a', line));
            tabuleiro[1, 0] = new Cavalo(isBranca, new Posicao('b', line));
            tabuleiro[2, 0] = new Bispo(isBranca, new Posicao('c', line));
            tabuleiro[3, 0] = new Rainha(isBranca, new Posicao('d', line));
            tabuleiro[4, 0] = new Rei(isBranca, new Posicao('e', line));
            tabuleiro[5, 0] = new Bispo(isBranca, new Posicao('f', line));
            tabuleiro[6, 0] = new Cavalo(isBranca, new Posicao('g', line));
            tabuleiro[7, 0] = new Torre(isBranca, new Posicao('h', line));

            line = 8;
            isBranca = false;
            tabuleiro[0, 7] = new Torre(isBranca, new Posicao('a', line));
            tabuleiro[1, 7] = new Cavalo(isBranca, new Posicao('b', line));
            tabuleiro[2, 7] = new Bispo(isBranca, new Posicao('c', line));
            tabuleiro[3, 7] = new Rainha(isBranca, new Posicao('d', line));
            tabuleiro[4, 7] = new Rei(isBranca, new Posicao('e', line));
            tabuleiro[5, 7] = new Bispo(isBranca, new Posicao('f', line));
            tabuleiro[6, 7] = new Cavalo(isBranca, new Posicao('g', line));
            tabuleiro[7, 7] = new Torre(isBranca, new Posicao('h', line));
        }

        public void Mostrar()
        {

            for (int y = 7; y >= 0; y--)
            {
                Console.Write(y + 1 + "  ");
                for (int x = 0; x < 8; x++)
                {
                    Peca peca = tabuleiro[x, y];
                    if (peca == null)
                    {
                        Console.Write("  ");
                        continue;
                    }
                    if (peca.IsBranca())
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca.GetSimbolo() + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
        }
    }
}