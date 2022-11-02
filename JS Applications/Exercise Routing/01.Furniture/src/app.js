import * as api from './api/data.js';
import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

import { registerPage } from "./views/register.js";
import { loginPage } from "./views/login.js";
import { dashboardPage } from './views/dashboard.js';
import { createPage } from './views/createFurniture.js';
import { myPublicationsPage } from './views/MyPublications.js'

const container = document.querySelector('.container');
const ctxRender = (templateResult) => render(templateResult, container)

page(renderMiddleware);

page('/register', renderMiddleware, registerPage);
page('/login', renderMiddleware, loginPage);
page('/dashboard', renderMiddleware, dashboardPage);
page('/create', renderMiddleware, createPage);
page('/myPublications', renderMiddleware, myPublicationsPage);

page.start();

function renderMiddleware(ctx, next) {
    ctx.render = ctxRender;

    next();
}

export function setUserNav() {
    const userId = sessionStorage.getItem('userId');

    if (userId) {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'inline-block';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}