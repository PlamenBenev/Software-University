import { html } from '../../node_modules/lit-html/lit-html.js';
import { dashboardRequest } from '../api.js';

const offerTemplate = (setData) => html`
 <div class="offer">
        <img src="${setData.imageUrl}" alt="example1" />
        <p>
            <strong>Title: </strong><span class="title">${setData.title}</span>
        </p>
        <p><strong>Salary:</strong><span class="salary">${setData.salary}</span></p>
        <a class="details-btn" href="/details/${setData._id}">Details</a>
    </div>`;

const dashboardTemplate = (setData) => html`
<section id="dashboard">
    <h2>Job Offers</h2>

    ${setData.length != 0
    ? html`${setData.map(x => offerTemplate(x))}` 
    : html`<h2>No offers yet.</h2>`}
</section>`

export const dashboardPage = (ctx) => {
    ctx.navBar();

    dashboardRequest()
    .then(x => {
        ctx.render(dashboardTemplate(x));
    });
}