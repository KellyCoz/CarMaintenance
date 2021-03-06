# CarMaintenance

CarMaintenance is a C# console app designed store and display vehicle and the maintenance details for each vehicle. The console app allows for adding new vehicles,
deleting unneeded vehicles, and editing existing vehicle details. 

When the app launches, it begins with displaying two kinds of vehicles: personal and rental. 

For personal vehicles, it will also display a message pertaining to the vehicle's 'oil change status', warning the user if a vehicle is nearing time for an oil change 
(based on miles or based on date of last oil change). The app assumes the vehicle needs a change every 3,000 miles or every 3 months, whichever is first.

For rental vehicles, it will display a message pertaining to the vehicle's 'rental status', warning the user if a vehicle should be returned soon (based on rental
period) or if the vehicle is nearing mileage limits.

The user will be prompted for inputs at various points during program execution. The user will either enter a number from a list or letters found in [ ]. For example, the user will be asked to [A]dd, [E]dit, or [D]elete a vehicle and the user can type 'a' to Add, 'e' to Edit, or 'd' to Delete.

If the user doesn't choose to [Q]uit, they will be prompted to either [A]dd, [E]dit, or [D]elete a vehicle.

The user is then asked to choose which type of vehicle they want to Add, Edit or Delete by selecting  [P]ersonal or [R]ental. If editing or deleting a vehicle, the user
will submit a number corresponding to the vehicle's position in the list.

This console app was created as part of my Code Kentucky project. This app meets the following Code Kentucky Programing Pathway requirement:

1. There is a ReadMe
2. The project was commited to GitHub a minimum of 5 times.
3. The project contains at least one class that which is populated with data with the data displayed. (Personal and Rental vehicle classes.)
4. There are at least 3 methods with at least one returning a value used. (The GetVehicle(iVehicle) returns a personal and/or rental depending on how its called.)
5. The code contains at least one master loop. (The master loop is exited when the user chooses 'Q'. There is also another loop that is exited when user chooses 'S'.)
6. The project reads data from a csv, and writes data back to the csv file. (Perhaps done in a more complicated way than was necessary.)
7. There is at least one Regex validation made on user entries.
8. The code calculates and displays data (Oil change uses Date.Now to calculate how many days until the rental must be returned)
9. The app also defines and implements an interface 'iVehicle' which is used by Personal.cs and Rental.cs (Ernesto approved this an additonal feature.)
