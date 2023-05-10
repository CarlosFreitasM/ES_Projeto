import React from 'react';
import Header from '../../components/Header';
import SignInForm from '../../components/SignInForm';
import Footer from '../../components/Footer';

function SignIn() {
    return (

        <div id="page-container">
            <div id="content-wrap">
                <div class='Rectangle'>
                    <Header />
                    <SignInForm />
                    <Footer />
                </div>
            </div>
        </div>
    )
}

export default SignIn;