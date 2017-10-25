import React from 'react';
import ReservationForm from './../../containers/bookingForm.js';
import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';

class Main extends React.Component{
    render(){
        return (<div>
            <Header text="Бронирование"/>
            <ReservationForm/>
            <Footer/>
        </div>);
    }
};
export default Main;