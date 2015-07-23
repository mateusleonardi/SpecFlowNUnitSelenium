//    --------------------------------------------------------------------------------------------------------------------
//    Autor: Mateus Leonardi
//    Data de criação: 23/07/2015
//    --------------------------------------------------------------------------------------------------------------------

using SpecFlowNUnitSelenium.Tests.Configs;
using TechTalk.SpecFlow;

namespace SpecFlowNUnitSelenium.Tests.Support
{
    public static class UrlManager
    {
        public static string UrlBase
        {
            get { return "http://localhost:51360/"; }
        }
    }

    [Binding]
    public class SeleniumHooks
    {
        static SeleniumHooks()
        {
            Navegador = Navegador.Chrome;
        }
        
        public static Navegador Navegador { get; set; }

        [BeforeFeature("web")]
        public static void AbreNavegador()
        {
            WebBindingBase.WebDriver = SeleniumHelper.ObterNavegadorWebDriver(Navegador);
        }

        [AfterFeature("web")]
        public static void FechaNavegador()
        {
            SeleniumHelper.FecharNavegador();
        }

        [BeforeTestRun]
        public static void CarregarTabelasDeSuporte()
        {
        }
    }
}