import React from 'react';
import ReservationForm from './reservation.jsx';
import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';

class Main extends React.Component{
    render(){
        return (<div>
            <div className="content">
                <Header text="Бронирование"/>
                <ReservationForm
                    workers={this.props.workers}
                    getWorkers={this.props.getWorkers}
                    captchaKey={this.props.captchaKey}
                    changeWorker={this.props.changeWorker}
                    worker={this.props.worker}
                    addReservation={this.props.addReservation}
                />
            </div>
            <Footer/>
        </div>);
    }
};
export default Main;