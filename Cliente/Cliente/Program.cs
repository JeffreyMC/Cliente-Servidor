using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Cliente
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			TcpClient cliente = new TcpClient ();
			Console.WriteLine ("Conectando al servidor...");
			cliente.Connect ("127.0.0.1", 6000);
			//escritor
			NetworkStream stream = cliente.GetStream();
			BinaryWriter escritor = new BinaryWriter (stream);

			Console.WriteLine ("CONECTADO\n\n");
			while (true) 
			{
				Console.Write("Por favor digite el mensaje a enviar: ");
				string mensaje = Console.ReadLine ();
				//escribe
				escritor.Write(mensaje);
				Console.WriteLine ("mensaje enviado");
			}



		}
	}
}
