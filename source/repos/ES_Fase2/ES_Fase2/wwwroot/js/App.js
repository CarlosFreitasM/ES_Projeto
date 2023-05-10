import React, { Component } from 'react';
import './App.css';
import {
    BrowserRouter as Router,
    Routes,
    Route
} from "react-router-dom";

import Home from './routes/Home/Home';
import Categorias from './routes/Categorias/Categorias';
import Votar from './routes/Votar/Votar';
import SignIn from './routes/SignIn/SignIn';
import Login from './routes/Login/Login'

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    render() {
        return (
            <>
                <Router>
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/votar" element={<Votar />} />
                        <Route path="/categorias" element={<Categorias />} />
                        <Route path="/signin" element={<SignIn />} />
                        <Route path="/login" element={<Login />} />
                    </Routes>
                </Router></>
        );
    }
}
