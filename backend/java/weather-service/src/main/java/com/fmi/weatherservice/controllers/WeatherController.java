package com.fmi.weatherservice.controllers;

import com.fmi.weatherservice.services.WeatherService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.io.IOException;

@RestController
@RequestMapping("/api/weather")
public class WeatherController {

    private final WeatherService weatherService;

    @Autowired
    public WeatherController(WeatherService weatherService) {
        this.weatherService = weatherService;
    }

    @GetMapping
    public ResponseEntity<String> getWeatherDataForCity(@RequestParam("city") String cityName) {
        try {
            return ResponseEntity.ok(weatherService.getWeatherForCity(cityName));
        } catch (IOException | InterruptedException e) {
            return ResponseEntity
                    .status(HttpStatus.BAD_REQUEST.value())
                    .body("Error fetching");
        }
    }
}
