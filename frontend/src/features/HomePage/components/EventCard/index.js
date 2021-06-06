import React, { useMemo } from "react";
import "./index.css";
import {
  Box,
  Heading,
  Link,
  Image,
  Text,
  HStack,
  Tag,
  useColorModeValue,
} from "@chakra-ui/react";
import CommentBox from "../CommentBox/index";
import { useHotels } from "../../../../providers/HotelsProvider";
import { useCovidData } from "../../../../providers/CovidStatiscticsProvider";

const EventCategories = ({ categories }) => {
  if (!categories || categories.length === 0) return null;
  return categories.map((category) => (
    <Tag key={category.id} size={"md"} variant="solid" colorScheme="orange">
      {category.name}
    </Tag>
  ));
};

const CityTag = (props) => {
  return (
    <Tag size={"md"} variant="solid" colorScheme="green" key={props.city}>
      {props.city}
    </Tag>
  );
};

const CovidTag = ({ cases }) => {
  return (
    <Tag
      size={"md"}
      variant="solid"
      colorScheme={parseInt(cases) / 100 < 500 ? "green" : "red"}
    >
      {`COVID19: ${cases}`}
    </Tag>
  );
};

export default function EventCard(event) {
  if (!event) return null;

  const [hotels] = useHotels([]);
  const [covidData] = useCovidData([]);

  const { photoUrl, name, description, happensOn } = event;

  const nearbyHotels = useMemo(
    () => hotels.filter((hotel) => hotel.cityId === event.city.id),
    [hotels]
  );

  const cityCovidData = useMemo(
    () => covidData.find((data) => data.name === event.city.name),
    [covidData]
  );

  return (
    <div className="event-card">
      <Box
        marginTop={{ base: "1", sm: "5" }}
        display="flex"
        flexDirection={{ base: "column", sm: "row" }}
        justifyContent="space-between"
      >
        <Box
          display="flex"
          flex="1"
          marginRight="3"
          position="relative"
          alignItems="center"
        >
          <Box
            width={{ base: "100%", sm: "85%" }}
            zIndex="2"
            marginLeft={{ base: "0", sm: "5%" }}
            marginTop="5%"
          >
            <Link textDecoration="none" _hover={{ textDecoration: "none" }}>
              <Image borderRadius="lg" src={photoUrl} objectFit="contain" />
            </Link>
          </Box>
          <Box zIndex="1" width="100%" position="absolute" height="100%">
            <Box
              bgGradient={useColorModeValue(
                "radial(orange.600 1px, transparent 1px)",
                "radial(orange.300 1px, transparent 1px)"
              )}
              backgroundSize="20px 20px"
              opacity="0.4"
              height="100%"
            />
          </Box>
        </Box>
        <Box
          display="flex"
          flex="1"
          flexDirection="column"
          justifyContent="center"
          marginTop={{ base: "3", sm: "0" }}
        >
          <div style={{ display: "flex" }}>
            <HStack spacing={2}>
              <CityTag city={event.city.name} />
              {cityCovidData ? (
                <CovidTag cases={cityCovidData.casesReported} />
              ) : null}
              <EventCategories categories={event.categories} />
            </HStack>
          </div>
          <Heading marginTop="1">
            <Link textDecoration="none" _hover={{ textDecoration: "none" }}>
              {`${name}`}
            </Link>
          </Heading>
          <Text
            as="p"
            marginTop="2"
            color={useColorModeValue("gray.700", "gray.200")}
            fontSize="lg"
          >
            {description}
          </Text>
          <CommentBox eventId={event.id} />
        </Box>
        <Box className="hotels-container">
          <h1>Hotels nearby</h1>
          {nearbyHotels
            ? nearbyHotels.map((hotel) => (
                <div key={hotel.id}>
                  <h1>
                    <a
                      href={`https://www.google.bg/search?q=${hotel.name
                        .split(" ")
                        .join("+")}`}
                    >
                      {hotel.name}
                    </a>
                  </h1>
                </div>
              ))
            : null}
        </Box>
      </Box>
    </div>
  );
}
