namespace HttpRequester
{
    using System;
    using System.Net;
    using System.Text;
    using System.Net.Sockets;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            const string NewLine = "\r\n";

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 1234);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                using NetworkStream networkStream = tcpClient.GetStream();

                // TODO: Use buffer
                byte[] requestBytes = new byte[1000000];
                int bytesRead = networkStream.Read(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                string responseText = @"<form action ='/Account/Login>
                                        <input type=date name='date' />
                                        <input type=text name='username' />
                                        <input type=password name='password' />
                                        <input type=submit value='Login' />
                                        </form>";

                string response = "HTTP/1.0 200 OK" + NewLine +
                    "Server: SoftUniServer/1.0" + NewLine +
                    "Content-Type: text/html" + NewLine +
                    // "Location: https://abv.bg" + NewLine +
                    // "Content-Disposition: attachment; filename=slavi.html" + NewLine +
                    "Content-Length: " + responseText.Length + NewLine +
                    NewLine +
                    responseText;
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                networkStream.Write(responseBytes, 0, responseBytes.Length);

                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
        }
    }
}
