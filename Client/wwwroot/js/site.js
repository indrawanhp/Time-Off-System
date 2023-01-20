/*// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let judul = document.getElementById("judul");
judul.style.backgroundColor = "whitesmoke";
judul.innerHTML =
 `<h1 class="text-center pt-3 pb-3"> Kita belajar Javascript</h1>
    `;

let paragraf = document.getElementsByTagName("p")[0];
paragraf.style.backgroundColor = "white";

let variable1 = document.getElementsByClassName("list")

judul.onclick = function () {
    paragraf.innerHTML = "berubah";
}

judul.onclick = () => {
    judul.style.backgroundColor = "cyan";
    judul.innerHTML = "saya rubah dari js";
}

judul.addEventListener("click", function () {
    paragraf.innerHTML = "berubah!";
})

paragraf.addEventListener("mouseenter", function () {
    paragraf.innerHTML = "mashookkk";
});

let list3 = document.querySelector("li.list#list:nth-child")

function berubah() {
    for (var i = 0; i < variable1.length; i++) {
        variable1.innerHTML = "diubah dari onclick html";
    }
}*/

/* ARRAY DALAM JS */
let array = [1, 2, 3, 4];

/* INSERT LIST */
array.push("hallo");
console.log(array);

/* DELETE LIST */
array.pop()
console.log(array);

/* INSERT FIRST */
array.unshift("test");
console.log(array);

/* DELETE FIRST */
array.shift();
console.log(array);

/* ARRAY MULTI DIMENSI */
let arrayMulti = [1, 2, 3, ['a', 'b', 'c'], true];
console.log(array);
console.log(arrayMulti[3][2]) //untuk ambil c

/* ARROW FUNCTION => */
let tambah = (x, y) => { return x + y; }
console.log(tambah(5, 10)); //untuk fungsi tambah

/* OBJEK (Harus kurung kurawal) */
let mhs = {
    nama: "budi", //nama adalah key, budi adalah value
    nim: "a11111313131312",
    gender: "Laki",
    hobby: ["mancing", "tawuran", "ngegame"],
    isActive: true, //agar bersifat boolean dan berbentuk pertanyaan untuk menentukan true or false
};
console.log(mhs)

let user = {};
user.username = "budilagi";
user.password = "inipasswordbudi";
console.log(user)

/* CONST (konstanta) */
const nilai = 50;
console.log(nilai);

/* ARRAY OF OBJECT */
let animals = [
    { name: "budi", species: "dog", class: { name: "mamalia" } },
    { name: "tono", species: "dog", class: { name: "mamalia" } },
    { name: "nemo", species: "fish", class: { name: "invertebrata" } },
    { name: "dori", species: "fish", class: { name: "invertebrata" } },
    { name: "james", species: "dog", class: { name: "mamalia" } },
]
console.log(animals[0].class.name);

//TUGAS JS
//1. BUAT FUNCTION onlyDog, yaitu looping ke animals => yang diambil hanya species dog
// contoh: const onlyDog
// gunakan looping

//Jawab nomor 1
/*const onlyDog = [];*/
//{
//    for(var i = 0; i < animals.length; i++) {
//        if (animals[i].species == "dog")
//        {
//            onlyDog.push(animals[i]);
//        }
//    }
//}
//onlyDog = animals.filter(animal => animal.species == "dog")
//console.log(onlyDog);

// 2. Jika speciesnya  = fish => maka ubah class name menjadi 'non-mamalia'
// buat fungsi juga

//Jawab nomor 2
//const onlyFish = []
//{
//    for(var i = 0; i < animals.length; i++) {
//        if (animals[i].species == "fish")
//        {
//            animals[i].class.name = "Non-Mamalia";
//            onlyFish.push(animals[i]);
//        }
//    }
//}
//console.log(onlyFish);

/*  Detail Animal Untuk Soa*/
//let detailAnimal;
//detailAnimal = animals.map(animal => {
//    return {
//        name: animal.name,
//        species: animal.species,
//        isFish: animal.species == fish? true:false  // menggunakan operator ternary
//    }
//})
//console.log(detailAnimal);

//let data = {
//    series: [30,20],
//    labels: ["cowo","cewe"]
//}

/* JQUERY */
//$("#judul").click(function () {
//    $("#judul").css("background-color", "red");
//    $("#judul").html("Berubah");
//})

/* AJAX = Asynchronous JS and XML */
//$.ajax({
//    url: "https://pokeapi.co/api/v2/pokemon",
//}).done((result) => {
//    let temp = ""
//    $.each(result.results, function (key, val) {
//        temp += `<tr>
//                    <td> ${key + 1}</td>
//                    <td class="text-capitalize"> ${val.name}</td>   
//                    <td> <button type="button" onclick="detailPoke('${val.url}')" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalPokeDetail">Detail Pokemon</button></td>
//                </tr>`
//    })
//    $("#tablePoke").html(temp);

//}).fail((err) => {
//    console.log(err);
//});

//untuk menampilkan detail poke dari poke API
function detailPoke(stringURL) {
    $.ajax({
        url: stringURL,
        success: function (result) {
            $(".modal-title").html(result.name)//MENAMPILKAN NAMA POKEMON
            console.log(result);

            // Image
            let pict = "";
            pict = `
                <img style="width: 120px" src="${result.sprites.other.dream_world.front_default}">
            `
            $(".picture").html(pict);

            //ability
            temp = ""
            $.each(result.abilities, function (key, val) {
                console.log(val.ability.name);
                temp += `<span class="badge bg-success text-capitalize">${val.ability.name}</span> `
            })
            $("#skill").html(temp);

            //types
            temp = ""
            $.each(result.types, function (key, val) {
                console.log(val.type.name);
                temp += `<span class="badge bg-success text-capitalize">${val.type.name}</span>  `
            })
            $("#types").html(temp);

            //Base experience
            let base = ""
            base = `<div class="progress">
                      <div class="progress-bar" role="progressbar" style="width: ${result.base_experience}%;" aria-valuenow="" aria-valuemin="0" aria-valuemax="10000">${result.base_experience}</div>
                    </div>`
            $(".base").html(base);

            // Status (Overall)
            let status = "";
            $.each(result.stats, function (key, val) {
                console.log(val.stats);
                status += `<div class="container">
                              <div class="row">
                                <div class="col-4">
                                  <div class="badge text-bg-warning" style="text-transform: Capitalize; color: black; font-weight: bold; ">${val.stat.name}</div>
                                </div>
                                <div class="col-8">
                                  <div class="progress">
                                    <div id="bar" class="progress-bar progress-bar-striped bg-success" role="progressbar" aria-label="Example with label" style="width:${val.base_stat}%;" aria-valuenow="${val.base_stat}" aria-valuemin="0" aria-valuemax="100">${val.base_stat}</div>
                                </div>
                                </div>
                              </div>
                            </div>`
            })
            $(".status").html(status);

            //height and weight (Baru bikin tadi)
            let height = ""
            height = `<span class="badge bg-success">${result.height + " m"}</span> `
            $("#height").html(height);

            let weight = ""
            weight = `<span class="badge bg-success">${result.weight + " lb"}</span> `
            $("#weight").html(weight);

            //Evolution
            let evo = ""
            evo = `<div class="container">
                      <div class="row">
                        <div class="col">
                          <img width="100px" src="${result.sprites.other.home.front_default}">
                        </div>
                        <div class="col">
                          <img width="100px" src="${result.sprites.other.home.front_shiny}">
                        </div>
                        <div class="col">
                           <img width="100px" src="${result.sprites.other["official-artwork"].front_default}">
                        </div>
                          </div>
                    </div>`
            $("#evo").html(evo);
        }
    })
}

$(document).ready(function () {
    let table = $('#poke').DataTable({
        ajax: {
            url: "https://pokeapi.co/api/v2/pokemon",
            dataType: "Json",
            dataSrc: "results" //notice jangan dihapus yaaa
        },
        columns: [
            {
                //Tugas buat numbering pada datatables !!!!
                "data": null, "sortable": false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "name"
            },
            {
                //menggunakan render function
                "data": "name",
                render: function (data, type, row) {
                    return `<td> <button type="button" onclick="detailPoke('${row.url}')" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalPokeDetail">Detail Pokemon</button></td>`;
                }
            },
        ]
    });
});

// ajax untuk employee di latihan admin dengan sbadmin
$(document).ready(function () {
    let tables = $('#employee').DataTable({
        ajax: {
            url: "https://localhost:7234/api/Employees",
            dataType: "Json",
            dataSrc: "data"
        },
        columns: [ //untuk nampilin nama kolom di datatable
            {
                "data": "nik"
            },
            {
                "data": "firstName"
            },
            {
                "data": "lastName"
            },
            {
                "data": "phone"
            },
            {
                "data": "birthDate",
                render: function (data, type, row) {
                    if (type === "sort" || type === "type") {
                        return data;
                    }
                    return moment(data).format("DD-MMMM-YYYY");
                }
            },
            {
                "data": null,
                render: function (data, type, row) {
                    return 'Rp. ' + row["salary"];
                }
            },
            {
                "data": "email"
            },
            {
                "data": "gender",
                render: function (data, type, row) {
                    if (row.gender == 0) {
                        return `Male`;
                    } else {
                        return `Female`;
                    }
                }
            },
            {
                "data": "nik",
                render: function (data, type, row) {
                    return `<td><button type="button" onclick="Update('${data}')" class="btn btn-primary bg-success" data-bs-toggle="modal" data-bs-target="#modal"><i class="fa-regular fa-pen-to-square"></i></button></td>
                            <td><button type="button" onclick="Delete('${data}')" class="btn btn-primary bg-danger"><i class="fa-solid fa-trash"></i></button></td>
                            `;
                }
            }
        ],
        dom: /*'Bfrtip',*/
            //"<'row'<'col-lg-4'l><'col-lg-6'B><'col-lg-2'f>>" +
            //"<'row'<'col-lg-12'tr>>" +
            //"<'row'<'col-lg-7'i><'col-lg-5'p>>", 
            "<'row'<'col-lg-2'l><'col-lg-6'B><'col-lg-4'f>>" +
            "<'row'<'col-lg-12'tr>>" +
            "<'row'<'col-lg-5'i><'col-lg-7'p>>",
        buttons: [
            {
                extend: 'copyHtml5',
                text: '<i class="fas fa-solid fa-copy"></i>',
                className: 'btn btn-info btn-xs', //nama class button saja
                attr: {
                    'data-bs-toggle': 'tooltip',
                    'title': 'Copy Data'
                },
                exportOptions: {
                    columns: [0, ':visible']
                }
            },
            {
                extend: 'excelHtml5',
                text: '<i class="fas fa-regular fa-file-excel text-lg"></i>',
                className: 'btn btn btn-success btn-xs', //nama class button saja
                attr: {
                    'data-bs-toggle': 'tooltip',
                    'title': 'Export to Excel'
                },
                exportOptions: {
                    columns: [0, ':visible']
                }
            },
            {
                extend: 'csvHtml5',
                text: '<i class="fas fa-regular fa-file-csv"></i>',
                className: 'btn btn-dark btn-xs',
                attr: {
                    'data-bs-toggle': 'tooltip',
                    /*'data-bs-placement': 'top',*/
                    'title': 'Export to CSV'
                },
                exportOptions: {
                    columns: [0, ':visible']
                }
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="fas fa-solid fa-file-pdf"></i>',
                className: 'btn btn-danger btn-xs',
                attr: {
                    'data-bs-toggle': 'tooltip',
                    /*'data-bs-placement': 'top',*/
                    'title': 'Export to PDF'
                },
                exportOptions: {
                    columns: [0, ':visible']
                }
            },
            {
                extend: 'colvis',
                text: '<i class="fas fa-solid fa-eye"></i>',
                attr: {
                    'data-bs-toggle': 'tooltip',
                    /*'data-bs-placement': 'top',*/
                    'title': 'Column Visibility'
                },
                className: 'btn btn-light btn-xs',
            },
        ],
        //untuk menghapus class dt button
        initComplete: function () {
            var btns = $('.dt-button');
            btns.removeClass('dt-button');

        },
    });
});

$(document).ready(function () {
    $('#formEmployee').validate({
        rules: {
            nik: {
                required: true,
                maxlength: 5,
            },
            firstName: {
                required: true,
            },
            lastName: {
                required: true
            },
            phone: {
                required: true,
                maxlength: 12,
            },
            birthDate: {
                required: true,
            },
            salary: {
                required: true,
            },
            email: {
                required: true,
            },
            gender: {
                required: true,
            }
        },
        messages: {
            nik: {
                required: "<h6>Silahkan masukan NIK</h6>",
                maxlength: "<h6>Nomor harus sesuai</h6>"
            },
            firstName: "<h6>Silahkan Masukan Firstname</h6>",
            lastName: "<h6>Silahkan masukan lastname</h6>",
            phone: {
                required: "<h6>Silahkan masukan phone number</h6>",
                maxlength: "<h6> Nomor Telefon harus 12 angka</h6>"
            },
            birthDate: "<h6> Silahkan Masukan Tanggal Lahir </h6>",
            salary: {
                required: "<h6>Silahkan masukan salary</h6>"
            },
            email: "<h6>Silahkan masukan email</h6>",
            gender: "<h6>Silahkan masukan gender</h6>",
        },
        submitHandler: () => {
            if (!check) {
                Insert()
            } else {
                prosesUpdate()
            }
        },
        errorElement: "em",
        errorPlacement: function (error, element) {
            // Add the help-block class to the error element
            error.addClass("help-block");

            // Add has-feedback class to the parent div.form-group
            // in order to add icons to inputs
            element.parents(".col-sm-5").addClass("has-feedback");

            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.parent("label"));
            } else {
                error.insertAfter(element);
            }

            // Add the span element, if doesn't exists, and apply the icon classes to it.
            if (!element.next("span")[0]) {
                $("<span class='glyphicon glyphicon-remove form-control-feedback'></span>").insertAfter(element);
            }
        },
        success: function (label, element) {
            // Add the span element, if doesn't exists, and apply the icon classes to it.
            if (!$(element).next("span")[0]) {
                $("<span class='glyphicon glyphicon-ok form-control-feedback'></span>").insertAfter($(element));
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).parents(".col-sm-5").addClass("has-error").removeClass("has-success");
            $(element).next("span").addClass("glyphicon-remove").removeClass("glyphicon-ok");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents(".col-sm-5").addClass("has-success").removeClass("has-error");
            $(element).next("span").addClass("glyphicon-ok").removeClass("glyphicon-remove");
        }
    })
});

// Ini Mulai Crud dengan ajax
// INSERT
function Insert() {
    let obj = {
        nik: $("#nik").val(),
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        phone: $("#phone").val(),
        birthDate: $("#birthDate").val(),
        salary: parseInt($("#salary").val()),
        email: $("#email").val(),
        gender: parseInt($("#gender").val())
    };
    console.log(obj);
    $.ajax({
        url: "https://localhost:7234/api/Employees",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(obj) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        Swal.fire(
            'Insert!',
            'Data Berhasil Disimpan.',
            'success'
        )
        $('#employee').DataTable().ajax.reload()
    }).fail((error) => {
        Swal.fire(
            'Failed!',
            'Data Gagal Disimpan.',
            'error'
        )
    }) //penutup ERROR
} //penutup insert()

//Untuk cek button apakah dia insert atau update
let check
const Add = () => {
    check = false
}

// UPDATE OR EDIT
function Update(id) {
    check = true //NILAI TRUE UNTUK UPDATE, YANG AKAN MASUK KE CHECK
    $.ajax({
        url: `https://localhost:7234/api/Employees/` + id,
        dataType: "Json",
        dataSrc: "data"
    }).done((result) => {
        $('#nik').val(result.data.nik);
        /*$('#nik').attr("disabled", false);*/
        $("#firstName").val(result.data.firstName);
        $("#lastName").val(result.data.lastName);
        $("#phone").val(result.data.phone);
        $("#birthDate").val(result.data.birthDate);
        $("#salary").val(result.data.salary);
        $("#email").val(result.data.email);
        $("#gender").val(result.data.gender);

        console.log(result.data.nik);
    })
}

function prosesUpdate() {
    event.preventDefault(); //untuk memberhentikan proses/action sebelumnya
    let coba = {
        nik: $("#nik").val(),
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        phone: $("#phone").val(),
        birthDate: $("#birthDate").val(),
        salary: parseInt($("#salary").val()),
        email: $("#email").val(),
        gender: parseInt($("#gender").val())
    };
    console.log(coba);
    $.ajax({
        url: "https://localhost:7234/api/Employees",
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(coba) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        console.log("success");
        Swal.fire(
            'Update!',
            'Data Berhasil Disimpan.',
            'success'
        );
        $('#employee').modal('hide')
        $('#employee').DataTable().ajax.reload()
    }).fail((error) => {
        Swal.fire(
            'Failed!',
            'Data Gagal Disimpan.',
            'error'
        );
    })
}


// DELETE
function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: 'You wont able to revert this!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'DELETE',
                url: `https://localhost:7234/api/Employees/${id}`,
                success: () => {
                    Swal.fire(
                        'Deleted!',
                        'Employee has been deleted.',
                        'success'
                    )
                    $('#employee').DataTable().ajax.reload()
                },
                error: () => {
                    Swal.fire(
                        'Failed!',
                        'Error deleting employee.',
                        'error'
                    )
                }
            })
        }
    })
}

//GET DATA FOR CHART APEX JS
$.ajax({
    url: `https://localhost:7234/api/Employees`,
}).done((data) => {
    console.log(data);
    var gender = data.data
        .map(x => ({ gender: x.gender }));
    var { gender0, gender1 } = gender.reduce((previous, current) => {
        if (current.gender === 0) {
            return { ...previous, gender0: previous.gender0 + 1 }
        } if (current.gender === 1) {
            return { ...previous, gender1: previous.gender1 + 1 }
        }
    }, { gender0: 0, gender1: 0 })

//chart1
    var options = {
        series: [{
            data: [gender0, gender1]
        }],
        chart: {
            height: 350,
            type: 'bar',
            events: {
                click: function (chart, w, e) {
                    // console.log(chart, w, e)
                }
            }
        },
        title: {
            text: 'Total Employee Gender With Bar Chart',
            align: 'left'
        },
        plotOptions: {
            bar: {
                columnWidth: '45%',
                distributed: true,
            }
        },
        dataLabels: {
            enabled: false
        },
        legend: {
            show: false
        },
        xaxis: {
            categories: [
                ['Total', 'Male'],
                ['Total', 'Female'],
            ],
            labels: {
                style: {
                    fontSize: '12px'
                }
            }
        }
    };

    var chart = new ApexCharts(document.querySelector("#chart1"), options);
    chart.render();

//chart2
var options = {
    series: [gender0, gender1],
    chart: {
        width: 400,
        type: 'pie',
    },
    title: {
        text: 'Total Employee Gender With Pie Chart',
        align: 'left'
    },
    labels: ['Male', 'Female'],
    responsive: [{
        breakpoint: 480,
        options: {
            chart: {
                width: 500
            },
            legend: {
                position: 'bottom',
                show: true,
            },
            style: {
                fontSize: '300px',
            }
        }
    }]
};

var chart2 = new ApexCharts(document.querySelector("#chart2"), options);
chart2.render();



}); //penutup get data api ajax