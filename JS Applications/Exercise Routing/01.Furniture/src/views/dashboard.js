import {html } from '../../node_modules/lit-html/lit-html.js';
import { dashboardRequest } from '../api/api.js';

const dashboardTemplate = (img,description,price) => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>Welcome to Furniture System</h1>
                <p>Select furniture from the catalog to view details.</p>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                            <img src="${img}" />
                            <p>${description}</p>
                            <footer>
                                <p>Price: <span>${price} $</span></p>
                            </footer>
                            <div>
                                <a href=”#” class="btn btn-info">Details</a>
                            </div>
                    </div>
                </div>
            </div>
        </div>`;

export const dashboardPage = (ctx) => {
    dashboardRequest().then(x => {
        console.log(x);
        ctx.render(dashboardTemplate(x.img,x.description,x.price));
    })
    ctx.setUserNav();
}
