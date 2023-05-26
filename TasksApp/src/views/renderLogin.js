import { loginTemplate } from '../templates/loginTemplate.js';
import * as authService from '../services/authService.js';

export const renderLogin = (ctx) => {
    ctx.render(loginTemplate(onSubmit.bind(null, ctx)));
};

const onSubmit = (ctx, e) => {
    e.preventDefault();
    let { email, password } = Object.fromEntries(new FormData(e.currentTarget));
    if (email == '' || password == '') {
        alert('All fields are required!');
    } else {
        authService
            .login(email, password)
            .then((data) => ctx.page.redirect('/'))
            .catch((err) => alert(err.message));
    }
};
