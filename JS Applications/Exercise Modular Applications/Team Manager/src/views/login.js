import { html } from "../../node_modules/lit-html/lit-html.js";
import { loginRequest } from "../api.js";



const loginTemplate = (errMessage,takeData) => html`
<section id="login">
    <article class="narrow">
        <header class="pad-med">
            <h1>Login</h1>
        </header>
        <form @submit="${takeData}" id="login-form" class="main-form pad-large">
            <div class="error">${errMessage}</div>
            <label>E-mail: <input type="text" name="email"></label>
            <label>Password: <input type="password" name="password"></label>
            <input class="action cta" type="submit" value="Sign In">
        </form>
        <footer class="pad-small">Don't have an account? <a href="/register" class="invert">Sign up here</a>
        </footer>
    </article>
</section>`

export const loginPage = (ctx) => {
    ctx.navBar();

    let errMessage = '';
    const takeData = (e) => {
        e.preventDefault();

        const data = new FormData(e.target);
        const email = data.get('email');
        const password = data.get('password');
        
        if (!email || !password) {
            errMessage = 'Empty fields!';
            ctx.render(loginTemplate(errMessage));
            return;
        }

        const body = {
            email: email,
            password: password
        }

        loginRequest(body)
            .then(x => {
                ctx.page.redirect('/')
            })
    }

    ctx.render(loginTemplate(errMessage, takeData));
}