//import { debug } from "util";

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$('#btCheck').click(function () {
    console.log($("#mytext").val());

    //call to API to check
    $.ajax({
        url: "http://localhost:10750/api/PalindromeCheck",
        type: "POST",
        data: JSON.stringify($("#mytext").val()),
        dataType: "json",
        contentType: "application/json"
    })
        .done(function (data) {
            
            if (data) {
                $("#myresult").html("this is a palindrome");
            }
            else {
                $("#myresult").html("this is <b>NOT</b> a palindrome");
            }
        });
});

$('#btClear').click(function () {
    $("#mytext").val("");
    $("#mytext").focus();
    $("#myresult").html("");
});

$('#btOpen').click(function () {

    $.ajax({
        url: "http://localhost:10750/api/PalindromeCheck",
        type: "GET",
        //data: JSON.stringify($("#mytext").val()),
        dataType: "json",
        contentType: "application/json"
    })
        .done(function (data) {
            
            var content = "<ol>";
            for (var i = 0; i < data.length; i++) {
                content = content + "<li>" + data[i] + "</li>";
            }
            content = content + "</ol>";
            
            $('#mymodalbody').html(content);

            $('#exampleModalLong').modal('show');
        });

    //$('#exampleModalLong').modal('show');
});


