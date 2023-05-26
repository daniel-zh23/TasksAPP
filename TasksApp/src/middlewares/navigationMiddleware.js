import { html, render, nothing } from "../../node_modules/lit-html/lit-html.js";

let header = document.querySelector("header");

const navigationTemplate = (isLogged) => html` <nav class="top-nav">
  <a href="/">
    <p class="logoName">Tasks</p>
    <img src="./images/Checkmark.svg" class="logo" />
  </a>
  <ul>
    <!--Users and Guest-->
    ${isLogged
      ? html` <li><a class="button" href="/">Home</a></li>
          <li><a class="button" href="/create">Create Task</a></li>
          <li><a class="button" href="/logout">Logout</a></li>`
      : html` <li><a class="button" href="/login">Login</a></li>
          <li><a class="button" href="/register">Register</a></li>`}
    <!--<li><a class="button" href="/about">About</a></li>-->
  </ul>
</nav>`;

export const navigationMiddleware = (ctx, next) => {
  ctx.updateNav = () => render(navigationTemplate(ctx.isLogged, ctx.userEmail), header);
  next();
};
