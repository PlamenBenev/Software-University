import { html } from "../../node_modules/lit-html/lit-html.js";
import { registerRequest } from "../api.js";


const registerTemplate = (takeData) => html`
<section id="registerPage">
    <form @submit="${takeData}">
        <fieldset>
            <legend>Register</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <label for="conf-pass" class="vhide">Confirm Password:</label>
            <input id="conf-pass" class="conf-pass" name="conf-pass" type="password" placeholder="Confirm Password">

            <button type="submit" class="register">Register</button>

            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
        </fieldset>
    </form>
</section>`

export const registerPage = (ctx) => {
    ctx.userNavBar();

    const takeData = (e) => {
        e.preventDefault();
        const data = new FormData(e.target);
        const email = data.get('email');
        const password = data.get('password')
        const rePass = data.get('conf-pass')

        if (!email || !password || !rePass){
            alert('Empty fields!');
            return;
        }

        if (password != rePass){
            alert('Password is not matching');
            return;
        }

        const body = {
            email: email,
            password: password,
        }

        registerRequest(body)
        .then(x => {
            ctx.userNavBar();
            ctx.page.redirect('/home');
        })
    }
    ctx.render(registerTemplate(takeData));
}