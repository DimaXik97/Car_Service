import React from 'react';
import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';
import Content from './content.jsx';

class Start extends React.Component{
    render(){
        return (<div>
            <div className="content">
                <Header text="Добро пожаловать в Car Service"/>
                <Content/>
            </div>
            <Footer/>
        </div>);
    }
};
export default Start;