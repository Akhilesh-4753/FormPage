// 🔹 Send Login Data
function fetchLogin(data) {
    return $.ajax({
        url: "/login1",
        type: "POST",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(data)
    });
}

$('#loginForm').on('submit', async function (e) {
    e.preventDefault();

    const bdyData = {
        Email: $('#loginEmail').val(),
        Password: $('#loginPassword').val()
    };

    try {
        const response = await fetchLogin(bdyData);

        Swal.fire({
            title: "Login Successful!",
            text: response.message,
            icon: "success",
            confirmButtonText: "OK"
        });
    } catch (err) {
        Swal.fire({
            title: "Login Failed!",
            text: err.responseJSON?.message || "Invalid email or password.",
            icon: "error",
            confirmButtonText: "Retry"
        });
    }
});
