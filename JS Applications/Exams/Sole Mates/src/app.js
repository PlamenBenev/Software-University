import page from "../node_modules/page/page.mjs";
import {render} from "../node_modules/lit-html/lit-html.js"
import { registerPage } from "./views/register.js";
import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { logoutRequest } from "./api.js";
import { dashboardPage } from "./views/dashboard.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { searchPage } from "./views/search.js";

const container = document.getElementById('container');

page(renderMiddleware);

page('/',renderMiddleware,homePage)
page('/register',renderMiddleware,registerPage);
page('/login',renderMiddleware,loginPage);
page('/dashboard',renderMiddleware,dashboardPage);
page('/create',renderMiddleware,createPage);
page(`/details/:id`,renderMiddleware,detailsPage);
page(`/edit/:id`,renderMiddleware,editPage);
page('/search',renderMiddleware,searchPage);

page();

function renderMiddleware(ctx,next){
    ctx.render = (templateResult) => render(templateResult,container);
    ctx.navBar = navBar;

    next();
}

function navBar(){
    const logged = sessionStorage.getItem('userId');

    if (logged){
        document.querySelector('.user').style.display = 'inline';
        document.querySelector('.guest').style.display = 'none';
    } else {
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = 'inline';
    }
}

document.getElementById('logout').addEventListener('click' , (e) => {
    e.preventDefault();

    logoutRequest()
    .then(() => {
        navBar();
        page.redirect('/dashboard');
    })
});