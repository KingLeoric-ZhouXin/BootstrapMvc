var Login = function () {

    return {
        //main function to initiate the module
        init: function () {

            $('.login-form').validate({
                errorElement: 'label', //default input error message container
                errorClass: 'help-inline', // default input error message class
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
                        required: "请输入登录名"
                    },
                    password: {
                        required: "请输入密码"
                    }
                },

                highlight: function (element) { // hightlight error inputs
                    $(element).closest('.control-group').addClass('error'); // set error class to the control group
                },

                success: function (label) {
                    label.closest('.control-group').removeClass('error');
                    label.remove();
                },

                errorPlacement: function (error, element) {
                    error.addClass('help-small no-left-padding').insertAfter(element.closest('.input-icon'));
                }
            });

            $('.forget-form').validate({
                errorElement: 'label', //default input error message container
                errorClass: 'help-inline', // default input error message class
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
                        required: "请输入Email"
                    }
                },

                highlight: function (element) { // hightlight error inputs
                    $(element).closest('.control-group').addClass('error'); // set error class to the control group
                },

                success: function (label) {
                    label.closest('.control-group').removeClass('error');
                    label.remove();
                },

                errorPlacement: function (error, element) {
                    error.addClass('help-small no-left-padding').insertAfter(element.closest('.input-icon'));
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

            $('.register-form').validate({
                errorElement: 'label', //default input error message container
                errorClass: 'help-inline', // default input error message class
                focusInvalid: false, // do not focus the last invalid input
                ignore: "",
                rules: {
                    username: {
                        required: true
                    },
                    password: {
                        required: true
                    },
                    rpassword: {
                        equalTo: "#register_password"
                    },
                    email: {
                        required: true,
                        email: true
                    }
                },

                messages: { // custom messages for radio buttons and checkboxes
                    username: {
                        required: "请输入登录名"
                    },
                    password: {
                        required: "请输入密码"
                    },
                    rpassword: {
                        equalTo: "和密码不同"
                    },
                    email: {
                        required: "请输入电子游戏"
                    }
                },

                invalidHandler: function (event, validator) { //display error alert on form submit   

                },

                highlight: function (element) { // hightlight error inputs
                    $(element)
                        .closest('.control-group').addClass('error'); // set error class to the control group
                },

                success: function (label) {
                    label.closest('.control-group').removeClass('error');
                    label.remove();
                },

                errorPlacement: function (error, element) {
                    if (element.attr("name") == "tnc") { //eslint-disable-line
                        // insert checkbox errors after the container
                        error.addClass('help-small no-left-padding').insertAfter($('#register_tnc_error'));
                    } else {
                        error.addClass('help-small no-left-padding').insertAfter(element.closest('.input-icon'));
                    }
                },

                submitHandler: function (form) {
                    window.location.href = "index.html";
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

    };

}();

var Sub = function () {
    return {
        init: function () {

            //登录
            $('#subLogin').click(function () {
                var json = {
                    username: encodeURI($('.login-form [name="username"]').val()),
                    password: encodeURI($('.login-form [name="password"]').val())
                };
                submit("login", "GET", json, '.login-form');
            });

            //查找密码
            $('#subFindPwd').click(function () {
             
                submit("login", "GET", '', '.forget-form');
            });

            //注册
            $('#subRegister').click(function () {
                submit("login", "GET", '', '.register-form');
            });
        }
    };
}();

function submit(action, method, json, from) {
    var thisfrom = $(from);
    if (thisfrom.valid()) {
        $.ajax({
            url: "../api/login/" + action,
            type: method,
            data: json,
            dataType: "json",
            success: function (data, textStatus) {
                if (data.success) {
                    alert(data.msg);
                } else {
                    alertMessage(data.msg);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

            }
        });
    }
}

function alertMessage(message) {
    $('#alertMessage').text(message);
    $('#alertModal').modal('show');
}