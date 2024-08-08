using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Runtime.InteropServices;

namespace Playwright_Automation
{
    [TestFixture]
    public class UITests : PageTest
    {



        [Test]
        public async Task A_RegisterUser_With_DeleteAccount()
        {
            //Home Page
            HomePage homePage = new HomePage(Page);
            await homePage.GotoUrl("http://automationexercise.com");
            await homePage.GotoHomePage();
            await homePage.ValidateHomePage();
            await homePage.GotoLoginSignupPage();

            //LoginSignUp Page
            Login_SignupPage loginSignUpPage = new Login_SignupPage(Page);
            await loginSignUpPage.SignUp("Zeeshan Essani", "zeeshanessani@gmail.com");
            await loginSignUpPage.Validate_Successful_SignUp();

            //RegisterationPage
            RegisterationPage registerationPage = new RegisterationPage(Page);
            await registerationPage.Register(

                "tpstps_123",
                "18",
                "5",
                "1992",
                "Zeeshan",
                "Essani",
                "Contour Software Pvt. Ltd",
                "Flat#5 Building#4 Trust Gulshan e Noor Society Scheme 33",
                "Sindh",
                "Karachi",
                "75330",
                "03471233262"

                );
            await registerationPage.SuccessFullRegistration_Validation();


            await Page.GetByRole(AriaRole.Link, new() { Name = "Continue" }).ClickAsync();
            await Expect(Page.GetByText("Logged in as Zeeshan Essani")).ToBeVisibleAsync(new() { Timeout = 10_000 });


            await Page.GetByRole(AriaRole.Link, new() { Name = " Delete Account" }).ClickAsync();
            await Expect(Page.GetByText("Account Deleted!")).ToBeVisibleAsync(new() { Timeout = 10_000 });

        }

        [Test]
        public async Task B_LoginUser_with_ValidCredentials()
        {
            //Home Page
            HomePage homePage = new HomePage(Page);
            await homePage.GotoUrl("http://automationexercise.com");
            await homePage.GotoLoginSignupPage();

            //LoginSignUp Page
            Login_SignupPage loginSignUpPage = new Login_SignupPage(Page);
            await loginSignUpPage.Login("zeeshan.bahadur@contour-software.com", "idsids_123");
            await loginSignUpPage.Validate_Successfull_Login();

        }


        [Test]
        public async Task C_LoginUser_with_InvalidCredentials()
        {
            //Home Page
            HomePage homePage = new HomePage(Page);
            await homePage.GotoUrl("http://automationexercise.com");
            await homePage.GotoLoginSignupPage();

            //Login SignUp Page
            //LoginSignUp Page
            Login_SignupPage loginSignUpPage = new Login_SignupPage(Page);
            await loginSignUpPage.Login("zeeshanessani@umail.com", "tptstps_123");
            await loginSignUpPage.Validate_UnSuccessfull_Login();



        }

   
    }
}