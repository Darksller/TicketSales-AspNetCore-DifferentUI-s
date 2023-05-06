import { makeAutoObservable } from 'mobx';
import axios from 'axios';

export default class Store {
    isAuth = false
    user = {}
    isAdmin = false
    isLoading = false
    constructor() {
        makeAutoObservable(this)
    }

    setAuth(bool) {
        this.isAuth = bool;
    }

    setUser(user) {
        this.user = user;
    }

    setLoading(bool) {
        this.isLoading = bool;
    }

    setAdmin(bool) {
        this.isAdmin = bool;
    }

    async login(email, password) {
        try {
            const response = await axios.post(`/user/login`, {
                email: email,
                password: password
            });

            console.log(response);

            localStorage.setItem('token', response.data.accessToken);
            this.setAuth(true);

            const user = {
                email: response.data.email,
                role: response.data.role
            }

            this.setUser(user);

            if (this.user.role === 'admin') {
                this.setAdmin(true);
            }

        } catch (e) {
            console.log(e.response?.data?.message);
        }
    }

    async registration(email, password, name, passport) {
        try {
            const response = await axios.post(`/user/registration`, {
                email: email,
                password: password,
                name: name,
                passport: passport
            });

            console.log(response);
            localStorage.setItem('token', response.data.accessToken);
            this.setAuth(true);

            const user = {
                email: response.data.email,
                roles: response.data.roles
            }

            this.setUser(user);

            if (this.user.role === 'admin') {
                this.setAdmin(true);
            }
        } catch (e) {
            console.log(e.response?.data?.message);
        }
    }

    async logout() {
        try {
            const response = await axios.post(`/user/logout`);
            localStorage.removeItem('token');
            this.setAuth(false);
            this.setUser({});
            this.setAdmin(false);
        } catch (e) {
            console.log(e.response?.data?.message);
        }
    }
}