import { html } from '../../node_modules/lit-html/lit-html.js';

export const loginTemplate = (onSubmit) => html` <section id="loginPage" class="Page">
    <form class="login Form" @submit=${onSubmit}>
        <h2>Login</h2>

        <div class="form-item">
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" class="form-input"/>
        </div>

        <div class="form-item">
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" class="form-input"/>
        </div>

        <button class="button" type="submit">Login</button>

        <p class="field">
            <span>If you don't have profile click <a href="/register">here</a></span>
        </p>
    </form>
</section>`;
