import React from 'react';

class SelectWorker extends React.Component{
    constructor(props) {
        super(props);
        this.addWorker = this.addWorker.bind(this);
    }
    addWorker() {
        let surName= this.refs.surName.value;
        let firstName= this.refs.firstName.value;
        console.log({surName,firstName});
    }
    render(){
        return (<form>
            <input type="text" ref="surName"/>
            <input type="text" ref="firstName"/>
            <input type="submit" value="Добавить" onClick={this.addWorker}/>
        </form>);
    }
};
export default SelectWorker;