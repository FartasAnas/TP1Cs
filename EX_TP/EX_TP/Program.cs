using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EX_TP;

namespace EX_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 choix=0;
            Int32 cpt = 0;
            Int32 nbrco = 0;
            Compt[] tabc = new Compt[100];
            while (choix != 6)
            {
                Console.WriteLine("------------Menu------------");
                Console.WriteLine("1) Cree un Compte bancaire");
                Console.WriteLine("2) credite");
                Console.WriteLine("3) debite");
                Console.WriteLine("4) verser");
                Console.WriteLine("5) consulter");
                Console.WriteLine("6) quitter");
                Console.WriteLine("----------------------------");
                do
                {
                    Console.Write("Votre choix:");
                    choix = Convert.ToInt32(Console.ReadLine());
                    if (tabc[0] == null)
                    {
                        Console.WriteLine("Erreur Aucun Compt trouver!!!!!!");
                        Console.WriteLine("Veuille cree un objet");
                        Console.WriteLine("----------------------------");
                    }
                } while ((choix != 1 && choix < 6) && tabc[0] == null);
                Console.Clear();
                switch (choix)
                {
                    case 1:
                        Console.WriteLine("-----------Creation des compt-----------");
                        Console.Write("Entrez le nombre du compt qui tu veux cree:");
                        nbrco += Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("----------------------------------------");
                        Console.Clear();
                        while (cpt < nbrco)
                        {
                            string N, P, A;
                            double s;
                            Console.WriteLine("---Les information de client "+(cpt +1)+"--");
                            Console.Write("Nom de client " + (cpt + 1) + ":");
                            N = Console.ReadLine();
                            Console.Write("Prenom de client " + (cpt + 1) + ":");
                            P = Console.ReadLine();
                            Console.Write("addresse de client " + (cpt + 1) + ":");
                            A = Console.ReadLine();
                            Client c = new Client(N, P, A);
                            Console.Write("solde:");
                            s = Convert.ToDouble(Console.ReadLine());

                            tabc[cpt] = new Compt(c, s);
                            cpt++;
                            Console.WriteLine("--------------------------------");
                            Console.Clear();
                        }
                        break;
                    case 2:
                        Console.WriteLine("-----------Crediter-----------");
                        Int32 numc=1;
                        if (cpt != 1)
                        {
                            do
                            {
                                Console.Write("Entre le compt qui tu veux le crediter:");
                                numc = Convert.ToInt32(Console.ReadLine());
                                if (tabc[numc - 1] == null)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur se compt est vide!!!!!!");
                                    Console.WriteLine("Veuille entrez un autre compt");
                                    Console.WriteLine("----------------------------------");
                                }
                            } while (tabc[numc - 1] == null);
                        }
                        if(tabc[numc-1] != null)
                        {
                            Console.Write("Somme:");
                            MAD somme = new MAD(Convert.ToDouble(Console.ReadLine()));
                            tabc[numc-1].crediter(somme);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        Console.WriteLine("-----------Debiter-----------");
                        numc = 1;
                        if (cpt != 1)
                        {
                            do
                            {
                                Console.Write("Entre le compt qui tu veux le debiter:");
                                numc = Convert.ToInt32(Console.ReadLine());
                                if (tabc[numc - 1] == null)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur se compt est vide!!!!!!");
                                    Console.WriteLine("Veuille entrez un autre compt");
                                    Console.WriteLine("----------------------------------");
                                }
                            } while (tabc[numc - 1] == null);
                        }
                        if (tabc[numc - 1] != null)
                        {
                            Console.Write("Somme:");
                            MAD somme = new MAD(Convert.ToDouble(Console.ReadLine()));
                            tabc[numc - 1].debiter(somme);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        Console.WriteLine("-----------Verser-----------");
                        int numc1;
                        if(cpt>=2)
                        {
                            do
                            {
                                Console.Write("Entre le compt qui vas envoyer:");
                                numc = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Entre le compt qui vas resever:");
                                numc1 = Convert.ToInt32(Console.ReadLine());
                                if (tabc[numc - 1] == null || tabc[numc1 - 1] == null)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur un ou plusieur  compts sont vide!!!!!!");
                                    Console.WriteLine("Veuille entrez des autres compts");
                                    Console.WriteLine("----------------------------------");
                                }
                                if(numc==numc1)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur tu ne peux pas verser a le meme compt!!!!!!");
                                    Console.WriteLine("Veuille entrez des autres compts");
                                    Console.WriteLine("----------------------------------");
                                }
                            } while (tabc[numc - 1] == null || tabc[numc1 - 1] == null || numc==numc1);
                            if (tabc[numc - 1] != null || tabc[numc1 - 1] != null || numc !=numc1)
                            {
                                Console.Write("Somme:");
                                MAD somme = new MAD(Convert.ToDouble(Console.ReadLine()));
                                tabc[numc - 1].verser(tabc[numc1 - 1], somme);
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("-----------Consulter-----------");

                        Int32 nbrca=1;
                        if (cpt != 1)
                        {
                            do
                            {
                                Console.Write("Entrez le nombre des compts qui tu veux afficher:");
                                nbrca = Convert.ToInt32(Console.ReadLine());
                                if (nbrca > cpt)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur ce nombre est superior a le nombre total des compts !!!!!!");
                                    Console.WriteLine("Veuille entrez un autre nombre");
                                    Console.WriteLine("----------------------------------");
                                }
                            } while (nbrca > cpt);
                        }
                        Console.Clear();
                        if (nbrca==cpt)
                        {
                            for(int i=0;i<nbrca;i++)
                            {
                                Console.WriteLine("----------Compt " + (i + 1) + "---------");
                                tabc[i].consulter();
                                Console.WriteLine("--------------------------");
                            }
                        }
                        else
                        {
                            int y=0;
                            do
                            {
                                Console.Write("Entrez le num de compte qui tu veux afficher :");
                                numc = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("----------Compt " + (y + 1)+ "---------");
                                tabc[numc-1].consulter();
                                Console.WriteLine("--------------------------");
                                y++;
                            } while (y < nbrca);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
