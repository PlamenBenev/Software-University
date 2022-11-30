import { html } from "../../node_modules/lit-html/lit-html.js";
import { registerRequest } from "../api.js";

const registerTemplate = (takeData) => html`
<section id="register">
    <div class="form">
        <h2>Register</h2>
        <form @submit="${takeData}" class="login-form">
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">login</button>
            <p class="message">Already registered? <a href="/login">Login</a></p>
        </form>
    </div>
</section>`

export const registerPage = (ctx) => {
    ctx.navBar();
    
    const takeData = (e) => {
        e.preventDefault();

        const data = new FormData(e.target);
        const email = data.get('email');
        const password = data.get('password');
        const rePassword = data.get('re-password');

        if (!email || !password || !rePassword){
            alert('Empty fields');
            return;
        }
        if (password != rePassword){
            alert('Password does not match!');
            return;
        }

        const body = {
            email: email,
            password: password
        }

        registerRequest(body)
        .then(()=>{
            ctx.page.redirect('/');
        })
    }
    ctx.render(registerTemplate(takeData));
}