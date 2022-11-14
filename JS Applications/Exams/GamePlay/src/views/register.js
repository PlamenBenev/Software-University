import { html } from '../../node_modules/lit-html/lit-html.js';
import { registerRequest } from '../api.js';

const registerTemplate = (takeData) => html`
<section id="register-page" class="content auth">
    <form @submit="${takeData}" id="register">
        <div class="container">
            <div class="brand-logo"></div>
            <h1>Register</h1>

            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="maria@email.com">

            <label for="pass">Password:</label>
            <input type="password" name="password" id="register-password">

            <label for="con-pass">Confirm Password:</label>
            <input type="password" name="confirm-password" id="confirm-password">

            <input class="btn submit" type="submit" value="Register">

            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
        </div>
    </form>
</section>
`

export const registerPage = (ctx) => {
    ctx.navBar();

    const takeData = (e) =>{
        e.preventDefault();
        const data = new FormData(e.target);
        const email = data.get('email');
        const password = data.get('password');
        const confirm = data.get('confirm-password');

        if (!email || !password || !confirm){
            alert('Empty fields');
            return;
        }
        if (password != confirm){
            alert('Password does not match!');
            return;
        }
        const body = {
            email: email,
            password: password
        }

        registerRequest(body)
        .then(x => {
            ctx.page.redirect('/');
        })
    }
    ctx.render(registerTemplate(takeData));
}