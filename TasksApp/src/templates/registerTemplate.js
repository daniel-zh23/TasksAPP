import { html } from "../../node_modules/lit-html/lit-html.js";

export const registerTemplate = (onSubmit) => html` <section id="registerPage" class="Page">
  <form class="register Form" @submit=${onSubmit}>
    <h2>Register</h2>
    <div class="wrapper">
      <div>
        <div class="form-item">
          <label for="firstName">First name:</label>
          <input id="firstName" name="firstName" type="text" class="form-input" />
        </div>
        <div class="form-item">
          <label for="lastName">Last name:</label>
          <input id="lastName" name="lastName" type="text" class="form-input" />
        </div>
        <div class="form-item">
          <label for="email">Email:</label>
          <input id="email" name="email" type="text" class="form-input" />
        </div>
      </div>
      <div>
        <div class="form-item">
          <label for="password">Password:</label>
          <input id="password" name="password" type="password" class="form-input" />
        </div>

        <div class="form-item">
          <label for="repeatPassword">Repeat Password:</label>
          <input id="repeatPassword" name="repeatPassword" type="password" class="form-input" />
        </div>
      </div>
    </div>
    <button class="button" type="submit">Register</button>

    <p class="field">
      <span>If you have profile click <a href="/login">here</a></span>
    </p>
  </form>
</section>`;
