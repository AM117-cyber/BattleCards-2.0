using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCards.Cards;
using BattleCards;

namespace BattleCardsLibrary.AI
{


    public class multiplayer
    {

        static Card FacilActivaciones(Player player, int pos, List<Card> cartas, List<Card> campo)

        {
            int a = cartas.Count;
            Random numero = new Random();
            int random = numero.Next(0, a);
            Card elegida = cartas[random];
            double ataque;
            double defensa;
            Utils.Utils.CardType tipo = elegida.Type;
            double costo = elegida.ManaCost;

            //evaluo que el campo no este lleno
            if (campo.Count < 4)
            {

                if (tipo is Utils.Utils.CardType.Monster)
                {
                    //invocar el monstruo si es posible viendo el mana 
                    if (costo <= player.Mana)
                    {
                        return elegida;
                    }
                }
                else
                {
                    return elegida;
                }
            }
            return null;

        }

        public static List<Card> AtaqueCartas(Player player, int pos, List<Card> cartas, List<Card> campo, List<Card> CampoEnemigo)
        {
            //saber si hay algun mosntruo en atatque o defensa que pueda atacar
            bool saber = Saber(CampoEnemigo, campo);

            List<Card> orden = new List<Card>();
            List<Card> atacantes = ordenado(campo, orden);
            return atacantes;
        }
        static List<Card> defensa(List<Card> CampoEnemigo, Card carta)
        {
            List<Card> cartas = new List<Card>();

            List<Card> retornar = ordenado1(CampoEnemigo, cartas, carta);

            return retornar;

        }

        // jugador medianamente competitivo//adrian aqui el va a coger la carta de la mano con mas ataque y la invocar 
        //yo supongo que tu llames este metod hasta q se llene el campo obviamente removiendo la carta que invoque este metodo de la mano
        public Card MedioActivacionMonstruo(Player player, List<Card> board, Card card, int pos, List<Card> cartas, List<Card> campo, List<Card> CampoMagico, List<Card> CampoEnemigo)
        {
            double costo;

            Card invocacion;
            List<Card> mano = cartas;
            List<Card> magic = new List<Card>();
            if (campo.Count < 6)
            {

                //cartas en la mano
                for (int i = 0; i < cartas.Count; i++)
                {
                    Utils.Utils.CardType tipo = cartas[i].Type;
                    //busco las cartas tipo monstruos
                    if (tipo is MonsterCard)
                    {
                        costo = cartas[i].ManaCost;
                        //evaluo si el costo del mana del monstruo es mayor al mana //si es mas alto que le mana del jugador lo descartamos
                        if (tipo is MonsterCard && costo > player.Mana || tipo is SpellCard)
                        {
                            mano.Remove(cartas[i]);
                        }
                    }
                }
            }
            Card carta = MayorAtaque(mano);

            return carta;
        }
        static Card MedioMagia(List<Card> cartas, Player player, int pos)
        {
            List<Card> magic = new List<Card>();
            int random;
            for (int i = 0; i < cartas.Count; i++)
            {
                Utils.Utils.CardType tipo = cartas[i].Type;
                if (tipo is SpellCard)
                {
                    magic.Add(cartas[i]);
                }
            }
            Random numero = new Random();
            random = numero.Next(0, magic.Count);

            return magic[random];
        }

        //saber si hay algun monstruo para atacar en el campo enemigo
        static bool Saber(List<Card> campoEnemigo, List<Card> campo)
        {
            for (int i = 0; i < campo.Count; i++)
            {
                for (int j = 0; j < campoEnemigo.Count; j++)
                {

                    double ataque = campo[i].Attack.Evaluate(campo[i], campoEnemigo[j]);
                    Utils.Utils.CardType tipo = campoEnemigo[j].Type;
                    if (tipo is MonsterCard && ataque <= 0)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        //saber si hay monstruos en el campo

        //mayor monstruo con ataque en el campo
        static Card MayorAtaque(List<Card> mano)
        {
            double atac = 0;
            Card carta = mano[0];
            for (int i = 0; i < mano.Count; i++)
            {
                for (int j = 0; j < mano.Count; j++)
                {

                    double ataque = mano[i].Attack.Evaluate(mano[i], mano[j]);

                    if (ataque >= atac)
                    {
                        carta = mano[i];
                    }
                }
            }
            return carta;

        }

        //activacion cartas magicas
        static List<Card> Activacion(List<Card> campo, List<Card> CampoEnemigo, List<Card> mano, Player player, int pos)
        {
            double mana = player.Mana;
            List<Card> magicas = new List<Card>();
            //activar todas las cartas magia de la mano 
            for (int i = 0; i < mano.Count; i++)
            {
                Utils.Utils.CardType tipo = mano[i].Type;
                if (tipo is SpellCard)
                {
                    //ACTIVO TODAS LAS CARTAS MAGICAS
                    magicas.Add(mano[i]);
                }
            }
            return magicas;
        }
        //activacion monstruos
        static List<Card> ActivacionM(List<Card> mano, Player player, List<Card> campo, List<Card> CampoEnemigo)
        {
            List<Card> descartado = mano;
            //
            for (int i = 0; i < mano.Count; i++)
            {
                //descartar cartas que consuman mas mana del que tienen para activarlo
                if (mano[i].ManaCost > player.Mana)
                {
                    descartado.Remove(mano[i]);
                }
            }
            List<Card> lista = new List<Card>();
            //lista de cartas que son mejores invocar por su ataque 
            List<Card> elegidas = EfectoInvocacion(descartado, CampoEnemigo, player.Mana, 0, 0, lista, player);
            //las ordeno por orden de ataque
            List<Card> ordenadas = ordenado(elegidas, lista);
            //CUANTOS LUgARES EN EL CAMPO HAY LIBRE?
            int lugares = 5 - campo.Count;
            //VOY ACTIVANDO LAS CARTAS DEPENDIENDO DE EL ESPACIO QUE HAYA
            List<Card> activar = new List<Card>();
            for (int i = 0; i < ordenadas.Count; i++)
            {
                if (lugares > 0)
                {
                    activar.Add(ordenadas[i]);

                }

            }
            return activar;
        }

        //en este metodo cojo los monstruos de la mano con mayor ataque y los meto en una lista 
        static List<Card> EfectoInvocacion(List<Card> descartado, List<Card> CampoEnemigo, double mana, double dan, int I, List<Card> lista, Player player)
        {
            if (I == descartado.Count) return lista;
            for (int i = I; i < descartado.Count; i++)
            {
                //maximo de dano que puede hacer la carta usando su efecto
                dan += atac(CampoEnemigo, descartado[i]);
                if (mana + descartado[i].ManaCost <= player.Mana && dan >= 0)
                {
                    {
                        lista.Add(descartado[i]);
                    }
                    lista = EfectoInvocacion(descartado, CampoEnemigo, mana += descartado[i].ManaCost, dan, I + 1, lista, player);
                }
            }
            return lista;

        }
        //maximo dano que puede causar un monstruo en campo enemigo
        static double atac(List<Card> CampoEnemigo, Card carta)
        {
            double dan = carta.Attack.Evaluate(carta, CampoEnemigo[0]);
            double dan1 = CampoEnemigo[0].Defend.Evaluate(CampoEnemigo[0], carta);
            double dan2 = dan - dan1;
            double a;
            double b;
            double c;
            for (int i = 1; i < CampoEnemigo.Count; i++)
            {
                a = carta.Attack.Evaluate(carta, CampoEnemigo[i]);
                b = CampoEnemigo[i].Defend.Evaluate(CampoEnemigo[i], carta);
                c = a - b;
                if (c > dan2)
                {
                    dan = a;
                }
            }
            return dan;
        }
        //este metodo voy evaluar la mejor combinacion entre activar carta 
        static List<Card> ordenado(List<Card> elegidas, List<Card> ordenadas)
        {
            if (elegidas.Count == 0) return ordenadas;
            Card mayor = MayorAtaque(elegidas);
            ordenadas.Add(mayor);
            elegidas.Remove(mayor);
            ordenadas = ordenado(elegidas, ordenadas);
            return ordenadas;
        }
        //menor vida 
        static Card MenorVida(List<Card> CampoEnemigo, Card carta)
        {
            double def = CampoEnemigo[0].Defend.Evaluate(CampoEnemigo[0], carta);
            Card menor = CampoEnemigo[0];
            for (int i = 1; i < CampoEnemigo.Count; i++)
            {
                double defensa = CampoEnemigo[i].Defend.Evaluate(CampoEnemigo[i], carta);

                if (defensa <= def)
                {
                    menor = CampoEnemigo[i];
                }
            }
            return menor;
        }
        static List<Card> ordenado1(List<Card> CampoEnemigo, List<Card> orden, Card carta)
        {
            if (CampoEnemigo.Count == 0) return orden;
            {
                Card menor = MenorVida(CampoEnemigo, carta);
                orden.Add(menor);
                CampoEnemigo.Remove(menor);
                orden = ordenado1(CampoEnemigo, orden, carta);

            }
            return orden;
        }
    }

}
