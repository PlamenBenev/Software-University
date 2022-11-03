import { html } from '../../node_modules/lit-html/lit-html.js';
import *  as api from '../api/api.js';
import { setUserNav } from '../app.js';

const registerTemplate = (registerHandler) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit="${registerHandler}">
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control" id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control" id="password" type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class="form-control" id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>`;

export const registerPage = (ctx) => {
    
    const registerHandler = (e) => {
        e.preventDefault();
        const email = document.getElementById('email');
        const password = document.getElementById('password');
        const rePass = document.getElementById('rePass');
        
        if (!email.value || !password.value || !rePass.value) {
            return alert("Empty fields");
        }
        
        if (rePass.value != password.value) {
            return alert('Password does not match');
        }
        
        api.registerRequest(email.value, password.value);

        e.target.reset();
        ctx.page.redirect('/dashboard')
    }
    setUserNav();
    ctx.render(registerTemplate(registerHandler));
}

