import { createContext, useContext } from "react";

const CovidDataContext = createContext(null);

export const useCovidData = (city) => {
  const context = useContext(CovidDataContext);

  return context;
};

export default function CovidDataProvider({ city, props }) {
  console.log(city);

  return <CovidDataContext.Provider value={{}} {...props} />;
}
