Playwright was created specifically to accommodate the needs of end-to-end testing. Playwright supports all modern rendering engines including Chromium, WebKit, and Firefox. Test on Windows, Linux, and macOS, locally or on CI, headless or headed with native mobile emulation.

You can choose to use MSTest base classes or NUnit base classes that Playwright provides to write end-to-end tests. These classes support running tests on multiple browser engines, parallelizing tests, adjusting launch/context options and getting a Page/BrowserContext instance per test out of the box. Alternatively you can use the library to manually write the testing infrastructure.


1. Start by creating a new project with dotnet new. This will create the PlaywrightTests directory which includes a UnitTest1.cs file:

dotnet new nunit -n PlaywrightTests
cd PlaywrightTests


2. Install the necessary Playwright dependencies:

dotnet add package Microsoft.Playwright.NUnit

3. Build the project so the playwright.ps1 is available inside the bin directory:

dotnet build

4. Install required browsers. This example uses net8.0, if you are using a different version of .NET you will need to adjust the command and change net8.0 to your version.

pwsh bin/Debug/net8.0/playwright.ps1 install

If pwsh is not available, you will have to install PowerShell.
