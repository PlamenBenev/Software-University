import { html } from "../../node_modules/lit-html/lit-html.js";
import { loginRequest } from "../api.js";

const loginTemplate = (takeData) => html`
<section id="login">
    <div class="form">
        <h2>Login</h2>
        <form @submit="${takeData}" class="login-form">
            <input type="text" name="email" id="email" placeholder="email" />
            <input type="password" name="password" id="password" placeholder="password" />
            <button type="submit">login</button>
            <p class="message">
                Not registered? <a href="/register">Create an account</a>
            </p>
        </form>
    </div>
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