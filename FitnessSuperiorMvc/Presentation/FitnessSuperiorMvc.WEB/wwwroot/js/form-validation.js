$(function () {
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