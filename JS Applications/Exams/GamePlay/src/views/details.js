import { html } from '../../node_modules/lit-html/lit-html.js';
import { commentsRequest, createCommentRequest, deleteRequest, detailsRequest } from '../api.js';

const comment = (comments) => html`
<li class="comment">
    <p>Content: ${comments.comment}</p>
</li>`

const detailsTemplate = (data,comments,isOwner,isLogged,onDelete,takeComment) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src="${data.imageUrl}" />
            <h1>${data.title}</h1>
            <span class="levels">MaxLevel: ${data.maxLevel}</span>
            <p class="type">${data.category}</p>
        </div>

        <p class="text">
            ${data.summary};
        </p>

        <!-- Bonus ( for Guests and Users ) -->
        <div class="details-comments">
            <h2>Comments:</h2>
            <ul>
          ${comments.length != 0 
        ? html`${comments.map(x => comment(x))}`
        : html`<p class="no-comment">No comments.</p>`}
        </ul>
        </div>

        <!-- Edit/Delete buttons ( Only for creator of this game )  -->
       ${isOwner 
        ? html`<div class="buttons">
            <a href="/edit/${data._id}" class="button">Edit</a>
            <a @click="${onDelete}" href="javascript:void(0)" class="button">Delete</a>
        </div>` 
        : null}
    </div>

    <!-- Bonus -->
    <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
    ${isLogged && !isOwner ? html`<article class="create-comment">
        <label>Add new comment:</label>
        <form @submit="${takeComment}" class="form">
            <textarea name="comment" placeholder="Comment......"></textarea>
            <input class="btn submit" type="submit" value="Add Comment">
        </form>
    </article>`:null}

</section>`

export const detailsPage = (ctx) =>{
    ctx.navBar();

    detailsRequest(ctx.params.id)
    .then(x => {
        const isOwner = sessionStorage.getItem('userId') == x._ownerId;
        const isLogged = sessionStorage.getItem('userId') != null;
        function onDelete(){
            deleteRequest(ctx.params.id)
            .then(x =>{
                ctx.page.redirect('/allGames');
            })
        }
        const takeComment = (e) => {
            e.preventDefault();
            const data = new FormData(e.target);
            const comment = data.get('comment');

            if (!comment){
                alert('Empty fields');
                return;
            }

            const body = {
                gameId: x._id,
                comment: comment
            }

            createCommentRequest(body)
            .then(s => {
                ctx.page.redirect(`/details/${ctx.params.id}`)
            })
        }
        console.log(x._id);
        console.log(ctx.params.id);
        commentsRequest(ctx.params.id)
        .then(c => {
            console.log(c);
            ctx.render(detailsTemplate(x,c,isOwner,isLogged,onDelete,takeComment));
        })

        
    })
}