//    --------------------------------------------------------------------------------------------------------------------
//    Autor: Mateus Leonardi
//    Data de criação: 23/07/2015
//    --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SpecFlowNUnitSelenium.Tests.Configs
{
    public static class SeleniumHelper
    {
        public static IWebDriver WebDriver;

        public static IWebDriver ObterNavegadorWebDriver(Navegador navegador)
        {
            AbrirNavegador(navegador);

            return WebDriver;
        }

        public static void FecharNavegador()
        {
            if (WebDriver == null)
            {
                return;
            }

            WebDriver.Close();
            WebDriver.Dispose();

            FechaIEDriverSeEstiverAberto();
        }

        public static void FechaIEDriverSeEstiverAberto()
        {
            var processos = Process.GetProcessesByName("IEDriverServer");

            foreach (var processo in processos)
            {
                processo.Kill();
                processo.Dispose();
            }
        }

        private static void AbrirNavegador(Navegador navegador)
        {
            switch (navegador)
            {
                case Navegador.Chrome:
                    WebDriver = ObterChrome();
                    break;

                case Navegador.InternetExplorer:
                    WebDriver = ObterInternetExplorerDriver();
                    break;

                case Navegador.Firefox:
                    WebDriver = new FirefoxDriver();
                    break;
            }
        }

        private static IWebDriver ObterChrome()
        {
            return new ChromeDriver(@"C:\Projetos\SpecFlow.NUnit.Selenium\packages\ChromeWebDriver");
        }

        private static IWebDriver ObterInternetExplorerDriver()
        {
            var sourceDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var solutionDir = Path.GetFullPath(Path.Combine(sourceDir, "..", "..", "..", "..", ".."));
            var driverPath = Path.GetFullPath(Path.Combine(solutionDir, @"tools\IEDriverServer_Win32_2.35.3"));

            var options = new InternetExplorerOptions
                              {
                                  IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                                  InitialBrowserUrl = "http://localhost:51360/",
                                  EnsureCleanSession = true,
                                  RequireWindowFocus = false
                              };

            return new InternetExplorerDriver(driverPath, options);
        }
    }

    public enum Navegador
    {
        Chrome,
        InternetExplorer,
        Firefox
    }
}
