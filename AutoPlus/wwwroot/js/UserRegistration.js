﻿$(function () {

    $("#UserRegistrationModal input[name = 'AcceptUserAgreement']").click(onAcceptUserAgreementClick);

    $("#UserRegistrationModal button[name = 'register']").prop("disabled", true);

    function onAcceptUserAgreementClick() {
        if ($(this).is(":checked")) {
            $("#UserRegistrationModal button[name = 'register']").prop("disabled", false);
        }
        else {
            $("#UserRegistrationModal button[name = 'register']").prop("disabled", true);

        }

    }

    $("#UserRegistrationModal button[name = 'Email']").blur(function () {

        var email = $("#UserRegistrationModal button[name = 'Email']").val();

        var url = "UserAuth/UserNameExists?userName" + email;

        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                if (data == true) {
                    PresentClosableBootstrapAlert("#alert_placeholder_register", "warning", "Invalid Email", "This Email Adress has already been registered");
                    //var alertHtml = '<div class="alert alert-warning alert-dismissible fade show" role="alert">' +
                    //    '<strong>Invalid Email</strong><br>This Email Adress has already been registered' +
                    //    '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
                    //    '<span aria-hidden="true">&times;</span>' +
                    //    '</button>' +
                    //    '</div>';

                    //$("#alert_placeholder_register").html(alertHtml);
                }
                else {
                    CloseAlert("#alert_placeholder_register");
                }
            },
            error: function(xhr, ajaxOptions,thrownError){
                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
            }
        });

    });

    var registerUserButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);

    function onUserRegisterClick() {

        var url = "UserAuth/RegisterUser";


        var antiForgeryToken = $("#UserRegistrationModal input[name='__RequestVerificationToken']").val();
        var email = $("#UserRegistrationModal input[name='Email']").val();
        var password = $("#UserRegistrationModal input[name='Password']").val();
        var confirmPassword = $("#UserRegistrationModal input[name='ConfirmPassword']").val();
        var firstName = $("#UserRegistrationModal input[name='FirstName']").val();
        var lastName = $("#UserRegistrationModal input[name='LastName']").val();    
        var phoneNumber = $("#UserRegistrationModal input[name='PhoneNumber']").val();
        var city = $("#UserRegistrationModal input[name='City']").val();
        var egn = $("#UserRegistrationModal input[name='EGN']").val();
        var registerTime = $("#UserRegistrationModal input[name='RegisterTime']").val();
        


        var user = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            FirstName: firstName,
            LastName: lastName,
            PhoneNumber: phoneNumber,
            City: city,
            EGN: egn,
            RegisterTime: registerTime,
            AcceptUserAgreement: true
        };

        $.ajax({
            type: "POST",
            url: url,
            data: user,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == 'true';

                if (hasErrors) {

                    $("#UserRegistrationModal").html(data);
                    var registerUserButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);
                    
                    $("#UserRegistrationForm").removeData("validator");
                    $("#UserRegistrationForm").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("#UserRegistrationForm");
                }
                else {
                    location.href = '/Home/Index';
                }

            },
            error: function (xhr,ajaxOptions,thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
            }

        });

    }

});
