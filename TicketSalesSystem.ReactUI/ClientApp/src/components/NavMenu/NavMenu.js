import { Navbar, NavbarBrand, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { Context } from '../../index';
import React, { useContext } from 'react';
import { observer } from 'mobx-react-lite';
import { useNavigate } from 'react-router-dom';

function NavMenu() {
    const { store } = useContext(Context);

    const navigate = useNavigate();

    const handleLogout = () => {
        store.logout();
        navigate('/');
    };

    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
                <NavbarBrand tag={Link} to="/">Система продажи авиабилетов</NavbarBrand>
                <ul className="navbar-nav flex-grow">
                    {store.isAdmin &&
                        <>
                            <NavItem>
                                <NavLink tag={Link} className="button" to="/allflights">Список всех рейсов</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="button" to="/confirmTickets">Подтверждение билетов</NavLink>
                            </NavItem>
                        </>
                    }
                    <NavItem>
                        <NavLink tag={Link} className="button" to="/">Поиск рейсов</NavLink>
                    </NavItem>
                    {store.isAuth ?
                        (
                            <>
                                <NavItem>
                                    <NavLink tag={Link} className="button" to="/mytickets">Личный кабинет</NavLink>
                                </NavItem>
                                <button className="button" onClick={handleLogout}>Выход</button>
                            </>
                        )
                        :
                        (
                            <>
                                <NavItem>
                                    <NavLink tag={Link} className="button" to="/login">Вход</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="button" to="/registration">Регистрация</NavLink>
                                </NavItem>
                            </>
                        )
                    }

                </ul>
            </Navbar>
        </header>
    );
}

export default observer(NavMenu);