
function fetchRegister(bdyData) {
    try {
        return $.ajax({
            url: "/register",
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
    catch (error)
    {
        console.log("error",error)
    }
}
async function setRegister() {
    debugger;
    const $formSelector = $("form#signupForm");

    const fname = $formSelector.find("#UsrName").val();
    const UsrEmail = $formSelector.find("#UsrEmail").val();
    const usrPswrd = $formSelector.find("#Usrpsswrd").val();

    const bdyData = {
        Name: fname,
        Email: UsrEmail,
        Password: usrPswrd
    }

    const apiResult = await fetchRegister(bdyData);
}

$(document).on("submit", "#signupForm", function (e) {
    e.preventDefault();
    setRegister();
});
