import { html } from "../../node_modules/lit-html/lit-html.js";
import { dashboardRequest } from "../api.js";

const productTemplate = (setData) => html`
<li class="card">
    <img src="${setData.imageUrl}" alt="travis" />
    <p>
        <strong>Brand: </strong><span class="brand">${setData.brand}</span>
    </p>
    <p>
        <strong>Model: </strong><span class="model">${setData.model}</span>
    </p>
    <p><strong>Value:</strong><span class="value">${setData.value}</span>$</p>
    <a class="details-btn" href="/details/${setData._id}">Details</a>
</li>`

const dashboardTemplate = (setData) => html`
<section id="dashboard">
    <h2>Collectibles</h2>
    <ul class="card-wrapper">
        ${setData.length != 0 
        ? html`${setData.map(x => productTemplate(x))}`
        : html`<h2>There are no items added yet.</h2>`}
    </ul>
</section>`

export const dashboardPage = (ctx) => {
    ctx.navBar();

    dashboardRequest()
        .then(x => {
            ctx.render(dashboardTemplate(x));
        })
}