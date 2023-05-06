import { Container } from 'reactstrap';
import NavMenu from './NavMenu/NavMenu';

function Layout(props) {
    return (
        <div>
            <NavMenu />
            <Container tag="main">
                {props.children}
            </Container>
        </div>
    );
}

export default Layout;