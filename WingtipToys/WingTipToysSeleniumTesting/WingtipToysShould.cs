using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WingTipToysSeleniumTesting
{
    [TestFixture]
    class WingtipToysShould
    {
        private const string HomeURL = "http://localhost:52886/";
        private const string FeedbackURL = "http://localhost:52886/Feedback";
        private const string HomeTitle = "Welcome - Wingtip Toys";
        [Test]
        [Property("Category","Smoke")] //Simple Test
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeURL); //the port the site is running on my local machine

                string pageTitle = driver.Title;

                Assert.AreEqual(HomeTitle, pageTitle);

            }
        }

        [Test]
        [Property("Category","Smoke")]
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeURL); //the port the site is running on my local machine

                driver.Navigate().Refresh();

                string pageTitle = driver.Title;
                Assert.AreEqual(HomeTitle, pageTitle);
                Assert.AreEqual(HomeURL, driver.Url);

            }
        }

        [Test]
        [Property("Category", "Smoke")]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeURL); //the port the site is running on my local machine
                driver.Navigate().GoToUrl(FeedbackURL);
                driver.Navigate().Back();

                Assert.AreEqual(HomeTitle, driver.Title);
                Assert.AreEqual(HomeURL, driver.Url);

            }
        }

        [Test]
        [Property("Category", "Smoke")]
        public void ReloadHomePageOnForward()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(FeedbackURL); //the port the site is running on my local machine
                driver.Navigate().GoToUrl(HomeURL);
                driver.Navigate().Back();
                driver.Navigate().Forward();

                Assert.AreEqual(HomeTitle, driver.Title);
                Assert.AreEqual(HomeURL, driver.Url);

            }
        }

    }
}
