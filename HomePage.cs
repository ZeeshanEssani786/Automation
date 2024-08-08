using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;


namespace Playwright_Automation
{
    public class HomePage : PageTest
    {
        private readonly IPage _page;
        private readonly ILocator _HomeBtn;
        private readonly ILocator _ProductsBtn;
        private readonly ILocator _CartBtn;
        private readonly ILocator _LoginSignupBtn;
        private readonly ILocator _TestCasesBtn;
        private readonly ILocator _APITestingBtn;
        private readonly ILocator _VideoTutorialsBtn;
        private readonly ILocator _ContactusBtn;

        public HomePage(IPage page) {

            _page = page;
            _HomeBtn = _page.GetByRole(AriaRole.Link, new() { Name = " Home" });
            _ProductsBtn = _page.GetByRole(AriaRole.Link, new() { Name = " Products" });
            _CartBtn = _page.GetByRole(AriaRole.Link, new() { Name = " Cart" });
            _LoginSignupBtn = _page.GetByRole(AriaRole.Link, new() { Name = " Signup / Login" });
            _TestCasesBtn = _page.GetByRole(AriaRole.Link, new() { Name = " Test Cases" });

            _APITestingBtn = _page.GetByRole(AriaRole.Link, new() { Name = " API Testing" });
            _VideoTutorialsBtn = _page.GetByRole(AriaRole.Link, new() { Name = " Video Tutorials" });
            _ContactusBtn = _page.GetByRole(AriaRole.Link, new() { Name = " Contact us" });
         
            }


        public async Task GotoUrl(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task GotoHomePage()
        {     
            await _HomeBtn.ClickAsync();
        }
        public async Task ValidateHomePage()
        {
            await Expect(_page.GetByText(" Home")).ToBeVisibleAsync(new() { Timeout = 10_000 });

        }
        public async Task GotoProductsPage()
        {
            await _ProductsBtn.ClickAsync();
        }

        public async Task GotoCartPage()
        {
            await _CartBtn.ClickAsync();
        }

        public async Task GotoLoginSignupPage()
        {
            await _LoginSignupBtn.ClickAsync();
        }

        public async Task GotoTestCasesPage()
        {
            await _TestCasesBtn.ClickAsync();
        }

        public async Task GotoAPITestingPage()
        {
            await _APITestingBtn.ClickAsync();
        }

        public async Task GotoVideoTutorialsPage()
        {
            await _APITestingBtn.ClickAsync();
        }

        public async Task GotoContactusPage()
        {
            await _ContactusBtn.ClickAsync();
        }

    }
}
