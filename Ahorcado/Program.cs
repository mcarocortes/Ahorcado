using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //******* VARIABLES
            Console.Write("Cadena: ");
            string cadena = Console.ReadLine().ToLower();
            char letra;
            int fallos = 0;
            string nuevaPalabra = "";
            for (int i = 0; i <= cadena.Length - 1; i++)
            { //******* CREAMOS UNA PALABRA NUEVA CON '_,'_'. Se le irán reemplazando los valores
                nuevaPalabra = nuevaPalabra.Insert(i, "_"); //posicion i, valor "_"
            };
            string ahorcado = ("┌───┐") + //L1
                              ("\n│   o") + //L2
                              ("\n│       ") + //L3 tiene un caracter más (8) (LINEAS QUE SE IRÁN REEMPLAZANDO)
                              ("\n│      ") + //l4 tiene un caracter menos (7) (LINEAS QUE SE IRÁN REEMPLAZANDO)
                              ("\n┴───────\n");  //L5
                                                 // ******* COMIENZO DEL JUEGO
            do
            {
                Console.Write("\nLetra: ");
                letra = Convert.ToChar(Console.ReadLine().ToLower());

                // ******* SI LA CADENA CONTIENE LA LETRA
                if (cadena.Contains(letra.ToString()))
                { //string con string
                    for (int i = 0; i <= cadena.Length - 1; i++)
                    { // recorremos la cadena
                        if (cadena[i] == letra)
                        { // si el valor de la cadena en posicion [i] ES IGUAL A LA LETRA
                            nuevaPalabra = nuevaPalabra.Remove(i, 1).Insert(i, letra.ToString()); // SE ELIMINA '_' en la posición i, 1un casilla y se reemplaza en i por la letra
                        };
                    };
                }
                // ******* SI LA CADENA NO CONTIENE LA LETRA
                else
                {
                    fallos++;
                    switch (fallos)
                    {
                        case 1:
                            Console.Write(ahorcado);
                            break;
                        case 2:
                            ahorcado = ahorcado.Replace("\n│       ", "\n│  /    "); //REEMPLAZO EN L3
                            Console.Write(ahorcado);
                            break;
                        case 3:
                            ahorcado = ahorcado.Replace("\n│  /    ", "\n│  /|   "); //REEMPLAZO EN L3
                            Console.Write(ahorcado);
                            break;
                        case 4:
                            ahorcado = ahorcado.Replace("\n│  /|   ", "\n│  /|\\ "); //REEMPLAZO EN L3
                            Console.Write(ahorcado);
                            break;
                        case 5:
                            ahorcado = ahorcado.Replace("\n│      ", "\n│  /   "); //REEMPLAZO EN L4
                            Console.Write(ahorcado);
                            break;
                        case 6:
                            ahorcado = ahorcado.Replace("\n│  /   ", "\n│  / \\"); //REEMPLAZO EN L4
                            Console.Write(ahorcado);
                            break;
                        default:
                            break;
                    };

                };
                //******* MUESTRA LA NUEVA PALABRA CREADA EN ESTA ITERACIÓN
                for (int j = 0; j <= nuevaPalabra.Length - 1; j++)
                {
                    Console.Write("{0} ", nuevaPalabra[j]);
                };
                //******* CUANDO SE COMPLETE EL LIMITE DE FALLOS MOSTRARÁ EL MENSAJE DE SALIDA DEL BUCLE
                if (fallos == 6)
                {
                    Console.WriteLine("\nR.I.P. La palabra era: {0}", cadena);
                    break;
                };
                //******* SI MI PALABRA NUEVA AÚN TIENE '_' , CONTINUARÁ, SINO, SE SALDRÁ DEL BUCLE            
                if (nuevaPalabra.Contains("_"))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("\n¡¡ENHORABUENA!!");
                    break;
                };
            } while (fallos < 6);
        }
    }
}
