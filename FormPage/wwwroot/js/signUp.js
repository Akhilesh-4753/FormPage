// 🔹 Send Register Data
function fetchRegister(data) {
    return $.ajax({
        url: "/register",
        type: "POST",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(data)
    });
}

$('#signupForm').on('submit', async function (e) {
    e.preventDefault();

    const bdyData = {
        Name: $('#UsrName').val(),
        Email: $('#UsrEmail').val(),
        Password: $('#Usrpsswrd').val()
    };

    try {
        const response = await fetchRegister(bdyData);

        Swal.fire({
            title: "Registration Successful!",
            text: response.message,
            icon: "success",
            confirmButtonText: "OK"
        });
    } catch (err) {
        Swal.fire({
            title: "Registration Failed!",
            text: err.responseJSON?.message || "Something went wrong!",
            icon: "error",
            confirmButtonText: "Retry"
        });
    }
});
