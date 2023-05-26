import page from "../node_modules/page/page.mjs";
import { navigationMiddleware } from "./middlewares/navigationMiddleware.js";
import { renderMiddleware } from "./middlewares/renderMiddleware.js";
import { statusMiddleware } from "./middlewares/statusMiddleware.js";
import { logout } from "./views/logout.js";
import { renderHome } from "./views/renderHome.js";
import { renderLogin } from "./views/renderLogin.js";
import { renderRegister } from "./views/renderRegister.js";
import { renderAbout } from "./views/renderAbout.js";


page(statusMiddleware);
page(navigationMiddleware);
page(renderMiddleware);
page("/", renderHome);
page("/login", renderLogin);
page("/register", renderRegister);
page("/logout", logout);
page("/about", renderAbout);


page.redirect("/login");
page.start();
