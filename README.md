# Parking System
This is a smart system for optimised parking.
## Project Goals
The project simulates a working parking lot that uses the console application as a way of optimisization and avoiding errors. The purpose of the application is an automated parking management system.
## Solution
Main functionality:
1. Choosing a parking space -
Users can see a list or grid of parking spaces and their current status - free/occupied, by whom they are occupied, and when the occupied parking spaces will be released.

2. Booking a parking space-
Users choose a booking option (OnDemand, Advance, Subscription) as well as the reservation duration. The method of identification is by the license plate of the vehicle.

3. Booking options -
Users can reserve a free parking space for a certain period of time according to 3 options:
- Advance reservation: Up to 1 week before the start of the reservation, users can reserve a desired free parking space for a period of 1 day to 1 week.
- OnDemand: Users can reserve a desired parking space from 1 hour to the whole day, and if they reserve during the weekend, they can stay for a duration of 1 hour until the end of the weekend (Saturday and Sunday).
- Subscription: Users can request a monthly subscription effective from the moment of saving with a duration of 30 days. When the subscription expires, the parking space is released.

4. Release of a parking space -
Users have the option to leave the car park early (without a subscription) and receive a refund of 70% of the remaining amount.

5. Price list of reservations -
The following reservation pricing applies:
- OnDemand: BGN 1 per hour.
- Advance reservation 2 or more days before the date of use: BGN 1.20 per hour,
- Advance reservation 1 day before the date of use: BGN 1 per hour.
- Subscription: BGN 168 per month.

### The program
The program has 5 main classes:
- ParkingSpot
- ParkingReservation
- ParkingLot
- Actions
- Program

1. ParkingSpot:
It contains the main properties that each parking space has:
ID/name (e.g. A1), check whether the spot is occupied or not, ID (registration number) of the vehicle occupying the spot, time until which the spot is reserved.

2. ParkingReservation:
It contains the main properties that each reservation has:
ID/name of the reserved seat, ID (registration number) of the vehicle using the spot, period of use of the spot, type of reservation.
Here is the encapsulation of each property the class has and a function which validates whether the input meets the conditions of the reservation type.

3. Parking Lot:
Creates a parking lot with a list of spaces and a list of reservations.
Here are the main activities the app does - functions for booking and realeasing a spot, as well as a list of reservations depending on the time period and a function that sums all the earnings.

4. Actions:
There are 2 base methods in this class - HandleUserActions and HandleAdminActions. They call out the other functions in the class - BookSpotInterface, ReleaseSpotInterface, ViewReservations, ViewEarnings. All of the functions represent what the user will see.

5. Program
Communicates with the user and follows the given commands.
