using MailKit.Security;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;

namespace Mail
{
    public class Outlook
    {
        string email = "xalexox4@hotmail.com";
        string appPassword = "rtilrklflamkevxl";

        public Outlook()
        {
            
        }
        public void LeerCorreos()
        {
            using (var client = new ImapClient())
            {
                try
                {
                    // Conectar al servidor de Outlook usando SSL (puerto 993)
                    client.Connect("outlook.office365.com", 993, SecureSocketOptions.SslOnConnect);

                    // Autenticarse con el correo y la contraseña de aplicación
                    client.Authenticate(email, appPassword);

                    // Abrir la bandeja de entrada
                    client.Inbox.Open(FolderAccess.ReadOnly);

                    Console.WriteLine($"Conectado. Hay {client.Inbox.Count} mensajes en la bandeja de entrada.");

                    // Leer los últimos 10 correos electrónicos
                    for (int i = 0; i < Math.Min(10, client.Inbox.Count); i++)
                    {
                        var message = client.Inbox.GetMessage(i);
                        Console.WriteLine($"Asunto: {message.Subject}");
                        Console.WriteLine($"De: {message.From}");
                        Console.WriteLine($"Fecha: {message.Date}");
                        Console.WriteLine($"Contenido: {message.TextBody}");
                        Console.WriteLine(new string('-', 50)); // Separador
                    }

                    // Desconectar del servidor
                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error: {ex.Message}");
                }
            }
        }
    }
}
