import React from 'react';

class Element extends React.Component{
    render(){
        return (<li>
            <a href={`${this.props.url}/${this.props.element.id}`}>{this.props.element.name}</a>
            {this.props.deleteBtm?<div className="deleteBtm" onClick={()=>this.props.deleteFunc(this.props.element.id)}>X</div>:undefined}
        </li>);
    }
};

Element.defaultProps = {
  deleteBtm: true
};

export default Element;