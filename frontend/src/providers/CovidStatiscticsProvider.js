import * as React from "react";
import { COVID_API_URL } from "../constants";

const CovidDataContext = React.createContext();

function useCovidData() {
  const context = React.useContext(CovidDataContext);
  if (!context) {
    throw new Error(`useCount must be used within a HotelProvider`);
  }
  return context;
}

function CovidDataProvider(props) {
  const [covidData, setCovidData] = React.useState([]);

  React.useEffect(() => {
    async function fetchData() {
      const data = await fetch(`${COVID_API_URL}/covidStatistics`);
      const json = await data.json();
      setCovidData(json);
    }

    fetchData();
  }, []);

  const value = React.useMemo(
    () => [covidData, setCovidData],
    [covidData, setCovidData]
  );

  return <CovidDataContext.Provider value={value} {...props} />;
}

export { CovidDataProvider, useCovidData };
