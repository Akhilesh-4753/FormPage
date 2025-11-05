
(function () {
    $('#loginForm').on('submit', function (e) {
        e.preventDefault();
        var email = $('#loginEmail').val();
        var password = $('#loginPassword').val();

        Swal.fire({
            title: "Login Successful!",
            text: "Welcome back, Akhilesh!",
            icon: "success",
            confirmButtonText: "OK"
        });

        console.log('Login Details:', { email, password });
    });
})();
