package startApplication.controllers;

import com.fasterxml.jackson.core.type.TypeReference;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpMethod;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestTemplate;
import startApplication.DbModel.AddressDb;
import startApplication.DbModel.CityDb;
import startApplication.DbModel.EventDb;
import startApplication.DbModel.UserDb;
import startApplication.ViewModel.EventVm;
import startApplication.ViewModel.UserVm;
import startApplication.controllers.ControllerNeeds;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;


@RestController
@RequestMapping("/startApplication/api")
public class UserController extends ControllerNeeds
{
    private List<UserDb> users = new ArrayList<>();
    private List<UserVm> usersView = new ArrayList<>();

    @RequestMapping(value = "/newUser", method = RequestMethod.POST)
    public ResponseEntity<?> createUser(@RequestBody UserVm userVm)
    {
        System.out.println(userVm+"User sent from view");

        UserDb userDb = new UserDb(userVm.getFirstName(),userVm.getLastName(),userVm.getEmailAddress(),userVm.getDob(),userVm.getPassword());

        System.out.println(userDb+"User in db");

        var response = restTemplate.postForObject("https://localhost:5001/api/users/newUser", userDb, UserDb.class);
        System.out.println(userVm);

        System.out.println("Sent!");
        return ResponseEntity.status(HttpStatus.CREATED).body(response);

    }


    @RequestMapping(value = "/updateUser", method = RequestMethod.POST)
    public ResponseEntity<?> updateUser(@RequestBody UserVm userVm)
    {
        System.out.println(userVm);

        UserDb userDb = new UserDb(userVm.getUserId(),userVm.getFirstName(),userVm.getLastName(),userVm.getEmailAddress(),userVm.getDob(),userVm.getPassword());

        System.out.println(userDb);
        HttpEntity<UserDb> eventHttpEntity = new HttpEntity<>(userDb);

        var response = restTemplate.postForObject("https://localhost:5001/api/users/newUser", userDb, UserDb.class);

        System.out.println("Sent!");
        return ResponseEntity.status(HttpStatus.CREATED).body(response);

    }






    @RequestMapping(value = "/userEmail", method = RequestMethod.GET)
    public Object getUserbyEmail(@RequestParam(value = "email") String email) {

        if (email != null) {

            String users = restTemplate.getForObject("https://localhost:5001/api/users/userEmail?email=" + email, String.class);

            try {
                List<UserDb> usersFromDatabase = objectMapper.readValue(users, new TypeReference<List<UserDb>>() {
                });

                List<UserVm> usersForView = new ArrayList<>();

                for (UserDb userDb : usersFromDatabase) {

                    UserVm userVm = new UserVm(userDb.getUserId(),userDb.getFirstName(),userDb.getLastName(),userDb.getEmailAddress(),userDb.getDob());
                    usersForView.add(userVm);

                }

                return ResponseEntity.status(HttpStatus.OK).body(usersForView);


            } catch (IOException e) {
                e.printStackTrace();

            }
        }
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Try again!");
    }

    @RequestMapping(value = "/allUsers", method = RequestMethod.GET)
    public ResponseEntity<?> getAllUsers() {

        String users = restTemplate.getForObject("https://localhost:5001/api/users/allUsers", String.class);

        System.out.println(users+"users from db");
            try {
                List<UserDb> usersFromDatabase = objectMapper.readValue(users, new TypeReference<List<UserDb>>() {
                });

                List<UserVm> usersForView = new ArrayList<>();

                for (UserDb userDb : usersFromDatabase) {

                    UserVm userVm = new UserVm(userDb.getUserId(),userDb.getFirstName(),userDb.getLastName(),userDb.getEmailAddress(),userDb.getDob());
                    usersForView.add(userVm);

                }
                System.out.println(usersForView+"users sent back to view");
                return ResponseEntity.status(HttpStatus.OK).body(usersForView);


            } catch (IOException e) {
                e.printStackTrace();

            }
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("");


    }



}
