import React from "react";
import { FirebaseAuth, StyledFirebaseAuth } from "react-firebaseui";
import firebase from "firebase";
import { Redirect } from "react-router-dom";

class Login extends React.Component {
  constructor(props) {
    super(props);
    this.uiConfig = {
      signInFlow: "popup",
      signInOptions: [firebase.auth.EmailAuthProvider.PROVIDER_ID],
      callbacks: {
        signInSuccessWithAuthResult: (result) => false,
      },
    };
    this.state = {
      isSignedIn: false,
    };
  }
  componentDidMount() {
    firebase.auth().onAuthStateChanged((user) => {
      this.setState({
        isSignedIn: !!user,
      });
    });
  }
  render() {
    return (
      <div>
        {this.state.isSignedIn ?
          <Redirect to={{ pathname: "/" }} /> :
          <div style={{ marginTop: '50px' }}>
            <StyledFirebaseAuth uiConfig={this.uiConfig} firebaseAuth={firebase.auth()} />
          </div>
        }
      </div>
    );
  }
}

export default Login;
