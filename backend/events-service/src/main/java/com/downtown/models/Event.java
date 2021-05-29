package com.downtown.models;

import javax.persistence.*;
import java.sql.Date;
import java.util.Set;

@Entity
@Table(name = "events")
public class Event {

    @Id
    @Column(name = "id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "name")
    private String name;

    @ManyToOne
    @JoinColumn(name = "city_id")
    private City city;

    @Column(name = "photo_url")
    private String photoUrl;

    @Column(name = "description")
    private String description;

    @Column(name = "happens_on")
    private Date happensOn;

    @Column(name = "created_at")
    private Date createdOn;

    @ManyToMany(fetch = FetchType.EAGER)
    @JoinTable(
            name = "events_categories",
            joinColumns = @JoinColumn(name = "event_id"),
            inverseJoinColumns = @JoinColumn(name = "category_id")
    )
    private Set<EventCategory> categories;

    public Set<EventCategory> getCategories() {
        return categories;
    }

    public Date getCreatedOn() {
        return createdOn;
    }

    public Event setCreatedOn(Date createdOn) {
        this.createdOn = createdOn;
        return this;
    }

    public Event setCategories(Set<EventCategory> categories) {
        this.categories = categories;
        return this;
    }

    public int getId() {
        return id;
    }

    public Event setId(int id) {
        this.id = id;
        return this;
    }

    public String getName() {
        return name;
    }

    public Event setName(String name) {
        this.name = name;
        return this;
    }

    public City getCity() {
        return city;
    }

    public Event setCity(City city) {
        this.city = city;
        return this;
    }

    public String getPhotoUrl() {
        return photoUrl;
    }

    public Event setPhotoUrl(String photoUrl) {
        this.photoUrl = photoUrl;
        return this;
    }

    public String getDescription() {
        return description;
    }

    public Event setDescription(String description) {
        this.description = description;
        return this;
    }

    public Date getHappensOn() {
        return happensOn;
    }

    public Event setHappensOn(Date happensOn) {
        this.happensOn = happensOn;
        return this;
    }
}
