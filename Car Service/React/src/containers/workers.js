import { connect } from 'react-redux'

import Workers from '../components/Workers/listWorker.jsx';
import {} from '../actions';

const mapStateToProps = state => ({
    workers: state.workers.workers,
    url: state.app.userURL
})

const mapDispatchToProps = dispatch => ({
    
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Workers)