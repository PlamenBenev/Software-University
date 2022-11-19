import { html } from "../../node_modules/lit-html/lit-html.js";
import { detailsRequest } from "../api.js";


const detailsTemplate = (data,isLogged) => html`
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
                <h4 class="donation">Donation: 0$</h4>
            </div>
            <!-- if there is no registered user, do not display div-->
           ${isLogged ? html`<div class="actionBtn">
                <!-- Only for registered user and creator of the pets-->
                <a href="/edit/${data._id}" class="edit">Edit</a>
                <a href="javascript:void(0)" class="remove">Delete</a>
                <!--(Bonus Part) Only for no creator and user-->
                <a href="/donate" class="donate">Donate</a>
            </div>`
            : null} 
        </div>
    </div>
</section>`

export const detailsPage = (ctx) => {
    ctx.navBar();

    detailsRequest(ctx.params.id)
    .then(x => {
        const isLogged = sessionStorage.getItem('userId') == x._id;

        ctx.render(detailsTemplate(x,isLogged));
    })
}