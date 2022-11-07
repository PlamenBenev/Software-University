import { html } from '../../node_modules/lit-html/lit-html.js';
import * as api from '../api/api.js';

const loginTemplate = (loginHandler) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Login User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit="${loginHandler}">
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control" id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control" id="password" type="password" name="password">
            </div>
            <input type="submit" class="btn btn-primary" value="Login" />
        </div>
    </div>
</form>`;

export const loginPage = (ctx) => {
    ctx.setUserNav()
    const loginHandler = (e) => {
        e.preventDefault();
        const form = new FormData(e.target);
        const email = form.get('email');
        const password = form.get('password');
        if (!email || !password) {
            return alert("Empty fields");
        }

        api.loginRequest(email,password)
        .then(x => ctx.setUserNav())
        .then(x => {
            e.target.reset();
            ctx.page.redirect('/')
        });
    }
    
    ctx.render(loginTemplate(loginHandler));
}
