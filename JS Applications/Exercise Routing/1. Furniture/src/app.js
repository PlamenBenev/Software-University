import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

import { registerPage } from "./views/register.js";
import { loginPage } from "./views/login.js";
import { dashboardPage } from './views/dashboard.js';
import { createPage } from './views/createFurniture.js';
import { myPublicationsPage } from './views/MyPublications.js'
import { detailsPage } from './views/details.js';
import { logoutRequest } from './api/api.js';
import { editPage } from './views/edit.js';

const container = document.querySelector('.container');
// const ctxRender = (templateResult) => render(templateResult, container)

export function setUserNav() {
    const userId = sessionStorage.getItem('userId');

    if (userId != null) {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'inline-block';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}
page(renderMiddleware);

page('/register', renderMiddleware, registerPage);
page('/login', renderMiddleware, loginPage);
page('/', renderMiddleware, dashboardPage);
page('/create', renderMiddleware, createPage);
page('/myPublications', renderMiddleware, myPublicationsPage);
page(`/details/:id`,renderMiddleware, detailsPage)
page(`/edit/:id`,renderMiddleware, editPage)


page.start();


function renderMiddleware(ctx, next) {
    ctx.setUserNav = setUserNav;
    ctx.render = (templateResult) => render(templateResult, container);

    next();
}

document.getElementById('logoutBtn').addEventListener('click', async (e) => {
    e.preventDefault();
    logoutRequest()
    .then(x => {
        setUserNav();
        page.redirect('/dashboard');
    });
})