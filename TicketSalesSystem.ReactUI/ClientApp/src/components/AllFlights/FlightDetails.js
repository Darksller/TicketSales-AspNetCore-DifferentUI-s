import React, { useState, useEffect } from "react";
import './FlightDetails.css';
import axios from 'axios';


function FlightDetails({ flight }) {
    const [airlineName, setAirlineName] = useState("");
    const [departurePoint, setDeparturePoint] = useState("");
    const [arrivalPoint, setArrivalPoint] = useState("");

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


    return (
        <div className="block">
            <div className="airline-name">{airlineName}</div>
            <div className="depPoint">{departurePoint}</div>
            <div className="arrPoint">{arrivalPoint}</div>
            <div className="depTime">{formatTime(flight.departureTime)}</div>
            <div className="arrTime">{formatTime(flight.arrivalTime)}</div>
            <div className="arrow">⟶</div>
        </div>
    );
}

export default FlightDetails;
