using System.Text;

using _01Logger.Models.Contracts;

namespace _01Logger.Models.Layouts
{
    class MyCustomLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("My custom format:")
                .AppendLine("Date: {0}")
                .AppendLine("Level: {1}")
                .AppendLine("Message: {2}");

            return sb.ToString().TrimEnd();
        }
    }
}
