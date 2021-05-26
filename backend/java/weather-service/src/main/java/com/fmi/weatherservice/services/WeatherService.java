package com.fmi.weatherservice.services;

import java.io.IOException;

public interface WeatherService {
    String getWeatherForCity(String cityName) throws IOException, InterruptedException;
}
