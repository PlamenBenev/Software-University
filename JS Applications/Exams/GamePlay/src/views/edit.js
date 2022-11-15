import { html } from '../../node_modules/lit-html/lit-html.js';
import { detailsRequest, editRequest } from '../api.js';


const editTemplate = (setData, takeData) => html`
<section id="edit-page" class="auth">
    <form @submit="${takeData}" id="edit">
        <div class="container">

            <h1>Edit Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" value="${setData.title}">

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" value="${setData.category}">

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" value="${setData.maxLevel}">

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" value="${setData.imageUrl}">

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary">${setData.summary}</textarea>
            <input class="btn submit" type="submit" value="Edit Game">

        </div>
    </form>
</section>`

export const editPage = (ctx) => {
    ctx.navBar();

    detailsRequest(ctx.params.id)
    .then(gameDetails => {
        ctx.render(editTemplate(gameDetails));
        const takeData = (e) =>{
            e.preventDefault();
            const data = new FormData(e.target);
            const title = data.get('title');
            const category = data.get('category');
            const maxLevel = data.get('maxLevel');
            const imageUrl = data.get('imageUrl');
            const summary = data.get('summary');
            
            if (!title || !category || !maxLevel || !imageUrl || !summary){
                alert('Empty fields');
                return;
            }
            
            const body = {
                title: title,
                category: category,
                maxLevel: maxLevel,
                imageUrl: imageUrl,
                summary: summary
            }
            editRequest(body,ctx.params.id)
            .then(x => {
                ctx.page.redirect('/allGames');
            })
        }
        
        ctx.render(editTemplate(gameDetails,takeData));
    })
}