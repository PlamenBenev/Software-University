import { html } from "../../node_modules/lit-html/lit-html.js";
import { allListingsRequest } from "../api.js";

const recordTemplate = (data) => html`
<!-- Display all records -->
<div class="listing">
    <div class="preview">
        <img src="${data.imageUrl}">
    </div>
    <h2>${data.make}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${data.year}</h3>
            <h3>Price: ${data.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`

const allListingsTemplate = (data) => html`
<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">

        ${data.length != 0 
        ? html`${data.map(x => recordTemplate(x))}`
        : html`<p class="no-cars">No cars in database.</p>`}
    </div>
</section>`

export const allListingsPage = (ctx) => {
    ctx.navBar();

    allListingsRequest()
    .then(data => {
        ctx.render(allListingsTemplate(data));
    })
}