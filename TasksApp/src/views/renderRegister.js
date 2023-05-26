import { registerTemplate } from '../templates/registerTemplate.js';
import * as authService from '../services/authService.js';

export const renderRegister = (ctx) => {
    ctx.render(registerTemplate(onSubmit.bind(null, ctx)));
};

const onSubmit = (ctx, e) => {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);
    let { firstName, lastName, email, password, repeatPassword } = Object.fromEntries(formData);
    if (email == '' || password == '' || repeatPassword == '') {
        alert('All fields are required!');
    } else if (password !== repeatPassword) {
        alert("Passwords doesn't match!");
    } else {
        authService
            .register(firstName, lastName, email, password)
            .then((data) => ctx.page.redirect('/login'))
            .catch((err) => {
                let error = '';
                for(let prop in err){
                    error += `${err[prop]}\n`;
                }
                alert(error);
            });
    }
};
