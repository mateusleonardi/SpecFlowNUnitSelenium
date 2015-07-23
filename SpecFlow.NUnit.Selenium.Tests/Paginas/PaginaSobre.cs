using OpenQA.Selenium;

namespace SpecFlowNUnitSelenium.Tests.Paginas
{
    public class PaginaSobre : Pagina
    {
        public PaginaSobre(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement MissaoDoGoogle
        {
            get { return ObterElementoPeloSeletorCSS("blockquote"); }
        }
    }
}