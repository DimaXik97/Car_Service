import React from 'react';
import ReservationForm from './../../containers/reservationForm.js';
import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';

class Main extends React.Component{
    render(){
        return (<div>
            <div className="content">
                <Header text="Бронирование"/>
                <ReservationForm/>
            </div>
            <Footer/>
        </div>);
    }
};
export default Main;