import {
  Box,
  Flex,
  Avatar,
  HStack,
  Link,
  IconButton,
  Button,
  Menu,
  MenuButton,
  MenuList,
  MenuItem,
  MenuDivider,
  useDisclosure,
  useColorModeValue,
  Stack,
} from "@chakra-ui/react";
import { HamburgerIcon, CloseIcon } from "@chakra-ui/icons";
import { useEffect, useState } from "react";
import { EVENTS_API_URL } from "../../constants";
import { COMMENTS_API_URL } from "../../constants";
import { Link as RouteLink } from "react-router-dom";
import firebase from "firebase";
import "firebase/auth";

const Links = ["Dashboard", "Projects", "Team"];

const NavLink = ({ children }) => (
  <Link
    px={2}
    py={1}
    rounded={"md"}
    _hover={{
      textDecoration: "none",
      bg: useColorModeValue("gray.200", "gray.700"),
    }}
    href={"#"}
  >
    {children}
  </Link>
);

const fetchWeather = async () => {
  const result = await fetch(`${EVENTS_API_URL}/api/weather?city=sofia`);
  return await result.json();
};

export default function Navbar() {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const [weatherData, setWeatherData] = useState();
  const [userData, setUserData] = useState();

  useEffect(() => {
    async function fetchData() {
      const data = await fetchWeather();
      setWeatherData(data);
    }
    fetchData();
  }, []);

  useEffect(() => {
    firebase.auth().onAuthStateChanged((user) => {
      setUserData(() => user);
    });
  }, []);

  return (
    <>
      <Box bg={useColorModeValue("gray.100", "gray.900")} px={4}>
        <Flex h={16} alignItems={"center"} justifyContent={"space-between"}>
          <IconButton
            size={"md"}
            icon={isOpen ? <CloseIcon /> : <HamburgerIcon />}
            aria-label={"Open Menu"}
            display={{ md: "none" }}
            onClick={isOpen ? onClose : onOpen}
          />
          <HStack spacing={8} alignItems={"center"}>
            <HStack
              as={"nav"}
              spacing={4}
              display={{ base: "none", md: "flex" }}
            >
              <Link
                px={2}
                py={1}
                rounded={"md"}
                _hover={{
                  textDecoration: "none",
                  bg: useColorModeValue("gray.200", "gray.700"),
                }}
                href={"/"}
              >
                Home
              </Link>
              <Link
                px={2}
                py={1}
                rounded={"md"}
                _hover={{
                  textDecoration: "none",
                  bg: useColorModeValue("gray.200", "gray.700"),
                }}
                href={`${COMMENTS_API_URL}/rss`}
              >
                RSS
              </Link>
            </HStack>
          </HStack>
          <Flex alignItems={"center"}>
            <Box pr={50} style={{ float: "right" }}>
              {weatherData && weatherData !== null
                ? `Currently in Sofia it feels like ${weatherData.main.feels_like}°C`
                : null}
            </Box>
            {!userData ? (
              <RouteLink to="/login">Login</RouteLink>
            ) : (
              <HStack spacing={2} alignItems={"center"}>
                <Avatar
                  size={"sm"}
                  src={
                    "https://thekindlife.com/wp-content/uploads/2020/08/bill-stephan-og0C_9Mz6RA-unsplash.jpg"
                  }
                />
                <h2>
                  {userData.displayName} (
                  <Link href="#" onClick={() => firebase.auth().signOut()}>
                    Logout
                  </Link>
                  )
                </h2>
              </HStack>
            )}
          </Flex>
        </Flex>

        {isOpen ? (
          <Box pb={4} display={{ md: "none" }}>
            <Stack as={"nav"} spacing={4}>
              {Links.map((link) => (
                <NavLink key={link}>{link}</NavLink>
              ))}
            </Stack>
          </Box>
        ) : null}
      </Box>
    </>
  );
}
