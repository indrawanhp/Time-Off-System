// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const IdLogin = parseInt($("#sessionUserId").val());
console.log(IdLogin)
let Name = document.getElementById("Name");
$.ajax({
    url: "https://localhost:7090/api/Employees/" + IdLogin,
    dataType: "Json"
}).done((result) => {
    Name.innerHTML = result.firstName + " " + result.lastName;
    console.log(result.firstName);
}).fail((error) => {
    console.log(error);
});

function ChangePassword() {
    var obj = {
        EmployeeId: IdLogin,
        OldPassword: $("#oldpass").val(),
        NewPassword: $("#newpass").val(),
    }; console.log(obj);
    $.ajax({
        url: "https://localhost:7090/api/Accounts/ChangePassword",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(obj)
    }).done((result) => {
        let timerInterval
        swal.fire({
            title: 'being processed!',
            html: 'Wait a moment',
            timer: 2000,
            timerProgressBar: true,
            didOpen: () => {
                swal.showLoading()
                const b = swal.getHtmlContainer().querySelector('b')
                timerInterval = setInterval(() => {
                    b.textContent = swal.getTimerLeft()
                }, 100)
            },
            willClose: () => {
                swal.fire({
                    icon: 'success',
                    title: 'successful change of password',
                    showConfirmButton: false,
                    timer: 1500
                }),
                    clearInterval(timerInterval),
                $('#changepass').refresh();
            }
        }).then((result) => {
            if (result.dismiss === swal.DismissReason.timer) {
                console.log('Waiting')
            }
        })

    }).fail((error) => {

        swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Failed Change Password',
        })
    })
}