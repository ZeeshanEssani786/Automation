using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Automation
{
    public class RegisterationPage : PageTest
    {
        private readonly IPage _page;
        private readonly ILocator _title;
        private readonly ILocator _password;
        private readonly ILocator _Dob_Day;
        private readonly ILocator _Dob_Month;
        private readonly ILocator _Dob_Year;
        private readonly ILocator _NewsLetter_Ckbox;
        private readonly ILocator _SpecialOffers_chkbox;
        private readonly ILocator _firstname;
        private readonly ILocator _lastname;
        private readonly ILocator _Companyname;
        private readonly ILocator _Address;
        private readonly ILocator _State;
        private readonly ILocator _City;
        private readonly ILocator _ZipCode;
        private readonly ILocator _MobileNumber;
        private readonly ILocator _CreateAccountBtn;


        public RegisterationPage(IPage page)
        {

            _page = page;
            _title = _page.GetByLabel("Mr.");
            _password = _page.GetByLabel("Password *");
            _Dob_Day = _page.Locator("#days");
            _Dob_Month = _page.Locator("#months");
            _Dob_Year = _page.Locator("#years");
            _NewsLetter_Ckbox = _page.GetByLabel("Sign up for our newsletter!");
            _SpecialOffers_chkbox = _page.GetByLabel("Receive special offers from our partners!");
            _firstname = _page.GetByLabel("First name *");
            _lastname = _page.GetByLabel("Last name *");
            _Companyname = _page.GetByLabel("Company", new() { Exact = true });
            _Address = _page.GetByLabel("Address * (Street address, P.");
            _State = _page.GetByLabel("State *");
            _City = _page.GetByLabel("City *");
            _ZipCode = _page.Locator("#zipcode");
            _MobileNumber = _page.GetByLabel("Mobile Number *");
            _CreateAccountBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create Account" });

        }

        public async Task Register(string password, string Dob_Day, string Dob_Month, string Dob_Year, string FirstName, string LastName, string CompanyName, string Address, string State, string city, string zipcode, string MobileNumber)
        {


            await _title.CheckAsync();
            await _password.FillAsync(password);
            await _Dob_Day.SelectOptionAsync(new[] { Dob_Day });
            await _Dob_Month.SelectOptionAsync(new[] { Dob_Month });
            await _Dob_Year.SelectOptionAsync(new[] { Dob_Year });

            await _NewsLetter_Ckbox.CheckAsync();
            await _SpecialOffers_chkbox.CheckAsync();

            await _firstname.FillAsync(FirstName);
            await _lastname.FillAsync(LastName);


            await _Companyname.FillAsync(CompanyName);
            await _Address.FillAsync(Address);
            await _State.FillAsync(State);
            await _City.FillAsync(city);
            await _ZipCode.FillAsync(zipcode);
            await _MobileNumber.FillAsync(MobileNumber);
            await _CreateAccountBtn.ClickAsync();


        }

        public async Task SuccessFullRegistration_Validation()
        {
            await Expect(_page.GetByText("Account Created!")).ToBeVisibleAsync(new() { Timeout = 10_000 });
        }

    }
}
