// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})
$(document).ready(function () {
    TableAccount = $("#account").DataTable({
        dom: 'Bfrtip', /*'<"top"Blf>rtip',*/
        buttons: [
            {
                extend: 'pageLength',
                className: 'button bg-info'
            },
            {
                extend: 'copyHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                titleAttr: 'Copy',
                className: 'button bg-primary',
                text: '<i class="bi bi-clipboard"></i>'
            },
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                titleAttr: 'Excel',
                className: 'button bg-success',
                text: '<i class="bi bi-file-earmark-excel"></i>'
            },
            {
                extend: 'csvHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                titleAttr: 'CSV',
                className: 'button bg-warning',
                text: '<i class="bi bi-filetype-csv"></i>'
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                titleAttr: 'Pdf',
                className: 'button bg-danger',
                text: '<i class="bi bi-filetype-pdf"></i>'
            }
            /*'pageLength', 'copy', 'csv', 'excel', 'pdf', 'print'*/
        ],
        ajax: {
            url: "https://localhost:7090/api/Accounts/AccountMaster",
            dataType: "Json",
            dataSrc: '',

        },
        "columns": [
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row["fullName"] /*+ " " + row["lastName"]*/;
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row["email"];
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row["roles"];
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return `<button class="btn btn-success" title="Edit" onclick="getEditModal('${row.accountRoleId}')" data-bs-toggle="modal" data-bs-target="#getEditModal"><i class="bi bi-gear"></i></button>
                            <button class="btn btn-danger" title="Delete" onclick="Delete('${row.employeeId}')"><i class="bi bi-trash3"></i></button>`;
                }
            }
        ]

    });

})
$.ajax({
    url: "https://localhost:7090/api/Roles",
    type: "GET",
    dataType: "Json"
}).done((result) => {
    let role = `<option value="" disabled selected>Please select role account</option>`;

    $.each(result, (key, val) => {
        role += `<option value="${val.id}" >${val.name}</option>`;
    })

    $("#roleS").html(role);

    $("#txtrole").html(role);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: "https://localhost:7090/api/Employees",
    type: "GET",
    dataType: "Json"
}).done((result) => {

    let emp = `<option value="" disabled selected>Please select employee</option>`;

    $.each(result, (key, val) => {
        emp += `<option value="${val.id}" >${val.firstName}</option>`;
    })

    $("#employeeId").html(emp);
}).fail((error) => {
    console.log(error);
});



$(function () {
    $("#formValidation").validate({
        rules: {
            employeeId: {
                required:true
            },
            email: {
                required: true,
                email: true
            },
            password: {
                required: true
            },
            txtrole: {
                required: true
               
            },
        },
        messages: {
            employeeId: {
                required: "Select user.",
            },
            email: {
                required: "Enter user email.",
                email: "xxx@xxx.xxx"
            },
            password: {
                required: "Enter user password"
            },
            txtrole: {
                required: "Select user role"
                }
        }
    });
    $('#btnAdd').click(function (e) {
        e.preventDefault();
        if ($('#formValidation').valid() == true) {
            Insert();
        }
    });
});

function Insert() {
    let obj = {
        employeeId: $("#employeeId").val(),
        email: $("#email").val(),
        password: $("#password").val(),
        roleId: $("#txtrole").val()
    };
    $.ajax({
        url: "https://localhost:7090/api/Accounts/Register",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(obj)
    }).done((result) => {
        swal.fire({
            title: "Good job!",
            text: "Data added successfully!!",
            icon: "success"

        })
        TableAccount.ajax.reload();
    }).fail((error) => {
        // jika gagal
        swal.fire({
            title: "Failed!",
            text: "email or this user has been registered!!",
            icon: "error",
            button: "Close",
        });
    })
}

function Delete(id) {
    swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
            $.ajax({
                headers: { 'Content-Type': 'application/json' },
                url: "https://localhost:7090/api/Accounts/" + id,
                type: "delete",
                dataType: 'json'
            }).done((result) => {
                swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Delete data from database',
                }),
                    TableAccount.ajax.reload()
            }).fire((error) => {
                swal({
                    icon: 'error',
                    title: 'Error',
                    text: 'Failed deleting data from Database',
                })
            })
        }
    })
}

function getEditModal(id) {
    $.ajax({
        url: "https://localhost:7090/api/AccountRoles/" + id,
        dataType: "Json",
        dataSrc: ""
    }).done((result) => {
        $('#idAccountRole').val(result.id);
        $('#idEmployee').val(result.accountId);
        $('#txtrole').val(result.roleId);
        console.log(result.roleId)

    }).fail((error) => {
        console.log(error);
    });
}
function EditAccount() {
    var obj = { 
        id: $("#idAccountRole").val(),
        accountId: $("#idEmployee").val(),
        roleId: $("#roleS").val()

    }; console.log(obj)
    $.ajax({
        url: "https://localhost:7090/api/AccountRoles",
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(obj)
    }).done((result) => {
        let timerInterval
        swal.fire({
            title: 'Saving Data!',
            html: 'Wait a minute <b></b> milliseconds.',
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
                    title: 'Success',
                    text: 'Upload Employee',
                })
                clearInterval(timerInterval)
            }
        }).then((result) => {
            if (result.dismiss === swal.DismissReason.timer) {
                console.log('Waiting')
            }
        }),
/*            $('#editEmployee').modal('hide');
*/        TableAccount.ajax.reload()

    }).fail((error) => {

        swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Failed Edit Account ',
        })
    })
}

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})
$(document).ready(function () {
    Table = $("#allocationsleave").DataTable({
        dom: 'Bfrtip', /*'<"top"Blf>rtip',*/
        buttons: [
            {
                extend: 'pageLength',
                className: 'button bg-info'
            },
            {
                extend: 'copyHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                titleAttr: 'Copy',
                className: 'button bg-primary',
                text: '<i class="bi bi-clipboard"></i>'
            },
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                titleAttr: 'Excel',
                className: 'button bg-success',
                text: '<i class="bi bi-file-earmark-excel"></i>'
            },
            {
                extend: 'csvHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                titleAttr: 'CSV',
                className: 'button bg-warning',
                text: '<i class="bi bi-filetype-csv"></i>'
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                titleAttr: 'Pdf',
                className: 'button bg-danger',
                text: '<i class="bi bi-filetype-pdf"></i>'
            }
            /*'pageLength', 'copy', 'csv', 'excel', 'pdf', 'print'*/
        ],
        ajax: {
            url: "https://localhost:7090/api/AllocationsLeave/AllocationLeaveMasters",
            dataType: "Json",
            dataSrc: '',

        },
        "columns": [
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row["fullName"];
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row["jabatan"];
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row["department"];
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row["sisaCuti"] + " Hari"; 
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return `<button class="btn btn-success" title="Edit" onclick="getEditModalAllocationLeave('${row.allocationsLeaveId}')" data-bs-toggle="modal" data-bs-target="#getEditModalAllocationsLeave"><i class="bi bi-gear"></i></button>
                            <button class="btn btn-danger" title="Delete" onclick="DeleteAllocationLeave('${row.allocationsLeaveId}')"><i class="bi bi-trash3"></i></button>`;
                }
            }
        ]

    });

})

$(function () {
    $("#formValidationAllocationLeave").validate({
        rules: {
            employeeId: {
                required: true
            },
            remaining: {
                required: true
            }
        },
        messages: {
            employeeId: {
                required: "Please Select Employee"
            },
            remaining: {
                required: "Please enter Remaining Out</h6>"
            }
        }
    });
    $('#btnAddAl').click(function (e) {
        e.preventDefault();
        if ($('#formValidationAllocationLeave').valid() == true) {
            InsertAllocationsLeave();
        }
    });
});

function InsertAllocationsLeave() {
    let obj = {
        employeeId: $("#employeeId").val(),
        remaining: $("#remaining").val(),
        
    };
    $.ajax({
        url: "https://localhost:7090/api/AllocationsLeave",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(obj)
    }).done((result) => {
        swal.fire({
            title: "Good job!",
            text: "Data added successfully!!",
            icon: "success",

        })
        Table.ajax.reload();
    }).fail((error) => {
        // jika gagal
        swal.fire({
            title: "Failed!",
            text: "Data failed to add!!",
            icon: "error",
            button: "Close",
        });
    })
}

function DeleteAllocationLeave(id) {
    swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
            $.ajax({
                headers: { 'Content-Type': 'application/json' },
                url: "https://localhost:7090/api/AllocationsLeave/" + id,
                type: "delete",
                dataType: 'json'
            }).done((result) => {
                swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Delete Employee from database',
                }),
                    Table.ajax.reload()
            }).fire((error) => {
                swal({
                    icon: 'error',
                    title: 'Error',
                    text: 'Failed deleting Employee from Database',
                })
            })
        }
    })
}

function getEditModalAllocationLeave(id) {
    $.ajax({
        url: "https://localhost:7090/api/AllocationsLeave/" + id,
        dataType: "Json",
        dataSrc: ""
    }).done((result) => {
        $('#txtid').val(result.id);
        $('#txtidEmployee').val(result.employeeId);
        $('#txtremaining').val(result.remaining);
        console.log(result)

    }).fail((error) => {
        console.log(error);
    });
}

function EditRemaining() {
    var obj = { //sesuaikan sendiri nama objectnya dan beserta isinya
        //ini ngambil value dari tiap inputan di form nya
        // obj,
        id: $("#txtid").val(),
        employeeId: $("#txtidEmployee").val(),
        remaining: $("#txtremaining").val()

    }; console.log(obj)
    $.ajax({
        url: "https://localhost:7090/api/AllocationsLeave",
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(obj)
    }).done((result) => {
        let timerInterval
        swal.fire({
            title: 'Saving Data!',
            html: 'Wait a minute <b></b> milliseconds.',
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
                    title: 'Success',
                    text: 'Upload Employee',
                })
                clearInterval(timerInterval)
            }
        }).then((result) => {
            if (result.dismiss === swal.DismissReason.timer) {
                console.log('Waiting')
            }
        }),
/*            $('#editEmployee').modal('hide');
*/        Table.ajax.reload()

    }).fail((error) => {

        swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Failed Edit Employee',
        })
    })
}