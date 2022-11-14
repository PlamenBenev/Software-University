import { html } from '../../node_modules/lit-html/lit-html.js';
import { loginRequest } from '../api.js';


const loginTemplate = (takeData) => html`
<section id="login-page" class="auth">
    <form @submit="${takeData}" id="login">

        <div class="container">
            <div class="brand-logo"></div>
            <h1>Login</h1>
            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

            <label for="login-pass">Password:</label>
            <input type="password" id="login-password" name="password">
            <input type="submit" class="btn submit" value="Login">
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </div>
    </form>
</section>`

export const loginPage = (ctx) => {
    ctx.navBar();

    const takeData = (e) =>{
        e.preventDefault();
        const data = new FormData(e.target);
        const email = data.get('email');
        const password = data.get('password');

        if (!email || !password ){
            alert('Empty fields');
            return;
        }
        const body = {
            email: email,
            password: password
        }

        loginRequest(body)
        .then(x => {
            ctx.page.redirect('/');
        })
    }
    ctx.render(loginTemplate(takeData));
}