import React from 'react';
import ListElement from "./../ListElement/index.jsx"

class ListWorker extends React.Component{
    constructor(props) {
        super(props);
        this.deleteElement = this.deleteElement.bind(this);
    }
    deleteElement(id){
        console.log(id);
    }
    render(){
        return (<ul className="list">
            {this.props.workers.map((element,num)=>{
                return <ListElement
                    key={num}
                    url={this.props.url}
                    element={element}
                    deleteFunc={this.deleteElement}
                />
            })}
            </ul>);
    }
};
export default ListWorker;