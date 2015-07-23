using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowNUnitSelenium.Tests.Paginas
{
    public class Pagina
    {
        protected readonly IWebDriver WebDriver;

        public Pagina(IWebDriver driver)
        {
            WebDriver = driver;
        }

        protected IWebElement ObterElementoPeloSeletorCSS(string seletor)
        {
            Func<IWebElement> obterElemento = () =>
                                              WebDriver.FindElement(By.CssSelector(seletor));

            var espera = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(20));
            espera.Until(x => obterElemento().Displayed);

            return obterElemento();
        }

        protected ReadOnlyCollection<IWebElement> ObterElementosPeloSeletorCSS(string seletor)
        {
            Func<ReadOnlyCollection<IWebElement>> obterElementos = () =>
                                              WebDriver.FindElements(By.CssSelector(seletor));

            var espera = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(20));
            espera.Until(x => obterElementos().Where(y => y.Displayed));

            return obterElementos();
        }

        // Exemplos de como obter elementos
        public IWebElement BotaoFiltrar
        {
            get { return ObterElementoPeloSeletorCSS("button.botao-filtrar"); }
        }

        public SelectElement SelectStatus
        {
            get { return new SelectElement(ObterElementoPeloSeletorCSS("#AtivoCombo")); }
        }
    }
}
