import { html } from "../../node_modules/lit-html/lit-html.js";
import { detailsRequest, editRequest } from "../api.js";

const editTemplate = (setData,takeData) => html`
<section id="edit">
    <div class="form">
        <h2>Edit item</h2>
        <form @submit="${takeData}" class="edit-form">
            <input type="text" name="brand" id="shoe-brand" placeholder="Brand" value="${setData.brand}" />
            <input type="text" name="model" id="shoe-model" placeholder="Model" value="${setData.model}" />
            <input type="text" name="imageUrl" id="shoe-img" placeholder="Image url" value="${setData.imageUrl}"/>
            <input type="text" name="release" id="shoe-release" placeholder="Release date" value="${setData.release}" />
            <input type="text" name="designer" id="shoe-designer" placeholder="Designer" value="${setData.designer}" />
            <input type="text" name="value" id="shoe-value" placeholder="Value" value="${setData.value}" />

            <button type="submit">post</button>
        </form>
    </div>
</section>`

export const editPage = (ctx) => {
    ctx.navBar();

    detailsRequest(ctx.params.id)
    .then(x => {
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
    
            editRequest(body,ctx.params.id)
            .then(() => {
                ctx.page.redirect(`/details/${ctx.params.id}`);
            })
        }
        
        ctx.render(editTemplate(x,takeData))
    });
}