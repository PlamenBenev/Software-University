import { html } from "../../node_modules/lit-html/lit-html.js";
import { detailsRequest, editRequest } from "../api.js";

const editTemplate = (giveData,takeData) => html`
<section class="editPage">
    <form @submit="${takeData}">
        <fieldset>
            <legend>Edit Album</legend>

            <div class="container">
                <label for="name" class="vhide">Album name</label>
                <input id="name" name="name" class="name" type="text" value="${giveData.name}">

                <label for="imgUrl" class="vhide">Image Url</label>
                <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" value="${giveData.imgUrl}">

                <label for="price" class="vhide">Price</label>
                <input id="price" name="price" class="price" type="text" value="${giveData.price}">

                <label for="releaseDate" class="vhide">Release date</label>
                <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" value="${giveData.releaseDate}">

                <label for="artist" class="vhide">Artist</label>
                <input id="artist" name="artist" class="artist" type="text" value="${giveData.artist}">

                <label for="genre" class="vhide">Genre</label>
                <input id="genre" name="genre" class="genre" type="text" value="${giveData.genre}">

                <label for="description" class="vhide">Description</label>
                <textarea name="description" class="description" rows="10"
                    cols="10">${giveData.description}</textarea>

                <button class="edit-album" type="submit">Edit Album</button>
            </div>
        </fieldset>
    </form>
</section>`

export const editPage = (ctx) => {
    
    detailsRequest(ctx.params.id)
    .then(x => {
        
        const takeData = (e) =>{
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
            
            editRequest(ctx.params.id,body)
            .then(x => {
                ctx.page.redirect('/catalog');
            })
        }

        ctx.render(editTemplate(x,takeData));
        
    })
    
}