import { html } from '../../node_modules/lit-html/lit-html.js';
import { createRequest } from '../api.js';


const createTemplate = (takeData) => html`
<section id="create">
    <div class="form">
        <h2>Create Offer</h2>
        <form @submit="${takeData}" class="create-form">
            <input type="text" name="title" id="job-title" placeholder="Title" />
            <input type="text" name="imageUrl" id="job-logo" placeholder="Company logo url" />
            <input type="text" name="category" id="job-category" placeholder="Category" />
            <textarea id="job-description" name="description" placeholder="Description" rows="4" cols="50"></textarea>
            <textarea id="job-requirements" name="requirements" placeholder="Requirements" rows="4"
                cols="50"></textarea>
            <input type="text" name="salary" id="job-salary" placeholder="Salary" />

            <button type="submit">post</button>
        </form>
    </div>
</section>`

export const createPage = (ctx) => {
    ctx.navBar();

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

        createRequest(body)
        .then(() => {
            ctx.page.redirect('/dashboard');
        });
    }

    ctx.render(createTemplate(takeData));
}