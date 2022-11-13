import { registerRequest } from "../api.js";
import { html } from "../../node_modules/lit-html/lit-html.js";

const registerTemplate = (takeData) => html`
<section id="register">
    <div class="container">
        <form @submit="${takeData}" id="register-form">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>
</section>`

export const registerPage = (ctx) => {
    ctx.navBar();

    const takeData = (e) => {
        e.preventDefault();
        const data = new FormData(e.target);
        const username = data.get('username');
        const password = data.get('password');
        const repeatPassword = data.get('repeatPass');

        if (!username || !password || !repeatPassword){
            alert('Empty fields');
            return;
        }
        if (password != repeatPassword){
            alert('Password does no match!');
            return;
        }

        const body = {
            username: username,
            password: password
        }

        registerRequest(body)
        .then(x => {
            ctx.page.redirect('/');
            ctx.navBar();
        })
    }
    ctx.render(registerTemplate(takeData));
}