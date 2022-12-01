import { html } from '../../node_modules/lit-html/lit-html.js';
import { applyRequest, countRequest, deleteRequest, detailsRequest } from '../api.js';


const detailsTemplate = (setData,isOwner,isLogged,onDelete,count,onApply) => html`
<section id="details">
    <div id="details-wrapper">
        <img id="details-img" src="${setData.imageUrl}" alt="example1" />
        <p id="details-title">${setData.title}</p>
        <p id="details-category">
            Category: <span id="categories">${setData.category}</span>
        </p>
        <p id="details-salary">
            Salary: <span id="salary-number">${setData.salary}</span>
        </p>
        <div id="info-wrapper">
            <div id="details-description">
                <h4>Description</h4>
                <span>${setData.description}</span>
            </div>
            <div id="details-requirements">
                <h4>Requirements</h4>
                <span>${setData.requirements}</span>
            </div>
        </div>
        <p>Applications: <strong id="applications">${count}</strong></p>

        <!--Edit and Delete are only for creator-->
        <div id="action-buttons">
          ${isOwner 
            ? html`<a href="/edit/${setData._id}" id="edit-btn">Edit</a>
            <a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>`
            : null}

            <!--Bonus - Only for logged-in users ( not authors )-->
           ${isLogged && !isOwner
            ? html`<a @click="${onApply}" href="javascript:void(0)" id="apply-btn">Apply</a>`
            : null}

        </div>
    </div>
</section>`

export const detailsPage = (ctx) => {
    ctx.render();

    detailsRequest(ctx.params.id)
    .then(x => {
        const isOwner = sessionStorage.getItem('userId') == x._ownerId;
        const isLogged = sessionStorage.getItem('userId');
        function onDelete(){
            const confirmed = confirm('You sure ?');

            if (confirmed){
                deleteRequest(x._id)
                .then(() => {
                    ctx.page.redirect('/dashboard');
                })
            }
        }

        function onApply(e){
            e.preventDefault();

            const body = {
                offerId: x._id
            }

            applyRequest(body)
            .then(() => {
                document.getElementById('apply-btn').style.display = 'none';
                countRequest(x._id)
                .then(count => {
                    ctx.render(detailsTemplate(x,isOwner,isLogged,onDelete,count));
                });
            })
        }

        countRequest(x._id)
        .then(count => {
            ctx.render(detailsTemplate(x,isOwner,isLogged,onDelete,count,onApply));
        });
    });
}