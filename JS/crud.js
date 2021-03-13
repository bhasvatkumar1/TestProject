function register() {
    var stdObj = {
        UserName: $('#UserName').val(),
        Password: $('#Password').val(),
        UserEmailAddress: $('#UserEmailAddress').val()
       
    };

    $.ajax({
        url: "/Account/Register",
        data: {
            userViewModel: stdObj

        },
        type: "POST",
        success: function () {

            alert("Data added");
            window.location.href = "/Account/LogOn";
        },
        error: function () {
            alert("Data is not inserted");
          
        }
    });

}

function logon() {

    var stdObj = {
        UserName: $('#UserName').val(),
        Password: $('#Password').val(),
        RememberMe: $('#RememberMe').prop('checked')
    };


    $.ajax({
        url: "/Account/LogOn",
        data: { user: stdObj },
        type: "POST",
        success: function (data) {

            console.log(data);
            alert("Logged In Successfully");
            window.location.href = "/Product/Index";
        },
        error: function () {
            alert("Failed to LogOn");
            window.location.href = "/Account/Register";
        }
    });

}

function changepassword() {

    var stdObj = {
        //UserId: $('#UserId').val(),
        Password: $('#Password').val(),
        NewPassword: $('#NewPassword').val(),
        ConfirmPassword: $('#ConfirmPassword').val()
    };


    $.ajax({
        url: "/Account/ChangePassword",
        data: { model: stdObj },
        type: "POST",
        success: function (data) {

            console.log(data);
            alert("Password is chnaged successfully");
            window.location.href = "/Account/ChangePasswordSuccess";
        },
        error: function () {
            alert("Failed to chnage password");
            window.location.href = "/Account/LogOn";
        }
    });

}

$(function () {
    $('.btn-update').click(function () {
        var element = this;

        $('#loadingElement').show();


        $.ajax({
            type: 'GET',
            url: '/Manage/UpdateRole',
            data: { 'userId': $(this).attr('data-id'), 'roleId': $(element).prev().val() },
            dataType: 'json',
            success: function () {
                $('#loadingElement').hide();
                alert('Updated the role successfully.');
            },
            error: function (req, status, err) {
                alert('unable to update the role, sorry, pls. try again... ' + err);
                $('#loadingElement').hide();
            }
        });
    });
});

function Addcategory() {

    var stdObj = {

        CategoryName: $('#CategoryName').val()
        
    };


    $.ajax({
        url: "/Category/Add",
        data: {
            categoryViewModel: stdObj

        },
        type: "POST",
        success: function () {

            alert("Category added successfully");
            window.location.href = "/Category/Index";
        },
        error: function () {
            alert("Category is not inserted");

        }
    });

}

function Update() {

    var stdObj = {
        CategoryId: $('#CategoryId').val(),
        CategoryName: $('#CategoryName').val()
       
    };

    $.ajax({
        url: "/Category/Edit",
        data: { categoryViewModel: stdObj },
        type: "POST",
        dataType: "json",
        success: function () {

            alert("Data is edited");
            window.location.href = "/Category/Index";
        },
        error: function () {
            alert("Data is not edited");
        }
    });

}

function Delete(CategoryId) {


    $.ajax({
        url: "/Category/Delete/" + CategoryId,
        type: "POST",
        
        success: function () {

            alert("Data Deleted");
            window.location.href = "/Category/Index";
        },
        error: function () {
            alert("Data is not Deleted");
        }
    });

}

function Addproduct() {

    var stdObj = {

        CategoryId: $('#CategoryId').val(),
        ProductName: $('#ProductName').val(),
        ProductPrice: $('#ProductPrice').val()

    };


    $.ajax({
        url: "/Product/Add",
        data: {
            productViewModel: stdObj

        },
        type: "POST",
        success: function () {

            alert("Product added successfully");
            window.location.href = "/Product/Index";
        },
        error: function () {
            alert("Product is not inserted");

        }
    });

}

function UpdateProduct(){

    var stdObj = {

        ProductId: $('#ProductId').val(),
        CategoryName: $('#CategoryName').val(),
        ProductName: $('#ProductName').val(),
        ProductPrice: $('#ProductPrice').val()

    };

    $.ajax({
        url: "/Product/Edit",
        data: { productViewModel: stdObj },
        type: "POST",
        dataType: "json",
        success: function () {

            alert("Data is edited");
            window.location.href = "/Product/Index";
        },
        error: function () {
            alert("Data is not edited");
        }
    });

}

function DeleteProduct(ProductId) {


    $.ajax({
        url: "/Product/Delete/" + ProductId,
        type: "POST",

        success: function () {

            alert("Data Deleted");
            window.location.href = "/Product/Index";
        },
        error: function () {
            alert("Data is not Deleted");
        }
    });

}