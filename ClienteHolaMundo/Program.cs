using ClienteHolaMundo.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteHolaMundo
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A Que Servidor se quiere Conectar: ");
            string servidor1= Console.ReadLine().Trim();
            Console.WriteLine("A Que Puerto se quiere Conectar: ");
            int puerto1 = Convert.ToInt32(Console.ReadLine().Trim());
            
            Console.WriteLine("Conectado a Servidor{0} en puerto {1}", servidor1, puerto1);
            ClienteSocket clienteSocket = new ClienteSocket(servidor1, puerto1);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Conectado... ");
                string mensaje = clienteSocket.Leer();
                bool terminar = false;
                while (!terminar)
                {
                    Console.WriteLine("Servidor Dice: " + mensaje);
                    string respuesta = Console.ReadLine().Trim();
                    clienteSocket.Escribir(respuesta);
                    
                    if (respuesta == "chao")
                    {
                        clienteSocket.Desconectar();
                        terminar = true;
                    }
                    string resultado = clienteSocket.Leer();
                    Console.WriteLine("Servidor Dice: {0}", resultado);
                    if (resultado == "chao")
                    {
                        clienteSocket.Desconectar();
                        terminar = true;
                    }
                }

                clienteSocket.Desconectar();


            }
            else
            {
                Console.WriteLine("Error de Conexion!");
            }
            Console.WriteLine("Desconectado del servidor!");
            Console.ReadKey();
        }
    }
}
