import * as authService from '../services/authService.js';
import * as itemsService from '../services/itemsService.js';

export const statusMiddleware = (ctx, next) => {
    ctx.isLogged = authService.isLogged();
    ctx.userId = authService.getId();
    ctx.userEmail = authService.getEmail();
    ctx.isOwner = authService.isOwner;
    next();
};
