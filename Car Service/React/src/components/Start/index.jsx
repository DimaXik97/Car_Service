import React from 'react';
import Header from './header.jsx';
import Footer from './footer.jsx';
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