namespace HttpRequester
{
    using System;
    using System.Text;
    using System.Net.Sockets;

    public class MyHttpRequester
    {
        private const string NEW_LINE = "\r\n";

        private readonly TcpListener tcpListener;

        public MyHttpRequester(TcpListener tcpListener)
        {
            this.tcpListener = tcpListener;
        }

        public void StartServer()
        {
            this.tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = this.tcpListener.AcceptTcpClient();

                using NetworkStream networkStream = tcpClient.GetStream();

                byte[] requestBytes = new byte[1000000];
                int bytesRead = networkStream.Read(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                // Body of the header
                string responseText = "<h1>Hello HTTP!</h1>";

                string response = "HTTP/1.0 200 OK" + NEW_LINE +
                    "Server: MyTestServer/1.0" + NEW_LINE +
                    "Content-type: text/html" + NEW_LINE +
                    $"Content-Length: {responseText.Length}" + NEW_LINE
                    + NEW_LINE +
                    responseText;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                networkStream.Write(responseBytes, 0, responseBytes.Length);

                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
        }
    }
}
