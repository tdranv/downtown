package com.downtown.services;

import java.io.IOException;

public interface WeatherService {
    String getWeatherForCity(String cityName) throws IOException, InterruptedException;
}
