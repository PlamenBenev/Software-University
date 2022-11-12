import { html } from "../../node_modules/lit-html/lit-html.js";
import { listOfAlbumsRequest } from "../api.js";

const catalog = (data,isLogged) => html`
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
            ${isLogged ? html`<a href="/details/${data._id}" id="details">Details</a>`:null}
        </div>

    </div>
</div>`

const catalogTemplate = (data,isLogged) => html`
<section id="catalogPage">
    <h1>All Albums</h1>
    ${data.map(x => catalog(x,isLogged))}
    <!--No albums in catalog-->
    ${data.length == 0 ? html`<p>No Albums in Catalog!</p>` : null}

</section>`

export const catalogPage = (ctx) => {
    ctx.userNavBar();

    listOfAlbumsRequest()
        .then(x => {
            const isLogged = sessionStorage.getItem('authToken') != null;
            ctx.render(catalogTemplate(x,isLogged));
        })
}