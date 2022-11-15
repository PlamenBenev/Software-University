import { html } from '../../node_modules/lit-html/lit-html.js';
import { createRequest } from '../api.js';

const createTemplate = (takeData) => html`
<section id="create-page" class="auth">
    <form @submit="${takeData}" id="create">
        <div class="container">

            <h1>Create Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" placeholder="Enter game title...">

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" placeholder="Enter game category...">

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" placeholder="1">

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo...">

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary"></textarea>
            <input class="btn submit" type="submit" value="Create Game">
        </div>
    </form>
</section>`

export const createPage = (ctx) => {
    ctx.navBar();

    const takeData = (e) => {
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
        createRequest(body)
        .then(x => {
            ctx.page.redirect('/allGames');
        })
    }
        ctx.render(createTemplate(takeData));
}