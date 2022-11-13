import { html } from "../../node_modules/lit-html/lit-html.js";
import { deleteRequest, detailsRequest } from "../api.js";


const detailsTemplate = (data,isOwner,onDelete) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${data.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${data.brand}</li>
            <li><span>Model:</span>${data.model}</li>
            <li><span>Year:</span>${data.year}</li>
            <li><span>Price:</span>${data.price}$</li>
        </ul>

        <p class="description-para">${data.description}</p>

       ${isOwner ? html`<div class="listings-buttons">
            <a href="/edit/${data._id}" class="button-list">Edit</a>
            <a @click="${onDelete}" href="javascript:void(0)" class="button-list">Delete</a>
        </div>` : null}
    </div>
</section>`

export const detailsPage = (ctx) =>{
    ctx.navBar();

    detailsRequest(ctx.params.id)
    .then(x => {
        const onDelete = (e) =>{
            e.preventDefault();

            deleteRequest(x._id)
            .then(d => {
                ctx.page.redirect('/allListings');
            })
        }

        const isOwner = sessionStorage.getItem('userId') == x._ownerId
        ctx.render(detailsTemplate(x,isOwner,onDelete));
    })
} 