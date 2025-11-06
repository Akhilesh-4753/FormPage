function fetchLogin(bdyData) {
    return $.ajax({
        url: "/login1",
        type: "POST",
        contentType: "application/json", // tell server you're sending JSON
        dataType: "json",  // expect JSON in response
        data: JSON.stringify(bdyData)  // convert JS object → JSON string
    });
}

$('#loginForm').on('submit', async function (e) {
    e.preventDefault();

    const logEmail = $('#loginEmail').val();
    const logPswrd = $('#loginPassword').val();

    const bdyData = {
        Email: logEmail,
        Password: logPswrd
    };

    try {
        const response = await fetchLogin(bdyData);

        // 🔹 check backend response
        if (response.isSuccess || response.success || response === "User login successful") {
            Swal.fire({
                title: "Login Successful!",
                text: "Welcome back, Akhilesh!",
                icon: "success",
                confirmButtonText: "OK"
            });
        }

        console.log("✅ Server Response:", response);

    } catch (error) {
        console.error("❌ Login Request Failed:", error);
        Swal.fire({
            title: "Server Error!",
            text: "Unable to connect to server. Please try again later.",
            icon: "error",
            confirmButtonText: "Retry"
        });
    }
});
