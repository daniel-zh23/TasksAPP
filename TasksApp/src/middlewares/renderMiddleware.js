import { render } from '../../node_modules/lit-html/lit-html.js';

let root = document.getElementById('content');
const ctxRender = (viewSection) => render(viewSection, root);

export const renderMiddleware = (ctx, next) => {
    ctx.updateNav();
    ctx.render = ctxRender;
    next();
};
