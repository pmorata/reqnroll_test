using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnRoll_Tests.e2e.Pages {
    public class LoginPage {
        #region private properties
        // TODO: todos los localizadores deberian seguir el estandar de la industria, el data-testid
        // Crear tareas para añadir el tag en los controles del modulo de manager
        private ILocator loginEmployee => page.Locator("#btn-sso-emp");
        private ILocator loginManagement => page.Locator("#btn-sso-usr");
        private ILocator buttonLoginForm => page.Locator("#normal-login");
        private ILocator linkPasswordRecovery => page.Locator("#recovery-link");
        private ILocator textboxUser => page.Locator("#input-user");
        private ILocator textboxPassword => page.Locator("#input-password");
        private ILocator buttonLogin => page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        private ILocator buttonSSO => page.GetByRole(AriaRole.Button, new() { Name = "SSO" });
        private readonly IPage page;
        #endregion

        public ILocator ErrorMessageBox => page.Locator("#BOX>div");

        public LoginPage(IPage page) {
            this.page = page;
        }

        public async Task GoTo() {
            await page.GotoAsync(Environment.GetEnvironmentVariable("netOneURL") ?? "");
        }
        public async Task LoginEmployee() {
            await GoTo();
            await LoginForm(Environment.GetEnvironmentVariable("EmployeeLogin") ?? "", Environment.GetEnvironmentVariable("EmployeePassword") ?? "");
        }

        public async Task LoginManagement() {
            await GoTo();
            await LoginForm(Environment.GetEnvironmentVariable("ManagerLogin") ?? "", Environment.GetEnvironmentVariable("ManagerPassword") ?? "");
        }

        public async Task ShowLoginForm() {
            await buttonLoginForm.ClickAsync();
        }
        public async Task ShowSSO() {
            await buttonSSO.ClickAsync();
        }

        public async Task LoginForm(string user, string password) {
            // la máquina usada para el testing envía directamente al formulario de login, no hace falta el showloginform
            //await ShowLoginForm();
            await textboxUser.FillAsync(user);
            await textboxPassword.FillAsync(password);
            await buttonLogin.ClickAsync();
        }
    }
}
