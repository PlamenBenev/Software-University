import { html } from "../../node_modules/lit-html/lit-html.js";
import { createRequest } from "../api.js";


const createTemplate = (takeData) => html`
<section id="createPage">
    <form @submit="${takeData}" class="createForm">
        <img src="./images/cat-create.jpg">
        <div>
            <h2>Create PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" placeholder="Max">
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" placeholder="Shiba Inu">
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" placeholder="2 years">
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" placeholder="5kg">
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" placeholder="./image/dog.jpeg">
            </div>
            <button class="btn" type="submit">Create Pet</button>
        </div>
    </form>
</section>`

export const createPage = (ctx) => {
    ctx.navBar();

    const takeData = (e) => {
         e.preventDefault();
         const data = new FormData(e.target);

         const name = data.get('name');
         const breed = data.get('breed');
         const age = data.get('age');
         const weight = data.get('weight');
         const image = data.get('image');

         if (!name || !breed || !age || !weight || !image){
            alert('Empty fields');
            return;
         }

         const body = {
            name: name,
            breed: breed,
            age: age,
            weight: weight,
            image: image
         }

         createRequest(body)
         .then(() => {
            ctx.page.redirect('/dashboard');
         })
    }
    ctx.render(createTemplate(takeData));
}