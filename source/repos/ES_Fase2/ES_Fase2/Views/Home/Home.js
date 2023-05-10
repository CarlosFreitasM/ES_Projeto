import React from 'react';
import Header from '../../components/Header';
import Caroussel from '../../components/Caroussel';
import Footer from '../../components/Footer';
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css';

function Home() {
    return (
        <div id="page-container">
            <div id="content-wrap">
                <div class='Rectangle'>
                <><Header />
                    <div class='caroussel'>
                        <><Caroussel /></>
                    </div>
                <></><Footer /></>
                </div>
            </div>
        </div>
    )
}

export default Home;