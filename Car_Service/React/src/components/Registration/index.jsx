import React from 'react';
import Form from './form.jsx';
import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';

class Registration extends React.Component{
    render(){
        return (<div>
            <Header text="Регистрация"/>
            <Form registration={this.props.registration} />
            <Footer/>
        </div>);
    }
};
export default Registration;