import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './Ticket.css';
import moment from "moment";

function Ticket({ ticket }) {
    const [airline, setAirline] = useState({});
    const [route, setRoute] = useState({})
    const [flight, setFlight] = useState({})
    const [seatType, setSeatType] = useState({})
    function formatTime(time) {
        const date = new Date(time);
        const day = date.getDate().toString().padStart(2, '0');
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const year = date.getFullYear().toString();
        const hours = date.getHours().toString().padStart(2, '0');
        const minutes = date.getMinutes().toString().padStart(2, '0');
        return `${day}.${month}.${year} ${hours}:${minutes}`;
    }

    async function fetchFlightData() {
        try {
            const response = await axios.get(`/flight/GetFlightById`, { params: { id: ticket.flightId } });
            const data = response.data;
            setFlight(data);
            return data; // Возвращаем полученные данные
        } catch (error) {
            console.error(error);
        }
    }

    async function fetchAirlineData() {
        try {
            const data = await fetchFlightData(); // Ждём завершения fetchFlightData
            const response = await axios.get(`/airline/GetAirlineById`, { params: { id: data.airlineId } });
            const airlineData = response.data;
            setAirline(airlineData);
        } catch (error) {
            console.error(error);
        }
    }

    async function fetchRouteData() {
        try {
            const data = await fetchFlightData(); // Ждём завершения fetchFlightData
            const response = await axios.get(`/route/GetRouteById`, { params: { id: data.routeId } });
            const routeData = response.data;
            setRoute(routeData);
        } catch (error) {
            console.error(error);
        }
    }

    async function fetchSeatTypeData() {
        try {
            const response = await axios.get(`/seatType/GetById`, { params: { id: ticket.seatTypeId } });
            const data = response.data;
            setSeatType(data);
        } catch (error) {
            console.error(error);
        }
    }


    useEffect(() => {
        fetchAirlineData();
        fetchRouteData();
        fetchSeatTypeData();
    }, []);


    const departureTime = flight.departureTime;
    const arrivalTime = flight.arrivalTime;
    const duration = moment.duration(moment(arrivalTime).diff(moment(departureTime)));
    const flightTimeInMinutes = duration.asMinutes();
    const hours = Math.floor(flightTimeInMinutes / 60);
    const minutes = flightTimeInMinutes % 60;

    return (
        <div className="blockk">
            <div className="ticketNumber">Номер билета: {ticket.id}</div>
            <div className="airlinee-name">{airline.name}</div>
            <div className="depPoint">{route.departurePoint}</div>
            <div className="arrPoint">{route.arrivalPoint}</div>
            <div className="depTime">{formatTime(flight.departureTime)}</div>
            <div className="arrTime">{formatTime(flight.arrivalTime)}</div>
            <div className="flightTime">Время в пути: {hours}ч {minutes}м</div>
            <div className="arrow">⟶</div>
            <div className="place">Место: {ticket.place}</div>
            <div className="seatType">{seatType.name}</div>
            {ticket.isConfirmed ?
                <div className="conf">Подтвержден</div>
                :
                <div className="conf">Ожидает Подтверждения</div>
            }
        </div>
    );

}

export default Ticket;
