package com.downtown.models;

import javax.persistence.*;

@Entity
@Table(name = "categories")
public class EventCategory {

    @Id
    @Column(name = "category_id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "name")
    private String name;

    public int getId() {
        return id;
    }

    public EventCategory setId(int id) {
        this.id = id;
        return this;
    }

    public String getName() {
        return name;
    }

    public EventCategory setName(String name) {
        this.name = name;
        return this;
    }
}
