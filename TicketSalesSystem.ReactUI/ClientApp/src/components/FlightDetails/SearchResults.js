import { useLocation } from 'react-router-dom';
import FlightDetails from './FlightDetails';

function SearchResults() {
    const { state } = useLocation();
    const flights = state.flights;

    if (flights.length === 0)
        return <h1>Подходящие билеты не найдены</h1>
    return (
        <div>
            {flights.map((flight) => (
                <FlightDetails key={flight.id} flight={flight} />
            ))}
        </div>
    );
}

export default SearchResults