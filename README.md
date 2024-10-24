# interview Assignment

## Assignment Description:

This following exercise is intended to help aid discussion * there are no wrong answers. You will 
have to make assumptions to complete the implementation. Please document your assumptions. 
Please limit the scope to about 2 hours (we’re not looking for a full solution – it’s up to you where 
you put the focus) and implemented in C#. Document what you have left out of the scope. 
Domain 
A Truck Plan describes a single driver driving a truck for a continuous period. For example; a five 
hour drive through Germany on a specific date. A driver is a person with a name, birthdate, etc. 
Each truck has a GPS device installed. This device provides the system with the current truck 
position approximately every 5 minutes. 
1. Design and implement a model for representing the domain. 
2. Implement functionality to calculate the approximate distance driven for a single TruckPlan. 
3. Find a way to get the country from a coordinate. A solution could, for example, be to call an 
external web service. 
4. Implement functionality for answering the following question: "How many kilometers did 
drivers over the age of 50 drive in Germany in February 2018?" 
We look forward to discussing your solution to this exercise! 
Please send us the solution in advance of the interview so we can set it up for your arrival. 

## Personal Assumptions
* TruckPlans can cross country lines
* Drivers wont change age during a truckplan
* Drivers follow google maps suggested routes
* A driver doesn't leave and return to a country between gps pings
* Google decided to give us free credits to use their API's
* A gps's first ping is at its start location


## Aspects I would improve with more time
* Null checking everything!
* Wrap most snippets in try/catch
* Logging as much as possible, levels; info, warn, error 
* Write tests, unit and integration
* Make the report more flexible, different kinds of params/filters
* A driver will often, but not always, start at his "homebase" location


## FileTree
### Models
* Driver
* GpsLocation
* TruckPlan

### Services
* LocationService
* TruckPlanReportService

### Main
* Program
 
