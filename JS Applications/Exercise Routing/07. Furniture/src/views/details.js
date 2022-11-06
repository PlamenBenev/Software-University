import { html } from '../../node_modules/lit-html/lit-html.js';
import * as api from '../api/api.js';

const detailsTemplate = (details,onDelete, isOwner) => html`
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="../${details.img}" />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${details.make}</span></p>
        <p>Model: <span>${details.model}</span></p>
        <p>Year: <span>${details.year}</span></p>
        <p>Description: <span>${details.description}</span></p>
        <p>Price: <span>${details.price}</span></p>
        <p>Material: <span>${details.material}</span></p>
        <div>
            ${isOwner ? html`
            <a href="/edit/${details._id}" class="btn btn-info">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="btn btn-red">Delete</a> 
        </div>` : null}
    </div>
</div>`

export const detailsPage = (ctx) => {
    ctx.setUserNav();

    api.detailsRequest(ctx.params.id)
    .then(x => {
        const isOwner = sessionStorage.getItem('userId') == x._ownerId;

            ctx.render(detailsTemplate(x,onDelete,isOwner));
            function onDelete(){
                const confirmed = confirm('Are you sure you want to delete this item?');
    
                if (confirmed){
                    api.deleteRequest(ctx.params.id)
                    .then(x => {
                        ctx.page.redirect('/')
                    });
                }
            }
    })
   // ctx.render(detailsTemplate(api.detailsRequest()))
}