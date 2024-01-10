using Exact_Sales_challenge_automation.Components;
using OpenQA.Selenium;

namespace Exact_Sales_challenge_automation.Pages
{
    internal class Selectable
    {
        private  IList<IWebElement> table = new List<IWebElement>();
        private IWebElement textList;
        private  Button btn_default = new Button();
        private  Button btn_serialize = new Button();
        private  IWebDriver driver;

        public IList<IWebElement> Table { get => table; }

        public  Button Btn_default { get => btn_default; }
        public  Button Btn_serialize { get => btn_serialize; }

        public Selectable(IWebDriver driverMain) 
        {
            driver = driverMain;
            btn_default.WebElement = driver.FindElement(By.CssSelector("a[href^=\"#Default\"]"));
            btn_default.SelectablePage = this;
        
            btn_serialize.WebElement = driver.FindElement(By.CssSelector("a[href^=\"#Serialize\"]"));
            btn_serialize.SelectablePage = this;
        }

        public void SelectOption(Button clicked)
        {
            if (clicked == btn_default) table = driver.FindElements(By.CssSelector("#Default .ui-widget-content"));
            else table = driver.FindElements(By.CssSelector("#Serialize .ui-widget-content"));
        }

        public bool CheckSelected(IWebElement element, bool serialize)
        {
            int row = table.IndexOf(element);

            //atualizar a seleção para pegar o element com a classe selected
            if (!serialize) table = driver.FindElements(By.CssSelector("#Default .ui-widget-content"));
            else table = driver.FindElements(By.CssSelector("#Serialize .ui-widget-content"));

            String classe = table[row].GetAttribute("class");
            if (classe.Equals("ui-widget-content selected"))
            {
                return true;
            }
            return false;
        }

        public bool CheckStringCorretOrder(IWebElement[] elementsInOrder) 
        {
            textList = driver.FindElement(By.Id("result"));
            string[] words = textList.Text.Split(" , ");

            int i = 0;

            foreach (var word in words)
            {
                string result = elementsInOrder[i].Text.Replace("Sakinalium - ", "");
                if (!word.Equals(result))
                {
                    return false;
                }
                i++;
            }

            return true;
        }

    }
}
