Alternate Project

Hotel Reservation System - Create a reservation system which books hotel rooms. It charges various rates for particular sections of the plane or hotel. Example, hotel rooms have penthouse suites which cost more. Keep track of when rooms will be available and can be scheduled.

A hotel has the following room types:

| Room Type | Sleeps | Number of Rooms | Price |
| --- | --- | --- | --- |
| Single | 1 guest | 2 | $30 |
| Double | 2 guests | 3 | $50 |
| Family | 4 guests | 1 | $85 |

Reservation requests take the form of the number of guests: \<number of guests\>

The system must respond with the available options to fulfill the reservation with the following rules:

● Multiple rooms can be proposed, for example two guests could take two Single rooms. 

● The exact number of guests in the reservation must be matched to the proposed option. For example, one guest should not be offered a Double room

● The cheapest option should be chosen as the reservation returned in the output. 

● If the reservation cannot be fulfilled, the result "No option" should be returned 

● No more than the number of rooms indicated can be assigned to a single reservation

The output format should be the following:

\<Room Type\> … \<Room Type\> - \<Total price\>

Examples

Input: 2

Output: Double - $50

Input: 3

Output: Single Double - $80

Input: 6

Output: Family Double - $135
