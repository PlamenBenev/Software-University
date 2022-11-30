import { html } from "../../node_modules/lit-html/lit-html.js";
import { detailsRequest, editRequest } from "../api.js";


const editTemplate = (setData, takeData) => html`
<section id="editPage">
    <form @submit="${takeData}" class="editForm">
        <img src="./images/editpage-dog.jpg">
        <div>
            <h2>Edit PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" value="${setData.name}">
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" value="${setData.breed}">
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" value="${setData.age}">
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" value="${setData.weight}">
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" value="${setData.image}">
            </div>
            <button class="btn" type="submit">Edit Pet</button>
        </div>
    </form>
</section>`

export const editPage = (ctx) => {
    ctx.navBar();

    detailsRequest(ctx.params.id)
    .then(setData => {
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
            
            editRequest(body,ctx.params.id)
            .then(() => {
                ctx.page.redirect(`/details/${ctx.params.id}`);
            })
        }

        ctx.render(editTemplate(setData,takeData));
    })

}