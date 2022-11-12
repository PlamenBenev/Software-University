import { html } from "../../node_modules/lit-html/lit-html.js";
import { searchRequest } from "../api.js";

const results = (data, isLogged) => html`
<div class="card-box">
    <img src="${data.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${data.name}</p>
            <p class="artist">Artist: ${data.artist}</p>
            <p class="genre">Genre: ${data.genre}</p>
            <p class="price">Price: $${data.price}</p>
            <p class="date">Release Date: ${data.relaseDate}</p>
        </div>
        <div class="btn-group">
            ${isLogged ? html`<a href="/details/${data._id}" id="details">Details</a>` : null}
        </div>
    </div>
</div>`

const resultsTemplate = (data,isLogged) => html`
<h2>Results:</h2>

<!--Show after click Search button-->
<div class="search-result">

<!--If have matches--> ${data.length != 0 
  ? html`${data.map(x => results(x,isLogged))}` 
  : html`<p class="no-result">No result.</p>`} <!--If there are no matches-->
</div>`

const searchTemplate = (onClick) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button @click="${onClick}" class="button-list">Search</button>
    </div>

</section>`

export const searchPage = (ctx) => {
    ctx.userNavBar();
    
    const click = (e) =>{
        e.preventDefault();
        const data = document.getElementById('search-input').value;

        if (!data){
            alert('Empty fields');
            return;
        }
        
        searchRequest(data)
        .then(x => {
            const isLogged = sessionStorage.getItem('authToken') != null;
            ctx.render(resultsTemplate(x,isLogged));
        })
    }

    ctx.render(searchTemplate(click));
}