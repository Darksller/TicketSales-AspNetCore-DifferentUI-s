import Home from "./components/Home/Home";
import LoginForm from "./components/LoginForm/LoginForm";
import RegistrationForm from "./components/RegistrationForm/RegistrationForm";
import SearchResults from "./components/FlightDetails/SearchResults"
import MyTickets from "./components/MyTickets/MyTickets";
import BuyTicket from "./components/BuyTicket/BuyTicket";
import ThankYouMessage from "./components/Thanks/ThankYouMessage";
import ConfirmTickets from "./components/ConfirmTickets/ConfirmTickets"
import AllFlights from "./components/AllFlights/AllFlights";
const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/search',
        element: <SearchResults />
    },
    {
        path: '/login',
        element: <LoginForm />
    },
    {
        path: '/registration',
        element: <RegistrationForm />
    },
    {
        path: '/mytickets',
        element: <MyTickets />
    },
    {
        path: '/buyticket',
        element: <BuyTicket />
    },
    {
        path: '/ThankYouMessage',
        element: <ThankYouMessage />
    },
    {
        path: '/confirmTickets',
        element: <ConfirmTickets />
    },
    {
        path: '/allflights',
        element: <AllFlights />
    }

];

export default AppRoutes;
