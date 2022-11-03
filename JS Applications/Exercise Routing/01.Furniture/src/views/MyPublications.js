import { html } from '../../node_modules/lit-html/lit-html.js';
import { myPublicationsRequest } from '../api/api.js';

const myPublicationTemplate = (img,description,price) => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
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
                                <a href="#" class="btn btn-info">Details</a>
                            </div>
                    </div>
                </div>
            </div>
        </div>`;

export const myPublicationsPage = (ctx) => {
    myPublicationsRequest();
  //  ctx.render(myPublicationTemplate(img,description,price));
}