import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import firebase from "firebase/app";
import "firebase/auth";
import { BrowserRouter } from "react-router-dom";

var firebaseConfig = {
  apiKey: "AIzaSyAyMgMuKktGLOeq-yfx9B-xtVHiZK0DMdI",
  authDomain: "downtown-app-su.firebaseapp.com",
  projectId: "downtown-app-su",
  storageBucket: "downtown-app-su.appspot.com",
  messagingSenderId: "508110562672",
  appId: "1:508110562672:web:ede86cd108a152354c9bb5",
  measurementId: "G-Z2F797HT7N",
};

firebase.initializeApp(firebaseConfig);
const auth = firebase.auth();

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
