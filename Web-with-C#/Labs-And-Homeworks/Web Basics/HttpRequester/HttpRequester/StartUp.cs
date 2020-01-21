namespace HttpRequester
{
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            /* First version of code
            const string NewLine = "\r\n";

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                using NetworkStream networkStream = tcpClient.GetStream();

                // TODO: Use buffer
                byte[] requestBytes = new byte[1000000];
                int bytesRead = networkStream.Read(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                string responseText = @"<form action ='/Account/Login' method='post'>
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
            */

            // OOP Solution
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(() => MyHttpRequester.StartServer(tcpClient));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

                var totalRequests = Enumerable.Range(0, 10000).ToList();
                Parallel.For(0, totalRequests.Count, i =>
                {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    Task.Run(() => MyHttpRequester.MakeRequest());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                });
            }
        }
    }
}
