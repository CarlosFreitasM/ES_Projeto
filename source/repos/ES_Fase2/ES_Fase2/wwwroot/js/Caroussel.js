import React from 'react';
import Carousel from 'react-bootstrap/Carousel';

function Caroussel() {
    return (
        <Carousel>
            <Carousel.Item>
                <a href="/"><img className="d-block w-100" src="pao.jfif" alt="First slide" width="400" height="450"/></a>
            </Carousel.Item>
            <Carousel.Item>
                <a href="/"><img className="d-block w-100" src="Pao-caseiro.jpg" alt="Second slide" width="400" height="450"/></a>
            </Carousel.Item>
            <Carousel.Item>
                <a href="/"><img className="d-block w-100" src="pao-frances.jpg" alt="Third slide" width="400" height="450"/></a>
            </Carousel.Item>                    
        </Carousel>
    )
}

export default Caroussel;