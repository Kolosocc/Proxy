using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Proxy : ISubject
    {
        private RealSubject _realSubject;
        private Dictionary<string, string> _cache;
        private DateTime _lastCacheTime;
        private readonly TimeSpan _cacheExpiration;
        private readonly string _userRole;
        private readonly Dictionary<string, List<string>> _permissions;

        public Proxy(string userRole, Dictionary<string, List<string>> permissions)
        {
            _realSubject = new RealSubject();
            _cache = new Dictionary<string, string>();
            _lastCacheTime = DateTime.MinValue;
            _cacheExpiration = TimeSpan.FromMinutes(1);
            _userRole = userRole;
            _permissions = permissions;
        }

        private bool HasPermission(string request)
        {
            return _permissions.ContainsKey(_userRole) && _permissions[_userRole].Contains(request);
        }

        public string Request(string request)
        {
            if (!HasPermission(request))
            {
                return "Доступ запрещён: у вас нет прав на выполнение этого запроса.";
            }

            if (_cache.ContainsKey(request) && DateTime.Now - _lastCacheTime < _cacheExpiration)
            {
                Console.WriteLine("Proxy: возвращаю ответ из кэша.");
                return _cache[request];
            }

            Console.WriteLine("Proxy: перенаправляю запрос на сервер.");
            string response = _realSubject.Request(request);
            _cache[request] = response;
            _lastCacheTime = DateTime.Now;
            return response;
        }
    }

}