/*$(document).ready(function () {

    $('#btn_login').click(function () {
        $('#popup').show().css({ display: 'block' });
        username = $('#username').val();
        password = $('#password').val();
        $.ajax({
            type: "POST",
            url: "/SetupServices.svc/StudentLogin",
            data: '{"username":"' + username + '", "password":"' + password + '"}',
//            data: '{"username":"ram","password":"ram1"}',
            dataType: "json",
            contentType: "application/json",
            success: function (data) {
                $.each(data, function (i, item) {
                    var msg = item.message;
                    var code = item.errorcode;
                    if (code == 0) {
                        window.location.href = "/login.aspx?username="+ msg +"";
                    }
                    else {
                        window.location.href = "/login.aspx";
                    }

                });
            },
            error: function (data) {
                alert('Error occured : ' + data.responseText);
                $('#popup').hide();
            },
            failure: function () { alert('Failed'); }
        });
    });
    return false;
});
*/


var Login = function () {

    var handleLogin = function () {

        //ajax login function to be called right after the form validation success

        var ajaxLogin = function (form) {
            $('#popup').show().css({ display: 'block' });
            form = $(form);
            var password_ = $('#password').val();
            var username_ = $('#username').val();

            $.ajax({
                type: "POST",
                url: "/LService.asmx/LoginUser",
                data: '{"userName":"' + username_ + '","UserPassword":"' + password_ + '"}',
                dataType: "json",
                contentType: "application/json",
                beforeSend: function () {
                    $('.alert-danger,.alert-success').hide();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                    $('.alert-danger').show();
                    $('.alert-danger span').html(errorThrown);
                    $('#popup').hide();
                },
                success: function (data) {
                    data = JSON.parse(data);
                    console.log(data);
                    if (data[0].errorcode == "1") {
                        var id = data[0].userid;
                        username_ = data[0].username;

                        window.location.href = "login.aspx?userID=" + id + "&username=" + username_
                    }
                    else {
                        $('#popup').hide();
                        alert(data[0].message);

                    }


                    $('.alert-success').show().css({ display: 'block' });

                    $('.alert-success span').html(data);
                }
            });
        }

        $('.login-form').validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            rules: {
                username: {
                    required: true
                },
                password: {
                    required: true
                },
                remember: {
                    required: false
                }
            },

            messages: {
                username: {
                    required: "Username is required."
                },
                password: {
                    required: "Password is required."
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   
                $('.alert-danger', $('.login-form')).show();
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
	                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            errorPlacement: function (error, element) {
                error.insertAfter(element.closest('.input-icon'));
            },

            submitHandler: function (form) {
                ajaxLogin(form); // form validation success, call ajax form submit
            }
        });

        $('.login-form input').keypress(function (e) {
            if (e.which == 13) {
                if ($('.login-form').validate().form()) {
                    ajaxLogin($('.login-form')); //form validation success, call ajax form submit
                }
                return false;
            }
        });
    }

    var handleForgetPassword = function () {
        $('.forget-form').validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                email: {
                    required: true,
                    email: true
                }
            },

            messages: {
                email: {
                    required: "Email is required."
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   

            },

            highlight: function (element) { // hightlight error inputs
                $(element)
	                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            errorPlacement: function (error, element) {
                error.insertAfter(element.closest('.input-icon'));
            },

            submitHandler: function (form) {
                form.submit();
            }
        });

        $('.forget-form input').keypress(function (e) {
            if (e.which == 13) {
                if ($('.forget-form').validate().form()) {
                    $('.forget-form').submit();
                }
                return false;
            }
        });

        jQuery('#forget-password').click(function () {
            jQuery('.login-form').hide();
            jQuery('.forget-form').show();
        });

        jQuery('#back-btn').click(function () {
            jQuery('.login-form').show();
            jQuery('.forget-form').hide();
        });

    }

    var handleRegister = function () {

        function format(state) {
            if (!state.id) return state.text; // optgroup
            return "<img class='flag' src='assets/img/flags/" + state.id.toLowerCase() + ".png'/>&nbsp;&nbsp;" + state.text;
        }


        $("#select2_sample4").select2({
            placeholder: '<i class="fa fa-map-marker"></i>&nbsp;Select a Country',
            allowClear: true,
            formatResult: format,
            formatSelection: format,
            escapeMarkup: function (m) {
                return m;
            }
        });


        $('#select2_sample4').change(function () {
            $('.register-form').validate().element($(this)); //revalidate the chosen dropdown value and show error or success message for the input
        });



        $('.register-form').validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {

                fullname: {
                    required: true
                },
                email: {
                    required: true,
                    email: true
                },
                address: {
                    required: true
                },
                city: {
                    required: true
                },
                country: {
                    required: true
                },

                username: {
                    required: true
                },
                password: {
                    required: true
                },
                rpassword: {
                    equalTo: "#register_password"
                },

                tnc: {
                    required: true
                }
            },

            messages: { // custom messages for radio buttons and checkboxes
                tnc: {
                    required: "Please accept TNC first."
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   

            },

            highlight: function (element) { // hightlight error inputs
                $(element)
	                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            errorPlacement: function (error, element) {
                if (element.attr("name") == "tnc") { // insert checkbox errors after the container                  
                    error.insertAfter($('#register_tnc_error'));
                } else if (element.closest('.input-icon').size() === 1) {
                    error.insertAfter(element.closest('.input-icon'));
                } else {
                    error.insertAfter(element);
                }
            },

            submitHandler: function (form) {
                form.submit();
            }
        });

        $('.register-form input').keypress(function (e) {
            if (e.which == 13) {
                if ($('.register-form').validate().form()) {
                    $('.register-form').submit();
                }
                return false;
            }
        });

        jQuery('#register-btn').click(function () {
            jQuery('.login-form').hide();
            jQuery('.register-form').show();
        });

        jQuery('#register-back-btn').click(function () {
            jQuery('.login-form').show();
            jQuery('.register-form').hide();
        });
    }

    return {
        //main function to initiate the module
        init: function () {

            handleLogin();
            handleForgetPassword();
            handleRegister();

        }

    };

} ();

