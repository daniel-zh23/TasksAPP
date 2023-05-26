import * as requester from "./requester.js";

const baseUrl = "https://localhost:7027/api/auth";

const saveUser = (user) => {
  sessionStorage.setItem("user", JSON.stringify(user));
  return user;
};

export const login = (email, password) =>
  requester
    .post(`${baseUrl}/login`, { email, password })
    .then((user) => {
      if (user.code == 200) {
        saveUser(user.data);
      } else {
        throw new Error(user.message);
      }
    })
    .catch((err) => {
      console.log(err);
      throw new Error(err.message);
    });

export const register = (firstName, lastName, email, password) =>
  requester
    .post(`${baseUrl}/register`, { email, firstName, lastName, password })
    .then((user) => {
      if (!user.data.email) {
        throw user;
      }
    })
    .catch((err) => {
      throw err;
    });

export const isLogged = () => {
  let user = JSON.parse(sessionStorage.getItem("user"));
  if (user) {
    return true;
  } else {
    return false;
  }
};

export const isOwner = (ownerId) => {
  let user = JSON.parse(sessionStorage.getItem("user"));
  if (user && user._id == ownerId) {
    return true;
  }
  return false;
};

export const getId = () => {
  if (sessionStorage.getItem("user")) {
    return JSON.parse(sessionStorage.getItem("user"))._id;
  }
  return null;
};

export const getToken = () => {
  if (sessionStorage.getItem("user")) {
    return JSON.parse(sessionStorage.getItem("user")).accessToken;
  }
  return null;
};

export const getEmail = () => {
  if (sessionStorage.getItem("user")) {
    return JSON.parse(sessionStorage.getItem("user")).email;
  }
  return null;
};

export const logout = () => {
  requester.get(`${baseUrl}/logout`);
  sessionStorage.removeItem("user");
};
