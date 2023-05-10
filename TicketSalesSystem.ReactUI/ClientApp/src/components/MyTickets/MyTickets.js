import React, { useState, useEffect, useContext } from 'react';
import axios from 'axios';
import './MyTickets.css';
import EditUser from './EditUser';
import { Context } from '../../index';
import Ticket from '../Ticket/Ticket';

function MyTickets() {
    const [tickets, setTickets] = useState([]);
    const { store } = useContext(Context);

    useEffect(() => {
        const fetchTickets = async () => {
            const response = await axios.get('/user/getbyemail', { params: { email: store.user.email } });
            setTickets(response.data.tickets);
        };
        fetchTickets();
    }, [store.user.email]);

    return (
        <>
            <EditUser />
            <div className="my-tickets">
                <h2>Мои билеты:</h2>
                {tickets.length > 0 ? (
                    <div>
                        {tickets.map((ticket) => (
                            <Ticket ticket={ticket} />
                        ))}
                    </div>
                ) : (
                    <p>Loading...</p>
                )}
            </div>
        </>
    );

}

export default MyTickets;
