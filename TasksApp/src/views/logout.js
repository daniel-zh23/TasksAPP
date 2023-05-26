import * as authService from '../services/authService.js';

export const logout = (ctx) => {
    authService.logout();
    ctx.page.redirect('/login');
};
