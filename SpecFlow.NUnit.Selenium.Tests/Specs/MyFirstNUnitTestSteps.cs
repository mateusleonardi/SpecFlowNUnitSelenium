using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowNUnitSelenium.Tests.Specs
{
    /// <summary>
    /// A ideia é que cada passo seja uma regra de negócio sendo explicada
    /// e também contenha a parte correspondente de código ou comportamento
    /// sendo executado
    /// </summary>
    [Binding]
    public class MyFirstNUnitTestSteps
    {
        private string parametro = string.Empty;

        [Given(@"que eu esteja fazendo meu primeiro NUnit")]
        public void DadoQueEuEstejaFazendoMeuPrimeiroNUnit()
        {
        }
        
        [Given(@"desejo validar se o parâmetro ""(.*)"" está sendo passado com sucesso")]
        public void DadoDesejoValidarSeOParametroEstaSendoPassadoComSucesso(string p0)
        {
            parametro = p0;
        }

        [When(@"confirmo que o parâmetro foi guardado em uma variável")]
        public void QuandoConfirmoOValorDoParametro()
        {
            parametro.Should().NotBeEmpty(parametro);
        }
        
        [Then(@"o resultado é positivo")]
        public void EntaoOResultadoEPositivo()
        {
            parametro.Should().Be("NUnit is awesome");
        }

        [Then(@"o resultado é negativo")]
        public void EntaoOResultadoENegativo()
        {
            parametro.Should().NotBe("NUnit is awesome");
        }
    }
}