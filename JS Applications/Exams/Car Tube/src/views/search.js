import { html } from "../../node_modules/lit-html/lit-html.js";
import { searchRequest } from "../api.js";

const results = (data) => html`
<div class="listing">
    <div class="preview">
        <img src="${data.imageUrl}">
    </div>
    <h2>${data.brand} ${data.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${data.year}</h3>
            <h3>Price: ${data.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${data._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`

const resultsTemplate = (data) => html`
    <h2>Results:</h2>
    <div class="listings">

       ${data.length != 0 
       ? html`${data.map(x => results(x))}` 
       : html`<p class="no-cars"> No results.</p>`}

    </div>`

const searchTemplate = (onClick) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button @click="${onClick}" class="button-list">Search</button>
    </div>
</section>`

export const searchPage = (ctx) => {
    ctx.navBar();

    const onClick = (e) =>{
        e.preventDefault();
        const data = document.getElementById('search-input').value;

        searchRequest(data)
        .then(x =>{
            ctx.render(resultsTemplate(x));
        })
    }
    ctx.render(searchTemplate(onClick));
}
