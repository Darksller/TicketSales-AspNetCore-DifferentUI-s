import React, { useEffect, useState } from "react";
import axios from "axios";
import FlightDetails from "./FlightDetails";
    
function AllFlights() {
    const [flights, setFlights] = useState([]);

    const fetchFlights = async () => {
        try {
            const response = await axios.get("/flight/getall");
            setFlights(response.data);
        } catch (error) {
            console.log(error);
        }
    };
    fetchFlights();


    return (
        <div>
            {flights.map(flight => (
                <FlightDetails key={flight.id} flight={flight} />
            ))}
        </div>
    );
}

export default AllFlights;
