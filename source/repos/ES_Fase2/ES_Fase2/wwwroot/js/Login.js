import React from 'react';
import Header from '../../components/Header';
import LoginForm from '../../components/LoginForm';
import Footer from '../../components/Footer';

function Login() {
    return (
        <div id="page-container">
            <div id="content-wrap">
                <div class='Rectangle'>
                    <Header />
                    <LoginForm />
                    <Footer />
                </div>
            </div>
        </div>
    )
}

export default Login;