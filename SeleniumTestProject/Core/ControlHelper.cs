using OpenQA.Selenium;

namespace SeleniumTestProject.Core
{
    public class ControlHelper
    {
        public bool IsValidatorFired(IWebElement validator)
        {
            var attributeValue = validator.GetAttribute("style");
            return attributeValue == "display: inline;";
        }

        public bool CheckValidatorText(IWebElement validator)
        {
            var text = validator.Text;
            return text == StringHelper.ValidationMessage;
        }
    }
}
