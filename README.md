# Promise Group recruitment task
## Repository description
- **WarehouseManagementSystem** -  This version of the project includes connection to the database. In order to function properly you need to use 

> <pre>update-database</pre> 
command in the package manager console.
In this version of the project you can select options by using :arrow_up: and :arrow_down: arrow keys and confirm by pressing enter 
![Arrow menu](/img/Arrow_Menu.png)
This version has seeding, i.e. upon launch, if the database has no records, the program will add few of them to the database 

- **WarehouseManagementSystemNoDb** - Version of the project, which doesnt include db connection. On every launch of the project, program initializes new empty list of the orders and performs requested functions on it. This version also includes unit tests
- **WarehouseManagementSystemNoDbTests** - 3 XUnit tests checking functionality of the ProcessToWarehouse() function 