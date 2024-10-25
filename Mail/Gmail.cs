using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Drawing;

namespace Mail
{
    public class Gmail
    {
        string email = "xalexox4@gmail.com";
        string appPassword = "iiqj iygc cyxd cdtn";
        /*
         * Para obtener appPassword activar doble verifiacion en correo y generar la password con el siguiente link.
         https://myaccount.google.com/u/3/apppasswords
         */
        public Gmail()
        {
            
        }
        public void LeerCorreos()
        {
            using (var client = new ImapClient())
            {
                try
                {
                    // Conectar al servidor de Gmail usando SSL (puerto 993)
                    client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

                    // Autenticarse con la dirección de correo y la contraseña de aplicación
                    client.Authenticate(email, appPassword);

                    // Abrir la carpeta de la bandeja de entrada
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
