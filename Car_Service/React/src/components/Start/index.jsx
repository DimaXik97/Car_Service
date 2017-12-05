import React from 'react';
import Header from './../../containers/header.js';
import Footer from './../Footer/index.jsx';
import Content from './content.jsx';

class Start extends React.Component{
    render(){
        return (<div>
        <Header/>
        <Content/>
        <Footer/>
        </div>);
    }
};
export default Start;