using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Playwright_Automation
{
    public class Login_SignupPage : PageTest
    {
        private readonly IPage _page;
        private readonly ILocator _SignUpName;
        private readonly ILocator _SignUpEmailAddress;
        private readonly ILocator _SignUpBtn;
        private readonly ILocator _LoginEmailAddress;
        private readonly ILocator _LoginPassword;
        private readonly ILocator _LoginBtn;

        public Login_SignupPage(IPage page)
        {
            _page = page;
            _SignUpName = _page.GetByPlaceholder("Name");
            _SignUpEmailAddress = _page.Locator("form").Filter(new() { HasText = "Signup" }).GetByPlaceholder("Email Address");
            _SignUpBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Signup" });
            _LoginEmailAddress = _page.Locator("form").Filter(new() { HasText = "Login" }).GetByPlaceholder("Email Address");
            _LoginPassword = _page.GetByPlaceholder("Password");
            _LoginBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        }

        public async Task SignUp(string SignUpName, string SignUpEmailAddress)
        {
            await _SignUpName.FillAsync(SignUpName);
            await _SignUpEmailAddress.FillAsync(SignUpEmailAddress);
            await _SignUpBtn.ClickAsync();
        }

        public async Task Validate_Successful_SignUp()
        {
            await Expect(_page.GetByText("Enter Account Information")).ToBeVisibleAsync(new() { Timeout = 10_000 });
        }


        public async Task Login(string LoginEmailAddress, string LoginPassword)
        {
            await _LoginEmailAddress.FillAsync(LoginEmailAddress);
            await _LoginPassword.FillAsync(LoginPassword);
            await _LoginBtn.ClickAsync();
        }

        public async Task Validate_Successfull_Login()
        {
            await Expect(_page.GetByText("Logged in as Zeeshan Bahadur Ali ")).ToBeVisibleAsync(new() { Timeout = 10_000 });
        }
        public async Task Validate_UnSuccessfull_Login()
        {
            await Expect(_page.GetByText("Your email or password is")).ToBeVisibleAsync(new() { Timeout = 10_000 });
        }
    }
}
