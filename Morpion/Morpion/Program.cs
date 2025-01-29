using System;

namespace Morpion
{
    class Program
    {
        public static int[,] grille = new int[3, 3]; // Matrice pour stocker les coups joués

        // Fonction permettant l'affichage du Morpion
        public static void AfficherMorpion()
        {
            // Nettoie la console pour afficher une grille mise à jour
            Console.Clear();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", AfficherCase(grille[0, 0]), AfficherCase(grille[0, 1]), AfficherCase(grille[0, 2]));
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", AfficherCase(grille[1, 0]), AfficherCase(grille[1, 1]), AfficherCase(grille[1, 2]));
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", AfficherCase(grille[2, 0]), AfficherCase(grille[2, 1]), AfficherCase(grille[2, 2]));
            Console.WriteLine("     |     |      ");
        }

        // Fonction pour afficher 'X' ou 'O' à la place des 1 ou 2
        public static string AfficherCase(int caseValue)
        {
            if (caseValue == 1) return "X";
            if (caseValue == 2) return "O";
            return " "; // Case vide
        }

        // Fonction permettant de vérifier et d'enregistrer un coup du joueur
        public static bool AJouer(int ligne, int colonne, int joueur)
        {
            // Vérifie si la position demandée est dans les limites de la grille
            if (ligne < 0 || ligne >= 3 || colonne < 0 || colonne >= 3)
            {
                Console.WriteLine("Position invalide. Réessayez.");
                return false;
            }

            // Vérifie si la case est déjà occupée
            if (grille[ligne, colonne] != 0)
            {
                Console.WriteLine("Case déjà occupée. Réessayez.");
                return false;
            }

            // Enregistre le coup du joueur dans la grille
            grille[ligne, colonne] = joueur;
            return true;
        }

        // Fonction permettant de vérifier si un joueur a gagné
        public static bool Gagner(int joueur)
        {
            // Vérifie les lignes
            for (int l = 0; l < 3; l++)
            {
                if (grille[l, 0] == joueur && grille[l, 1] == joueur && grille[l, 2] == joueur)
                {
                    return true;
                }
            }

            // Vérifie les colonnes
            for (int c = 0; c < 3; c++)
            {
                if (grille[0, c] == joueur && grille[1, c] == joueur && grille[2, c] == joueur)
                {
                    return true;
                }
            }

            // Vérifie les diagonales
            if (grille[0, 0] == joueur && grille[1, 1] == joueur && grille[2, 2] == joueur)
            {
                return true;
            }

            if (grille[0, 2] == joueur && grille[1, 1] == joueur && grille[2, 0] == joueur)
            {
                return true;
            }

            // Pas de victoire
            return false;
        }

        // Programme principal
        static void Main(string[] args)
        {
            // Initialisation de la grille avec des cases vides (0)
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grille[i, j] = 0; // 0 représente une case vide
                }
            }

            int joueur = 1; // Le joueur 1 commence (1 pour X, 2 pour O)
            int essais = 0;    // Compteur de tours joués
            bool gagner = false;

            // Boucle principale du jeu
            while (!gagner && essais < 9)
            {
                try
                {
                    // Affiche la grille actuelle
                    AfficherMorpion();

                    // Demande au joueur actuel de saisir son coup
                    Console.WriteLine($"Joueur {joueur}, c'est à vous de jouer.");
                    Console.Write("Entrez le numéro de la ligne (1-3) : ");
                    int ligne = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Entrez le numéro de la colonne (1-3) : ");
                    int colonne = int.Parse(Console.ReadLine()) - 1;

                    // Tente de jouer le coup
                    if (AJouer(ligne, colonne, joueur))
                    {
                        essais++; // Augmente le compteur de tours

                        // Vérifie si le joueur actuel a gagné
                        if (Gagner(joueur))
                        {
                            gagner = true; // Marque la fin de la partie
                            AfficherMorpion(); // Affiche l'état final de la grille
                            Console.WriteLine("Félicitations ! Le joueur " + (joueur == 1 ? "X" : "O") + " a gagné !");
                            break;
                        }

                        // Change le joueur (1 -> 2 ou 2 -> 1)
                        joueur = (joueur == 1) ? 2 : 1;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("Entrée invalide. Veuillez entrer des numéros valides pour la ligne et la colonne.");
                }
                catch (Exception ex)
                {
                    Console.Write($"Une erreur s'est produite : {ex.Message}");
                }
            }

            // Si la boucle se termine sans victoire, c'est un match nul
            if (!gagner)
            {
                AfficherMorpion();
                Console.WriteLine("Match nul !");
            }

            // Attend une touche pour fermer le programme
            Console.ReadKey();
        }
    }
}