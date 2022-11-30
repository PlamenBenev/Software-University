import { html } from "../../node_modules/lit-html/lit-html.js";
import { deleteRequest, detailsRequest } from "../api.js";


const detailsTemplate = (setData, isOwner,onDelete) => html`
<section id="details">
    <div id="details-wrapper">
        <p id="details-title">Shoe Details</p>
        <div id="img-wrapper">
            <img src="${setData.imageUrl}" alt="example1" />
        </div>
        <div id="info-wrapper">
            <p>Brand: <span id="details-brand">${setData.brand}</span></p>
            <p>
                Model: <span id="details-model">${setData.model}</span>
            </p>
            <p>Release date: <span id="details-release">${setData.release}</span></p>
            <p>Designer: <span id="details-designer">${setData.designer}</span></p>
            <p>Value: <span id="details-value">${setData.value}</span></p>
        </div>
        ${isOwner ? html`<div id="action-buttons">
            <a href="/edit/${setData._id}" id="edit-btn">Edit</a>
            <a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>`
        : null}
        </div>
    </div>
</section>`

export const detailsPage = (ctx) => {
    ctx.navBar();

    detailsRequest(ctx.params.id)
    .then(x => {
        console.log(x);
        const isOwner = sessionStorage.getItem('userId') == x._ownerId;

        function onDelete(){
           const confirmed = confirm("you sure ?")

           if (confirmed){
               deleteRequest(ctx.params.id)
               .then(() => {
                   ctx.page.redirect("/dashboard");
               })   
           }
        }

        ctx.render(detailsTemplate(x,isOwner,onDelete));
    })
}