import { html } from "../../node_modules/lit-html/lit-html.js";
import { createRequest } from "../api.js";


const createTemplate = (errMessage,takeData) => html`
<section id="create">
    <article class="narrow">
        <header class="pad-med">
            <h1>New Team</h1>
        </header>
        <form @submit="${takeData}" id="create-form" class="main-form pad-large">
            <div class="error">${errMessage}</div>
            <label>Team name: <input type="text" name="name"></label>
            <label>Logo URL: <input type="text" name="logoUrl"></label>
            <label>Description: <textarea name="description"></textarea></label>
            <input class="action cta" type="submit" value="Create Team">
        </form>
    </article>
</section>`

export const createPage = (ctx) => {
    ctx.navBar();

    let msg = '';
    const takenData = (e) =>{
        e.preventDefault();

        const data = new FormData(e.target);
        const name = data.get('name');
        const logoUrl = data.get('logoUrl');
        const description = data.get('description');

        if (!name || !logoUrl || !description){
            msg = 'Empty fields';
            ctx.render(createTemplate(msg));
            return;
        }

        const body = {
            name: name,
            logoUrl: logoUrl,
            description: description
        }

        createRequest(body)
        .then(x =>{
            ctx.page.redirect('/')
        })
    } 
    ctx.render(createTemplate(msg,takenData));
}