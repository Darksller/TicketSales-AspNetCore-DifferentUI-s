import React, { useEffect, useState } from 'react';
import './Footer.css';

function Footer() {
    const [isVisible, setIsVisible] = useState(false);

    useEffect(() => {
        const handleScroll = () => {
            const isBottom = window.innerHeight + window.scrollY >= document.body.offsetHeight;
            setIsVisible(isBottom);
        };

        window.addEventListener('scroll', handleScroll);
        return () => {
            window.removeEventListener('scroll', handleScroll);
        };
    }, []);

    return (
        <footer className={`footer ${isVisible ? 'show' : ''}`}>
            <p>© 2023, My Awesome Company</p>
        </footer>
    );
}

export default Footer;
