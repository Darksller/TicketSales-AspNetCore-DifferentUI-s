import React, { useState, useContext } from 'react';
import { Form } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './LoginForm.css';
import { Link } from 'react-router-dom';
import { NavLink } from 'reactstrap';
import { observer } from 'mobx-react-lite';
import { Context } from '../../index';
import { Navigate } from 'react-router-dom';

const LoginForm = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { store } = useContext(Context);
    const [isError, setError] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        store.login(email, password);
        setTimeout(() => {
            if (!store.isAuth) {
                setError('Неверный Email или пароль');
            }
        }, 1000);
    }

    if (store.isAuth) {
        return <Navigate to='/' />;
    }

    return (

        <div className="login-form-container">
            <Form onSubmit={handleSubmit}>
                <Form.Label className="head">Вход</Form.Label>
                <Form.Group controlId="formBasicEmail">
                    <Form.Label>Email:</Form.Label>
                    <Form.Control type="email" placeholder="Введите Email" value={email} required onChange={(e) => setEmail(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="formBasicPassword">
                    <Form.Label>Пароль:</Form.Label>
                    <Form.Control type="password" placeholder="Введите пароль" value={password} required onChange={(e) => setPassword(e.target.value)} />
                    <NavLink tag={Link} className="textButton" to="/registration">Нет аккаунта? Зарегиструруйся</NavLink>
                </Form.Group>

                <button className="buton" variant="primary" type="submit">Войти</button>
                <Form.Label className="error">{isError}</Form.Label>
            </Form>
        </div>
    );
}

export default observer(LoginForm);
