import * as authService from "../services/authService.js";

const requester = (method, url, data) => {
  let options = {
    method,
    headers: {},
  };

  if (method != "get") {
    options.headers["content-type"] = "application/json";
    options.body = JSON.stringify(data);
  }
  if (authService.isLogged()) {
    options.headers["Authorization"] = `Bearer ${authService.getToken()}`;
  }

  return fetch(url, options).then((res) => res.json().then((data) => ({ code: res.status, data: data })));
};

export const get = requester.bind(null, "get");
export const post = requester.bind(null, "post");
export const put = requester.bind(null, "put");
export const del = requester.bind(null, "delete");
