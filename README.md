# Library
# Instruction how to use this API
After executing this Api you will see Swagger page. Using this page you can test this Api 
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
