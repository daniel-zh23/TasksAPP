import { aboutTemplate } from "../templates/aboutTemplate.js";

export const renderAbout = (ctx) => {
  ctx.render(aboutTemplate());
};
