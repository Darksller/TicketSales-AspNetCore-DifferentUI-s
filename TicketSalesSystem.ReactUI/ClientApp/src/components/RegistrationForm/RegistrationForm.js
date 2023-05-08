import React, { useState, useContext } from 'react';
import { Form } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './RegistrationForm.css';
import { Link } from 'react-router-dom';
import { NavLink } from 'reactstrap';
import { observer } from 'mobx-react-lite';
import { Context } from '../../index';
import { Navigate } from 'react-router-dom';

const RegistrationForm = () => {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [passport, setPassport] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [phone, setPhone] = useState('');
    const [phoneError, setPhoneError] = useState('');

    const { store } = useContext(Context);
    const [isError, setError] = useState('');

    const isPhoneValid = (phone) => {
        const phonePattern = /^[+]*[(]?[0-9]{1,4}[)]?[-\s./0-9]*$/;
        return phonePattern.test(phone);
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        if (password !== confirmPassword) {
            setError('Пароли должны совпадать!');
            return;
        }
        if (!isPhoneValid(phone)) {
            setPhoneError('Некорректный номер телефона!');
            return;
        }
        store.registration(email, password, name, passport, phone);
        setTimeout(() => {
            if (!store.isAuth) {
                setError('Пользователь с таким Email уже зарегистрирован');
            }
        }, 1000);
    }


    if (store.isAuth) {
        return <Navigate to='/' />;
    }

    return (
        <div className="registration-form-container">
            <Form onSubmit={handleSubmit}>
                <Form.Label className="head">Регистрация</Form.Label>

                <Form.Group controlId="formBasicName">
                    <Form.Label>ФИО:</Form.Label>
                    <Form.Control type="textarea" placeholder="Введите ФИО" value={name} required onChange={(e) => setName(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="formBasicEmail">
                    <Form.Label>Email:</Form.Label>
                    <Form.Control type="email" placeholder="Введите Email" value={email} required onChange={(e) => setEmail(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="formBasicPhone">
                    <Form.Label>Телефон:</Form.Label>
                    <Form.Control type="textarea" placeholder="Введите номер телефона" value={phone} onChange={(e) => setPhone(e.target.value)} />
                    <Form.Label className="error">{phoneError}</Form.Label>
                </Form.Group>

                <Form.Group controlId="formBasicPassport">
                    <Form.Label>Паспорт:</Form.Label>
                    <Form.Control type="textarea" placeholder="Введите паспортные данные" required value={passport} onChange={(e) => setPassport(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="formBasicPassword">
                    <Form.Label>Пароль:</Form.Label>
                    <Form.Control type="password" placeholder="Введите пароль" value={password} required onChange={(e) => setPassword(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="formBasicConfirmPassword">
                    <Form.Label>Подтверждение пароля:</Form.Label>
                    <Form.Control type="password" placeholder="Подтвердите пароль" value={confirmPassword} required onChange={(e) => setConfirmPassword(e.target.value)} />
                </Form.Group>
                <NavLink tag={Link} className="textButton" to="/login">Уже есть аккаунт? Войти</NavLink>
                <button className="buttn" variant="primary" type="submit">Зарегистрироваться</button>
                <Form.Label className="error">{isError}</Form.Label>
            </Form>
        </div>
    );
}

export default observer(RegistrationForm);
