
$(function () {
    $("form[name='registration']").validate({
        rules: {
            login: {
                required: true,
                minlength: 7,
                maxlength: 40
            },
            name: {
                required: true,
                minlength: 2,
                maxlength: 40
            },
            surname: {
                required: false,
                minlength: 2,
                maxlength: 40
            },
            email: {
                required: true,
                email: true
            },
            birthdate: {
                required: true,
                date:true
            },
            password: {
                required: true,
                minlength: 5
            },
            confirmPassword: {
                required: true,
                equalTo: "#password"
            }
        },
        messages: {
            login: {
                required: "Please enter a login!",
                minlength: "Login must contain at least 7 characters",
                maxlength: "Login must contain no more than 40 characters"
            },
            name: {
                required: "Please enter a name!",
                minlength: "Name must contain at least 2 characters",
                maxlength: "Name must contain no more than 40 characters"
            },
            surname: {
                required: "Please enter a surname!",
                minlength: "Surname must contain at least 2 characters",
                maxlength: "Surname must contain no more than 40 characters"
            },
            email: {
                required: "Please enter an email!",
                email: "Please enter correct email"
            },
            birthdate: {
                required: "Please enter the date of your birth!",
                date: "Please enter correct birthdate"
            },
            password: {
                required: "Please provide a password!",
                minlength: "Your password must be at least 5 characters long!"
            },
            confirmPassword: {
                required: "Please enter confirmation password!",
                equalTo: "Confirmation different from a password"
            }
            
        },
        submitHandler: function(form) {
            form.submit();
        }
    }),
    $("form[name='login']").validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            password: {
                required: true
            }
        },
        messages: {
            email: {
                required: "Please enter an email!",
                email: "Please enter correct email"
            },
            password: {
                required: "Please provide a password!"
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    }),
    $("form[name='program']").validate({
        rules: {
            programName: {
                required: true,
                minlength: 6,
                maxlength: 50
            },
            description: {
                required: true,
                minlength: 6,
                maxlength: 300
            },
            price: {
                number:true
            },
            age: {
                digits: true,
                min: 10,
                max:18
            }
        },
        messages: {
            programName: {
                required: "Please enter a program name!",
                minlength: "Program name must contain at least 6 characters",
                maxlength: "Program name must contain no more than 50 characters"
            },
            description: {
                required: "Please enter a description!",
                minlength: "Description name must contain at least 6 characters",
                maxlength: "Description name must contain no more than 300 characters"
            },
            price: {
                number: "Price must be decimal type (x.xx)"
            },
            age: {
                digits: "Digits only!",
                min: "Min age restriction - 10",
                max: "Max age restriction - 18"
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    }),
    $("form[name='contact']").validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            message: {
                required: true,
                maxlength: 500
            }
        },
        messages: {
            email: {
                required: "Please enter an email!",
                email: "Please enter correct email"
            },
            message: {
                required: "Please enter a message!",
                maxlength: "Message name must contain no more than 500 characters"
            }

        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});