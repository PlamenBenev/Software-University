import { html } from "../../node_modules/lit-html/lit-html.js";
import { createRequest } from "../api.js";

const createTemplate = (takeData) => html`
<section id="create-listing">
    <div class="container">
        <form @submit="${takeData}" id="create-form">
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>
</section>`

export const createPage = (ctx) => {
    ctx.navBar();
    const takeData = (e) => {
        e.preventDefault();
        const data = new FormData(e.target);
        const brand = data.get('brand');
        const model = data.get('model');
        const description = data.get('description');
        const year = data.get('year');
        const imageUrl = data.get('imageUrl');
        const price = data.get('price');

        const body = {
            brand: brand,
            model: model,
            description: description,
            year: year,
            imageUrl: imageUrl,
            price: price
        }

        createRequest(body)
        .then(x => {
            ctx.page.redirect('/allListings');
        })
    }
    ctx.render(createTemplate(takeData));
}