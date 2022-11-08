import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js'

import { homePage } from "./views/home.js";
import { registerPage } from './views/register.js';
import { loginPage } from './views/login.js';
import { browsePage } from './views/browseTeams.js';
import { logoutRequest } from './api.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';

const container = document.getElementById('container');

page(renderMiddleware)

page('/', renderMiddleware,homePage);
page('/register',renderMiddleware,registerPage)
page('/login',renderMiddleware,loginPage)
page('/browseTeams',renderMiddleware,browsePage)
page('/create',renderMiddleware,createPage)
page(`/details/:id`,renderMiddleware,detailsPage)

page();


function renderMiddleware(ctx,next){
    ctx.render = (templateResult) => render(templateResult,container);
    ctx.navBar = navBar;

    next();
}

export function navBar(){
    const userId = sessionStorage.getItem('userId');

    const logged = document.getElementById('logged');
    const guest = document.getElementById('guest');

    if (userId){
        logged.style.display = 'inline-block';
        guest.style.display = 'none';
    } else {
        logged.style.display = 'none';
        guest.style.display = 'inline-block';
    }
}

document.getElementById('logout').addEventListener('click',(e) => {
    e.preventDefault();
    logoutRequest()
    .then(x => {
        navBar();
        page.redirect('/');
    })
})