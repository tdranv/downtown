package com.downtown.repositories;

import com.downtown.models.Event;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.query.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class EventsRepositoryImpl implements EventsRepository {

    private final SessionFactory sessionFactory;

    @Autowired
    public EventsRepositoryImpl(SessionFactory sessionFactory) {
        this.sessionFactory = sessionFactory;
    }

    @Override
    public List<Event> getAll(Boolean latest, Integer page, Integer results) {
        try (Session session = sessionFactory.openSession()) {
            String baseQuery = "from Event ";
            if (latest == Boolean.TRUE) baseQuery = "from Event " + "order by createdOn desc";
            var s = session.createQuery(baseQuery, Event.class);
            return applyPaginationArguments(s, page, results).list();
        }
    }

    @Override
    public Event getById(int id) {
        try (Session session = sessionFactory.openSession()) {
            return session.get(Event.class, id);
        }

    }

    @Override
    public List<Event> getByCity(String city, Boolean latest, Integer page, Integer results) {
        try (Session session = sessionFactory.openSession()) {
            var baseQuery = "from Event where city.name = :cityName" + (latest ? "order by createdOn desc" : "");
            var s = session.createQuery(baseQuery, Event.class).setParameter("cityName", city);
            return applyPaginationArguments(s, page, results).list();
        }
    }

    private Query<Event> applyPaginationArguments(Query<Event> baseQuery, Integer page, Integer results) {
        if (page != null) {
            var first = results != null ? results : 10;
            baseQuery.setFirstResult(page * first - first);
        }
        if (results != null) {
            baseQuery.setMaxResults(results);
        }
        return baseQuery;
    }
}
