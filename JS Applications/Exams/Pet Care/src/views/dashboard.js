import { html } from "../../node_modules/lit-html/lit-html.js";
import { dashboardRequest } from "../api.js";

const animalTemplate = (data) => html`
<div class="animals-board">
    <article class="service-img">
        <img class="animal-image-cover" src="${data.image}">
    </article>
    <h2 class="name">${data.name}</h2>
    <h3 class="breed">${data.breed}</h3>
    <div class="action">
        <a class="btn" href="/details/${data._id}">Details</a>
    </div>
</div>`

const dashboardTemplate = (data) => html`
<section id="dashboard">
    <h2 class="dashboard-title">Services for every animal</h2>
    <div class="animals-dashboard">

        ${data.length != 0 
        ? html`${data.map(x => animalTemplate(x))}`
        : html`<div>
            <p class="no-pets">No pets in dashboard</p>
        </div>`}
        <!--If there is no pets in dashboard-->
    </div>
</section>
` 

export const dashboardPage = (ctx) => {
    ctx.navBar();

    dashboardRequest()
    .then(x => {
        ctx.render(dashboardTemplate(x));
    })
}