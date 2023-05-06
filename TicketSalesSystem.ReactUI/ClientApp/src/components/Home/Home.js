import React, { useState } from 'react';
import './Home.css';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import ru from 'date-fns/locale/ru';
import moment from 'moment-timezone';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function Home() {
    const [from, setFrom] = useState('');
    const [to, setTo] = useState('');
    const [selectedDate, setSelectedDate] = useState(null);
    const currentDate = new Date();
    const serverTimezone = 'Europe/Moscow';
    moment.tz.setDefault(serverTimezone);

    const navigate = useNavigate();

    const handleFromChange = (event) => {
        setFrom(event.target.value);
    };

    const handleToChange = (event) => {
        setTo(event.target.value);
    };

    const handleSearchClick = async () => {
        try {
            const selectedDateServerTimezone = moment(selectedDate).tz(serverTimezone);
            const depTime = selectedDateServerTimezone.format('YYYY-MM-DDTHH:mm:ss');

            const response = await axios.get(`/flight/GetFlights`, {
                params: {
                    depPoint: from,
                    arrPoint: to,
                    depTime: depTime
                }
            });
            const data = response.data;
            navigate('/search', { state: { flights: data } });
        } catch (error) {
            console.error(error);
        }

    };

    return (
        <div className="ticket-search-container">
            <h1>Поиск билетов</h1>
            <form className="ticket-search-form">
                <div className="ticket-search-form-row">
                    <input type="text" value={from} onChange={handleFromChange} placeholder="Откуда" />
                    <input type="text" value={to} onChange={handleToChange} placeholder="Куда" />
                    <label>
                        <DatePicker
                            selected={selectedDate}
                            onChange={(date) => setSelectedDate(date)}
                            dateFormat="dd.MM.yyyy"
                            placeholderText="Выберите дату"
                            minDate={currentDate}
                            locale={ru}
                        />
                    </label>
                    <button type="button" onClick={handleSearchClick}>Найти билет</button>
                </div>
            </form>

        </div>


    );
}

export default Home;
