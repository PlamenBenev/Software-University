import { html } from "../../node_modules/lit-html/lit-html.js";
import { registerRequest } from "../api.js";

const registerTemplate = (takeData) => html`
<section id="registerPage">
    <form @submit="${takeData}" class="registerForm">
        <img src="./images/logo.png" alt="logo" />
        <h2>Register</h2>
        <div class="on-dark">
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
        </div>

        <div class="on-dark">
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" placeholder="********" value="">
        </div>

        <div class="on-dark">
            <label for="repeatPassword">Repeat Password:</label>
            <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
        </div>

        <button class="btn" type="submit">Register</button>

        <p class="field">
            <span>If you have profile click <a href="/login">here</a></span>
        </p>
    </form>
</section>`

export const registerPage = (ctx) => {
    ctx.navBar();

    const takeData = (e) => {
        e.preventDefault();
        const data = new FormData(e.target);
        const email = data.get('email');
        const password = data.get('password');
        const repeatPassword = data.get('repeatPassword');

        if (!email || !password || !repeatPassword){
            alert('Empty fields');
            return;
        }
        if (password != repeatPassword){
            alert('Password does not match');
            return;
        }

        const body = {
            email: email,
            password: password
        }

        registerRequest(body)
        .then(() => {
            ctx.page.redirect('/');
        })
    }
    ctx.render(registerTemplate(takeData));
}