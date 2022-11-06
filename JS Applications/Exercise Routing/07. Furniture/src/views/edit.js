import { html } from '../../node_modules/lit-html/lit-html.js';
import * as api from '../api/api.js';

const editTemplate = (data, submit) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Edit Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit="${submit}">
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class="form-control" id="new-make" type="text" name="make" value="${data.make}">
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class="form-control is-valid" id="new-model" type="text" name="model" value="${data.model}">
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class="form-control is-invalid" id="new-year" type="number" name="year" value="${data.year}">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class="form-control" id="new-description" type="text" name="description"
                    value="${data.description}">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class="form-control" id="new-price" type="number" name="price" value="${data.price}">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class="form-control" id="new-image" type="text" name="img" value="${data.image}">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material" value="${data.material}">
            </div>
            <input type="submit" class="btn btn-info" value="Edit" />
        </div>
    </div>
</form>`

export const editPage = (ctx) => {
    ctx.setUserNav();

    api.detailsRequest(ctx.params.id)
        .then(x => {
            ctx.render(editTemplate(x, submit))
        })

    const submit = (e) => {
        e.preventDefault();

        const data = new FormData(e.target);

        const make = data.get('make');
        const model = data.get('model');
        const year = data.get('year');
        const description = data.get('description');
        const price = data.get('price');
        const img = data.get('img');
        const material = data.get('material');

        const body = {
            make: make,
            model: model,
            year: year,
            description: description,
            price: price,
            img: img,
            material: material,
        }

        api.editRequest(ctx.params.id, body)
            .then(x => {
                //  e.target.reset();
                ctx.page.redirect('/')
            })


    }
    //ctx.render(editTemplate(submit));

}

