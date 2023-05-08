import React, { useState, useEffect, useContext } from 'react';
import axios from 'axios';
import { Context } from '../../index';
import './MyTickets.css';

function EditUser() {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [phone, setPhone] = useState('');
    const [passport, setPassport] = useState('');
    const [isEditing, setIsEditing] = useState(false);
    const [user, setUser] = useState({})
    const { store } = useContext(Context);
    const [phoneError, setPhoneError] = useState('');

    const isPhoneValid = (phone) => {
        const phonePattern = /^[+]*[(]?[0-9]{1,4}[)]?[-\s./0-9]*$/;
        return phonePattern.test(phone);
    }

    useEffect(() => {
        async function getUserData() {
            const response = await axios.get('/user/getbyemail', { params: { email: store.user.email } });
            const userData = response.data;
            setUser(userData)
            setName(userData.name);
            setEmail(userData.email);
            setPhone(userData.phone);
            setPassport(userData.passport);
        }
        getUserData();
    }, [store.user.email]);

    const handleEdit = () => {

        setIsEditing(true);
    };


    const handleSave = async () => {
        if (!isPhoneValid(phone)) {
            setPhoneError('Некорректный номер телефона!');
            return;
        }

        const response = await axios.put('/user/updateuser', {
            name: name,
            email: email,
            phone: phone,
            passport: passport
        });
        if (response.data) {
            setIsEditing(false);
        }

    };

    const handleCancel = () => {
        setName(user.name);
        setPhone(user.phone);
        setPassport(user.passport);
        setIsEditing(false);
        setPhoneError(' ')
    };

    const handleChangeName = (event) => {
        setName(event.target.value);
    };

    const handleChangePhone = (event) => {
        setPhone(event.target.value);
    };

    const handleChangePassport = (event) => {
        setPassport(event.target.value);
    };

    return (
        <div className="containr">
            <h4>Личные данные</h4>
            <div className="field">
                <label className="lab" htmlFor="name">Имя: </label>
                {isEditing ? (
                    <input id="name" type="text" value={name} onChange={handleChangeName} />
                ) : (
                    <span>{name}</span>
                )}
            </div>
            <div className="field">
                <label className="lab" htmlFor="email">Email: </label>
                <span>{email}</span>
            </div>
            <div className="field">
                <label className="lab" htmlFor="phone">Телефон: </label>
                {isEditing ? (
                    <><input id="phone" type="text" value={phone} onChange={handleChangePhone} /><label className="error">{phoneError}</label></>
                ) : (
                    <span>{phone}</span>
                )}
            </div>
            <div className="field">
                <label className="lab" htmlFor="passport">Паспорт: </label>
                {isEditing ? (
                    <input id="passport" type="text" value={passport} onChange={handleChangePassport} />
                ) : (
                    <span>{passport}</span>
                )}
            </div>
            {isEditing ? (
                <div>
                    <button onClick={handleSave}>Сохранить</button>
                    <button onClick={handleCancel}>Отмена</button>
                </div>
            ) : (
                <button className="field" onClick={handleEdit}>Редактировать</button>
            )}
        </div>
    );
}

export default EditUser;
