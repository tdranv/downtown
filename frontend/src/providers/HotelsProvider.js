import * as React from "react";
import { HOTELS_API_URL } from "../constants";

const HotelContext = React.createContext();

function useHotels() {
  const context = React.useContext(HotelContext);
  if (!context) {
    throw new Error(`useCount must be used within a HotelProvider`);
  }
  return context;
}

function HotelProvider(props) {
  const [hotels, setHotels] = React.useState([]);

  React.useEffect(() => {
    async function fetchHotels() {
      const data = await fetch(`${HOTELS_API_URL}/hotels`);
      const json = await data.json();
      setHotels(json);
    }

    fetchHotels();
  }, []);

  const value = React.useMemo(() => [hotels, setHotels], [hotels]);

  return <HotelContext.Provider value={value} {...props} />;
}

export { HotelProvider, useHotels };
