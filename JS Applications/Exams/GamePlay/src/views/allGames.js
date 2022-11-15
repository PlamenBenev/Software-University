import { html } from '../../node_modules/lit-html/lit-html.js';
import { allGamesRequest } from '../api.js';

const gameTemplate = (data) => html`
    <div class="allGames">
        <div class="allGames-info">
            <img src="${data.imageUrl}">
            <h6>${data.category}</h6>
            <h2>${data.title}</h2>
            <a href="/details/${data._id}" class="details-button">Details</a>
        </div>
    
    </div>`

const allGamesTemplate = (data) => html`
<section id="catalog-page">
    <h1>All Games</h1>

    <!-- Display div: with information about every game (if any) -->
    ${data.length != 0 
    ? data.map(x => gameTemplate(x))
    : html`<h3 class="no-articles">No articles yet</h3>`}
    <!-- Display paragraph: If there is no games  -->
</section>`

export const allGamesPage = (ctx) => {
    ctx.navBar();

    allGamesRequest()
    .then(x => {
        ctx.render(allGamesTemplate(x));
    })

}