namespace HttpRequester
{
    using System;
    using System.Text;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System.IO;

    public class MyHttpRequester
    {
        private const string NEW_LINE = "\r\n";

        public static async Task StartServer(TcpClient tcpClient)
        {
            while (true)
            {
                using NetworkStream networkStream = tcpClient.GetStream();

                byte[] requestBytes = new byte[1000000];
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                // Body of the header
                string responseText = @"<form action='/Account/Login' method='post'>
                                        <input type=date name='date' />
                                        <input type=text name='username' />
                                        <input type=password name='pasword' />
                                        <input type=submit value='Login' />
                                        </form>" + "<h1>" + DateTime.UtcNow + "</h1>";

                string response = "HTTP/1.0 200 OK" + NEW_LINE +
                    "Server: MyTestServer/1.0" + NEW_LINE +
                    "Content-type: text/html" + NEW_LINE +
                    $"Content-Length: {responseText.Length}" + NEW_LINE
                    + NEW_LINE +
                    responseText;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);

                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
        }

        public static async Task MakeRequest()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:80");
            string result = await response.Content.ReadAsStringAsync();

            // File.WriteAllText("../../../test.html", result, Encoding.UTF8);
        }
    }
}
