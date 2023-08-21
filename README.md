# Hotel-Management-Reservation
# Task
Develop software for hotel operations. In any modern hotel
There is a large number of possible variants of guests' occupancy: all rooms differ by
categories (superluxe, deluxe, etc.), the number of rooms in a room, the number of beds in each room, as well as the arrangement of rooms - for example, the presence of TV, refrigerator, refrigerator, etc.).
rooms, as well as the arrangement of the rooms - for example, the presence of a TV, refrigerator, telephone,
telephone. The hotel administrator's duties include selection of the most suitable for the guest accommodation, registration of guests, reception of guests, taking into account the presence of TV, refrigerator and telephone.
accommodation option, registration of guests, receipt of payment for accommodation, issuance of receipts,
check-out of departing guests. The possibility of the guest's departure earlier than the time specified at the registration is also taken into account, and a re-scheduling is made.
check-in period, and a recalculation is made. There is also a reservation service
room reservation service.
# Description
The program consists of several classes. Let's look at each class and describe their features and purpose:

Class ClassClients: represents a customer in the hotel.
The ClassClients class has various properties that represent different attributes of the client, such as first name, last name, patronymic, passport number, date of birth, country, city, address, check-in date, check-out date, information about work/study, availability of rooms, cash payment information, receipt number, VIP status, and notes.
The [Key] attribute is used to mark the ClientID property as the primary key in the underlying data store.
Properties have get and set methods that generate the PropertyChanged event when the property value changes.
The OnPropertyCanged method is a helper method that raises the PropertyChanged event. It uses the [CallerMemberName] attribute to automatically pass the name of the property that is being changed.
The PropertyChanged event is declared as part of the implementation of the INotifyPropertyChanged interface.
In addition, there is a List<ClassClients>, called clients defined as static, which can contain a collection of ClassClients objects. 
The implementation of the INotifyPropertyChanged interface allows you to bind data and notify about changes when properties are updated. 

Class ClassRooms: represents a room (hotel room).
The ClassRooms class has the Number, Floor, Price, RoomCount, RoomType, BedCount, HasTV, HasRefrigerator, HasBalcony, and HasAirConditioner properties. These properties represent different aspects of a room, such as room number, floor, price, room count, room type, bed count, and whether it has amenities such as TV, refrigerator, balcony, and air conditioning.
Each property has a getter method and a setter method. The setter methods raise the PropertyChanged event when the property value changes.
The OnPropertyChanged method is a helper method that raises the PropertyChanged event. It uses the [CallerMemberName] attribute to automatically pass the name of the property that is being changed.
The [Key] attribute is used to mark the NumberID property as a primary key in the underlying data store. This indicates that this property uniquely identifies each room entity.
The PropertyChanged event is declared as part of the implementation of the INotifyPropertyChanged interface.  The implementation of the INotifyPropertyChanged interface allows you to bind data and notify about changes when properties are updated. 

Class ClassReceptions: represents the receptionist.
The ClassReceptions class has properties for RecName, RecSurname, RecPatronymic, RecPassportId, RecDateOfBirth, RecCountry, RecCity, RecAddress, RecEnglish, RecUkrainian, RecExperience, RecPrWork, RecDate, RecLogin, and RecJobTitle. These properties represent various aspects of the receptionist, such as first name, last name, passport number, date of birth, address, language skills, experience, login, password, and job title.
Properties have get and set methods that generate a PropertyChanged event when the value of a property changes.
The OnPropertyCanged method is a helper method that raises the PropertyChanged event. It uses the [CallerMemberName] attribute to automatically pass the name of the property that is being changed.
The PropertyChanged event is declared as part of the implementation of the INotifyPropertyChanged interface.
The [Key] attribute is used to mark the WorkerID property as the primary key in the underlying data store.
The implementation of the INotifyPropertyChanged interface allows you to bind data and notify about changes when properties are updated. 

ClassLogin: represents the user login information.
This class is responsible for storing login credentials, such as email and password, for different users of the system. It can have properties for storing the user's role or access level (administrator, receptionist) and methods for verifying credentials.
The ClassLogin class has properties for JobTitle, Password, and Email.
These properties have get and set methods that generate a PropertyChanged event when the property value changes.
The OnPropertyCanged method is a helper method that raises the PropertyChanged event. It uses the [CallerMemberName] attribute to automatically pass the name of the property that is being changed.
The PropertyChanged event is declared as part of the implementation of the INotifyPropertyChanged interface.
The [Key] attribute is used to indicate the Id property as the primary key in the underlying data store.
The implementation of the INotifyPropertyChanged interface allows you to bind data and notify about changes in properties when they are updated.

Class ClassReservations: represents a reservation made by a client.
The ClassReservations class has the Number, Type, BookingStart, BookingEnd, BookingStatus, Name, and Surname properties. These properties represent various aspects of the reservation, such as the reservation number, type, booking period, status, and the name and surname of the person who made the reservation.
Each property has a getter method and a setter method. The setter methods generate a PropertyChanged event when the value of the property changes.
The OnPropertyChanged method is a helper method that raises the PropertyChanged event. It uses the [CallerMemberName] attribute to automatically pass the name of the property that is being changed.
The [Key] attribute is used to mark the BookedBy property as the primary key in the underlying data store. It's important to note that in the code snippet you've seen, the BookedBy property is of type string, which is an unusual choice for a primary key. Typically, primary keys are numeric types, such as int or Guid. You may want to reconsider the data type for your primary key depending on your specific requirements.
The PropertyChanged event is declared as part of the implementation of the INotifyPropertyChanged interface.
Implementation of the INotifyPropertyChanged interface allows you to bind data and notify changes when properties are updated.

The "AddClientWindow" window. 
Contains event handlers and logic for adding a client.
It has two properties: Client of type ClassClients and Reserv of type ClassReservations. These properties are used to store information about the client and the reservation.

The AddClientWindow constructor receives a ClassClients object as a parameter and initializes the window. It sets the DataContext to the Client object and creates a new ClassReservations object.

The AddButton_Click event handler is called when the Add button is clicked. It executes the necessary logic to add a client.
Inside the event handler, values from text fields and other controls are received and assigned to the appropriate properties of the Client object.
Similarly, values from some text fields are assigned to the properties of the Reserv object.

The DialogResult property of the window is set to true to indicate that the client has been successfully added, and the window is closed.

The ClearButton_Click event handler is called when the Clear button is clicked. It clears the text fields and resets the selected values of the controls. The DialogResult property is set to false, which indicates that the operation has been canceled and the window is closed.
In general, it processes the interaction with the user and executes the necessary logic to add a client in response to button presses in the "AddClientWindow" window.

The "AddReceptionWindow" window.
Contains event handlers and logic for adding a receptionist. 
As a property of the window, a ClassReceptions object named Reception is declared.

The constructor AddReceptionWindow(ClassReceptions reception) is defined. It initializes the window and sets the Reception property to the provided reception object. The data context of the window is set to the Reception object, which allows you to bind data between the controls and the object.

The AddButton_Click event handler is defined. It is triggered when you click on the "Add" button. Inside the event handler, values from text fields, date switches, and checkboxes are assigned to the corresponding properties of the Reception object.

The ClearButton_Click event handler is defined. It is triggered when the Clear button is clicked. Inside the event handler, the text fields are cleared, and the selected values of the checkboxes and date switches are reset.
Event handlers are set for buttons in XAML markup using the Click attribute.
In general, the code provides the logic for processing user interaction with the controls in the "AddReceptionWindow" window and updating the Reception object accordingly.
The provided code is a code file for an XAML window (AddNumberWindow.xaml). It contains event handlers for button clicks and some additional logic. Here is the code breakdown:
"AddNumberWindow".
It has two properties defined: Room of type ClassRooms and Reserv of type ClassReservations.

The AddNumberWindow(ClassRooms room) constructor is defined, which receives a ClassRooms object as a parameter. It initializes the Room property, sets the data context for the Room object, creates a new instance of ClassReservations and assigns the Reserv property to it.

The AddButton_Click event handler is called when the "Add" button is clicked. It receives values from the input controls (text fields, combo boxes, checkboxes) and assigns them to the properties of the Room and Reserv objects. Then it sets the DialogResult of the window to true, indicating that the button was clicked successfully.

The ClearButton_Click event handler is called when the "Clear" button is clicked. It clears the values of the input controls by setting them to an empty state or resetting the selected index/validated state.

The code file processes button presses and updates the Room and Reserv objects with the values entered by the user in the interface.

The "FindClientWindow" window contains event handlers and properties related to the functionality of the window. 

The FindClientWindow class is declared, which represents the code for the window. It is inherited from the Window class.

Inside the class is the FindClientWindow() constructor, which is called when a window instance is created. It calls the InitializeComponent() method, which initializes the window and its controls.

After the constructor, several properties are defined to receive the values of the filters entered by the user. Each property corresponds to a specific control and returns the text or state of that control.

The SearchButton_Click event handler is executed when the Search button is clicked. It sets the DialogResult property of the window to true, indicating that the search operation should continue, and then closes the window.

The CancelButton_Click event handler is executed when the Cancel button is clicked. It sets the DialogResult property of the window to false, indicating that the search operation has been canceled, and then closes the window.

In general, this code controls the interaction and behavior of the controls in the FindClientWindow. It receives the filter values entered by the user and provides event handlers for the search and cancel buttons.

The "FindNumberWindow" window contains event handlers and properties associated with the controls defined in the XAML code. 

The constructor of the FindNumberWindow class is implemented. It calls the InitializeComponent method, which initializes the window and its controls.

Properties are defined for each filtering criterion. These properties provide access to the values entered by the user in the corresponding controls.

The NumberFilter property receives the text entered in the NumberTextBox control.

The NumberOfRoomsFilter and FloorNumberFilter properties return the selected item from the NumberOfRoomsSlider and FloorNumberTextBox controls, respectively.

The HasTVFilter, HasRefrigeratorFilter, HasBalconyFilter, and HasAirConditionerFilter properties return the state of the corresponding CheckBox controls.

The RoomTypeFilter and NumberOfBedsFilter properties return the selected item from the TypeComboBox and NumberOfBedsSlider controls, respectively.

The SearchButton_Click event handler is implemented. It sets the DialogResult property to true and closes the window when the search button is clicked.

The CancelButton_Click event handler is implemented. It sets the DialogResult property to false and closes the window when the cancel button is clicked.

This code provides functionality for handling events and getting values from the controls in the FindNumberWindow.

The FindReceptionWindow contains event handlers and properties associated with the controls defined in the XAML file. 

The FindReceptionWindow class is a partial class that represents the code that underlies the FindReceptionWindow.

The constructor (FindReceptionWindow()) is called when an instance of the window is created. It initializes the window by calling the InitializeComponent() method, which is automatically generated and initializes the controls defined in the XAML file.

The properties defined in the class correspond to the filters for finding administrators. Each property gets a value from the corresponding control in the XAML file.


The event handlers for the search button and the cancel button are implemented in the SearchButton_Click and CancelButton_Click methods, respectively. When the search button is clicked, the DialogResult property is set to true, which means that the search operation was successful and the window closes. Similarly, when the cancel button is clicked, the DialogResult property is set to false, which indicates that the search operation was canceled and the window is closed.

This code provides the functionality of the FindReceptionWindow, allowing you to get the values of the search filters entered by the user and handle button click events.

The code you provided is a code file for the LogonWindow in a WPF application. It contains the event handlers and logic for the window. Here is an explanation of the code:

The "LogonWindow" window is a partial class that represents the code file for LogonWindow.xaml.

Two private fields are declared in the class: receptionistLogin and adminLogin, which are used to store login information for the administrator and the receptionist, respectively.

The LogonWindow constructor is called when an instance of the window is created. It calls the InitializeComponent method to initialize the window components, and then calls the LoadLoginFromDatabase method to populate the login dictionaries from the database.

The LoadLoginFromDatabase method retrieves the login information from the database using an ApplicationContext instance. It queries the Login table and fills in the receptionistLogin and adminLogin dictionaries based on job titles.

The LoginButton_Click event handler is triggered when the Login button is clicked. It receives the email and password entered by the user from the text fields.

The method checks whether the email exists in the receptionistLogin or adminLogin dictionaries and checks whether the entered password matches the saved password for the corresponding email.

If the login is successful, an instance of the MainWindow is created and the user's position is passed as a parameter. After that, a new window is displayed and the current login window is hidden.

If the login fails, a window is displayed with a message that the user has entered an invalid email address or password.

This code controls the login functions of the LogonWindow and interacts with the database to retrieve login information.
