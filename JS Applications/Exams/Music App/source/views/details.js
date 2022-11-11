import { html } from "../../node_modules/lit-html/lit-html.js";
import { deleteRequest, detailsRequest } from "../api.js";


const detailsTemplate = (data,isOwner,onDelete) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src="${data.imgUrl}">
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${data.name}</h1>
                <h3>Artist: ${data.artist}</h3>
                <h4>Genre: ${data.genre}</h4>
                <h4>Price: $${data.price}</h4>
                <h4>Date: ${data.date}</h4>
                <p>Description: ${data.description}</p>
            </div>

            <!-- Only for registered user and creator of the album-->
           ${isOwner ? html`<div class="actionBtn">
                <a href="/edit/${data._id}" class="edit">Edit</a>
                <a @click="${onDelete}" href="javascript:void(0)" class="remove">Delete</a>
            </div>` : null}
        </div>
    </div>
</section>`

export const detailsPage = (ctx) => {
    ctx.userNavBar();

    detailsRequest(ctx.params.id)
    .then(x => {
        function onDelete(){
            const confirmed = confirm('Are you sure you want to delete this album?');
        
            if (confirmed){
                deleteRequest(ctx.params.id)
                .then(x => {
                    ctx.page.redirect('/catalog');
                })
            }
        }
        
        const isOwner = sessionStorage.getItem('userId') == x._ownerId;
        ctx.render(detailsTemplate(x,isOwner,onDelete));
    })
}
