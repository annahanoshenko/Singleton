using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class WebDriverSingleton
    {
        private static IWebDriver _driver;
        private static readonly object _lock = new object();

        private WebDriverSingleton()
        {
        }

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                lock (_lock)
                {
                    if (_driver == null)
                    {
                        _driver = new ChromeDriver();
                    }
                }
            }
            return _driver;
        }
        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
