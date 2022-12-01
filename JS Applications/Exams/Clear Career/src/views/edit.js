import { html } from '../../node_modules/lit-html/lit-html.js';
import { detailsRequest, editRequest } from '../api.js';


const editTemplate = (setData, takeData) => html`
<section id="edit">
    <div class="form">
        <h2>Edit Offer</h2>
        <form @submit="${takeData}" class="edit-form">
            <input type="text" name="title" id="job-title" placeholder="Title" value="${setData.title}" />
            <input type="text" name="imageUrl" id="job-logo" placeholder="Company logo url" value="${setData.imageUrl}"/>
            <input type="text" name="category" id="job-category" placeholder="Category" value="${setData.category}"/>
            <textarea id="job-description" name="description" placeholder="Description" rows="4" cols="50" >${setData.description}</textarea>
            <textarea id="job-requirements" name="requirements" placeholder="Requirements" rows="4"
                cols="50">${setData.requirements}</textarea>
            <input type="text" name="salary" id="job-salary" placeholder="Salary" value="${setData.salary}" />

            <button type="submit">post</button>
        </form>
    </div>
</section>`

export const editPage = (ctx) => {
    ctx.navBar();

    detailsRequest(ctx.params.id)
    .then(set => {
        const takeData = (e) => {
            e.preventDefault();
    
            const data = new FormData(e.target);
            const title = data.get('title');
            const imageUrl = data.get('imageUrl');
            const category = data.get('category');
            const description = data.get('description');
            const requirements = data.get('requirements');
            const salary = data.get('salary');
    
            if (!title || !imageUrl || !category || !description || !requirements || !salary) {
                alert('Empty fields');
                return;
            }
    
            const body = {
                title: title,
                imageUrl: imageUrl,
                category: category,
                description: description,
                requirements: requirements,
                salary: salary,
            }
            
            editRequest(body, set._id)
            .then(() => {
                ctx.page.redirect('/details/' + set._id);
            })
        }

        ctx.render(editTemplate(set,takeData))
    });
}