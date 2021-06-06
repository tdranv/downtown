import { ChakraProvider } from "@chakra-ui/react";
import { Route, Switch } from "react-router";
import HomePage from "./features/HomePage/index";
import Navbar from "./features/Navbar";
import Login from "./features/Login/login";

function App() {
  return (
    <ChakraProvider>
      <Navbar />
      <Switch>
        <Route exact path="/">
          <HomePage />
        </Route>
        <Route exact path="/login">
          <Login />
        </Route>
      </Switch>
    </ChakraProvider>
  );
}

export default App;
