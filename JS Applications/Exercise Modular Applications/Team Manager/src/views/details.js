import { html } from "../../node_modules/lit-html/lit-html.js";
import { requestForSingleTeam } from "../api.js";


const detailsTemplate = (state, data) => html`
<section id="team-home">
    <article class="layout">
        <img src="./assets/rocket.png" class="team-logo left-col">
        <div class="tm-preview">
            <h2>Team Rocket</h2>
            <p>Gotta catch 'em all!</p>
            <span class="details">3 Members</span>
            <div>
                ${state == 'isOwner' ? html`<a href="#" class="action">Edit team</a>` : null}
                ${state == 'notMember' ? html`<a href="#" class="action">Join team</a>` : null}
                ${state == 'isMember' ? html`<a href="#" class="action invert">Leave team</a>` : null}
                ${state == 'pending' ? html`Membership pending. <a href="#">Cancel request</a>` : null}
            </div>
        </div>
        <div class="pad-large">
            <h3>Members</h3>
            <ul class="tm-members">
                <li>My Username</li>
                ${data.map(x => membersTemplate(x, true))}
            </ul>
        </div>
        <div class="pad-large">
            <h3>Membership Requests</h3>
            <ul class="tm-members">
                <li>John<a href="#" class="tm-control action">Approve</a><a href="#"
                        class="tm-control action">Decline</a></li>
                <li>Preya<a href="#" class="tm-control action">Approve</a><a href="#"
                        class="tm-control action">Decline</a></li>
            </ul>
        </div>
</section>`

const membersTemplate = (data, isOwner) => html`
<li>${data.username} ${isOwner ? html`<a href="#" class="tm-control action">Remove from team</a>` : null}</li>`

const requestsTemplate = (data, isOwner) =>
    html`<li>${data.username} ${isOwner ? html`<a href="#" class="tm-control action">Approve</a><a href="#"
        class="tm-control action">Decline</a>`
    : null}</li>`


export const detailsPage = (ctx) => {
    ctx.navBar();
    requestForSingleTeam(ctx.id)
        .then(x => {
            let state = 'isOwner';
            ctx.render(detailsTemplate(state, x))
        })
}