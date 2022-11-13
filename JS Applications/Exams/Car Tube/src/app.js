import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";

import { logoutRequest } from "./api.js";
import { registerPage } from "./views/register.js";
import { loginPage } from "./views/login.js";
import { homePage } from "./views/home.js";
import { allListingsPage } from "./views/allListings.js";
import { createPage } from "./views/create.js";

const container = document.getElementById('site-content');

function navBar(){
    const userId = sessionStorage.getItem('userId');

    if (userId){
        document.getElementById('guest').style.display = 'none';
        document.getElementById('profile').style.display = 'inline';
    } else {
        document.getElementById('guest').style.display = 'inline';
        document.getElementById('profile').style.display = 'none';
    }
}
page(renderMiddleware);

page('/register',renderMiddleware,registerPage);
page('/login',renderMiddleware,loginPage);
page('/',renderMiddleware,homePage);
page('/allListings',renderMiddleware,allListingsPage);
page('/create',renderMiddleware,createPage)

page();


function renderMiddleware(ctx,next){
    ctx.render = (templateResult) => render(templateResult,container);
    ctx.navBar = navBar;

    next();
}

document.getElementById('logout').addEventListener('click',(e)=>{
    e.preventDefault();
    logoutRequest()
    .then(x => {
        navBar();
        page.redirect('/');
    })
    
})