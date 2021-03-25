# Rocket_Elevators_REST_API

<p>
In order to connect our information system to the equipment in operation throughout the territory served, we first need to develop a REST API using C # and .NET Core.
It will allow us to know and to manipulate the status of all the relevant entities of the operational database.
</p>

<ol>
   <li>Retrieving the current status of a specific Battery</li>
   <p>https://rocketelevatorapi.azurewebsites.net/batteries/1/status</p>
   <li>Changing the status of a specific Batter</li>
   <p>Edit in postman status text:
   {
 
   "Status": "Inactive"
    }
  </p>
   <li>Retrieving the current status of a specific Column</li>
   <p>https://rocketelevatorapi.azurewebsites.net/columns/1/status</p>
   <li>Changing the status of a specific Column</li>
   <p>Edit in postman status text:
   {
 
   "Status": "Inactive"
    }</p>
   <li>Retrieving the current status of a specific Elevator</li>
   <p>https://rocketelevatorapi.azurewebsites.net/elevators/1/status</p>
   <li>Changing the status of a specific Elevator</li>
   <p>Edit in postman status text:
   {
 
   "Status": "Inactive"
    }</p>
   <li>Retrieving a list of Elevators that are not in operation at the time of the request</li>
   <p>https://rocketelevatorapi.azurewebsites.net/elevators/inactive</p>
   <li>Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention</li>
   <p>https://rocketelevatorapi.azurewebsites.net/Buildings</p>
   <li>Retrieving a list of Leads created in the last 30 days who have not yet become customers.</li>
   <p>https://rocketelevatorapi.azurewebsites.net/Leads/recent</p>
</ol>
