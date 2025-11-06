
function fetchLogin(bdyData) {
    try {
        return $.ajax({
            url: "/login1",
            type: "POST",
            contentType: "application/json", // ✅ tell server you're sending JSON
            dataType: "text",                // ✅ expect JSON in response
            data: JSON.stringify(bdyData),  // ✅ convert JS object → JSON string
            success: function (response) {
                console.log("✅ Data sent successfully:", response);
            },
            error: function (xhr, status, error) {
                console.error("❌ Error fetching data:", error);
            }
        });

    }
    catch (error) {
        console.log("error", error)
    }
}

async function setLogin() {
    debugger;
    const $formSelector = $("form#loginForm");
    
    const logEmail = $formSelector.find("#loginEmail").val();
    const logPswrd = $formSelector.find("#loginPassword").val();

    const bdyData = {
        Email: logEmail,
        Password: logPswrd
    }

    const apiResult = await fetchLogin(bdyData);
}

$('#loginForm').on('submit', function (e) {
    e.preventDefault();
    var email = $('#loginEmail').val();
    var password = $('#loginPassword').val();

    setLogin();

    Swal.fire({
        title: "Login Successful!",
        text: "Welcome back, Akhilesh!",
        icon: "success",
        confirmButtonText: "OK"
    });

    console.log('Login Details:', { email, password });
});
