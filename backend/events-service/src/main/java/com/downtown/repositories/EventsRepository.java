package com.downtown.repositories;

import com.downtown.models.Event;

import java.util.List;

public interface EventsRepository {
    List<Event> getAll(Boolean latest, Integer page, Integer results);

    Event getById(int id);

    List<Event> getByCity(String city, Boolean latest, Integer page, Integer results);
}
