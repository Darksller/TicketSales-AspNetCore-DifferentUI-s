import React from "react";
import { useLocation } from 'react-router-dom';

const ThankYouMessage = () => {
    const { state } = useLocation();
    const name = state.name;
    return (
        <div className="thank-you-message">
            <h2>Спасибо, {name}!</h2>
            <p>Мы благодарим Вас за покупку билета. Желаем Вам приятного времяпрепровождения!</p>
        </div>
    );
};

export default ThankYouMessage;
