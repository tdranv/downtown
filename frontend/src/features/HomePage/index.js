import React, { useEffect, useReducer, useRef, useState } from "react";
import "./index.css";
import { Heading, Divider, Container, Spinner } from "@chakra-ui/react";
import EventCard from "./components/EventCard";
import { EVENTS_API_URL } from "../../constants";
import useIntersectionObserver from "../../hooks/useIntersectionObserver";
import { CovidDataProvider } from "../../providers/CovidStatiscticsProvider";
import { HotelProvider } from "../../providers/HotelsProvider";

const fetchEvents = async (page) => {
  const result = await fetch(
    `${EVENTS_API_URL}/api/events?page=${page}&results=10`
  );
  return await result.json();
};

function eventsReducer(state, action) {
  switch (action.type) {
    case "fetch-start":
      if (state && state.all && state.all.length > 0) {
        return { ...state, isLoadingMore: true, isLoadingInitial: false };
      }
      return { ...state, isLoadingInitial: true, isLoadingMore: false };
    case "fetch-end":
      return {
        all: [...state.all, ...action.data],
        isLoadingInitial: false,
        isLoadingMore: false,
      };
    default:
      throw new Error();
  }
}

const HomePage = () => {
  const [page, setPage] = useState(1);
  const [ref, { entry }] = useIntersectionObserver();
  const [canFetchMore, setCanFetchMore] = useState(true);

  const isVisible = entry && entry.isIntersecting;

  const [{ all, isLoadingInitial, isLoadingMore }, dispatch] = useReducer(
    eventsReducer,
    {
      all: [],
      isLoadingInitial: false,
      isLoadingMore: false,
    }
  );

  useEffect(() => {
    if (isVisible) setPage((page) => page + 1);
  }, [isVisible]);

  useEffect(() => {
    if (!canFetchMore) return;
    async function fetchData(pageToFetch) {
      dispatch({ type: "fetch-start" });
      const events = await fetchEvents(pageToFetch);
      if (events.length === 0) setCanFetchMore(false);
      dispatch({ type: "fetch-end", data: events });
    }

    fetchData(page);
  }, [page]);

  return (
    <>
      {isLoadingInitial ? (
        <div className="spinner-container">
          <Spinner size="xl" className="spinner" />
        </div>
      ) : (
        <CovidDataProvider>
          <HotelProvider>
            <Container maxW={"7xl"} p="12">
              {all &&
                all.length > 0 &&
                all.map((event) => <EventCard key={event.id} {...event} />)}
              <Divider marginTop="5" />
            </Container>
          </HotelProvider>
        </CovidDataProvider>
      )}
      {isLoadingMore ? (
        <div className="bottom-spinner-container">
          <Spinner className="bottom-spinner" />
        </div>
      ) : null}
      {!canFetchMore ? (
        <div className="bottom-spinner-container">
          <h1>No more events</h1>
        </div>
      ) : null}
      <div ref={ref} />
    </>
  );
};

export default HomePage;
