import { html } from "../../node_modules/lit-html/lit-html.js";
import { loginRequest } from "../api.js";


const loginTemplate = (takedata) => html`
<section id="loginPage">
    <form @submit="${takedata}">
        <fieldset>
            <legend>Login</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <button type="submit" class="login">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </fieldset>
    </form>
</section>`

export const loginPage = (ctx) =>{
    ctx.userNavBar();

    const takeData = (e) => {
        e.preventDefault();
        const data = new FormData(e.target);
        const email = data.get('email');
        const password = data.get('password');

        if (!email || !password){
            alert("Empty fields!");
            return;
        }

        const body = {
            email: email,
            password: password
        }

        loginRequest(body)
        .then(x =>{
            ctx.userNavBar();
            ctx.page.redirect('/');
        })
    }
    ctx.render(loginTemplate(takeData));
}