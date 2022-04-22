using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TCPIP
{
	class MainClass
	{
		static TcpListener servidor;
		static Thread hilo;

		public static void Main (string[] args)
		{
			servidor = new TcpListener(IPAddress.Parse("127.0.0.1"), 6000);
			Console.WriteLine ("Conectando al servidor...");
			hilo = new Thread(new ThreadStart(escucha));
			hilo.Start();
		}

		public static void escucha()
		{
			servidor.Start ();
			Console.WriteLine ("Servidor conectado. Esperando clientes...");

			//crea un cliente
			while (true) 
			{
				TcpClient cliente = servidor.AcceptTcpClient ();
				Console.WriteLine (" Se conectó un cliente");

				Thread datos = new Thread (new ParameterizedThreadStart (clientes));
				datos.Start (cliente);
			}
		}

		public static void clientes(object cliente)
		{
			TcpClient client = (TcpClient)cliente;
			NetworkStream stream = client.GetStream();
			BinaryReader lector = new BinaryReader (stream);
			while (true) 
			{
				string mensaje = lector.ReadString ();
				Console.WriteLine ("Mensaje leído: " + mensaje);
			}
		}
	}
}
