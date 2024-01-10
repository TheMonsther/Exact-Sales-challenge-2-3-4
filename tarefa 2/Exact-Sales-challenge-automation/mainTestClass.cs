using Exact_Sales_challenge_automation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Exact_Sales_challenge_automation
{
    public class Tests
    {
        protected IWebDriver driver;

        [TestCase]
        public void TestSelectionDefaultOption()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Selectable.html");
          
            Selectable selectable = new Selectable(driver);

            selectable.Btn_default.Click();
            selectable.Table[5].Click();

            Assert.IsTrue(selectable.CheckSelected(selectable.Table[5], false));

            driver.Quit();

        }

        [TestCase]
        public void TestSelectionSerializeOption()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Selectable.html");

            Selectable selectable = new Selectable(driver);

            selectable.Btn_serialize.Click();
            selectable.Table[5].Click();

            Assert.IsTrue(selectable.CheckSelected(selectable.Table[5], true));

            driver.Quit();

        }

        [TestCase]
        public void TestTextShowing()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Selectable.html");

            Selectable selectable = new Selectable(driver);

            selectable.Btn_serialize.Click();

            selectable.Table[1].Click();
            Actions actions = new Actions(driver);
            actions.KeyDown(Keys.LeftControl)
                .Click(selectable.Table[3])
                .Click(selectable.Table[4])
                .KeyUp(Keys.LeftControl)
                .Build()
                .Perform();

            Assert.IsTrue(selectable.CheckStringCorretOrder([selectable.Table[1], selectable.Table[3], selectable.Table[4]]));
            
            driver.Quit();

        }

    }
}