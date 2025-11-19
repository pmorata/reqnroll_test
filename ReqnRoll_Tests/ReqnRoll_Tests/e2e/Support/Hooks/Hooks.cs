using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;
using System.Threading.Tasks;

namespace ReqnRoll_Tests.e2e.Support.Hooks {
    [Binding]
    public sealed class Hooks {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext) {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario()]
        public async Task SetupPlaywright() {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to false if you want to see the browser UI during tests
            });
            var browserContext = await browser.NewContextAsync(
                new BrowserNewContextOptions { BypassCSP = true  });
            var page = await browserContext.NewPageAsync();
            _objectContainer.RegisterInstanceAs(browser);
            _objectContainer.RegisterInstanceAs(page);
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario() {
            // Example of ordering the execution of hooks
            // See https://go.reqnroll.net/doc-hooks#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario() {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}