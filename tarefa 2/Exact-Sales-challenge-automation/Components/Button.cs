using Exact_Sales_challenge_automation.Pages;
using OpenQA.Selenium;


namespace Exact_Sales_challenge_automation.Components
{
    internal class Button
    {
        private IWebElement webElement;

        private Selectable selectable;

        public IWebElement WebElement { get => webElement; set { webElement = value; } }
        public Selectable SelectablePage { set { selectable = value; } }

        public void Click()
        {
            webElement.Click();
            selectable.SelectOption(this);
        }

    }
}
