import { html } from "../../node_modules/lit-html/lit-html.js";
import { deleteRequest, detailsRequest, donationRequest } from "../api.js";


const detailsTemplate = (data,isOwner,onDelete,onDonate,isLogged,donated) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src="${data.image}">
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${data.name}</h1>
                <h3>Breed: ${data.breed}</h3>
                <h4>Age: ${data.age} years</h4>
                <h4>Weight: ${data.weight}kg</h4>
                <h4 class="donation">Donation: ${donated}$</h4>
            </div>
            <!-- if there is no registered user, do not display div-->
           ${isOwner ? html`<div class="actionBtn">
                <!-- Only for registered user and creator of the pets-->
                <a href="/edit/${data._id}" class="edit">Edit</a>
                <a @click="${onDelete}" href="javascript:void(0)" class="remove">Delete</a>
            </div>`: null}

            ${isLogged && !isOwner 
            ? html`<a @click="${onDonate}" href="javascript:void(0)" class="donate">Donate</a>`
            : null}
        </div>
    </div>
</section>`

export const detailsPage = (ctx) => {
    ctx.navBar();

    detailsRequest(ctx.params.id)
    .then(x => {
        const isOwner = sessionStorage.getItem('userId') == x._ownerId;
        const isLogged = sessionStorage.getItem('userId');

        const onDelete = () => {

            deleteRequest(ctx.params.id)
            .then(() => {
                done
                ctx.page.redirect('/');
            })
        }
        let donated = 0;
        const onDonate = () => {
            const body = {
                petId: ctx.params.id,
            }
  
            document.querySelector('.donate').style.display = 'none';
        }
        ctx.render(detailsTemplate(x,isOwner,onDelete,onDonate,isLogged,donated));
    })
}