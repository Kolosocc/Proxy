using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class RealSubject : ISubject
    {
        public string Request(string request)
        {
            Console.WriteLine($"Сервер обрабатывает запрос: {request}");
            return $"Ответ от сервера: {request}";
        }
    }
}
