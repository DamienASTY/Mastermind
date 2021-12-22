using System;

namespace Mastermind
{
    class Program
    {
        // Cette fonction se charge d'afficher un tableau en générale
        // (fonction d'affichage à but de test)
        static void dumpArray(int[] T, string descript)
        {
            Console.WriteLine(descript);
            for(int i = 0; i < T.Length; i++)
            {
                Console.WriteLine(T[i]);
            }
        }
        // Cette fonction calcul le nombre de pions blanc
        static void pionsBlanc(int[] ordinateur, int[] joueur, out int nbPb)
        {
            nbPb = 0;
            for(int i = 0; i < ordinateur.Length; i++)
            {
                for(int j = 1; j < ordinateur.Length; j++)
                {
                    if(ordinateur[i] == joueur[j])
                    {
                        nbPb++;
                    }
                }
            }
            Console.WriteLine($"Vous avez {nbPb} pions blanc");
        }
        // Cette fonction calcul de le nombre de pions rouge
        static void pionsRouge(int[] ordinateur, int[] joueur, out int[] ordinateurModifier)
        {
            ordinateurModifier = new int[4];
            int pionsRouge = 0;
            for(int i = 0; i < ordinateur.Length; i++)
            {
                if(ordinateur[i] == joueur[i])
                {
                    ordinateurModifier[i] = -1;
                    pionsRouge++;
                }
                else
                {
                    ordinateurModifier[i] = ordinateur[i];
                }
            }
            Console.WriteLine($"Vous avez {pionsRouge} pion(s) rouge");
        }
        // Cette fonction crée la combinaison secrète
        static void computerChoose(int n, out int[] combinaison)
        {
            combinaison = new int[4];
            for(int i = 0; i < n; i++)
            {
                // J'instancie un objet Random afin de générer un nombre
                // aléatoire entre 1 et 6
                Random aleatoire = new Random();
                combinaison[i] = aleatoire.Next(1, 6);
            }
        }
        // Cette fonction permet à l'utilisateur de crée sa combinaison
        static void playerChoose(out int[] combinaison)
        {
            combinaison = new int[4];
            int choix;
            Console.WriteLine("\n\nGuide couleur : { 1 : Bleu ; 2 : Noir ; 3 : Rouge ; 4 : Vert ; 5 : Violet ; 6 : Marron }");
            for (int i = 0; i < combinaison.Length; i ++)
            {
                Console.Write($"Choissez la couleur {i + 1} -> ");
                try
                {
                    choix = int.Parse(Console.ReadLine());
                    if (choix >= 1 && choix <= 6)
                    {
                        combinaison[i] = choix;
                    }
                    else
                    {
                        i--;
                    }
                }
                catch(Exception exception)
                {
                    i--;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Jeu du Mastermind");
            string relancer = "";
            // Tableau contenant la combinaison de l'ordinateur
            int[] combinaisonOrdinateur = new int[4];
            int[] combinaisonJoueur = new int[4];
            int[] combiDepart = new int[4];
            int test; // a supprimer
            computerChoose(4, out combinaisonOrdinateur);
            combiDepart = combinaisonOrdinateur;
            // dumpArray(combiDepart, "Combi départ");
            // dumpArray(combinaisonOrdinateur, "Combinaison Ordinateur"); // a supprimer
            while(relancer != "q") {
                playerChoose(out combinaisonJoueur);
                // dumpArray(combinaisonJoueur, "Combinaison Joueur"); // a supprimer
                pionsRouge(combinaisonOrdinateur, combinaisonJoueur, out combinaisonOrdinateur);
                // dumpArray(combinaisonOrdinateur, "Pions rouge"); // a supprimer
                pionsBlanc(combinaisonOrdinateur, combinaisonJoueur, out test);
                try
                {
                    Console.Write("Voulez vous relancer la partie ? -> ");
                    relancer = Console.ReadLine();
                }
                catch(Exception exception)
                {
                    // vide
                }
            }
        }
    }
}