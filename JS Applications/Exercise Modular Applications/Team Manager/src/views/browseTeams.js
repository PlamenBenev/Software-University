import { html } from "../../node_modules/lit-html/lit-html.js";
import { browseRequest } from "../api.js";

const teamsTemplate = (data) => html`
<article class="layout">
        <img src="${data.logoUrl}" class="team-logo left-col">
        <div class="tm-preview">
            <h2>${data.name}</h2>
            <p>${data.description}</p>
            <span class="details">5000 Members</span>
            <div><a href="/details" class="action">See details</a></div>
        </div>
    </article>`

const browseTemplate = (isLogged,teams) => html`
<section id="browse">

    <article class="pad-med">
        <h1>Team Browser</h1>
    </article>

    ${isLogged
         ? html`<article class="layout narrow">
        <div class="pad-small"><a href="/create" class="action cta">Create Team</a></div>
    </article>`
        : null}

${teams.map(x => teamsTemplate(x))}
</section>`

export const browsePage = (ctx) => {
    ctx.navBar();
    
    browseRequest()
    .then(x => {
        const isLogged = sessionStorage.getItem('userId') != ctx._id;
        console.log(x);
        ctx.render(browseTemplate(isLogged,x));
    })
}