import React, { useState } from 'react';
import './BuyTicket.css';
import moment from "moment";
import { useLocation } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import axios from "axios";
import { useContext } from 'react';
import { Context } from '../../index';

function BuyTicket() {
    const { state } = useLocation();
    const flight = state.flight;
    const seatTypes = state.seatTypes;
    const route = state.route;
    const airlineName = state.airlineName;
    const navigate = useNavigate();
    const { store } = useContext(Context);

    function formatTime(time) {
        const date = new Date(time);
        const day = date.getDate().toString().padStart(2, '0');
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const year = date.getFullYear().toString();
        const hours = date.getHours().toString().padStart(2, '0');
        const minutes = date.getMinutes().toString().padStart(2, '0');
        return `${day}.${month}.${year} ${hours}:${minutes}`;
    }
    const departureTime = flight.departureTime;
    const arrivalTime = flight.arrivalTime;
    const duration = moment.duration(moment(arrivalTime).diff(moment(departureTime)));
    const flightTimeInMinutes = duration.asMinutes();
    const hours = Math.floor(flightTimeInMinutes / 60);
    const minutes = flightTimeInMinutes % 60;

    const [selectedSeatTypePrice, setSelectedSeatType] = useState(seatTypes[0].price);
    const [selectedPrice, setSelectedPrice] = useState(flight.price + selectedSeatTypePrice);
    function handleSeatTypeChange(event) {
        setSelectedSeatType(event.target.value);
        setSelectedPrice(parseInt(flight.price) + parseInt(event.target.value));

    }

    const [showConfirmation, setShowConfirmation] = useState(false);
    function handleBuyTicket() {
        setShowConfirmation(true);
    }

    async function handleConfirm() {
        const response = await axios.get('/user/getbyemail', { params: { email: store.user.email } });
        const user = response.data;

        const selectedSeatType = seatTypes.find((seatType) => parseInt(seatType.price) === parseInt(selectedSeatTypePrice));
        navigate('/ThankYouMessage', {
            state: { name: user.name }
        });
        setShowConfirmation(false);
        await axios.post("/ticket/buyticket", {
            price: selectedPrice,
            userId: user.id,
            flightId: flight.id,
            seatTypeId: selectedSeatType.id,
            isConfirmed: false
        });
        await axios.post('/email/send', { to: user.email, subject: `Билет зарезервирован`, text: `Билет на сумму ${selectedPrice} был зарезервирован, номер билета можно посмотреть в личном кабинете\nОжидайте подтверждения` });
        
    }

    function handleCancel() {
        setShowConfirmation(false);
    }

    return (
        <div>
            <div className="block">
                <div className="airline-name">{airlineName}</div>
                <div className="depPoint">{route.departurePoint}</div>
                <div className="arrPoint">{route.arrivalPoint}</div>
                <div className="depTime">{formatTime(flight.departureTime)}</div>
                <div className="arrTime">{formatTime(flight.arrivalTime)}</div>
                <div className="flightTime">Время в пути: {hours}ч {minutes}м</div>
                <div className="arrow">⟶</div>
            </div >


            <div className="seat-type-panel">
                {seatTypes.map((type) =>
                (type.count > 0 &&
                    <label key={type.id} className={`seat-type-item ${type.id}`}>
                        <input
                            type="radio"
                            name="seatType"
                            value={type.price}
                            onChange={handleSeatTypeChange}
                            defaultChecked={type === seatTypes[0]}
                        />
                        <div className="seat-type-item-content">
                            <div className="seat-type-name">{type.name}</div>
                            <div className="seat-type-price">Цена: {type.price} руб</div>
                        </div>
                    </label>
                ))
                }
            </div>
            <div className="ticket-price">Цена билета: {selectedPrice} руб</div>

            <button className="buy-ticket-button" onClick={handleBuyTicket}>
                Купить билет
            </button>
            {showConfirmation &&
                <React.Fragment>
                    <div className="confirmation-overlay"></div>
                    <div className="confirmation-panel">
                        <p>Вы уверены, что хотите купить билет?</p>
                        <button onClick={handleConfirm}>Да</button>
                        <button onClick={handleCancel}>Нет</button>
                    </div>
                </React.Fragment>
            }

        </div>
    );
}

export default BuyTicket;
