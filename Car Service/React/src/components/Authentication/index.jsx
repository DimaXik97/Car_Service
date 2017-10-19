import React from 'react';
import Form from './form.jsx';
import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';

class Authentication extends React.Component{
    render(){
        return (<div>
            <Header text="Вход"/>
            <Form/>
            <Footer/>
        </div>);
    }
};
export default Authentication;