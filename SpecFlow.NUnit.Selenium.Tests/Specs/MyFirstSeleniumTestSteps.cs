using FluentAssertions;
using SpecFlowNUnitSelenium.Tests.Paginas;
using SpecFlowNUnitSelenium.Tests.Support;
using TechTalk.SpecFlow;

namespace SpecFlowNUnitSelenium.Tests.Specs
{
    [Binding]
    public class MyFirstSeleniumTestSteps : WebBindingBase
    {
        private static PaginaSobre _pagina;
        private static PaginaSobre Pagina { get { return _pagina ?? (_pagina = new PaginaSobre(WebDriver)); } }

        [Given(@"que eu esteja fazendo meu primeiro Selenium")]
        public void DadoQueEuEstejaFazendoMeuPrimeiroSelenium()
        {
        }
        
        [Given(@"desejo abrir a página do Google")]
        public void DadoDesejoAbrirAPaginaDoGoogle()
        {
        }
        
        [When(@"eu for para a página sobre")]
        public void QuandoEuForParaAPaginaSobre()
        {
            WebDriver.Navigate().GoToUrl("https://www.google.com.br/intl/pt-BR/about/");
        }
        
        [Then(@"eu devo ter a descrição: ""(.*)""")]
        public void EntaoEuDevoTerADescricao(string missaoDoGoogle)
        {
            Pagina.MissaoDoGoogle.Text.Should().Be(missaoDoGoogle);
        }
    }
}
