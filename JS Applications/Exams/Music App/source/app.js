import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";
import { homePage } from "./views/home.js";
import { registerPage } from "./views/register.js";
import { loginPage } from "./views/login.js";
import { logoutRequest } from "./api.js";
import { catalogPage } from "./views/catalog.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { searchPage } from "./views/search.js";

const container = document.getElementById('main-content')

export function userNavBar(){
    const userId = sessionStorage.getItem('userId');

    if (!userId){
        document.getElementById('guest').style.display = 'inline';
        document.getElementById('user').style.display = 'none';
    } else {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'inline';
    }
}

page(renderMiddleware);

page('/',renderMiddleware,homePage);
page('/register',renderMiddleware,registerPage);
page('/login',renderMiddleware,loginPage);
page('/catalog',renderMiddleware,catalogPage);
page('/createAlbum',renderMiddleware,createPage);
page(`/details/:id`,renderMiddleware,detailsPage);
page(`/edit/:id`,renderMiddleware,editPage);
page('/search',renderMiddleware,searchPage);

page();

function renderMiddleware(ctx,next){
    ctx.userNavBar = userNavBar;
    ctx.render = (templateResult) => render(templateResult,container);

    next();
}

document.getElementById('logout').addEventListener('click',(e)=>{
    e.preventDefault();
    logoutRequest()
    .then(x => {
        userNavBar();
        page.redirect('/')
    })
})