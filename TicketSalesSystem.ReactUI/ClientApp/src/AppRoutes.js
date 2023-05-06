import Home from "./components/Home/Home";
import LoginForm from "./components/LoginForm/LoginForm";
import RegistrationForm from "./components/RegistrationForm/RegistrationForm";
import SearchResults from "./components/FlightDetails/SearchResults"

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

];

export default AppRoutes;
