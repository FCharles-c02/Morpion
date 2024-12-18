using System;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;

namespace Morpion
{
    class Program
    {
        public static int[,] grille = new int[3, 3]; // matrice pour stocker les coups joués
        // Fonction permettant l'affichage du Morpion
        public static void AfficherMorpion()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", grille[0,0], grille[0,1], grille[0,2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", grille[1,0], grille[1,1], grille[1,2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", grille[2,0], grille[2,1], grille[2,2]);
            Console.WriteLine("     |     |      ");
        }

        // Fonction permettant de changer dans le tableau quel est le joueur qui a joué
        // Bien vérifier que le joueur ne sort pas du tableau et que la position n'est pas déjà jouée
        public static bool AJouer(int j, int k, int joueur)
        {
            // A compléter
            return false;
        }
        private const int colonne = 3;
        private const int ligne = 3;
        // Fonction permettant de vérifier si un joueur a gagné
        public static bool Gagner(int quette, int ok, int joueur)
        {
            // verif lignes
            for (int l = 0; l < ligne; l++)
            {
                if (grille[l, 0] == grille[l, 1] && grille[l, 1] == grille[l, 2] && grille[l, 0] != ' ')
                {
                    return true;
                }
            }

            // verif colonnes
            for (int c = 0; c < colonne; c++)
            {
                if (grille[0, c] == grille[1, c] && grille[1, c] == grille[2, c] && grille[0, c] != ' ')
                {
                    return true;
                }
            }

            // verif diagonales
            if (grille[0, 0] == grille[1, 1] && grille[0, 0] == grille[1, 1] && grille[2, 2] != ' ')
            {
                return true;
            }
            if (grille[2, 0] == grille[1, 1] && grille[0, 2] == grille[1, 1] && grille[2, 0] != ' ')
            {
                return true;
            }

            return false;
        }
        /*
        X/O aux cases (HORIZONTALES) [0, 0] && [0, 1] && [0, 2] || [1, 0] && [1, 1] && [1, 2] || [2, 0] && [2, 1] && [2, 2]
        X/O aux cases (VERTICALES) [0, 0] && [1, 0] && [2, 0] || [0, 1] && [1, 1] && [2, 1] || [0, 2] && [1, 2] && [2, 2]
        X/O aux cases (DIAGONALES) [0, 0] && [1, 1] && [2, 2] || [0, 2] && [1, 1] && [2, 0]
        */
        // Programme principal
        static void Main(string[] args)
        {
            //--- Déclarations et initialisations --
            int LigneDébut = Console.CursorTop;     // par rapport au sommet de la fenêtre
            int ColonneDébut = Console.CursorLeft; // par rapport au sommet de la fenêtre

            int essais = 0;    // compteur d'essais
	        int joueur = 1 ;   // 1 pour la premier joueur, 2 pour le second
	        int l, c = 0;      // numéro de ligne et de colonne
            int j, k = 0;      // Parcourir le tableau en 2 dimensions
            bool gagner = false; // Permet de vérifier si un joueur a gagné 
            bool bonnePosition = false; // Permet de vérifier si la position souhaitée est disponible
            AfficherMorpion();
            //--- initialisation de la grille ---
            // On met chaque valeur du tableau à 10
            
	        for (j=0; j < grille.GetLength(0); j++)
		        for (k=0; k < grille.GetLength(1); k++)
			        grille[j,k] = 10;
            while(!gagner && essais != 9)
            {
                
                // A compléter 
                try
                {
                    
                    Console.WriteLine("Ligne   =    ");
                    Console.WriteLine("Colonne =    ");
                    Console.WriteLine("\n");
                    Console.WriteLine("C'est au tour du joueur",joueur);
                    // Peut changer en fonction de comment vous avez fait votre tableau.
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 9); // Permet de manipuler le curseur dans la fenêtre 
                    l = int.Parse(Console.ReadLine()) - 1; 
                    // Peut changer en fonction de comment vous avez fait votre tableau.
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 10); // Permet de manipuler le curseur dans la fenêtre 
                    c = int.Parse(Console.ReadLine()) - 1;
                    essais++;
                    // A compléter 

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                // changement de joueur 
                Console.WriteLine("C'est au tour de", joueur);

                if (joueur == 1)
                {
                    joueur++;
                    break;
                }
                if (joueur == 2)
                {
                    joueur = 1;
                    break;
                }
                if (joueur > 2)
                {
                    Console.WriteLine("Joueur 3 ?");
                }


            }; // Fin TQ

            // Fin de la partie
            // A compléter 

            Console.ReadKey();
    }
  }
}

/*
        affichage tablo
            for (var p = 0; j < grille.GetLength(0); j++)
            {
                Console.Write("\n|====|====|====|====|\n");
                Console.Write("|");

                for (var i = 0; i < grille.GetLength(1); i++)
                {
                    Console.Write(" -- ");
                    Console.Write("|");
                }

            }
            Console.Write("\n|====|====|====|====|");


à implémenter lorsque la vérification sera mise en place

if 
X/O aux cases (HORIZONTALES) [0, 0] && [0, 1] && [0, 2] || [1, 0] && [1, 1] && [1, 2] || [2, 0] && [2, 1] && [2, 2]
X/O aux cases (VERTICALES) [0, 0] && [1, 0] && [2, 0] || [0, 1] && [1, 1] && [2, 1] || [0, 2] && [1, 2] && [2, 2]
X/O aux cases (DIAGONALES) [0, 0] && [1, 1] && [2, 2] || [0, 2] && [1, 1] && [2, 0]
vérification du joueur (X ou O)



*/