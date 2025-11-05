
(function () {

        $('#signupForm').on('submit', function (e) {
            e.preventDefault();

            var name = $('#name').val();
            var email = $('#email').val();
            var password = $('#password').val();

            console.log('Signup Details:', { name, email, password });
        });

})();


function fetchRegister() {
    try {
        return $.ajax({
            url: "register", 
            type: "POST", 
            dataType: "json",   
            success: function (response) {
                console.log("✅ Data fetched successfully:", response);
            },
            error: function (xhr, status, error) {
                console.error("❌ Error fetching data:", error);
            }
        });

    }
    catch (error)
    {
        console.log("error",error)
    }
}