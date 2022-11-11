import { html } from "../../node_modules/lit-html/lit-html.js";
import { listOfAlbumsRequest } from "../api.js";


const catalog = (data) => html`
<div class="card-box">
    <img src="${data.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${data.name}</p>
            <p class="artist">Artist: ${data.artist}</p>
            <p class="genre">Genre: ${data.genre}</p>
            <p class="price">Price: $${data.price}</p>
            <p class="date">Release Date: ${data.date}</p>
        </div>
        <div class="btn-group">
            <a href="/details/${data._id}" id="details">Details</a>
        </div>
    </div>
</div>`

const catalogTemplate = (data) => html`
<section id="catalogPage">
    <h1>All Albums</h1>
    ${data.map(x => catalog(x))}
    <!--No albums in catalog-->
    ${data.length == 0 ? html`<p>No Albums in Catalog!</p>` : null}

</section>`

export const catalogPage = (ctx) => {
    ctx.userNavBar();

    listOfAlbumsRequest()
        .then(x => {
            ctx.render(catalogTemplate(x));
        })
}