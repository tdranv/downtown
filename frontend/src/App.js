import { ChakraProvider } from "@chakra-ui/react";
import HomePage from "./features/HomePage/index";
import Navbar from "./features/Navbar";

function App() {
  return (
    <ChakraProvider>
      <Navbar />
      <HomePage />
    </ChakraProvider>
  );
}

export default App;
