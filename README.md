
# Warehouse System Demo

This demo basically covers the basics of how a warehouse infrastructure should work.
Keeping the system's database on my local machine with **Microsoft SQL Server Management Studio**,
I combined it with the ASP.NET MVC nugget package. Thus, basic user login systems, user management,
I was able to design product management, security and rapid data interaction systems.


## Dependencies

Required Applications:
- Microsoft SQL Server Management Studio
- Visual Studio 2022 w/ ASP.NET

First, transfer the database copies in the database dependency folder to **Microsoft SQL Server Management Studio**.
you need to install. .mdf files in the folder *"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA"*
After copying it to its location, you can easily install it from within the database application.

After installing our database, it is time to establish the database connection to the Model section of ASP.NET. To do this, follow the steps below in order.

1/4

![Database-Dependency](https://user-images.githubusercontent.com/73427323/211585739-906402f6-4bcf-471f-839e-86733a5d15d9.png)

2/4

![dependency png1 png](https://user-images.githubusercontent.com/73427323/211585904-4afcfa94-8636-4ee1-8eed-5fc52d27335d.png)

3/4

![dependency2](https://user-images.githubusercontent.com/73427323/211585913-547d9376-a47f-43e9-aa03-2cb164db9062.png)

After this point, you will see that your database has been successfully added to the Model folder. But in order for the Controller to recognize your database entity, make sure it is written as follows in the Web.Config file.

4/4

![dependency3](https://user-images.githubusercontent.com/73427323/211586335-7c8adb96-4348-4446-8b59-d2648bb367df.png)


Congratulations! You have connected your local database to the system and now you can run the application.

## How it works?

When you log in to the system, the login page will first appear in front of you. Here you can login using admin@admin.com and 12345 and pass Captcha verification.

***(Note: You will not be able to view the passwords in the database because the system hash the passwords of the created users. Therefore, password leaking of your users from your database cannot be performed.)***

![Screenshot_12](https://user-images.githubusercontent.com/73427323/211587269-4ec645f8-eb9e-4e23-a59a-07dec0f17233.png)

After logging in, the following simple database table design will appear in front of you. I would like to tell you about some features on this page.

![Screenshot_1](https://user-images.githubusercontent.com/73427323/211588061-d941f5c6-0b66-4ab5-8729-84d84aeac0c5.png)

As you can see, we have a repository that doesn't have much data in it. First, let's start by adding products to this warehouse.

![Screenshot_2](https://user-images.githubusercontent.com/73427323/211588284-ac870022-b254-4acb-abb4-188ce160881c.png)

When we press the **Add Product** button, the above screen will appear. In the meantime, we need to enter into the system how the products with the features we want will be kept in the database.

*(Note: You can easily change the products in the category section from the database. For the future of the project, a page can be created where the admin can add a new category)*

After adding the product, the system will direct us to our database page and show us the product we just added.

![after_add_prod](https://user-images.githubusercontent.com/73427323/211588864-2476d98b-35df-4c0c-be4e-1894fa600e60.png)

When we press the **Update Product** button, the product information will be automatically filled in the form. From here, we can easily update the product by changing the data we want.

![update](https://user-images.githubusercontent.com/73427323/211589053-e04f46b1-aaf6-4da3-a4aa-3eec9393be8e.png)

When we make a change to the brand as above, the system will look like this:

![after_update](https://user-images.githubusercontent.com/73427323/211589131-bbd417e6-2a95-4740-a330-72e6741f7b3e.png)

When we want to delete something, we need to use the **Delete Product** button. Here, when deleting the product, we need to enter its properties such as how it will be destroyed and the reason for deletion.

![delete](https://user-images.githubusercontent.com/73427323/211589428-93f28ac5-8431-46cf-9ef9-86d91b753168.png)

When we return to the system after entering the above information, we will not be able to see the deleted product in front of us. However, if we proceed to the **Deleted Items** section, we can see the history of all deleted items, by whom and on what date they were deleted automatically.

![deleted-items-page](https://user-images.githubusercontent.com/73427323/211589704-15b51938-a99d-46c8-b53d-52a75fd001ce.png)

I would like to mention that the **Add User** and **Deleted Items** buttons are only displayed for people with Admin privileges. This is controlled as follows:

![add-user_deleted-items_only-admin](https://user-images.githubusercontent.com/73427323/211589915-cc99fef5-68bf-4766-814d-8627e24076a1.png)

Also, the password hashing I mentioned in the login section works as follows:

![hash](https://user-images.githubusercontent.com/73427323/211590053-ef512a0e-7d3a-43fc-a9f7-1d06363921b8.png)

## Future Works

Things I intend to add in the future of the project:
- Writing a warning to the system when the product is low. (For example, we get a warning when our number of computers drops below 4)
- Search Bar (It may be difficult to find as the number of products in the system increases)
- Innovative design. (As I concentrate more on the back-end part of the system, it has some deficiencies in terms of design.)
- Adding/Updating a Category.
- New Captcha usage.
- Upload to a domain.



