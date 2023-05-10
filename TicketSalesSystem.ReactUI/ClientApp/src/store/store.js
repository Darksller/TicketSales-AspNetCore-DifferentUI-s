import { makeAutoObservable } from 'mobx';
import axios from 'axios';

export default class Store {
    isAuth = false
    user = {
        email: "",
        role: ""
    }
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
        this.setLoading(true);
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
        } finally {
            this.setLoading(false);
        }
    }

    async registration(email, password, name, passport, phone) {
        this.setLoading(true);
        try {
            const response = await axios.post(`/user/registration`, {
                email: email,
                password: password,
                name: name,
                passport: passport,
                phone: phone
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
        } finally {
            this.setLoading(false);
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

    async checkAuth() {
        this.setLoading(true);
        try {
            axios.defaults.withCredentials = true;
            const response = await axios.post("/user/refresh")
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
        } finally {
            this.setLoading(false);
        }
    }

}