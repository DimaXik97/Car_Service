import React from 'react';


class Header extends React.Component{
    render(){
        return (<div className="head"><p>{this.props.text}</p></div>);
    }
};

export default Header;