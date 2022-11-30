import { html } from "../../node_modules/lit-html/lit-html.js";
import { loginRequest } from "../api.js";


const loginTemplate = (takeData) => html`
<section id="loginPage">
    <form @submit="${takeData}" class="loginForm">
        <img src="./images/logo.png" alt="logo" />
        <h2>Login</h2>

        <div>
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
        </div>

        <div>
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" placeholder="********" value="">
        </div>

        <button class="btn" type="submit">Login</button>

        <p class="field">
            <span>If you don't have profile click <a href="/register">here</a></span>
        </p>
    </form>
</section>`

export const loginPage = (ctx) => {
    ctx.navBar();

    const takeData = (e) => {
        e.preventDefault();
        const data = new FormData(e.target);
        const email = data.get('email');
        const password = data.get('password');

        if (!email || !password){
            alert('Empty fields');
            return;
        }

        const body = {
            email: email,
            password: password
        }

        loginRequest(body)
        .then(() => {
            ctx.page.redirect('/');
        })
    }
    ctx.render(loginTemplate(takeData));
}