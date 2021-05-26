import { ChakraProvider } from '@chakra-ui/react';
import HomePage from './features/HomePage';

function App() {
  return (
    <ChakraProvider>
      <HomePage />
    </ChakraProvider>
  );
}

export default App;
