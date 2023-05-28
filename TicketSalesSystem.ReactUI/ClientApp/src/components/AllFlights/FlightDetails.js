import React, { useState, useEffect } from "react";
import axios from 'axios';
import './FlightDetails.css';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import ru from 'date-fns/locale/ru';
import { Form } from 'react-bootstrap';

function FlightDetails({ flight }) {
    const [airlineName, setAirlineName] = useState("");
    const [departurePoint, setDeparturePoint] = useState("");
    const [arrivalPoint, setArrivalPoint] = useState("");
    const [flightStatus, setFlightStatus] = useState("")
    const [isEditing, setIsEditing] = useState(false);
    const [editedDepartureTime, setEditedDepartureTime] = useState(null);
    const [editedArrivalTime, setEditedArrivalTime] = useState(null);
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

        axios.get(`/flightStatus/getbyid`, {
            params: {
                id: flight.flightStatusId
            }
        })
            .then(response => {
                const data = response.data;
                setFlightStatus(data);
            })
            .catch(error => {
                console.error(error);
            });

        axios.get('/flightstatus/getall')
            .then(response => {
                setFlightStatuses(response.data);
            })
            .catch(error => {
                console.log(error);
            });
    }, [flight.airlineId, flight.airplaneId, flight.routeId, flight.flightStatusId]);
    function formatTime(time) {
        const date = new Date(time);
        const day = date.getDate().toString().padStart(2, '0');
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const year = date.getFullYear().toString();
        const hours = date.getHours().toString().padStart(2, '0');
        const minutes = date.getMinutes().toString().padStart(2, '0');
        return `${day}.${month}.${year} ${hours}:${minutes}`;
    }
    const currentDate = new Date();
    let departureTimeElement = <div className="depTime">{formatTime(flight.departureTime)}</div>;
    let arrivalTimeElement = <div className="arrTime">{formatTime(flight.arrivalTime)}</div>;
    if (isEditing) {
        let newTime = new Date(editedDepartureTime);
        newTime.setHours(newTime.getHours() + 1);
        departureTimeElement = <DatePicker
            className="picker"
            selected={editedDepartureTime}
            onChange={(date) => {
                setEditedDepartureTime(date)
                newTime = new Date(date);
                newTime.setHours(newTime.getHours() + 1);
                setEditedArrivalTime(newTime)
            }}
            dateFormat="dd.MM.yyyy HH:mm"
            minDate={currentDate}
            locale={ru}
            showTimeSelect
            timeFormat="HH:mm"
            timeIntervals={15}
            timeCaption="Время"
            minTime={new Date().setHours(0, 0)}
            maxTime={new Date().setHours(23, 59)}
        />

        arrivalTimeElement = <DatePicker
            className="picker"
            selected={editedArrivalTime}
            onChange={(date) => setEditedArrivalTime(date)}
            dateFormat="dd.MM.yyyy HH:mm"
            minDate={newTime}
            locale={ru}
            showTimeSelect
            timeFormat="HH:mm"
            timeIntervals={15}
            timeCaption="Время"
            minTime={new Date().setHours(0, 0)}
            maxTime={new Date().setHours(23, 59)}
        />
    }

    function handleEditClick() {
        setIsEditing(true);
        setEditedDepartureTime(new Date())

        const newTime = new Date();
        newTime.setHours(newTime.getHours() + 1);
        setEditedArrivalTime(newTime)
        setEditedFlightStatus(1)
    }
    async function handleSaveClick() {
        if (editedArrivalTime > editedDepartureTime)
            await axios.put('/flight/update', {
                id: flight.id,
                departureTime: editedDepartureTime,
                arrivalTime: editedArrivalTime,
                flightStatusId: editedFlightStatus
            });
        setIsEditing(false);
    }
    function handleCancelClick() {
        setIsEditing(false);
    }




    const [flightStatuses, setFlightStatuses] = useState([]);
    const [editedFlightStatus, setEditedFlightStatus] = useState("");
        const handleStatusChange = (event) => {
            setEditedFlightStatus(event.target.value);
    };
    const flightStatusElement = isEditing ? (
        <Form.Select onChange={handleStatusChange} className="Form">
            {flightStatuses.map(status => (
                <option key={status.id} value={status.id}>{status.name}</option>
            ))}
        </Form.Select>
    ) : (
        <div className="status">{flightStatus.name}</div>
    );

    return (
        <div className="block">
            <div className="airline-name">{airlineName}</div>
            <div className="depPoint">{departurePoint}</div>
            <div className="arrPoint">{arrivalPoint}</div>
            {departureTimeElement}
            {arrivalTimeElement}
            <div className="status">{flightStatusElement}</div>
            <div className="buttons">
                {isEditing ? <button onClick={handleSaveClick}>Сохранить</button> : <button onClick={handleEditClick}>Изменить</button>}
                {isEditing ? <button onClick={handleCancelClick}>Отмена</button> : null}
            </div>
            <div className="arrow">⟶</div>
        </div>
    );

}

export default FlightDetails;
