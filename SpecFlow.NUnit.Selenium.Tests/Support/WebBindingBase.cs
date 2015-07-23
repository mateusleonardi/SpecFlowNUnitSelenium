//    --------------------------------------------------------------------------------------------------------------------
//    Autor: Mateus Leonardi
//    Data de criação: 23/07/2015
//    --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowNUnitSelenium.Tests.Support
{
    [Binding]
    public class WebBindingBase
    {
        public static IWebDriver WebDriver { get; set; }
    }
}
