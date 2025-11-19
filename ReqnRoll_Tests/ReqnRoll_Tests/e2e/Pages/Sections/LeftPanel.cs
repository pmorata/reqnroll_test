using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReqnRoll_Tests.e2e.Pages.Sections {
    public class LeftPanel {
        #region private properties
        // TODO: todos los localizadores deberian seguir el estandar de la industria, el data-testid
        // Crear tareas para añadir el tag en los controles del modulo de manager
        private readonly IPage page;
        #endregion

        #region public Locators
        public ILocator ButtonMarkings => page.Locator("[src='./assets/svg/white/moviments_brand.svg']");
        public ILocator ButtonSchedule => page.Locator("[src='./assets/svg/white/calendar_brand.svg']");
        public ILocator ButtonPlanners => page.Locator("[src='./assets/svg/white/planificacion_brand.svg']");
        public ILocator ButtonLists => page.Locator("[src='./assets/svg/white/listado_brand.svg']").First;
        public ILocator ButtonDocuments => page.Locator("[src='./assets/svg/white/consulta_brand.svg']");
        public ILocator ButtonConfiguration => page.Locator("[src='./assets/svg/white/setting_brand.svg']");
        public ILocator ButtonCreateMark => page.Locator("[src='./assets/svg/white/clock_brand.svg']");
        public ILocator ImageLogo => page.Locator("[src='./assets/img/logos/ntOneLogoWhite.svg']");

        public ILocator ButtonNotifications => page.Locator("[src='./assets/svg/white/notification_brand.svg']");
        public ILocator ButtonChangePIN => page.Locator("[src='./assets/svg/white/password_brand.svg']").GetByText(new Regex("/PIN"));
        public ILocator ButtonChangePassword => page.Locator("[src='./assets/svg/white/password_brand.svg']");
        public ILocator ButtonLastConnection => page.Locator("[src='./assets/svg/white/last-login_brand.svg']");
        public ILocator ButtonChangeLanguage => page.Locator("[src='./assets/svg/white/globe.svg']");
        public ILocator ButtonAbout => page.Locator("[src='./assets/svg/white/about_brand.svg']");

        #region admin specific buttons
        public ILocator ButtonPeople => page.Locator("[src='./assets/svg/white/users_brand.svg']");
        public ILocator ButtonTimetable => page.Locator("[src='./assets/svg/white/clock_brand.svg']");
        public ILocator ButtonAccesses => page.Locator("[src='./assets/svg/white/accesos_brand.svg']");
        public ILocator ButtonVisits => page.Locator("[src='./assets/svg/white/briefcase_brand.svg']");
        public ILocator ButtonAnonymousListings => page.Locator("[src='./assets/svg/white/listado_brand.svg']");

        #endregion
        public ILocator Version => page.GetByText("/^Version");
        #endregion

        public LeftPanel(IPage page) {
            this.page = page;
        }
    }
}
