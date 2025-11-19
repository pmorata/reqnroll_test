using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Reqnroll;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReqnRoll_Tests.e2e.StepDefinitions
{
    [Binding]    
    public class LoginFeatureStepDefinitions : PageTest
    {
        private readonly IPage _page;
        private Pages.LoginPage loginPage;
        private Pages.DashboardPage dashboardPage;

        public LoginFeatureStepDefinitions(IPage page)
        {
            _page = page;
            loginPage = new Pages.LoginPage(_page);
            dashboardPage = new Pages.DashboardPage(_page);
        }

        [Given("the user is on the login page")]
        public async Task GivenTheUserIsOnTheLoginPage()
        {
            await loginPage.GoTo();
        }

        [When("the user enters employee credentials")]
        public async Task WhenTheUserEntersEmployeeCredentials()
        {
            await loginPage.LoginForm(Environment.GetEnvironmentVariable("EmployeeLogin") ?? "", Environment.GetEnvironmentVariable("EmployeePassword") ?? "");
        }

        [When("the user enters manager credentials")]
        public async Task WhenTheUserEntersManagerCredentials() {
            await loginPage.LoginForm(Environment.GetEnvironmentVariable("ManagerLogin") ?? "", Environment.GetEnvironmentVariable("ManagerPassword") ?? "");
        }

        [Then("the user should be redirected to the dashboard")]
        public async Task ThenTheUserShouldBeRedirectedToTheDashboard()
        {
            await Expect(dashboardPage.TopBar.ButonLogout).ToBeVisibleAsync();            
        }

        [Then("the user should see Employee options")]
        public async Task ThenTheUserShouldSeeEmployeeOptions()
        {
            await Expect(dashboardPage.LeftPanel.ButtonMarkings).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonSchedule).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonPlanners).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonLists).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonDocuments).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonConfiguration).ToBeVisibleAsync();
            // El marcaje remoto es opcional, por eso se comenta la verificacion de su boton
            //await Expect(dashboardPage.LeftPanel.ButtonCreateMark).ToBeVisibleAsync();
            await CheckHeaderAndLogo();
        }

        [Then("the user should see Manager options")]
        public async Task ThenTheUserShouldSeeManagerOptions()
        {
            await Expect(dashboardPage.LeftPanel.ButtonPeople).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonTimetable).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonLists).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonAccesses).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonVisits).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonDocuments).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonConfiguration).ToBeVisibleAsync();
            await CheckHeaderAndLogo();
        }

        [When("the user enters invalid username or password")]
        public async Task WhenTheUserEntersInvalidUsernameOrPassword()
        {
            await loginPage.LoginForm("invalid", "password");
        }

        [Then("an error message should be displayed indicating invalid credentials")]
        public async Task ThenAnErrorMessageShouldBeDisplayedIndicatingInvalidCredentials()
        {
            await Expect(loginPage.ErrorMessageBox).ToBeVisibleAsync();
            await Expect(loginPage.ErrorMessageBox).ToHaveTextAsync(new Regex(@"^(?!\s*$).+"));
        }

        [When("the user leaves the username and password fields empty")]
        public async Task WhenTheUserLeavesTheUsernameAndPasswordFieldsEmpty()
        {
            await loginPage.LoginForm("", "");
        }

        private async Task CheckHeaderAndLogo() {
            await Expect(dashboardPage.TopBar.ButtonHelp).ToBeVisibleAsync();
            await Expect(dashboardPage.TopBar.ButtonNotifications).ToBeVisibleAsync();
            await Expect(dashboardPage.TopBar.ButonLogout).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ImageLogo).ToBeVisibleAsync();
        }
    }
}
