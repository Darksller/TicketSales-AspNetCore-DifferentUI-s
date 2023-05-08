import React, { useState, useEffect } from "react";
import moment from "moment";
import './FlightDetails.css';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { useContext } from 'react';
import { Context } from '../../index';


function FlightDetails({ flight }) {
    const [airlineName, setAirlineName] = useState("");
    const [seatTypes, setSeatTypes] = useState([]);
    const [departurePoint, setDeparturePoint] = useState("");
    const [arrivalPoint, setArrivalPoint] = useState("");
    const navigate = useNavigate();
    const { store } = useContext(Context);

    useEffect(() => {
        axios.get(`/airline/GetAirlineById`, {
            params: { id: flight.airlineId }
        })
            .then(response => {
                const data = response.data;
                setAirlineName(data.name);
            })
            .catch(error => {
                console.error(error);
            });

        axios.get(`/seatType/GetSeatTypesByAirplaneId`, {
            params: { id: flight.airplaneId }
        })
            .then(response => {
                const data = response.data;
                const totalSeats = data.reduce((sum, seat) => sum + seat.count, 0);
                if (totalSeats > 0) {
                    setSeatTypes(data);
                }
            })
            .catch(error => {
                console.error(error);
            });

        axios.get(`/route/GetRouteById`, {
            params: {
                id: flight.routeId
            }
        })
            .then(response => {
                const data = response.data;
                setDeparturePoint(data.departurePoint);
                setArrivalPoint(data.arrivalPoint);
            })
            .catch(error => {
                console.error(error);
            });
    }, [flight.airlineId, flight.airplaneId, flight.routeId]);

    if (seatTypes.length === 0) {
        return null;
    }

    const departureTime = flight.departureTime;
    const arrivalTime = flight.arrivalTime;

    const duration = moment.duration(moment(arrivalTime).diff(moment(departureTime)));
    const flightTimeInMinutes = duration.asMinutes();
    const hours = Math.floor(flightTimeInMinutes / 60);
    const minutes = flightTimeInMinutes % 60;

    function formatTime(time) {
        const date = new Date(time);
        const day = date.getDate().toString().padStart(2, '0');
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const year = date.getFullYear().toString();
        const hours = date.getHours().toString().padStart(2, '0');
        const minutes = date.getMinutes().toString().padStart(2, '0');
        return `${day}.${month}.${year} ${hours}:${minutes}`;
    }

    const handleSelect = () => {
        if (!store.isAuth) {
            navigate('/login');
        } else {
            navigate('/buyticket', {
                state: {
                    flight: flight, airlineName: airlineName, seatTypes: seatTypes, route:
                        { departurePoint: departurePoint, arrivalPoint: arrivalPoint }
                }
            });
        }
    };

    return (
        <div className="block">
            <div className="airline-name">{airlineName}</div>
            <div className="depPoint">{departurePoint}</div>
            <div className="arrPoint">{arrivalPoint}</div>
            <div className="depTime">{formatTime(flight.departureTime)}</div>
            <div className="arrTime">{formatTime(flight.arrivalTime)}</div>
            <div className="flightTime">Время в пути: {hours}ч {minutes}м</div>
            <div className="price">Цена: {seatTypes[0].price + flight.price} - {seatTypes[seatTypes.length - 1].price + flight.price}</div>
            <div className="arrow">⟶</div>
            <button className="but" onClick={handleSelect}>Выбрать</button>
        </div >
    );
}

export default FlightDetails;
