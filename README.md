  In this application, your users will be able to:

    Select an animal type to view a random animal of that type
    Save their favorite animals
    View a list of their favorite animals

  Home Page - When users first visit your web app, they will see:

    A drop-down list of animal types
      This list is populated via an array of animal types. -- to do. Currently not in array
    A link that takes them to a list of any favorited animals
    A count of the number of favorited animals

  Animal View -

    Once an animal is selected from the drop-down list, the application will display a random
      pet of the selected animal type.
    This will require a call to the PetFinder API. --Done
    The pet details should include at least:
      An image of the pet
      The name of the pet
      The complete description of the pet

  Favorites Button -

    In addition, the user will have access to a button that adds the current pet to a list of favorites.
    The list of favorites will be saved to a database.
    The data needed includes:
      pet ID
      pet name
      pet image URL
      the first 100 characters of the pet's description

  Your Favorites View -

    When users navigate to this page, they will see a list of all of the animals they have favorited.
    This list will be pulled from the database.

Hard Mode -

  Get fancy! Use your own CSS styles to make this amazing!

Pro Mode -

  Modify the Favorites view to display animals grouped by animal type.
