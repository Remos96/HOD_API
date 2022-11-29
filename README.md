# House of the Dragon API

### Information about the repository

This repository focuses on some of main characters in HBO's House of the Dragon season 1.

#### Endpoints & HTTP Methods

- GET: 
    -  `api/character` ---> Displays all characters in database. 
    -  `api/character/{id}` ---> Displays specific character.
    -  `api/house` ---> Displays all houses.

- POST
    - `api/character/{id}` ---> Update a characters information.

- DELETE
    - `api/character/{id}` ---> Delete a specific character.

#### Attributes
###### Character

    {
      "characterID": 2,
      "fullName": "Rhaenyra Targaryen",
      "gender": "Female",
      "dob": 97,
      "dragon": "Syrax",
      "houseID": 1
    }
###### House
    {
        "houseID": 1, 
        "houseName": Targaryen,
        "slogan": "Fire and Blood."
    }


