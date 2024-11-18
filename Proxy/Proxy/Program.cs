namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var permissions = new Dictionary<string, List<string>>
            {
                { "admin", new List<string> { "Запрос1", "Запрос2", "Запрос3" } },
                { "guest", new List<string> { "Запрос1" } }
            };

            ISubject proxyAdmin = new Proxy("admin", permissions);
            Console.WriteLine(proxyAdmin.Request("Запрос1"));
            Console.WriteLine(proxyAdmin.Request("Запрос2"));

            ISubject proxyGuest = new Proxy("guest", permissions);
            Console.WriteLine(proxyGuest.Request("Запрос1"));
            Console.WriteLine(proxyGuest.Request("Запрос2"));
        }
    }
}
