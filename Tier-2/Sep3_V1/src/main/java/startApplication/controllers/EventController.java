package startApplication.controllers;

import com.fasterxml.jackson.core.type.TypeReference;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import startApplication.DbModel.AddressDb;
import startApplication.DbModel.CityDb;
import startApplication.DbModel.EventDb;
import startApplication.ViewModel.EventVm;
import startApplication.ViewModel.UserVm;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/startApplication/api")
public class EventController extends ControllerNeeds {

    @RequestMapping(value = "/newEvent", method = RequestMethod.POST)
    public ResponseEntity<?> createEvent(@RequestBody EventVm event) {
        CityDb cityDb = new CityDb(event.getCity(), event.getPostalCode());
        AddressDb addressdb = new AddressDb(event.getStreetName(), event.getBuildingNumber(), cityDb, event.getFlatNumber(), event.getBlockNo(), event.getFloorNo());
        EventDb eventDb = new EventDb(event.getUserID(), addressdb, event.getDate(), event.getStartTime(), event.getEndTime(), event.getMaxNoOfGuests(), event.getAgeLimit(), event.isPets(), event.getDescription(), event.isEntertainment(), event.getEntryFee(), event.isDrinksVm(), event.getStarter(), event.getMainCourse(), event.getDessert());
        System.out.println(event + "Event from view");
        System.out.println(eventDb + "Event sent to database");
        var response = restTemplate.postForEntity("https://localhost:5001/api/diningEvents/newEvent", eventDb, EventDb.class);
        System.out.println("Sent!");
        return response;

    }

    @RequestMapping(value = "/eventsId", method = RequestMethod.GET)
    public Object getEventById(@RequestParam(value = "eventId") Integer eventId) {
        if (eventId != 0) {
            String events = restTemplate.getForObject("https://localhost:5001/api/diningEvents/eventsId?eventId=" + eventId, String.class);
            try {
                List<EventDb> eventsFromDatabase = objectMapper.readValue(events, new TypeReference<List<EventDb>>() {
                });
                List<EventVm> eventsForUser = new ArrayList<>();

                for (EventDb databaseEvent : eventsFromDatabase) {
                    System.out.println(databaseEvent);
                    EventVm eventForView = new EventVm(databaseEvent.getEventId(), databaseEvent.getAddress().getStreetName(), databaseEvent.getAddress().getCity().getCityName(), databaseEvent.getAddress().getCity().getPostalCode(), databaseEvent.getAddress().getBlock(), databaseEvent.getAddress().getFloor(), databaseEvent.getAddress().getFlat(), databaseEvent.getAddress().getBuildingNo(), databaseEvent.getDateOfEvent(), databaseEvent.getStartTime(), databaseEvent.getEndTime(), databaseEvent.getMaxNoOfGuests(), databaseEvent.getAgeLimit(), databaseEvent.getPets(), databaseEvent.getDescription(), databaseEvent.getEntertainment(), databaseEvent.getEntryFee(), databaseEvent.getAlcoholicDrink(), databaseEvent.getStarter(), databaseEvent.getMainCourse(), databaseEvent.getDessert());
                    eventsForUser.add(eventForView);
                }

                return ResponseEntity.status(HttpStatus.OK).body(eventsForUser);


            } catch (IOException e) {
                e.printStackTrace();

            }
        }
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Try again!");
    }


    @RequestMapping(value = "/events", method = RequestMethod.GET)
    public ResponseEntity<?> getAllEvents() {


        String events = restTemplate.getForObject("https://localhost:5001/api/diningEvents/events", String.class);
        try {
            List<EventDb> eventsFromDatabase = objectMapper.readValue(events, new TypeReference<List<EventDb>>() {
            });

            List<EventVm> eventsForUser = new ArrayList<>();

            for (EventDb databaseEvent : eventsFromDatabase) {
                System.out.println(databaseEvent);
                EventVm eventForView = new EventVm(databaseEvent.getEventId(), databaseEvent.getAddress().getStreetName(), databaseEvent.getAddress().getCity().getCityName(), databaseEvent.getAddress().getCity().getPostalCode(), databaseEvent.getAddress().getBlock(), databaseEvent.getAddress().getFloor(), databaseEvent.getAddress().getFlat(), databaseEvent.getAddress().getBuildingNo(), databaseEvent.getDateOfEvent(), databaseEvent.getStartTime(), databaseEvent.getEndTime(), databaseEvent.getMaxNoOfGuests(), databaseEvent.getAgeLimit(), databaseEvent.getPets(), databaseEvent.getDescription(), databaseEvent.getEntertainment(), databaseEvent.getEntryFee(), databaseEvent.getAlcoholicDrink(), databaseEvent.getStarter(), databaseEvent.getMainCourse(), databaseEvent.getDessert());
                eventsForUser.add(eventForView);
            }

            return ResponseEntity.status(HttpStatus.OK).body(eventsForUser);


        } catch (IOException e) {
            e.printStackTrace();

        }

        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Try again!");
    }


    @RequestMapping(value = "/search", method = RequestMethod.GET)
    public Object searchEventByCity(@RequestParam(value = "city") String city) {
        if (city != null) {
            String events = restTemplate.getForObject("https://localhost:5001/api/diningEvents/search?city=" + city, String.class);
            try {
                List<EventDb> eventsFromDatabase = objectMapper.readValue(events, new TypeReference<List<EventDb>>() {
                });

                List<EventVm> eventsForUser = new ArrayList<>();

                for (EventDb databaseEvent : eventsFromDatabase) {
                    EventVm eventForView = new EventVm(databaseEvent.getEventId(), databaseEvent.getAddress().getStreetName(), databaseEvent.getAddress().getCity().getCityName(), databaseEvent.getAddress().getCity().getPostalCode(), databaseEvent.getAddress().getBlock(), databaseEvent.getAddress().getFloor(), databaseEvent.getAddress().getFlat(), databaseEvent.getAddress().getBuildingNo(), databaseEvent.getDateOfEvent(), databaseEvent.getStartTime(), databaseEvent.getEndTime(), databaseEvent.getMaxNoOfGuests(), databaseEvent.getAgeLimit(), databaseEvent.getPets(), databaseEvent.getDescription(), databaseEvent.getEntertainment(), databaseEvent.getEntryFee(), databaseEvent.getAlcoholicDrink(), databaseEvent.getStarter(), databaseEvent.getMainCourse(), databaseEvent.getDessert());
                    eventsForUser.add(eventForView);
                }
                return ResponseEntity.status(HttpStatus.OK).body(eventsForUser);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Search again!");
    }





    @RequestMapping(value = "/cancelEvent", method = RequestMethod.POST)
    public ResponseEntity<?> cancelEvent(@RequestBody EventVm event) {

            CityDb cityDb = new CityDb(event.getCity(), event.getPostalCode());
            AddressDb addressdb = new AddressDb(event.getStreetName(), event.getBuildingNumber(), cityDb, event.getFlatNumber(), event.getBlockNo(), event.getFloorNo());
            EventDb eventDb = new EventDb(event.getUserID(), addressdb, event.getDate(), event.getStartTime(), event.getEndTime(), event.getMaxNoOfGuests(), event.getAgeLimit(), event.isPets(), event.getDescription(), event.isEntertainment(), event.getEntryFee(), event.isDrinksVm(), event.getStarter(), event.getMainCourse(), event.getDessert());
            System.out.println(event+"Event from view");
            System.out.println(eventDb+"Event sent to database");
            var response = restTemplate.postForEntity("https://localhost:5001/api/diningEvents/rEvent", eventDb, EventDb.class);
            System.out.println("Sent!");
            return response;

        }

}



