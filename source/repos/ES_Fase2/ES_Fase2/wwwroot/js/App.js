import React, { Component } from 'react';
import './App.css';
import {
    BrowserRouter as Router,
    Routes,
    Route
} from "react-router-dom";

import Home from './Home';
import Categorias from './Categorias';
import Votar from './Votar';
import SignIn from './SignIn';
import Login from './Login'

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
