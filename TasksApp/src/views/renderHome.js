import { homeTemplate } from '../templates/homeTemplate.js';

export const renderHome = (ctx) => {
    ctx.render(homeTemplate());
};
