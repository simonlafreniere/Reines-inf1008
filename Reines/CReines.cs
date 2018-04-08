using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reines
{
    class CReines
    {
        private int[] echiquier, diagDroiteGauche, diagGaucheDroite;
        private int[,] solutions;
        private int largeur, dimension, trouves;
        public CReines()
        {
            largeur = 3;
            echiquier = new int[largeur];
            for(int i=0;i<largeur;i++)
                echiquier[i] = -1;
            diagDroiteGauche = new int[largeur];
            diagGaucheDroite = new int[largeur];
        }

        public CReines(int side)
        {
            largeur = side;
            echiquier = new int[largeur];
            for (int i = 0; i < largeur; i++)
                echiquier[i] = -1;
            diagDroiteGauche = new int[largeur];
            diagGaucheDroite = new int[largeur];
        }

        public void setLargeur(int side)
        {
            largeur = side;
            echiquier = new int[largeur];
            for (int i = 0; i < largeur; i++)
                echiquier[i] = -1;
            diagDroiteGauche = new int[largeur];
            diagGaucheDroite = new int[largeur];
        }

        public int getLargeur()
        {
            return largeur;
        }
        public int getDimension()
        {
            return largeur * largeur;
        }

        public void reset()
        {
            trouves = 0;
        }

        public bool branche(int ligne)
        {
            if (trouves == largeur)
                return true;

            if (echiquier[ligne] == -1)
            {
                for (int j = 0; j < largeur; j++)
                {
                    if (colonnelibre(j) && diagDGlibre(ligne,j) && diagGDlibre(ligne,j))
                    {
                        echiquier[ligne] = j;
                        trouves++;
                        for (int k = 0; k < largeur; k++)
                            if(branche(k))
                                return true;
                    }
                }
            }

            trouves--;
            return false;
        }

        public bool colonnelibre(int colonne)
        {
            for(int i = 0; i < largeur; i++)
            {
                if (echiquier[i] == colonne)
                    return false;
            }
            return true;
        }

        public bool diagDGlibre(int ligne, int colonne)
        {
            int pos = ligne + colonne;
            if (diagDroiteGauche[pos] == 0)
            {
                diagDroiteGauche[pos] = 1;
                return true;
            }
            return false;
        }

        public bool diagGDlibre(int ligne, int colonne)
        {
            int pos = ligne - colonne + largeur - 1;
            if (diagGaucheDroite[pos] == 0)
            {
                diagGaucheDroite[pos] = 1;
                return true;
            }
            return false;
        }
    }
}
