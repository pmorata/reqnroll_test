using Microsoft.Playwright;
using System.ComponentModel;

namespace ReqnRoll_Tests.e2e.Pages.Widgets {
    public class ChangeLanguageWidget {
        public enum Languages {
            [System.ComponentModel.Description("ca-ES")]
            Catalan =0,
            [System.ComponentModel.Description("en-GB")]
            English =1,
            [System.ComponentModel.Description("es-ES")]
            Spanish =2,
            [System.ComponentModel.Description("eu-ES")]
            Euskara =3,
            [System.ComponentModel.Description("fr-FR")]
            French =4,
            [System.ComponentModel.Description("pt-PT")]
            Portuguese =5,
        }

        #region private properties
        // TODO: todos los localizadores deberian seguir el estandar de la industria, el data-testid
        // Crear tareas para añadir el tag en los controles del modulo de manager
        private readonly IPage page;
        private ILocator widgetRoot => page.Locator("#win_3").Locator("#CWIN-INTERNAL");
        #endregion

        #region public Locators
        public ILocator ButtonSave => widgetRoot.Locator("[menu-id=save]");
        public ILocator ButtonClose => widgetRoot.Locator("[menu-id=cancel]");
        public ILocator ListLanguages => widgetRoot.Locator("#BTCOMBO");
        public ILocator Language(Languages language) {        
            return page.Locator($"#GRID_CONTAINER > div:nth-child({(int)language})");
        }
        
        //page.locator('#GRID_CONTAINER').getByText('Euskara')
        #endregion

        public ChangeLanguageWidget(IPage page) {
            this.page = page;
        }
    }
}
