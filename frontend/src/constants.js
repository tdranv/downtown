const isDev = !process.env.NODE_ENV || process.env.NODE_ENV === "development";
export const EVENTS_API_URL = isDev
  ? "http://localhost:8080"
  : "https://downtown-backend-downtown.azuremicroservices.io/";
