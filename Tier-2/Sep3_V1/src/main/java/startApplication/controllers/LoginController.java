package startApplication.controllers;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import startApplication.socket.Login;

import java.io.*;
import java.net.Socket;

@RestController
@RequestMapping("startApplication/api")
public class LoginController extends ControllerNeeds {

    @RequestMapping(value = "/login", method = RequestMethod.POST)
    public ResponseEntity<String> login(@RequestBody Login login) {
        try {
            Socket socket = new Socket("localhost", 4567);
            InputStream input = socket.getInputStream();
            OutputStream output = socket.getOutputStream();
            String json = objectMapper.writeValueAsString(login);
            System.out.println(json);
            byte[] toSendBytes = json.getBytes();
            int toSendLen = toSendBytes.length;
            byte[] toSendLenBytes = new byte[4];
            toSendLenBytes[0] = (byte)(toSendLen & 0xff);
            toSendLenBytes[1] = (byte)((toSendLen >> 8) & 0xff);
            toSendLenBytes[2] = (byte)((toSendLen >> 16) & 0xff);
            toSendLenBytes[3] = (byte)((toSendLen >> 24) & 0xff);
            output.write(toSendLenBytes);
            output.write(toSendBytes);

            //It will contain "Email not found" or "Password mismatched" or "Login successful"
            byte[] lenByte = new byte[4];
            input.read(lenByte,0,4);
            int len = ((lenByte[3] & 0xff) << 24 | ((lenByte[2] & 0xff) << 16) | ((lenByte[1] & 0xff) << 8) | ((lenByte[0] & 0xff)));
            byte[] recieved = new byte[len];
            input.read(recieved,0,len);


            String responseFromTier3 = new String(recieved,0,len);
            if (responseFromTier3.equals("Email not found") || responseFromTier3.equals("Password mismatched")) {
                return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Try again!");

            } else {
                return ResponseEntity.status(HttpStatus.OK).body("Login successful");
            }

        } catch (IOException e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Try again!");

        }


    }


}
