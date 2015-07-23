//    --------------------------------------------------------------------------------------------------------------------
//    Autor: Mateus Leonardi
//    Data de criação: 23/07/2015
//    --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowNUnitSelenium.Tests.Support
{
    public static class SeleniumExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static bool MatchCondition(
            this IWebElement element, Func<IWebElement, bool> predicate, int timeoutInSeconds)
        {
            if (timeoutInSeconds <= 0) return predicate(element);

            var wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = TimeSpan.FromSeconds(timeoutInSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(500.0)
            };
            return wait.Until(predicate);
        }

        public static IWebElement SetText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
            return element;
        }

        public static IWebElement FindElement(this IWebElement element, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds <= 0) return element.FindElement(@by);

            var wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = TimeSpan.FromSeconds(timeoutInSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(500.0)
            };
            wait.IgnoreExceptionTypes(new[] { typeof(NotFoundException) });
            return wait.Until(e => e.FindElement(@by));
        }

        public static bool IsElementPresent(this IWebDriver driver, By by, int timeoutInSeconds = 0)
        {
            try
            {
                driver.FindElement(by, timeoutInSeconds);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        public static bool WaitUntil(this IWebDriver driver, Func<IWebDriver, bool> actionToWait, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            return wait.Until(actionToWait);
        }

        public static bool WaitUntil(this IWebDriver driver, Func<IWebDriver, bool> actionToWait, int timeoutInSeconds = 2)
        {
            return WaitUntil(driver, actionToWait, new TimeSpan(0, 0, timeoutInSeconds));
        }

        public static IWebElement ClickAndWait(this IWebElement element, TimeSpan? time = null)
        {
            time = time ?? TimeSpan.FromSeconds(1);
            element.Click();
            Thread.Sleep(time.Value);
            return element;
        }

        public static IWebDriver WaitForAllAjaxCallsToComplete(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            wait.Until(d =>
            {
                var javaScriptExecutor = driver as IJavaScriptExecutor;
                if (javaScriptExecutor == null)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(15));
                    return true;
                }
                return (bool)javaScriptExecutor.ExecuteScript("return typeof jQuery !== 'undefined' && jQuery.active == 0");
            });

            return driver;
        }

        public static IWebDriver CheckEventIsAttached(this IWebDriver driver, IWebElement element, string eventName)
        {
            var javaScriptExecutor = driver as IJavaScriptExecutor;
            if (javaScriptExecutor == null)
            {
                throw new InvalidOperationException(driver.GetType() + " não implementa IJavaScriptExecutor");
            }

            element.MatchCondition(
                e =>
                {
                    var id = element.GetAttribute("id");
                    return (bool)javaScriptExecutor
                                      .ExecuteScript("return $('#" + id + "').data('events')." + eventName +
                                                     ".length > 0");

                }, 15);

            return driver;
        }

        public static IWebDriver MoveToElement(this IWebDriver driver, IWebElement element)
        {
            new Actions(driver)
                .MoveToElement(element)
                .Build()
                .Perform();

            return driver;
        }

        public static IWebDriver MoveToElement(this IWebDriver driver, IWebElement element, int x, int y)
        {
            new Actions(driver)
                .MoveToElement(element, x, y)
                .Build()
                .Perform();

            return driver;
        }

        public static IWebDriver Navigate(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl("about:blank");
            driver.Navigate().GoToUrl(url);
            return driver;
        }
    }
}
