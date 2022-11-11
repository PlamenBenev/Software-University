import { html } from "../../node_modules/lit-html/lit-html.js";
import { createRequest } from "../api.js";


const createTemplate = (takeData) => html`
<section class="createPage">
    <form @submit="${takeData}">
        <fieldset>
            <legend>Add Album</legend>

            <div class="container">
                <label for="name" class="vhide">Album name</label>
                <input id="name" name="name" class="name" type="text" placeholder="Album name">

                <label for="imgUrl" class="vhide">Image Url</label>
                <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" placeholder="Image Url">

                <label for="price" class="vhide">Price</label>
                <input id="price" name="price" class="price" type="text" placeholder="Price">

                <label for="releaseDate" class="vhide">Release date</label>
                <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" placeholder="Release date">

                <label for="artist" class="vhide">Artist</label>
                <input id="artist" name="artist" class="artist" type="text" placeholder="Artist">

                <label for="genre" class="vhide">Genre</label>
                <input id="genre" name="genre" class="genre" type="text" placeholder="Genre">

                <label for="description" class="vhide">Description</label>
                <textarea name="description" class="description" placeholder="Description"></textarea>

                <button class="add-album" type="submit">Add New Album</button>
            </div>
        </fieldset>
    </form>
</section>`

export const createPage = (ctx) => {
    ctx.userNavBar();

    const takeData = (e) => {
        e.preventDefault();
        const data = new FormData(e.target);
        const name = data.get('name');
        const imgUrl = data.get('imgUrl');
        const price = data.get('price');
        const releaseDate = data.get('releaseDate');
        const artist = data.get('artist');
        const genre = data.get('genre');
        const description = data.get('description');
        
        if (!imgUrl || !name || !price || !releaseDate || !artist || !genre || !description ){
            alert('Empty fields!');
            return;
        }

        const body = {
            name: name,
            imgUrl: imgUrl,
            price: price,
            releaseDate: releaseDate,
            artist: artist,
            genre: genre,
            description: description
        }

        createRequest(body)
        .then(x => {
            ctx.userNavBar();
            ctx.page.redirect('/catalog');
        })
    }
    ctx.render(createTemplate(takeData));
}