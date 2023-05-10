import React from 'react';
import Button from '../../node_modules/react-bootstrap//Button';
import Form from '../../node_modules/react-bootstrap//Form';
import InputGroup from '../../node_modules/react-bootstrap//InputGroup';
import '../../node_modules/bootstrap/dist/css/bootstrap.min.css';

function Header() {
    return (
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark pt-3 pb-3 shadow p-3 mb-5">
            <div className="d-flex flex-row" style={{width:"700px"}}>
                <a class="navbar-brand" href="/"><img src='3658959.png' alt='logo' class='logo'></img></a>
                <div class="searchheader">
                <InputGroup className="mb-3">
                    <Form.Control
                        placeholder="Procurar"
                        aria-label="Recipient's username"
                        aria-describedby="basic-addon2"
                    />
                    <Button variant="light" id="button-addon2">
                    <img src='search-icon.png' alt='search' class='search'></img>
                    </Button>
                </InputGroup>
                </div>
                <div className="nomesnavbar">
                    <a class="navbar-brand" href="/votar">Votar</a>
                    <a class="navbar-brand" href="/categorias">Categorias</a>
                </div>
            </div>
            <div className="d-flex flex-row" style={{marginLeft:"255px"}}>
                <Button type="primary" size="lg" href="/login" > Login </Button>
                <p>esp</p>
                <Button variant="info" size="lg" href="/signin" style={{width:"100px",}} > Sign In</Button>
            </div>
        </nav>
    )
}

export default Header;