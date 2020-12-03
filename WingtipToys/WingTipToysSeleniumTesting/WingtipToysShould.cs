using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

        [Test]
        [Property("Category", "App")]
        public void ClickToNavigate()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeURL);
                IWebElement feedbackLink = driver.FindElement(By.LinkText("Feedback"));
                feedbackLink.Click();

                Assert.AreEqual(FeedbackURL, driver.Url);
            }
        }

        [Test]
        [Property("Category", "App")]
        public void GiveUserFeedback() // auto navigate to feedback page, choose a product, leave a review and submit it to the database
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeURL);
                IWebElement feedbackLink = driver.FindElement(By.LinkText("Feedback"));
                feedbackLink.Click();

                driver.FindElement(By.Id("MainContent_emailAddress")).SendKeys("Me123@gmail.com"); // Entering Email

                IWebElement categorySelectElement = driver.FindElement(By.Id("MainContent_categoryDropdown"));
                SelectElement categorySource = new SelectElement(categorySelectElement);
                //check default is the same
                Assert.AreEqual("Cars", categorySource.SelectedOption.Text);
                categorySource.SelectByText("Planes"); // Product category

                IWebElement productSelectElement = driver.FindElement(By.Id("MainContent_productDropdown"));
                SelectElement productSource = new SelectElement(productSelectElement);
                productSource.SelectByText("Glider"); // Specific Product

                driver.FindElement(By.Id("MainContent_feedbackTextBox")).SendKeys("Product was fab, great fun for all to be had!"); // review text

                driver.FindElement(By.Id("MainContent_feedbackSubmit")).Click(); // Send the data over network to database
            }
        }
    }
}
