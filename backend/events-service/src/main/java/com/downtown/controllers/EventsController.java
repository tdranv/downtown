package com.downtown.controllers;

import com.downtown.models.Event;
import com.downtown.repositories.EventsRepository;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/events")
public class EventsController {

    private final EventsRepository repository;

    public EventsController(EventsRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<Event> getAll(@RequestParam(required = false) String city,
                              @RequestParam(required = false) Boolean latest,
                              @RequestParam(required = false) Integer page,
                              @RequestParam(required = false) Integer results) {
        if (city != null) return repository.getByCity(city, latest, page, results);
        return repository.getAll(latest, page, results);
    }

    @GetMapping("/{id}")
    public Event getById(@PathVariable int id) {
        return repository.getById(id);
    }

}
