import { html } from "../../node_modules/lit-html/lit-html.js";
import { createRequest } from "../api.js";

const createTemplate = (takeData) => html`
<section id="create">
    <div class="form">
        <h2>Add item</h2>
        <form @submit="${takeData}" class="create-form">
            <input type="text" name="brand" id="shoe-brand" placeholder="Brand" />
            <input type="text" name="model" id="shoe-model" placeholder="Model" />
            <input type="text" name="imageUrl" id="shoe-img" placeholder="Image url" />
            <input type="text" name="release" id="shoe-release" placeholder="Release date" />
            <input type="text" name="designer" id="shoe-designer" placeholder="Designer" />
            <input type="text" name="value" id="shoe-value" placeholder="Value" />

            <button type="submit">post</button>
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
        const imageUrl = data.get('imageUrl');
        const release = data.get('release');
        const designer = data.get('designer');
        const value = data.get('value');

        if (!brand || !model || !imageUrl || !release || !designer || !value){
            alert("empty fields");
            return;
        }

        const body = {
            brand: brand,
            model: model,
            imageUrl: imageUrl,
            release: release,
            designer: designer,
            value: value
        }

        createRequest(body)
        .then(() => {
            ctx.page.redirect('/dashboard')
        })
    }
    ctx.render(createTemplate(takeData));
}