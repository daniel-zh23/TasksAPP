import * as requester from './requester.js';
const host = 'https://localhost:7027';
const baseUrl = `${host}/api/task`;

export const getAll = () => requester.get(`${baseUrl}/all`);
export const create = (title, description) => requester.post(`${baseUrl}/create`, {title, description});
