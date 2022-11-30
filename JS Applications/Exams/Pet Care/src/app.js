import page from '../node_modules/page/page.mjs'
import { render } from '../node_modules/lit-html/lit-html.js'
import { registerPage } from './views/register.js';
import { loginPage } from './views/login.js';
import { logoutRequest } from './api.js';
import { homePage } from './views/home.js';
import { dashboardPage } from './views/dashboard.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';

const container = document.getElementById('content');

page(renderMiddleware);

page('/register',renderMiddleware,registerPage);
page('/login',renderMiddleware,loginPage);
page('/',renderMiddleware,homePage);
page('/dashboard',renderMiddleware,dashboardPage);
page('/create',renderMiddleware,createPage);
page('/details/:id',renderMiddleware,detailsPage);
page('/edit/:id',renderMiddleware,editPage);

page();

function renderMiddleware(ctx,next){
    ctx.render = (templateresult) => render(templateresult,container);
    ctx.navBar = navBar;

    next();
}

function navBar(){
    const logged = sessionStorage.getItem('userId');

    if (logged){
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'block';
    } else {
        document.getElementById('guest').style.display = 'block';
        document.getElementById('user').style.display = 'none';
    }
}

document.getElementById('logout').addEventListener('click', (e) => {
    e.preventDefault();
    logoutRequest()
    .then(() => {
        navBar();
        page.redirect('/');
    })
})