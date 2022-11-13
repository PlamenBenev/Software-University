import { html } from "../../node_modules/lit-html/lit-html.js";
import { detailsRequest, editRequest } from "../api.js";

const editTemplate = (takeData,oldData) => html`
<section id="edit-listing">
    <div class="container">

        <form @submit="${takeData}" id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" value="${oldData.brand}">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" value="${oldData.model}">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" value="${oldData.description}">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" value="${oldData.year}">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" value="${oldData.imageUrl}">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" value="${oldData.price}">

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>`

export const editPage = (ctx) => {
    ctx.navBar();

    const takeData = (e) =>{
        e.preventDefault();
        const data = new FormData(e.target);
        const brand = data.get('brand');
        const model = data.get('model');
        const description = data.get('description');
        const year = Number(data.get('year'));
        const imageUrl = data.get('imageUrl');
        const price = Number(data.get('price'));

        if (!brand || !model || !description || !year || !imageUrl || !price){
            alert('Empty fields');
            return;
        }
        if (year < 0 || price < 0){
            alert('Negative numbers');
            return;
        }

        const body = {
            brand: brand,
            model: model,
            description: description,
            year: year,
            imageUrl: imageUrl,
            price: price
        }

        editRequest(ctx.params.id,body)
        .then(x => {
            ctx.page.redirect('/allListings');
        })
    }
    detailsRequest(ctx.params.id)
    .then(x => {
        ctx.render(editTemplate(takeData,x));

    })
}