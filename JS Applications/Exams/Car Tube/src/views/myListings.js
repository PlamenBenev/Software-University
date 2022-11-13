import { html } from "../../node_modules/lit-html/lit-html.js";
import { myListingsRequest } from "../api.js";

const recordTemplate = (data) => html`
<div class="listing">
    <div class="preview">
        <img src="${data.imageUrl}">
    </div>
    <h2>${data.brand} ${data.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${data.year}</h3>
            <h3>Price: ${data.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${data._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`

const myListingsTemplate = (data) => html`
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">

        <!-- Display all records -->
        <!-- Display if there are no records -->
        ${data.length != 0 
        ? html`${data.map(x => recordTemplate(x))}`
        : html`<p class="no-cars"> You haven't listed any cars yet.</p>`}
    </div>
</section>`

export const myListingsPage = (ctx) => {
    ctx.navBar();

    const userId = sessionStorage.getItem('userId');
    myListingsRequest(userId)
        .then(data => {
                ctx.render(myListingsTemplate(data));
        })
}