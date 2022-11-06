import { html } from '../../node_modules/lit-html/lit-html.js';
import { myPublicationsRequest } from '../api/api.js';

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

const myPublicationTemplate = (catalog) => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
            </div>
        </div>
        <div class="row space-top">
            ${catalog.map(x => catalogTemplate(x))}
        </div>`;

export const myPublicationsPage = (ctx) => {
    
    myPublicationsRequest()
    .then(x => {
        ctx.render(myPublicationTemplate(x));
    }).then(x => ctx.setUserNav())
}