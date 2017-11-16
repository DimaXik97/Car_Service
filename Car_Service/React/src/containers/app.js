import { connect } from 'react-redux'

import App from '../components/App/index.jsx';
import {} from '../actions';

const mapStateToProps = state => ({
   user: {role:"admin"}
})

const mapDispatchToProps = dispatch => ({
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(App)