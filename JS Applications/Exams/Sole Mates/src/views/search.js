import { html } from "../../node_modules/lit-html/lit-html.js";
import { searchRequest } from "../api.js";

const cardTemplate = (data,isLogged) => html`
<li class="card">
    <img src="${data.imageUrl}" alt="travis" />
    <p>
        <strong>Brand: </strong><span class="brand">${data.brand}</span>
    </p>
    <p>
        <strong>Model: </strong><span class="model">${data.model}</span>
    </p>
    <p><strong>Value:</strong><span class="value">${data.value}</span>$</p>
   ${isLogged ? html`<a class="details-btn" href="/details/${data._id}">Details</a>` : null} 
</li>`

const result = (data,takeInput,isLogged) => html`
<section id="search">
    <h2>Search by Brand</h2>

    <form @submit="${takeInput}" class="search-wrapper cf">
        <input id="#search-input" type="text" name="search" placeholder="Search here..." required />
        <button type="submit">Search</button>
    </form>

    <h3>Results:</h3>
    <div id="search-container">
       ${data != 0 
        ? html`<ul class="card-wrapper">
            ${data.map(x => cardTemplate(x,isLogged))}
        </ul>` 
       : html`<<h2>There are no results found.</h2>`}
    </div>
</section>`

const searchTemplate = (takeInput) => html`
<section id="search">
    <h2>Search by Brand</h2>

    <form @submit="${takeInput}" class="search-wrapper cf">
        <input id="#search-input" type="text" name="search" placeholder="Search here..." required />
        <button type="submit">Search</button>
    </form>

    <h3>Results:</h3>
</section>`

export const searchPage = (ctx) => {
    ctx.navBar();

    const takeData = (e) =>{
        e.preventDefault();
        const data = new FormData(e.target);
        const input = data.get('search');

        if (!input){
            alert("Empty fields");
            return;
        }

        searchRequest(input)
        .then(x => {
            const isLogged = sessionStorage.getItem('userId');
            ctx.render(result(x,takeData,isLogged));
        })
    }
    ctx.render(searchTemplate(takeData));
}