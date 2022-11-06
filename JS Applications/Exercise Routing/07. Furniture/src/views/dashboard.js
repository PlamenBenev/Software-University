import { html } from '../../node_modules/lit-html/lit-html.js';
import { dashboardRequest } from '../api/api.js';

const catalogTemplate = (objects) => html`
<div class="card text-white bg-primary">
    <div class="card-body">
        <img src="${objects.img}" />
        <p>${objects.description}</p>
        <footer>
            <p>Price: <span>${objects.price} $</span></p>
        </footer>
        <div>
            <a href="/details/${objects._id}" class="btn btn-info">Details</a>
        </div>
    </div>
</div>
</div>`

const dashboardTemplate = (catalog) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
    </div>
</div>
<section class="row space-top">
    ${catalog.map(x => catalogTemplate(x))}
</section>`;

export const dashboardPage = (ctx) => {
    ctx.setUserNav();

    dashboardRequest()
    .then(x => {
        ctx.render(dashboardTemplate(x));
    }).then(x => ctx.setUserNav())

}
