using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace TechFabricSln.Test
{
    class SeleniumTest
    {
        [Test]
        [Category("UITests")]
        public void VisitMicrosoft_CheckWindowsMenu()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            var driverPath = Path.Combine(Directory.GetCurrentDirectory());
            var envChromeWebDriver = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (!string.IsNullOrEmpty(envChromeWebDriver) &&
               File.Exists(Path.Combine(envChromeWebDriver, "chromedriver.exe")))
            {
                driverPath = envChromeWebDriver;
            }
            ChromeDriverService defaultService = ChromeDriverService.CreateDefaultService(driverPath);
            defaultService.HideCommandPromptWindow = true;
            var driver = (IWebDriver)new ChromeDriver(defaultService, chromeOptions);

            //IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.microsoft.com/");

            Thread.Sleep(10000);

            string Windows_text = driver.FindElement(By.Id("shellmenu_1")).Text;
            Assert.AreEqual("Windows", Windows_text);

            driver.Quit();
        }
    }
}
