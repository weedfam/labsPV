using System;

namespace Xadrez
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("    Nível 1    \n");

            Posicao pos1 = new Posicao{ X = 'e', Y = 7 }; //posicao x e y
            Posicao pos2 = new Posicao();

            Console.WriteLine("Posicao: " + pos1);
            Console.WriteLine("Posicao: " + pos2.X + pos2.Y);

            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("    Nível 2    \n");

            Peao p1 = new Peao(false, new Posicao { X = 'e', Y = 5 });
            Peao p2 = new Peao(true, new Posicao());
            p2.X = 'd';
            p2.Y = 2;

            Console.WriteLine("Peão 1 - " + p1);
            Console.WriteLine("Peão 2 - " + p2);

            Console.Write("Peão 1 na posicao: ");
            Console.WriteLine("" + p1.X + p1.Y);

            Console.Write("Peão 2 na posicao: ");
            Console.WriteLine("" + p2.X + p2.Y);

            Torre t1 = new Torre(true, pos2);

            Console.WriteLine("Torre - " + t1);
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("    Nível 3    \n");

            Peca[] pecas = new Peca[] { p1, p2, t1 };
            Console.WriteLine("Peças no array:");

            foreach (Peca peca in pecas)
                Console.WriteLine(peca.Nome);

            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("    Nível 4    \n");

            Console.WriteLine("Torre - " + t1);
            Console.WriteLine("Mover a Torre dx=2");
            t1.Deslocar(2, 0);
            Console.WriteLine("Torre - " + t1);
            Console.WriteLine("Mover a Torre dy=1");
            t1.Deslocar(0, 1);
            Console.WriteLine("Torre - " + t1);
            Console.WriteLine("Mover a Torre dx=3 e dy=3");
            t1.Deslocar(3, 3);
            Console.WriteLine("Torre - " + t1);

            Console.WriteLine("Peão - " + p1);
            Console.WriteLine("Mover o Peão dx=1");
            p1.Deslocar(1, 0);
            Console.WriteLine("Peão - " + p1);
            Console.WriteLine("Mover o Peão dy=1");
            p1.Deslocar(0, 1);
            Console.WriteLine("Peão - " + p1);
            Console.WriteLine("Mover o Peão dx=1 e dy=1");
            p1.Deslocar(1, 1);
            Console.WriteLine("Peão - " + p1);

            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("    Nível 5    \n");

            Console.WriteLine("Peão - " + p1);
            Console.WriteLine("Mover o Peão p1++");
            p1++;
            Console.WriteLine("Peão - " + p1);

            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("    Desafio    \n");

            Tabuleiro tabuleiro = new Tabuleiro();
            tabuleiro.Mostrar();

            Console.ReadKey();

            // Nivel 3 (Lab 1)
            Console.Clear();
            Console.WriteLine("    Lab 1, Nível 3 \n");

            Console.Write("\n Linha 1 -> ");
            for (char x = 'a'; x <= 'h'; x++)
                Console.Write(tabuleiro[x, 1] + "  ");

            Console.ReadKey();

            // Nivel 4 (Lab 1)
            Console.Clear();
            Console.WriteLine("    Lab 1, Nível 4 \n");

            Peca t2 = new Torre(true, new Posicao());
            t2.Moved += PecaMoveu;
            t2.X++;

            Console.ReadKey();

            // Nivel 5 (Lab 1)
            Console.Clear();
            Console.WriteLine("    Lab 1, Nível 5 \n");
            Console.Clear();

            tabuleiro.Mostrar();
            Console.ReadKey();

            tabuleiro['e', 2].Y = 4;

            Console.ReadKey();
        }

        // Nivel 4 (Lab 1)
        private static void PecaMoveu(Peca peca)
        {
            Console.WriteLine(peca.Nome + " moveu-se");
        }
    }
}
