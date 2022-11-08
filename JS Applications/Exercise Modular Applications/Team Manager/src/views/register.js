import { html } from "../../node_modules/lit-html/lit-html.js";
import { registerRequest } from "../api.js";



const registerTemplate = (takeData,errMessage) => html`
<section id="register">
    <article class="narrow">
        <header class="pad-med">
            <h1>Register</h1>
        </header>
        <form @submit="${takeData}" id="register-form" class="main-form pad-large">

            <div class="error">${errMessage}</div>
            <label>E-mail: <input type="text" name="email"></label>
            <label>Username: <input type="text" name="username"></label>
            <label>Password: <input type="password" name="password"></label>
            <label>Repeat: <input type="password" name="repass"></label>
            <input class="action cta" type="submit" value="Create Account">
        </form>
        <footer class="pad-small">Already have an account? <a href="/login" class="invert">Sign in here</a>
        </footer>
    </article>
</section>`

export const registerPage = (ctx) => {
    ctx.navBar();

    let errMessage = '';
    const takeData = (e) =>{
        e.preventDefault();

        const data = new FormData(e.target);
        const email = data.get('email');
        const username = data.get('username');
        const password = data.get('password');
        const rePass = data.get('repass');

        if (!email || !username || !password || !rePass){
            errMessage = 'Empty fields!';
            ctx.render(registerTemplate(takeData,errMessage));
            return;
        }
        if (password !== rePass){
            errMessage = 'Password do not match!';
            ctx.render(registerTemplate(takeData,errMessage));
            return;
        }

        const body = {
            email: email,
            username: username,
            password: password
        }

        registerRequest(body)
        .then(x => {
            ctx.page.redirect('/')
        })
    }

    ctx.render(registerTemplate(takeData,errMessage));
}