using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace WebTest
{

    [TestClass]
    public class WebSiteTests
    {
        const string PATH = @"C:\Users\Grava\Downloads\geckodriver-v0.30.0-win64";
        const string URL = "https://developer.mozilla.org/ru/docs/Web/HTML/Element/select";

        [TestMethod]
        public void InputText()
        {
            try
            {
                var driver = new FirefoxDriver(PATH);

                Assert.IsNotNull(driver);

                driver.Navigate().GoToUrl(URL);
                driver.FindElement(By.Name("q")).SendKeys("Ноутбук HP");

                var text = driver.FindElement(By.Name("q")).GetAttribute("value");

                driver.Close();

                Assert.AreEqual("Ноутбук HP", text);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void DownButton()
        {
            try
            {
                var driver = new FirefoxDriver(PATH);

                Assert.IsNotNull(driver);

                driver.Navigate().GoToUrl(URL);
                var buttons = driver.FindElements(By.CssSelector(@"#technologies-button")); //Если именно на этой странице
                //var buttons = driver.FindElements(By.TagName("button")); // любая кнопка

                Assert.IsNotNull(buttons);

                buttons[0].Click();

                driver.Close();

                Assert.AreEqual(true, buttons.Count > 0);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SelectListItem()
        {
            try
            {
                var driver = new FirefoxDriver(PATH);
                string xPath = @"/html/body/div[1]/div[1]/main/article/div[4]/p/select";

                Assert.IsNotNull(driver);

                driver.Navigate().GoToUrl(URL);

                var element = driver.FindElements(By.XPath(xPath)).FirstOrDefault();

                Assert.IsNotNull(element);

                SelectElement itemList = new SelectElement(element);

                itemList.SelectByIndex(1);

                driver.Close();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void FindElementByClassName()
        {
            try
            {
                var driver = new FirefoxDriver(PATH);

                Assert.IsNotNull(driver);

                driver.Navigate().GoToUrl(URL);

                var elements = driver.FindElements(By.ClassName("logo"));

                driver.Close();

                Assert.IsNotNull(elements);
                Assert.AreEqual(true, elements.Count > 0);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void FindElementByTag()
        {
            try
            {
                var driver = new FirefoxDriver(PATH);

                Assert.IsNotNull(driver);

                driver.Navigate().GoToUrl(URL);

                var elements = driver.FindElements(By.TagName("select"));

                driver.Close();

                Assert.IsNotNull(elements);
                Assert.AreEqual(true, elements.Count > 0);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
