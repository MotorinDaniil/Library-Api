# Library
# Instruction how to use this API
To open this project you can use Visual Studio.
You can clone this repository in Visual Studio.
You also need to change connection strings to connect to your Sql Server Managment Studio in files Program.cs (on line 11)
and BookContext.cs (on line 18). You need change Data Source to yours.
Then run this Api in Visual Studio.
After running this Api you will see Swagger page. Using this page you can test this Api 
On this page you can see all controllers CRUD actions:
1) Get all books (Get)
2) Create new book (Post)
3) Get book by Id (Get)
4) Get book by ISBN (Get)
5) Edit book information (Put)
6) Delete book (Delete)
   
To execute action you need to chose action, press button Try it out then press button Execute.
After you will see server response.
Bellow all the actions you can see 2 schemas(models):
1) Book - this model have all fields from Book table in database.
2) BookRequestModel - same as the book model, but not have Id field to prevent the user from changing this field
(this model is used in Create and Put actions)

