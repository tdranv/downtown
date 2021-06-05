package com.downtown.services;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

import static java.lang.String.format;

@Service
public class WeatherServiceImpl implements WeatherService {

    @Value("${weather-api.key}")
    private String apiKey;
    @Value("${weather-api.url}")
    private String apiUrl;

    public WeatherServiceImpl() {
    }

    @Override
    public String getWeatherForCity(String cityName) throws IOException, InterruptedException {
        var client = HttpClient.newHttpClient();
        var request = HttpRequest.newBuilder(
                URI.create(format("%s/weather?q=%s&appid=%s&units=metric", apiUrl, cityName, apiKey)))
                .header("accept", "application/json")
                .build();

        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

        return response.body();
    }

}