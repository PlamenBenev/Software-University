import { html } from "../../node_modules/lit-html/lit-html.js";
import { loginRequest } from "../api.js";

const loginTemplate = (takeData) => html`
<section id="login">
    <div class="container">
        <form @submit="${takeData}" id="login-form" action="#" method="post">
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>`

export const loginPage = (ctx) =>{
    ctx.navBar();

    const takeData = (e) => {
        e.preventDefault();
        const data = new FormData(e.target);
        const username = data.get('username');
        const password = data.get('password');

        if (!username || !password){
            alert('Empty fields');
            return;
        }

        const body = {
            username: username,
            password: password
        }

        loginRequest(body)
        .then(x => {
            ctx.page.redirect('/');
            ctx.navBar();
        })
    }
    ctx.render(loginTemplate(takeData));
}