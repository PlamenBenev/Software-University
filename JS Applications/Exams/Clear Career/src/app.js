import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';
import { homePage } from './views/home.js';
import { registerPage } from './views/register.js';
import { logoutRequest } from './api.js';
import { loginPage } from './views/login.js';
import { dashboardPage } from './views/dashboard.js';
import { detailsPage } from './views/details.js';
import { createPage } from './views/create.js';
import { editPage } from './views/edit.js';

const container = document.getElementById('container');

page(renderMiddleware);

page('/', renderMiddleware, homePage);
page('/register',renderMiddleware,registerPage);
page('/login',renderMiddleware,loginPage);
page('/dashboard',renderMiddleware,dashboardPage);
page('/details/:id',renderMiddleware,detailsPage);
page('/create',renderMiddleware,createPage);
page('/edit/:id',renderMiddleware,editPage);

page();

function renderMiddleware(ctx, next) {
    ctx.render = (templateResult) => render(templateResult, container);
    ctx.navBar = navBar;

    next();
}

export function navBar() {
    const userId = sessionStorage.getItem('userId');

    const guest = document.querySelector('.guest');
    const logged = document.querySelector('.user');

    
    if (userId != null) {
        logged.style.display = 'inline';
        guest.style.display = 'none';
    } else {
        logged.style.display = 'none';
        guest.style.display = 'inline';
    }
}

document.getElementById('logout').addEventListener('click',(e) => {
    e.preventDefault();
    logoutRequest()
    .then(() => {
        page.redirect('/');
        navBar();
    })
});
