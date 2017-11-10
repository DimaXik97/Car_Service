import { connect } from 'react-redux'

import Workers from '../components/Workers/index.jsx';
import {} from '../actions';

const mapStateToProps = state => ({
    workers: state.workers.workers,
    url: state.app.workerURL
})

const mapDispatchToProps = dispatch => ({
    
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Workers)