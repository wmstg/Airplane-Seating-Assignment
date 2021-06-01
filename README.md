# Airplane Seating Assignment

## The Task
Design and implement a C# desktop application (not a client-server or database application) that
assigns seats on an airplane. Assume the airplane has 20 seats in first class (5 rows of 4 seats each,
separated by an aisle), and 180 seats in economy class (30 rows of 6 seats each, separated by an
aisle).

The application should provide the following functionality:
1. Assign seat(s) to passenger(s). When assigning seats, ask for the class (first or economy),
and the number of passengers travelling together (1 or 2 in first class, 1 to 3 in economy).
Then try to find match and assign the seats. If no match exists, display a message.
2. Display seating status (assigned & available) on the computer screen, allowing the user to
select from at least two different sorting orders, e.g. by seat numbers or by passenger names.
3. Save and retrieve the airplane’s seating state between program runs.
Page 2 of 3
4. Quit the application.
Passenger’s details are not required to be maintained by the system; however, you may add extra
features - both data and functionality to the application, if you wish.

** Provide either console-based or window-based user interface for your application

## My Implementation
![Screen3](https://user-images.githubusercontent.com/60779128/120317544-a9a6c180-c2d6-11eb-8667-aff5c9d713f0.PNG)

There are three ways to select seats in the application.
1. The Seating Manifest.
2. The Seat Availability Search.
3. The Airplane Seat Model panel.

### Airplane Seat Model
A seat can be reserved by clicking directly on a seat in the Airplane Seat Model. The selected seat will become highlighted and a prompt will appear to confirm if this seat should be reserved. Confirm by 
clicking Yes.

![Screen4](https://user-images.githubusercontent.com/60779128/120318018-3782ac80-c2d7-11eb-9ef7-8a1642c156a3.PNG)


Clicking ‘Yes’, will reserve the seat. The selected seat will change to green in the Aircraft Seat 
Model and the seat row will be highlighted in the Seating Manifest. A question mark will be in the 
Passenger name field, where the name can be entered.

### Seating Manifest
Another method to reserve a seat is by entering a passenger’s name directly into the Seating 
Manifest. The seat will be reserved, and the Airplane Seat Model panel will update.

### Seat Availability Search
The  Seat Availability Search will try and locate seats matching the specified criteria
A dialog will display if available seats have been found. If the user confirms the seat selection the 
seat(s) will be reserved.
