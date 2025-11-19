using Microsoft.Playwright;
using ReqnRoll_Tests.e2e.Pages.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnRoll_Tests.e2e.Pages {
    public class DashboardPage {
        #region private properties
        // TODO: todos los localizadores deberian seguir el estandar de la industria, el data-testid
        // Crear tareas para añadir el tag en los controles del modulo de manager
        private ILocator listEmployees => page.Locator("id=BTCOMBO");
        private ILocator dropDownMarkingType => page.Locator("id=WGT_CONTAINER");
        private ILocator buttonMark => page.Locator("id=BTN");
        //private ILocator markingType => page.Locator("id=gg-row");
        private ILocator markingType(int? index) => page.Locator($"id=gg-row" + index.HasValue is null ? "entity-id={index}" : "");
        private readonly IPage page;
        #endregion


        public LeftPanel LeftPanel => new LeftPanel(page);
        public TopBar TopBar => new TopBar(page);

        public DashboardPage(IPage page) {
            this.page = page;
        }

        public async Task ExpandMarkingTypeDropDown() {
            await dropDownMarkingType.ClickAsync();
        }
    }
}
