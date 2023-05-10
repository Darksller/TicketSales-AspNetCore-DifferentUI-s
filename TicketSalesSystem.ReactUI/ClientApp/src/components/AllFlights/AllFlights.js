import React, { useEffect, useState } from "react";
import axios from "axios";
import FlightDetails from "./FlightDetails";

function AllFlights() {
    const [flights, setFlights] = useState([]);

    useEffect(() => {
        axios.get("/flight/getall")
            .then(response => {
                setFlights(response.data);
            })
            .catch(error => {
                console.log(error);
            });
    }, []);

    return (
        <div>
            {flights.map(flight => (
                <FlightDetails key={flight.id} flight={flight} />
            ))}
        </div>
    );
}

export default AllFlights;
