import { useState, useEffect } from "react";
import axios from 'axios';
import { Card } from 'react-bootstrap';

function User({ userId }) {
    const [user, setUser] = useState({});

    useEffect(() => {
        const fetchUser = async () => {
            const response = await axios.get('/user/getbyid', { params: { id: userId } });
            setUser(response.data);
        };
        fetchUser();
    }, [userId]);

    return (

        <Card style={{ width: '250px', boxShadow: '2px 2px 10px rgba(0, 0, 0, 0.2)' }}>
            <Card.Body>
                <Card.Title>{user.name}</Card.Title>
                <Card.Text>
                    <strong>Email:</strong> {user.email}<br />
                    <strong>Passport:</strong> {user.passport}<br />
                    <strong>Phone:</strong> {user.phone}<br />
                </Card.Text>
            </Card.Body>
        </Card>

    );
}

export default User;
