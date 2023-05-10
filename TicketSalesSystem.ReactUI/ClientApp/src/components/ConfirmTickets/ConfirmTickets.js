import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Ticket from '../Ticket/Ticket';
import User from './User';
import './ConfirmTickets.css';

function ConfirmTickets() {
    const [tickets, setTickets] = useState([]);

    const fetchTickets = async () => {
        const response = await axios.get('/ticket/getunconfirmed');
        setTickets(response.data);
    };

    useEffect(() => {
        fetchTickets();
    }, []);

    const handleConfirmTicket = async (ticketId, userId) => {
        try {
            const response = await axios.get('/user/getbyid', { params: { id: userId } });
            const data = response.data;
            await axios.post('/email/send', { to: data.email, subject: `Билет #${ticketId} подтвержден`, text: 'Ваш билет был успешно подтвержден.' });
            await axios.put(`/ticket/update`, { Id: ticketId, isConfirmed: true });
            fetchTickets();
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="my-tickets">
            <h2>Билеты, ожидающие подтверждения:</h2>
            {tickets.length > 0 ? (
                <div>
                    {tickets.map((ticket) => (
                        <div key={ticket.id} className="ticket-user-container">
                            <Ticket ticket={ticket} />
                            <div style={{ padding: '25px' }}>
                                <User userId={ticket.userId} />
                            </div>
                            <button onClick={() => handleConfirmTicket(ticket.id, ticket.userId)}>Подтвердить билет</button>
                        </div>
                    ))}
                </div>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
}

export default ConfirmTickets;
