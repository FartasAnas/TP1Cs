using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    class Compt
    {
        private readonly int NumComp;
        private static int cpt=0;
        private readonly Client titulaire;
        private MAD sold;
        private static MAD plafond=new MAD(100000);


        public Compt(Client c,double v)
        {
            this.NumComp = ++Compt.cpt;
            this.titulaire=c;
            this.sold = new MAD(v);
        }
        public bool crediter(MAD somme)
        {
            if (somme > 0)
            {
                sold += somme;
                Console.Write("New solde crediteur:");
                sold.afficher();
                return true;
            }
            else
            {
                Console.WriteLine("la somme est negative");
            }
            return false;
        }
        public bool debiter(MAD somme)
        {

            if (somme > 0)
            {
                if (somme < plafond)
                {
                    if (sold > somme)
                    {
                        sold -= somme;
                        Console.Write("New solde debiteur:");
                        sold.afficher();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("solde insufision");
                    }
                }
                else
                {
                    Console.WriteLine("la somme est superior a le platform");
                }
            }
            else
            {
                Console.WriteLine("la somme est negative");
            }
            return false;
        }
        public bool verser(Compt c,MAD somme)
        {
            if (this.debiter(somme) == true && c.crediter(somme) == true)
            {
                return true;
            }
            return false;
        }
        public void consulter()
        {
            titulaire.affiche();
            Console.WriteLine("Num Compte: "+this.NumComp);
            Console.Write("plafond:");
            plafond.afficher();
            sold.afficher();
            
        }

    }
}
