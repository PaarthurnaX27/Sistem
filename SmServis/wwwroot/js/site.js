window.history.forward(1);


function filterSifirla() {

    let input = document.getElementsByClassName("form-control");
    let label = document.getElementById("lblChck");
    let check = document.getElementById("chckSilindi");
    check.checked = false;
    for (let i = 0; i < input.length; i++) {
        input[i].value = "";
    }

    label.innerText = "Mevcut";

}
function icerikGor(Dt) {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    if (document.querySelector('input[name="radio"]:checked') == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
    }
    else {
        let radio = document.querySelector('input[name="radio"]:checked').value;
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            data: { id: radio },
            success: function (data) {
                if (Dt == 'Personel') {
                    window.location.href = '/PersonelKarti/PersonelKartiGor?id=' + radio;
                }
                else if (Dt == 'CariPersonel') {
                    window.location.href = '/CariPersonelKarti/CariPersonelKartiGor?id=' + radio;
                }
                else if (Dt == 'TempCariPersonel') {
                    window.location.href = '/TempCariPersonelKarti/TempCariPersonelKartiGor?id=' + radio;
                }
                else if (Dt == 'GTempCariPersonel') {
                    window.location.href = '/TempCariPersonelKarti/GTempCariPersonelKartiGor?id=' + radio;
                }
                else if (Dt == 'IlgiliKisiler') {
                    window.location.href = '/IlgiliKisiler/IlgiliKisiGor?id=' + radio;
                }
                else if (Dt == 'ServisGor') {
                    window.location.href = '/Servis/ServisGor?id=' + radio;
                }
                else if (Dt == 'ProjeGor') {
                    window.location.href = '/Proje/IcerikYonlendir?id='+radio;
                }
                else {
                    if (Dt == 'Modul') {
                        let departman = document.querySelector('input[name="radio"]:checked ').parentElement.parentElement.children[4].innerHTML;
                        window.location.href = '/Dt' + Dt + '/' + Dt + 'Gor?id=' + radio + '&departmanId=' + departman;
                    }
                    else {

                        window.location.href = '/Dt' + Dt + '/' + Dt + 'Gor?id=' + radio;
                    }
                }
            },
            error: function (httpRequest, textStatus, errorThrown) {
                alert("Error: " + textStatus + " " + errorThrown + " " + httpRequest);
            }
        });
    }
}
function DakikaSaatFT() {
    let ftSuresiInput = document.getElementById('inputFTSuresi');
    let ftSuresiSaat = document.getElementById('inputFTSuresiSaat');
    ftSuresiSaat.value = ftSuresiInput.value / 60;
}
function DakikaSaatT() {
    let ftSuresiInput = document.getElementById('inputTSuresi');
    let ftSuresiSaat = document.getElementById('inputTSuresiSaat');
    ftSuresiSaat.value = ftSuresiInput.value / 60;
}
function guncelle(Dt) {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    if (document.querySelector('input[name="radio"]:checked') == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
    }
    else {
        let radio = document.querySelector('input[name="radio"]:checked').value;


        $.ajax({
            type: "GET",

            contentType: "application/json; charset=utf-8",
            data: { id: radio },

            success: function (data) {
                if (Dt == 'Personel') {
                    window.location.href = '/PersonelKarti/PersonelKartiGuncelle?id=' + radio;
                }
                else if (Dt == 'CariPersonel') {
                    window.location.href = '/CariPersonelKarti/CariPersonelKartiGuncelle?id=' + radio;
                }
                else if (Dt == 'IlgiliKisiler') {
                    window.location.href = '/IlgiliKisiler/IlgiliKisiGuncelle?id=' + radio;
                }
                else if (Dt == 'TempCariPersonel') {
                    window.location.href = '/TempCariPersonelKarti/TempCariPersonelKartiGuncelle?id=' + radio;
                }
                else if (Dt == 'GTempCariPersonel') {
                    window.location.href = '/TempCariPersonelKarti/GTempCariPersonelKartiGuncelle?id=' + radio;
                }
                else if (Dt == 'ServisGuncelle') {
                    window.location.href = '/Servis/ServisGuncelle?id=' + radio;
                }
                
                else {
                    if (Dt == 'Modul') {
                        let departman = document.querySelector('input[name="radio"]:checked ').parentElement.parentElement.children[4].innerHTML;
                        window.location.href = '/Dt' + Dt + '/' + Dt + 'Guncelle?id=' + radio + '&departmanId=' + departman;
                    }
                    else {

                        window.location.href = '/Dt' + Dt + '/' + Dt + 'Guncelle?id=' + radio;
                    }
                }

            },
            error: function (httpRequest, textStatus, errorThrown) {
                alert("Error: " + textStatus + " " + errorThrown + " " + httpRequest);
            }
        });
    }
}
function bagli_ana(Dt) {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    if (document.querySelector('input[name="radio"]:checked') == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
    }
    else {
        let radio = document.querySelector('input[name="radio"]:checked').value;
        $.ajax({
            type: "GET",

            contentType: "application/json; charset=utf-8",
            data: { id: radio },

            success: function (data) {
                window.location.href = '/Dt' + Dt + '/' + Dt + '_AnaSektor?id=' + radio;
            },
            error: function (httpRequest, textStatus, errorThrown) {
                alert("Error: " + textStatus + " " + errorThrown + " " + httpRequest);
            }
        });
    }
}
function ilgiliKisiIsSelected() {
    if (document.querySelector('input[name="radio"]:checked') == null && document.getElementById('ilgiliKisiCari').value == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
    }
}
$('#tblDestek tr').click(function () {
    $(this).find('input[type=radio]').prop('checked', true);
});
$('#tblServis tr').click(function () {
    $(this).find('input[type=radio]').prop('checked', true);
});
$('#tblDestekG tr').click(function () {
    $(this).find('input[type=radio]').prop('checked', true);
});
$('#tblIlgili tr').click(function () {
    let b = $(this).find('input[type=radio]').prop('checked', true);
    let radio = document.querySelector('input[name="radio"]:checked').value;
    let lbl = document.getElementById('lblPersonelId');
    lbl.textContent = radio;
    lbl.value = radio;
    if (radio != null) {
        let personelKodu = document.getElementById("pPersonelKodu");
        let personelAdi = document.getElementById("pPersonelAdi");
        let personelSoyadi = document.getElementById("pPersonelSoyadi");
        let personelTelefon = document.getElementById("pPersonelTelefon");
        let personelMail = document.getElementById("pPersonelMail");
        let personelUnvan = document.getElementById("pPersonelUnvan");
        let personelDepartman = document.getElementById("pPersonelDepartman");
        let personelPozisyon = document.getElementById("pPersonelPozisyon");
        let personelAdres1 = document.getElementById("pPersonelAdres1");
        let personelAdres2 = document.getElementById("pPersonelAdres2");
        let personelCinsiyet = document.getElementById("pPersonelCinsiyet");
        $.ajax({
            url: '/IlgiliKisiler/PersonelGetir',
            type: "GET",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { id: radio },
            success: function (personels) {

                personelKodu.innerText = personels.cariPersonelKodu;
                personelAdi.innerText = personels.cariPersonelAdi + " " + personels.cariPersonelAdi2;
                personelSoyadi.innerText = personels.cariPersonelSoyadi;
                personelMail.innerText = personels.mail;
                personelUnvan.innerText = personels.unvanId;
                personelDepartman.innerText = personels.departmanId;
                personelPozisyon.innerText = personels.pozisyonId;
                if (personels.cinsiyetId == 1) {
                    personelCinsiyet.innerText = "Erkek";
                }
                else if (personels.cinsiyetId == 2) {
                    personelCinsiyet.innerText = "Kız";
                }
                personelTelefon.innerText = personels.telefon;
                personelAdres1.innerText = personels.adres1;
                personelAdres2.innerText = personels.adres2;
            }
        });
    }
});
function addCariPersonel(cariId) {
    window.location.href = '/CariPersonelKarti/CariPersonelKartiEkle?cariId=' + cariId;
}
function addTempCariPersonel(route) {
    if (route == 'cariGuncelle') {
        window.location.href = '/TempCariPersonelKarti/TempCariPersonelKartiEkle?route=' + route;
    }
    else {
        window.location.href = '/TempCariPersonelKarti/TempCariPersonelKartiEkle?route=' + route;
    }

}
function selectIlgili3() {
    let radio = document.querySelector('input[name="radio"]:checked').value;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: { id: radio },
        success: function (data) {
            window.location.href = '/IlgiliKisiler/IlgiliKisilierId';
        },
        error: function (httpRequest, textStatus, errorThrown) {
            alert("Error: " + textStatus + " " + errorThrown + " " + httpRequest);
        }
    });
}
function filter_isDeleted() {
    let label = document.getElementById("lblChck");
    let check = document.getElementById("chckSilindi").checked;
    if (check == true) {
        label.innerText = "Silindi";
    }
    else {
        label.innerText = "Mevcut";
    }
}

function ilgiliKisiEkle2() {
    let radio = document.querySelector('input[name="radio"]:checked').value;
    let cariSec = document.getElementById("ilgiliKisiCari");
    let tbsidfg = document.querySelector('input[name="radio"]:checked');
    // let personelSec = document.getElementById("ilgiliKisiPersonel");
    let cari = cariSec.value;

    //let personel = personelSec.value;
    if (cariSec.value != "Cari Seçin") {
        let unvanId = document.getElementById("ikUnvanId").value;
        let departmanId = document.getElementById("ikDepartmanId").value;
        let pozisyonId = document.getElementById("ikPozisyonId").value;
        //let personelKodu = document.getElementById("ikPersonelKodu");
        //let personelAdi = document.getElementById("ikPersonelAdi");
        //let personelAdi2 = document.getElementById("ikPersonelAdi2");
        //let personelSoyadi = document.getElementById("ikPersonelSoyadi");
        //let personelTelefon = document.getElementById("ikPersonelTelefon");
        //let personelAdres1 = document.getElementById("ikPersonelAdres1");
        //let personelAdres2 = document.getElementById("ikPersonelAdres2");
        //let personelCinsiyet = document.getElementById("ikPersonelCinsiyet");

        $.ajax({
            url: '/IlgiliKisiler/IlgiliKisiler',
            type: "POST",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { unvan: unvanId },
            success: function (personels) {
                //    window.location.href = '/IlgiliKisiler/IlgiliKisiler?id=' + radio;
                //    //personelKodu.value = personels.personelKodu;
                //    //personelAdi.value = personels.personelAdi;
                //    //personelAdi2.value = personels.personelAdi2;
                //    //personelSoyadi.value = personels.personelSoyadi;
                //    //if (personels.cinsiyetId == 1) {
                //    //    personelCinsiyet.value = "Erkek";
                //    //}
                //    //else if (personels.cinsiyetId == 2) {
                //    //    personelCinsiyet.value = "Kız";
                //    //}
                //    //personelTelefon.value = personels.telefon;
                //    //personelAdres1.value = personels.adres1;
                //    //personelAdres2.value = personels.adres2;



            }
        });
    }
}
function cariPersonelGor() {
    let radio = document.querySelector('input[name="radio"]:checked').value;
    let asdf = 23;
    if (radio != null) {
        let personelKodu = document.getElementById("pPersonelKodu");
        let personelAdi = document.getElementById("pPersonelAdi");
        let personelSoyadi = document.getElementById("pPersonelSoyadi");
        let personelTelefon = document.getElementById("pPersonelTelefon");
        let personelUnvan = document.getElementById("pPersonelUnvan");
        let personelDepartman = document.getElementById("pPersonelDepartman");
        let personelPozisyon = document.getElementById("pPersonelPozisyon");
        let personelAdres = document.getElementById("pPersonelAdres1");
        let personelAdres2 = document.getElementById("pPersonelAdres2");
        let personelCinsiyet = document.getElementById("pPersonelCinsiyet");
        $.ajax({
            url: '/IlgiliKisiler/PersonelGetir',
            type: "GET",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { id: radio },
            success: function (personels) {

                personelKodu.innerText = personels.cariPersonelKodu;
                personelAdi.innerText = personels.cariPersonelAdi + " " + personels.cariPersonelAdi2;
                personelSoyadi.innerText = personels.cariPersonelSoyadi;
                personelUnvan.innerText = personels.UnvanId;
                personelDepartman.innerText = personels.DepartmanId;
                personelPozisyon.innerText = personels.PozisyonId;
                if (personels.cinsiyetId == 1) {
                    personelCinsiyet.value = "Erkek";
                }
                else if (personels.cinsiyetId == 2) {
                    personelCinsiyet.value = "Kız";
                }
                personelTelefon.value = personels.telefon;
                personelAdres1.value = personels.adres1;
                personelAdres2.value = personels.adres2;
            }
        });
    }
}
function ilgiliKisiEkle() {
    let cariSec = document.getElementById("ilgiliKisiCari");
    let personelSec = document.getElementById("ilgiliKisiPersonel");
    let cari = cariSec.value;
    let personel = personelSec.value;
    if (cariSec.value != "Cari Seçin" && personelSec.value != "Personel Seçin") {
        let personelKodu = document.getElementById("ikPersonelKodu");
        let personelAdi = document.getElementById("ikPersonelAdi");
        let personelAdi2 = document.getElementById("ikPersonelAdi2");
        let personelSoyadi = document.getElementById("ikPersonelSoyadi");
        let personelTelefon = document.getElementById("ikPersonelTelefon");
        let personelAdres1 = document.getElementById("ikPersonelAdres1");
        let personelAdres2 = document.getElementById("ikPersonelAdres2");
        let personelCinsiyet = document.getElementById("ikPersonelCinsiyet");
        $.ajax({
            url: '/IlgiliKisiler/PersonelGetir',
            type: "GET",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { id: personel },
            success: function (personels) {
                personelKodu.value = personels.cariPersonelKodu;
                personelAdi.value = personels.cariPersonelAdi;
                personelAdi2.value = personels.cariPersonelAdi2;
                personelSoyadi.value = personels.cariPersonelSoyadi;
                if (personels.cinsiyetId == 1) {
                    personelCinsiyet.value = "Erkek";
                }
                else if (personels.cinsiyetId == 2) {
                    personelCinsiyet.value = "Kız";
                }
                personelTelefon.value = personels.telefon;
                personelAdres1.value = personels.adres1;
                personelAdres2.value = personels.adres2;
            }
        });
    }
}

function firmaSecCmp() {
    let selectCmp = document.getElementById("firmaSecLogin").value;
    $.ajax({
        url: "/Login/FirmaSec?companyNo=" + selectCmp,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: { firmaId: selectCmp },
        success: function (data) {
            window.location.href = '/Home/Index';
        },
    });
}

//#region cari
function icerikGorCari() {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    if (document.querySelector('input[name="radio"]:checked') == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
    }
    else {
        let radio = document.querySelector('input[name="radio"]:checked').value;
        $.ajax({
            //url: '/DestekTablosu/IcerikGor',
            type: "GET",
            contentType: "application/json; charset=utf-8",
            data: { id: radio },
            success: function (data) {
                window.location.href = '/Cari/IcerikGor?id=' + radio;
            },
            error: function (httpRequest, textStatus, errorThrown) {
                alert("Error: " + textStatus + " " + errorThrown + " " + httpRequest);
            }
        });
    }
}
function degistir() {
    let personel = document.getElementById('btnDegistirCariPersonel2');
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    let checked = document.querySelector('input[name="radio"]:checked');
    if (checked == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
        personel.setAttribute("form", "formTable");

    }
    else {



        personel.setAttribute("form", "formCariGuncelle");
        // personel.innerText=radio;
        personel.value = checked.value;
    }
}
function degistir2() {
    let personel = document.getElementById('btnDegistirCariPersonel2');
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    let checked = document.querySelector('input[name="radio"]:checked');
    if (checked == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
        personel.setAttribute("form", "formTable");

    }
    else {



        personel.setAttribute("form", "addCariForm");
        // personel.innerText=radio;
        personel.value = checked.value;
    }
}
function degistir3() {
    let personel = document.getElementById('btnDegistirTempCariPersonel3');
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    let checked = document.querySelector('#tblDestekG input[name="radio"]:checked');
    if (checked == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
        personel.setAttribute("form", "formTableTemp");

    }
    else {



        personel.setAttribute("form", "formCariGuncelle");
        // personel.innerText=radio;
        personel.value = checked.value;
    }
}
function guncelleCari() {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    if (document.querySelector('input[name="radio"]:checked') == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
    }
    else {
        let radio = document.querySelector('input[name="radio"]:checked').value;
        $.ajax({
            //url: '/DestekTablosu/IcerikGor',
            type: "GET",

            contentType: "application/json; charset=utf-8",
            data: { id: radio },

            success: function (data) {
                window.location.href = '/Cari/CariGuncelle?id=' + radio;
            },
            error: function (httpRequest, textStatus, errorThrown) {
                alert("Error: " + textStatus + " " + errorThrown + " " + httpRequest);
            }
        });
    }
}

function idDone() {
    let btnTumunuKaydet = document.getElementById('btnTumunuKaydet');
    btnTumunuKaydet.value = "true";
}
$('#example1 tr').click(function () {
    $(this).find('input[type=radio]').prop('checked', true);
});

function myFunction() {
    var input, filter, table, tr, td, i, txtValue, tdi, isCheckBox = false;
    input = document.activeElement;
    filter = input.value.toLowerCase();
    table = document.getElementById("example1");
    tr = table.getElementsByTagName("tr");
    if (input.id === "firmaNoFlt") {
        tdi = 0;
    }
    else if (input.id === "unvanFlt") {
        tdi = 1;
    }
    else if (input.id === "vergiDFlt") {
        tdi = 3;
    }
    else if (input.id === "vergiNoFlt") {
        tdi = 4;
    }
    else if (input.id === "firmaDilFlt") {
        tdi = 5;
    }
    else if (input.id === "ulkeFlt") {
        tdi = 6;
    }
    else if (input.id === "sehirFlt") {
        tdi = 7;
    }
    else {
        tdi = 1000;
    }
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[tdi];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toLowerCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            }
            else {
                tr[i].style.display = "none";
            }
            if (isCheckBox == true) {
                txtValue = td.textContent || td.innerText;
            }
        }
    }
}


$(function () {
    $('#tblSelect').delegate('tbody > tr', 'click', function () {
        $(this).find('input[name="radio"]').prop('checked', true);
    });
});
function FillPozisyon() {
    var id = $('#ikDepartmanId').val();
    $.ajax({
        url: '/IlgiliKisiler/PozisyonGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: id },
        success: function (pozisyons) {
            $("#selectIlce").html("");
            var s = '<option selected disabled value="-1" >Pozisyon Seçin</option>';
            $("#ikPozisyonId").html(s);
            $.each(pozisyons, function (i, db) {
                $("#ikPozisyonId").append(
                    $('<option></option>').val(db.pozisyonId).html(db.pozisyonAdi));
            });
        }
    });
}
function FillCounty() {
    var id = $('#sehir').val();
    $.ajax({
        url: '/Cari/IlceGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { sehirId: id },
        success: function (counties) {
            $("#selectIlce").html("");
            var s = '<option selected disabled value="-1" >İlçe Seçin</option>';
            $("#selectIlce").html(s);
            $.each(counties, function (i, db) {
                $("#selectIlce").append(
                    $('<option></option>').val(db.ilceId).html(db.ilceAdi));
            });
        }
    });
}

function FillCity() {
    var stateId = $('#ulke').val();
    $.ajax({
        url: '/Cari/SehirGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { ulkeId: stateId },
        success: function (cities) {
            $("#sehir").html("");
            var s = '<option selected disabled value="-1" >İl Seçin</option>';
            $("#sehir").html(s);
            $.each(cities, function (i, db) {
                $("#sehir").append(
                    $('<option></option>').val(db.sehirId).html(db.sehirAdi));
            });
        }
    });
}

function FillCountry() {
    var stateId = $('#ulke').val();
    $.ajax({
        url: '/Cari/UlkeGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (ulkes) {
            $("#sUlkeFilter1").html("");
            var s = '<option selected disabled value="0" >Ülke Seçin</option>';
            $("#sUlkeFilter1").html(s);
            $.each(ulkes, function (i, db) {
                $("#sUlkeFilter1").append(
                    $('<option></option>').val(db.ulkeAdi).html(db.ulkeAdi));
            });
        }
    });
}

function BagliSektor() {
    var id = $('#selectAnaSektor').val();
    $.ajax({
        url: '/Cari/BagliSektorGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { anaSektorId: id },
        success: function (sektors) {
            $("#selectBagliSektor").html("");
            var s = '<option selected disabled value="-1" >Bağlı Sektör Seçin</option>';
            $("#selectBagliSektor").html(s);
            $.each(sektors, function (i, db) {
                $("#selectBagliSektor").append(
                    $('<option></option>').val(db.bagliSektorId).html(db.bagliSektorAdi));
            });
        }
    });
}
function Modul() {
    var id = $('#inputDepartman').val();
    $.ajax({
        url: '/Servis/ModulGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { departmanId: id },
        success: function (departmans) {
            $("#inputModul").html("");
            var s = '<option selected disabled value="-1" >Modül Seçin</option>';
            $("#inputModul").html(s);
            $.each(departmans, function (i, db) {
                $("#inputModul").append(
                    $('<option></option>').val(db.modulId).html(db.modulAdi));
            });
        }
    });
}
function ModulW() {
    var id = $('#inputDepartmanW').val();
    $.ajax({
        url: '/Servis/ModulGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { departmanId: id },
        success: function (departmans) {
            $("#inputModulW").html("");
            var s = '<option selected disabled value="-1" >Modül Seçin</option>';
            $("#inputModulW").html(s);
            $.each(departmans, function (i, db) {
                $("#inputModulW").append(
                    $('<option></option>').val(db.modulId).html(db.modulAdi));
            });
            $("#inputModulWL").html("");
            var s = '<option selected disabled value="-1" >Modül Seçin</option>';
            $("#inputModulWL").html(s);
            $.each(departmans, function (i, db) {
                $("#inputModulWL").append(
                    $('<option></option>').val(db.modulId).html(db.modulAdi));
            });
        }
    });
}
function ModulWL() {
    var id = $('#inputDepartmanWL').val();
    $.ajax({
        url: '/Servis/ModulGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { departmanId: id },
        success: function (departmans) {
            $("#inputModulWL").html("");
            var s = '<option selected disabled value="-1" >Modül Seçin</option>';
            $("#inputModulWL").html(s);
            $.each(departmans, function (i, db) {
                $("#inputModulWL").append(
                    $('<option></option>').val(db.modulId).html(db.modulAdi));
            });
        }
    });
}

function TelCode() {
    var ulkeId = $('#ulke').val();
    var span = document.getElementById("telCode");
    $.ajax({
        url: '/Cari/TelCode',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { ulkeId: ulkeId },
        success: function (cities) {
            $("#telCode").html("");
            span.innerText = "+" + cities;
        }
    });
}

function TelCode2() {
    var sehirId = $('#sehir').val()
    var span = document.getElementById("telCode2");
    $.ajax({
        url: '/Cari/TelCode2',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { sehirId: sehirId },
        success: function (telCd) {
            $("#telCode2").html("");
            span.innerText = "0" + telCd;
        }
    });
}
//endregion
function FindUlkeId() {
    var sehirAdi = $('#sehir').val();
    var span = document.getElementById("telCode2");
    $.ajax({
        url: '/DtSehir/findUlkeId',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { sehirAdi: sehirAdi },
        success: function (telCd) {
            $("#telCode2").html("");

            span.innerText = "0" + telCd;
        }
    });
}

function filter_type(box) {
    var cbs = document.getElementsByTagName('input');
    var all_checked_types = [];
    for (var i = 0; i < cbs.length; i++) {
        if (cbs[i].type == "checkbox") {
            if (cbs[i].name.match(/^filter/)) {
                if (cbs[i].checked) {
                    all_checked_types.push(cbs[i].value);
                }
            }
        }
    }
    if (all_checked_types.length > 0) {
        $('#example1 tr').each(function (i, row) {
            var $tds = $(this).find('td');
            if ($tds.length) {
                var type = $tds[17].innerText;

                if (type == "True" && all_checked_types.indexOf(type)) {
                    $(this).show();
                }
                else {
                    $(this).hide();
                }
            }
        });
    }
    else {
        $('#example1 tr').each(function (i, row) {
            var $tds = $(this).find('td'),
                type = $tds.eq(17).text();
            $(this).show();
        });
    }
    return true;
}

function filter_type2(box) {
    var cbs = document.getElementsByTagName('input');
    var all_checked_types = [];
    for (var i = 0; i < cbs.length; i++) {
        if (cbs[i].type == "checkbox") {
            if (cbs[i].name.match(/^filter/)) {
                if (cbs[i].checked) {
                    all_checked_types.push(cbs[i].value);
                }
            }
        }
    }
    if (all_checked_types.length > 0) {
        $('#example1 tr').each(function (i, row) {
            var $tds = $(this).find('td')
            if ($tds.length) {
                var type = $tds[18].innerText;

                if (type == "True" && all_checked_types.indexOf(type)) {
                    $(this).show();
                }
                else {
                    $(this).hide();
                }
            }
        });
    }
    else {
        $('#example1 tr').each(function (i, row) {
            var $tds = $(this).find('td'),
                type = $tds.eq(18).text();
            $(this).show();
        });
    }
    return true;
}



function filter_type3(box) {
    var cbs = document.getElementsByTagName('input');
    var all_checked_types = [];
    for (var i = 0; i < cbs.length; i++) {
        if (cbs[i].type == "checkbox") {
            if (cbs[i].name.match(/^filter/)) {
                if (cbs[i].checked) {
                    all_checked_types.push(cbs[i].value);
                }
            }
        }
    }
    if (all_checked_types.length > 0) {
        $('#example1 tr').each(function (i, row) {
            var $tds = $(this).find('td')
            if ($tds.length) {
                var type = $tds[3].innerText;
                console.log(type)
                if (!(type && all_checked_types.indexOf(type) >= 0)) {
                    $(this).hide();
                }
                else {
                    $(this).show();
                }
            }
        });

    }
    else {
        $('#example1 tr').each(function (i, row) {
            var $tds = $(this).find('td'),
                type = $tds.eq(3).text();
            $(this).show();
        });
    }
    return true;
}

$('#tblDestek tr').click(function perosnelIdGonder() {

    let personel = document.getElementById('btnDegistirCariPersonel2');

    let radio = document.querySelector('input[name="radio"]:checked').value;

    //  personel.innerText=radio;
    personel.value = radio;
});


$('#tblDestekG tr').click(function perosnelIdGonder() {

    let personel = document.getElementById('btnDegistirTempCariPersonel');

    let radio = document.querySelector('input[name="radio"]:checked').value;

    // personel.innerText=radio;
    personel.value = radio;
});
function CariNo() {
    var cariId = $('#inputCari').val();

    var servisNo = document.getElementById("inputServisNo");

    var servisNoVal = servisNo.value;
    var cariNo = document.getElementById("inputCariNo");
    $.ajax({
        url: '/Servis/HesapKoduGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { cariId: cariId },
        success: function (caris) {
            cariNo.value = caris;
            $.ajax({
                url: '/Servis/ServisSiraGetir',
                type: 'GET',
                dataType: 'JSON',
                contentType: 'application/json; charset=utf-8',
                success: function (siras) {
                    servisNo.value = caris + "-" + siras;
                }
            })


        }
    });
}
function CariNoW() {
    var cariId = $('#inputCariW').val();

    var servisNo = document.getElementById("inputServisNoWL");

    var servisNoVal = servisNo.value;
    var cariNo = document.getElementById("inputCariNoWL");
    $.ajax({
        url: '/Servis/HesapKoduGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { cariId: cariId },
        success: function (caris) {
            cariNo.value = caris;
            $.ajax({
                url: '/Servis/ServisSiraGetir',
                type: 'GET',
                dataType: 'JSON',
                contentType: 'application/json; charset=utf-8',
                success: function (siras) {
                    servisNo.value = caris + "-" + siras;
                }
            })
        }
    });
}
function CariNoWL() {
    var cariId = $('#inputCariWL').val();

    var servisNo = document.getElementById("inputServisNoWL");

    var servisNoVal = servisNo.value;
    var cariNo = document.getElementById("inputCariNoWL");
    $.ajax({
        url: '/Servis/HesapKoduGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { cariId: cariId },
        success: function (caris) {
            cariNo.value = caris;
            $.ajax({
                url: '/Servis/ServisSiraGetir',
                type: 'GET',
                dataType: 'JSON',
                contentType: 'application/json; charset=utf-8',
                success: function (siras) {
                    servisNo.value = caris + "-" + siras;
                }
            })
        }
    });
}


function clickSummernote(tempKalemId) {
    let row = document.getElementById("tempKalemRow");
    $.ajax({
        url: '/Servis/KalemAciklamaGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: tempKalemId },
        success: function (kalems) {
            //  row.style.color = "#FF0000";
            $('#summernote1').summernote('code', kalems.aciklama);
        }
    });
}
function clickSummernoteG(kalemId) {
    let row = document.getElementById("kalemRow");
    $.ajax({
        url: '/Servis/KalemAciklamaGetirG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: kalemId },
        success: function (kalems) {
            //row.style.color = "#FF0000";
            $('#summernote1').summernote('code', kalems.aciklama);
        }
    });
}
function ServisBilgileriDbl(id) {
    window.location.href = '/Servis/ServisGuncelle?id=' + id;
}
function doubleClickG(kalemId) {
    AjaxFormSubmit();
    let id = kalemId;
    let basZamaani = document.getElementById("edtKalemBaslangicZamani");
    let gnlAciklamma = document.getElementById("edtKalemGenelAciklama");
    let islemYapan = document.getElementById("edtKalemIslemYapan");
    let islemYeri = document.getElementById("edtKalemIslemYeri");
    let sonDurum = document.getElementById("edtKalemSonDurum");
    let btnTempKalemDuzenle = document.getElementById("inputKalemId");
    let btnTempKalemSil = document.getElementById("btnTempKalemSil");
    let mevcutKalem = document.getElementById("inputMevcutKalem");
    // btnTempKalemDuzenle.setAttribute("asp-route-id", kalemId);
    btnTempKalemDuzenle.value = kalemId;
    btnTempKalemSil.value = kalemId;
    let bitisZamani = document.getElementById("edtKalemBitisTarihi");
    let sure = document.getElementById("edtKalemSure");
    $("#modalKalemDuzenle").modal("toggle");
    $.ajax({
        url: '/Servis/KalemGetirG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: kalemId },
        success: function (kalems) {
            mevcutKalem.value = true;
            basZamaani.innerHTML = kalems.baslamaZamani;
            basZamaani.innerText = kalems.baslamaZamani;
            basZamaani.textContent = kalems.baslamaZamani;
            basZamaani.text = kalems.baslamaZamani;
            basZamaani.value = kalems.baslamaZamani.toString().substring(0, 16);
            gnlAciklamma.value = kalems.genelAciklama;
            // islemYapan.value=kalems.personelId;
            // islemYeri.value=kalems.islemYeriId;
            // sonDurum.value=kalems.sonDurumId;
            bitisZamani.value = kalems.bitisZamani.substring(0, 16);
            sure.value = kalems.sure;
            $('#edtKalemAciklama').summernote('code', kalems.aciklama);
            SonDurumGetirG(kalemId);
            IslemYeriGetirG(kalemId);
            PersonelGetirG(kalemId);
        }
    });
}
function doubleClickGr(kalemId) {
    AjaxFormSubmit();
    let id = kalemId;
    let basZamaani = document.getElementById("edtKalemBaslangicZamani");
    let gnlAciklamma = document.getElementById("edtKalemGenelAciklama");
    let islemYapan = document.getElementById("edtKalemIslemYapan");
    let islemYeri = document.getElementById("edtKalemIslemYeri");
    let sonDurum = document.getElementById("edtKalemSonDurum");
    let btnTempKalemDuzenle = document.getElementById("inputKalemId");
    let btnTempKalemSil = document.getElementById("btnTempKalemSil");
    let mevcutKalem = document.getElementById("inputMevcutKalem");
    // btnTempKalemDuzenle.setAttribute("asp-route-id", kalemId);
    btnTempKalemDuzenle.value = kalemId;
    btnTempKalemSil.value = kalemId;
    let bitisZamani = document.getElementById("edtKalemBitisTarihi");
    let sure = document.getElementById("edtKalemSure");
    $("#modalKalemGor").modal("toggle");
    $.ajax({
        url: '/Servis/KalemGetirG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: kalemId },
        success: function (kalems) {
            mevcutKalem.value = true;
            basZamaani.innerHTML = kalems.baslamaZamani;
            basZamaani.innerText = kalems.baslamaZamani;
            basZamaani.textContent = kalems.baslamaZamani;
            basZamaani.text = kalems.baslamaZamani;
            basZamaani.value = kalems.baslamaZamani.toString().substring(0, 16);;
            gnlAciklamma.value = kalems.genelAciklama;
            // islemYapan.value=kalems.personelId;
            // islemYeri.value=kalems.islemYeriId;
            // sonDurum.value=kalems.sonDurumId;
            bitisZamani.value = kalems.bitisZamani.substring(0, 16);
            sure.value = kalems.sure;
            $('#edtKalemAciklama').summernote('code', kalems.aciklama);
            SonDurumGetirGr(kalemId);
            IslemYeriGetirGr(kalemId);
            PersonelGetirG(kalemId);
        }
    });
}
function doubleClick(tempKalemId) {
    AjaxFormSubmit();
    let id = tempKalemId;
    let basZamaani = document.getElementById("edtKalemBaslangicZamani");
    let gnlAciklamma = document.getElementById("edtKalemGenelAciklama");
    let islemYapan = document.getElementById("edtKalemIslemYapan");
    let islemYeri = document.getElementById("edtKalemIslemYeri");
    let sonDurum = document.getElementById("edtKalemSonDurum");
    let btnTempKalemDuzenle = document.getElementById("inputKalemId");
    let btnTempKalemSil = document.getElementById("btnTempKalemSil");
    // btnTempKalemDuzenle.setAttribute("asp-route-id", tempKalemId);
    btnTempKalemDuzenle.value = tempKalemId;
    btnTempKalemSil.value = tempKalemId;
    let bitisZamani = document.getElementById("edtKalemBitisTarihi");
    let sure = document.getElementById("edtKalemSure");
    $("#modalKalemDuzenle").modal("toggle");
    $.ajax({
        url: '/Servis/KalemGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: tempKalemId },
        success: function (kalems) {
            basZamaani.value = kalems.baslamaZamani.toString().substring(0, 16);;
            gnlAciklamma.value = kalems.genelAciklama;
            // islemYapan.value=kalems.personelId;
            // islemYeri.value=kalems.islemYeriId;
            // sonDurum.value=kalems.sonDurumId;
            bitisZamani.value = kalems.bitisZamani.substring(0, 16);
            sure.value = kalems.sure;
            $('#edtKalemAciklama').summernote('code', kalems.aciklama);
            SonDurumGetir(tempKalemId);
            IslemYeriGetir(tempKalemId);
            PersonelGetir(tempKalemId);
        }
    });
}
function AjaxFormSubmit() {
    //Set the URL.
    var url = $("#frmServis").attr("action");
    let chckKapandi = false;
    let chckMusteriOnayi = false;
    if ($('#inputMusteriOnayi').is(":checked")) {
        chckMusteriOnayi = true;
    }
    if ($('#inputKapandi').is(":checked")) {
        chckKapandi = true;
    }
    var formData = new FormData();
    formData.append("ServisNo", $("#inputServisNo").val());
    formData.append("CariId", $("#inputCari").val());
    formData.append("ServisDepartmanId", $("#inputDepartman").val());
    formData.append("ModulId", $("#inputModul").val());
    formData.append("DepartmanYetkilisi", $("#inputYetkili").val());
    formData.append("Konu", $("#inputKonu").val());
    formData.append("OncelikId", $("#inputOncelik").val());
    formData.append("ServisSekliId", $("#inputServisSekli").val());
    formData.append("ServisTipiId", $("#inputServisTipi").val());
    formData.append("PersonelId", $("#inputSorumlu").val());
    formData.append("TSuresi", $("#inputTSuresi").val());
    formData.append("FTSuresi", $("#inputFTSuresi").val());
    formData.append("TarihSaat", $("#inputTarihSaat").val());
    formData.append("PlanlananTarih", $("#inputPalanlananTarih").val());
    formData.append("TahminiSure", $("#inputTahiminiSure").val());
    formData.append("GercekSure", $("#inputGercekSure").val());
    formData.append("GirilenSure", $("#inputGirilenSure").val());
    formData.append("SonDurumTarihi", $("#inputSonDurumTarihi").val());
    formData.append("SonDurumID", $("#inputSonDurum").val());
    formData.append("Kapandi", chckKapandi);
    formData.append("MusteriOnayi", chckMusteriOnayi);

    $.ajax({
        type: 'POST',
        url: url,
        data: formData,
        processData: false,
        contentType: false
    })
}
function SonDurumGetir(tempKalemId) {
    $.ajax({
        url: '/Servis/SonDurumGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: tempKalemId },
        success: function (sonDurums) {
            $("#edtKalemSonDurum").html("");
            var s = '<option selected  value="' + sonDurums.sonDurumId + '" >' + sonDurums.sonDurumAciklama + '</option>';
            $.ajax({
                url: '/Servis/SonDurumList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (sonDurumList) {
                    $("#edtKalemSonDurum").html(s);
                    $.each(sonDurumList, function (i, db) {
                        $("#edtKalemSonDurum").append(
                            $('<option></option>').val(db.sonDurumId).html(db.sonDurumAciklama));
                    });
                }
            })

        }
    });
}
function SonDurumGetirGr(tempKalemId) {
    $.ajax({
        url: '/Servis/SonDurumGetirG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: tempKalemId },
        success: function (sonDurums) {
            document.getElementById("edtKalemSonDurum").value = sonDurums.sonDurumAciklama;
        }
    });
}
function SonDurumGetirG(kalemId) {
    $.ajax({
        url: '/Servis/SonDurumGetirG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: kalemId },
        success: function (sonDurums) {
            $("#edtKalemSonDurum").html("");
            var s = '<option selected  value="' + sonDurums.sonDurumId + '" >' + sonDurums.sonDurumAciklama + '</option>';
            $.ajax({
                url: '/Servis/SonDurumList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (sonDurumList) {
                    $("#edtKalemSonDurum").html(s);
                    $.each(sonDurumList, function (i, db) {
                        $("#edtKalemSonDurum").append(
                            $('<option></option>').val(db.sonDurumId).html(db.sonDurumAciklama));
                    });
                }
            })
        }
    });
}
function IslemYeriGetir(tempKalemId) {
    $.ajax({
        url: '/Servis/IslemYeriGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: tempKalemId },
        success: function (islemYeris) {
            $("#edtKalemIslemYeri").html("");
            var s = '<option selected  value="' + islemYeris.islemYeriId + '" >' + islemYeris.islemYeriAdi + '</option>';
            $.ajax({
                url: '/Servis/IslemYeriList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (islemYeriList) {
                    $("#edtKalemIslemYeri").html(s);
                    $.each(islemYeriList, function (i, db) {
                        $("#edtKalemIslemYeri").append(
                            $('<option></option>').val(db.islemYeriId).html(db.islemYeriAdi));
                    });
                }
            })

        }
    });
}
function IslemYeriGetirGr(tempKalemId) {
    $.ajax({
        url: '/Servis/IslemYeriGetirG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: tempKalemId },
        success: function (islemYeris) {
            document.getElementById("edtKalemIslemYeri").value = islemYeris.islemYeriAdi
        }
    });
}
function IslemYeriGetirG(kalemId) {
    $.ajax({
        url: '/Servis/IslemYeriGetirG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: kalemId },
        success: function (islemYeris) {
            $("#edtKalemIslemYeri").html("");
            var s = '<option selected  value="' + islemYeris.islemYeriId + '" >' + islemYeris.islemYeriAdi + '</option>';
            $.ajax({
                url: '/Servis/IslemYeriList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (islemYeriList) {
                    $("#edtKalemIslemYeri").html(s);
                    $.each(islemYeriList, function (i, db) {
                        $("#edtKalemIslemYeri").append(
                            $('<option></option>').val(db.islemYeriId).html(db.islemYeriAdi));
                    });
                }
            })

        }
    });
}
function PersonelGetir(tempKalemId) {
    $.ajax({
        url: '/Servis/PersonelGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: tempKalemId },
        success: function (personels) {
            let personelAdi2 = personels.personelAdi2;
            if (personelAdi2 == null) {
                personelAdi2 = "";
            }
            else {
                personelAdi2 = personelAdi2;
            }
            let personelAdi = personels.personelAdi + " " + personelAdi2 + " " + personels.personelSoyadi;
            document.getElementById("edtKalemIslemYapan").value = personelAdi;
            //$("#edtKalemIslemYapan").html("");
            // let personelAdi2 = personels.personelAdi2;
            // if (personelAdi2 == null) {
            //     personelAdi2 = "";
            // }
            // else {
            //     personelAdi2 = personelAdi2;
            // }
            // var s = '<option selected  value="' + personels.personelId + '" >' + personels.personelAdi + " " + personelAdi2 + " " + personels.personelSoyadi + '</option>';
            // $.ajax({
            //     url: '/Servis/PersonelList',
            //     type: "GET",
            //     dataType: "JSON",
            //     contentType: "application/json;charset=utf-8",
            //     success: function (personelList) {

            //         // $("#edtKalemIslemYapan").html(s);
            //         // $.each(personelList, function (i, db) {
            //         //     let personelAdi2 = db.personelAdi2;
            //         //     if (personelAdi2 == null) {
            //         //         personelAdi2 = "";
            //         //     }
            //         //     else {
            //         //         personelAdi2 = personelAdi2;
            //         //     }
            //         //     $("#edtKalemIslemYapan").append(
            //         //         $('<option></option>').val(db.personelId).html(db.personelAdi + " " + personelAdi2 + " " + db.personelSoyadi));
            //         // });
            //     }
            // })

        }
    });
}
function PersonelGetirG(kalemId) {
    $.ajax({
        url: '/Servis/PersonelGetirG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { kalemId: kalemId },
        success: function (personels) {

            let personelAdi2 = personels.personelAdi2;
            if (personelAdi2 == null) {
                personelAdi2 = "";
            }
            else {
                personelAdi2 = personelAdi2;
            }
            let personelAdi = personels.personelAdi + " " + personelAdi2 + " " + personels.personelSoyadi;
            document.getElementById("edtKalemIslemYapan").value = personelAdi;
            // var s = '<option selected  value="' + personels.personelId + '" >' + personels.personelAdi + " " + personelAdi2 + " " + personels.personelSoyadi + '</option>';
            // $.ajax({
            //     url: '/Servis/PersonelList',
            //     type: "GET",
            //     dataType: "JSON",
            //     contentType: "application/json;charset=utf-8",
            //     success: function (personelList) {
            //         $("#edtKalemIslemYapan").html(s);
            //         $.each(personelList, function (i, db) {
            //             let personelAdi2 = db.personelAdi2;
            //             if (personelAdi2 == null) {
            //                 personelAdi2 = "";
            //             }
            //             else {
            //                 personelAdi2 = personelAdi2;
            //             }
            //             $("#edtKalemIslemYapan").append(
            //                 $('<option></option>').val(db.personelId).html(db.personelAdi + " " + personelAdi2 + " " + db.personelSoyadi));
            //         });
            //     }
            // })

        }
    });
}
function BaslangicZamani() {
    let planlanan = document.getElementById("inputPalanlananTarih");
    let baslangic = document.getElementById("kalemBaslangicZamani");
    baslangic.value = planlanan.value;
}
function BaslangicZamaniW() {
    let planlanan = document.getElementById("inputPalanlananTarihW");
    let baslangic = document.getElementById("kalemBaslangicZamaniW");
    let baslangic2 = document.getElementById("kalemBaslangicZamaniWL");
    baslangic.value = planlanan.value;
    baslangic2.value = planlanan.value;
}
function TahminiSureGetir() {
    let baslangic = document.getElementById("inputTarihSaat");
    let bitis = document.getElementById("inputPalanlananTarih");
    let sure = document.getElementById("inputTahiminiSure");
    if (baslangic.value != "" && bitis.value != "") {
        $.ajax({
            url: '/Servis/KalanSureGetir',
            type: "GET",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { baslangicZamani: baslangic.value, bitisZamani: bitis.value },
            success: function (kalanSure) {
                sure.value = kalanSure;
            }
        });
    }
}
function KalanSureGetir() {
    let baslangic = document.getElementById("kalemBaslangicZamani");
    let bitis = document.getElementById("kalemBitisTarihi");
    let sure = document.getElementById("kalemSure");
    if (baslangic.value != "" && bitis.value != "") {
        $.ajax({
            url: '/Servis/KalanSureGetir',
            type: "GET",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { baslangicZamani: baslangic.value, bitisZamani: bitis.value },
            success: function (kalanSure) {
                sure.value = kalanSure;
            }
        });
    }
}
function KalanSureGetirEdt() {
    let baslangic = document.getElementById("edtKalemBaslangicZamani");
    let bitis = document.getElementById("edtKalemBitisTarihi");
    let sure = document.getElementById("edtKalemSure");
    if (baslangic.value != "" && bitis.value != "") {
        $.ajax({
            url: '/Servis/KalanSureGetir',
            type: "GET",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { baslangicZamani: baslangic.value, bitisZamani: bitis.value },
            success: function (kalanSure) {
                sure.value = kalanSure;
            }
        });
    }
}
function KalanSureGetirW() {
    let baslangic = document.getElementById("kalemBaslangicZamaniW");
    let bitis = document.getElementById("kalemBitisTarihiW");
    let sure = document.getElementById("kalemSureW");
    let sureWL = document.getElementById("kalemSureWL");
    if (baslangic.value != "" && bitis.value != "") {
        $.ajax({
            url: '/Servis/KalanSureGetir',
            type: "GET",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { baslangicZamani: baslangic.value, bitisZamani: bitis.value },
            success: function (kalanSure) {
                sure.value = kalanSure;
                sureWL.value = kalanSure;
            }
        });
    }
}
function KalanSureGetirWL() {
    let baslangic = document.getElementById("kalemBaslangicZamaniWL");
    let bitis = document.getElementById("kalemBitisTarihiWL");
    let sure = document.getElementById("kalemSureWL");
    let sureW = document.getElementById("kalemSureW");
    if (baslangic.value != "" && bitis.value != "") {
        $.ajax({
            url: '/Servis/KalanSureGetir',
            type: "GET",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { baslangicZamani: baslangic.value, bitisZamani: bitis.value },
            success: function (kalanSure) {
                sure.value = kalanSure;
                sureW.value = kalanSure;
            }
        });
    }
}
function FullScreen() {
    let clicked = true;

    let kalemCard = document.getElementById("kalemler");
    if (clicked) {
        kalemCard.classList.add("full_screen");
    } else {
        kalemCard.classList.remove("full_screen");
    }
    clicked = !clicked;

}
function ShowModal() {
    $('#modalKalemEkle').modal('show');
}

function Wizard(input) {

    if (input == "summernoteWizard") {
        let summernoteWL = document.getElementById("summernoteWizardL").innerText
        $('#summernoteWizard').summernote('code', summernoteWL);
    }
    else {

        let inputW = document.getElementById(`${input}`);
        let inputWL = document.getElementById(`${input}L`);
        inputWL.value = inputW.value;
    }
}
function WizardL(input) {
    if (input == "summernoteWizard") {
        let summernoteWL = document.getElementById("summernoteWizardL").innerText
        $('#summernoteWizard').summernote('code', summernoteWL);
    }
    else {
        let substr = input.slice(0, -1);
        let inputWL = document.getElementById(`${input}`);
        let inputW = document.getElementById(`${substr}`);
        inputW.value = inputWL.value;
    }
}
function WSelectCari(input) {
    let inputW = document.getElementById(`${input}`);
    let inputWL = document.getElementById(`${input}L`);
    let val = inputW.value;
    inputWL.value = val;
    $.ajax({
        url: '/Servis/CariGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#inputCariWL").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/CariListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#inputCariWL").html(s);
                    $.each(cariList, function (i, db) {
                        $(`#${input}L`).append(
                            $('<option></option>').val(db.cariId).html(db.cariAdi));
                    });
                }
            })

        }
    });

}
function WSelectDepartman(input) {
    let inputW = document.getElementById(`${input}`);
    let inputWL = document.getElementById(`${input}L`);
    let val = inputW.value;
    inputWL.value = val;
    $.ajax({
        url: '/Servis/DepartmanGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $(`#${input}L`).html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/DepartmanListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $(`#${input}L`).html(s);
                    $.each(cariList, function (i, db) {
                        $(`#${input}L`).append(
                            $('<option></option>').val(db.servisDepartmanId).html(db.servisDepartmanAdi));
                    });
                }
            })

        }
    });

}
function WSelectModul(input) {
    let inputW = document.getElementById(`${input}`);
    let inputWL = document.getElementById(`${input}L`);
    let val = inputW.value;
    inputWL.value = val;
    $.ajax({
        url: '/Servis/ModulGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $(`#${input}L`).html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/ModulListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $(`#${input}L`).html(s);
                    $.each(cariList, function (i, db) {
                        $(`#${input}L`).append(
                            $('<option></option>').val(db.modulId).html(db.modulAdi));
                    });
                }
            })

        }
    });
}
function WSelectOncelik(input) {
    let inputW = document.getElementById(`${input}`);
    let inputWL = document.getElementById(`${input}L`);
    let val = inputW.value;
    inputWL.value = val;
    $.ajax({
        url: '/Servis/OncelikGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $(`#${input}L`).html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/OncelikListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $(`#${input}L`).html(s);
                    $.each(cariList, function (i, db) {
                        $(`#${input}L`).append(
                            $('<option></option>').val(db.oncelikId).html(db.oncelikAciklama));
                    });
                }
            })

        }
    });

}
function WSelectServisSekli(input) {
    let inputW = document.getElementById(`${input}`);
    let inputWL = document.getElementById(`${input}L`);
    let val = inputW.value;
    inputWL.value = val;
    $.ajax({
        url: '/Servis/ServisSekliGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $(`#${input}L`).html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/ServisSekliListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $(`#${input}L`).html(s);
                    $.each(cariList, function (i, db) {
                        $(`#${input}L`).append(
                            $('<option></option>').val(db.servisSekliId).html(db.servisSekliAciklama));
                    });
                }
            })

        }
    });

}
function WSelectServisTipi(input) {
    let inputW = document.getElementById(`${input}`);
    let inputWL = document.getElementById(`${input}L`);
    let val = inputW.value;
    inputWL.value = val;
    $.ajax({
        url: '/Servis/ServisTipiGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $(`#${input}L`).html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/ServisTipiListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $(`#${input}L`).html(s);
                    $.each(cariList, function (i, db) {
                        $(`#${input}L`).append(
                            $('<option></option>').val(db.servisTipiId).html(db.servisTipiAciklama));
                    });
                }
            })

        }
    });

}
function WSelectSorumlu(input) {
    let inputW = document.getElementById(`${input}`);
    let inputWL = document.getElementById(`${input}L`);
    let val = inputW.value;
    inputWL.value = val;
    let personelAdi2 = "";
    $.ajax({
        url: '/Servis/SorumluGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $(`#${input}L`).html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/SorumluListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $(`#${input}L`).html(s);
                    $.each(cariList, function (i, db) {
                        if (db.personelAdi2 == null) {
                            personelAdi2 = "";
                        }
                        $(`#${input}L`).append(
                            $('<option></option>').val(db.personelId).html(db.personelAdi + " " + personelAdi2 + " " + db.personelSoyadi));
                    });
                }
            })

        }
    });

}
function WSelectSonDurum(input) {
    let inputW = document.getElementById(`${input}`);
    let inputWL = document.getElementById(`${input}L`);
    let val = inputW.value;
    inputWL.value = val;
    $.ajax({
        url: '/Servis/SonDurumGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $(`#${input}L`).html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/SonDurumListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $(`#${input}L`).html(s);
                    $.each(cariList, function (i, db) {
                        $(`#${input}L`).append(
                            $('<option></option>').val(db.sonDurumId).html(db.sonDurumAciklama));
                    });
                }
            })

        }
    });

}
function WSelectIslemYeri(input) {
    let inputW = document.getElementById(`${input}`);
    let inputWL = document.getElementById(`${input}L`);
    let val = inputW.value;
    inputWL.value = val;
    $.ajax({
        url: '/Servis/IslemYeriGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $(`#${input}L`).html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/IslemYeriListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $(`#${input}L`).html(s);
                    $.each(cariList, function (i, db) {
                        $(`#${input}L`).append(
                            $('<option></option>').val(db.islemYeriId).html(db.islemYeriAdi));
                    });
                }
            })

        }
    });

}

function WLSelectCari(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    inputW.value = val;
    $.ajax({
        url: '/Servis/CariGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#inputCariW").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/CariListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#inputCariW").html(s);
                    $.each(cariList, function (i, db) {
                        $(`#${input}`).append(
                            $('<option></option>').val(db.cariId).html(db.cariAdi));
                    });
                }
            })

        }
    });

}
function WLSelectDepartman(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    inputW.value = val;
    $.ajax({
        url: '/Servis/DepartmanGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#inputDepartmanW").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/DepartmanListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#inputDepartmanW").html(s);
                    $.each(cariList, function (i, db) {
                        $("#inputDepartmanW").append(
                            $('<option></option>').val(db.servisDepartmanId).html(db.servisDepartmanAdi));
                    });
                }
            })

        }
    });

}
function WLSelectModul(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    inputW.value = val;
    $.ajax({
        url: '/Servis/ModulGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#inputModulW").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/ModulListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#inputModulW").html(s);
                    $.each(cariList, function (i, db) {
                        $("#inputModulW").append(
                            $('<option></option>').val(db.modulId).html(db.modulAdi));
                    });
                }
            })

        }
    });
}
function WLSelectOncelik(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    inputW.value = val;
    $.ajax({
        url: '/Servis/OncelikGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#inputOncelikW").html("");
            // $(`#${inputW}`).html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/OncelikListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#inputOncelikW").html(s);
                    $.each(cariList, function (i, db) {
                        $("#inputOncelikW").append(
                            $('<option></option>').val(db.oncelikId).html(db.oncelikAciklama));
                    });
                }
            })

        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });

}
function WLSelectServisSekli(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    inputW.value = val;
    $.ajax({
        url: '/Servis/ServisSekliGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#inputServisSekliW").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/ServisSekliListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#inputServisSekliW").html(s);
                    $.each(cariList, function (i, db) {
                        $("#inputServisSekliW").append(
                            $('<option></option>').val(db.servisSekliId).html(db.servisSekliAciklama));
                    });
                }
            })

        }
    });

}
function WLSelectServisTipi(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    inputW.value = val;
    $.ajax({
        url: '/Servis/ServisTipiGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#inputServisTipiW").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/ServisTipiListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#inputServisTipiW").html(s);
                    $.each(cariList, function (i, db) {
                        $("#inputServisTipiW").append(
                            $('<option></option>').val(db.servisTipiId).html(db.servisTipiAciklama));
                    });
                }
            })

        }
    });

}
function WLSelectSorumlu(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    let personelAdi2 = "";
    inputW.value = val;
    $.ajax({
        url: '/Servis/SorumluGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#inputSorumluW").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/SorumluListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#inputSorumluW").html(s);
                    $.each(cariList, function (i, db) {
                        if (db.personelAdi2 == null) {
                            personelAdi2 = "";
                        }
                        $("#inputSorumluW").append(
                            $('<option></option>').val(db.personelId).html(db.personelAdi + " " + personelAdi2 + " " + db.personelSoyadi));
                    });
                }
            })

        }
    });

}
function WLSelectSonDurum(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    inputW.value = val;
    $.ajax({
        url: '/Servis/SonDurumGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#inputSonDurumW").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/SonDurumListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#inputSonDurumW").html(s);
                    $.each(cariList, function (i, db) {
                        $("#inputSonDurumW").append(
                            $('<option></option>').val(db.sonDurumId).html(db.sonDurumAciklama));
                    });
                }
            })

        }
    });

}
function WLSelectSonDurumKalem(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    inputW.value = val;
    $.ajax({
        url: '/Servis/SonDurumGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#kalemSonDurumW").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/SonDurumListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#kalemSonDurumW").html(s);
                    $.each(cariList, function (i, db) {
                        $("#kalemSonDurumW").append(
                            $('<option></option>').val(db.sonDurumId).html(db.sonDurumAciklama));
                    });
                }
            })

        }
    });

}
function WLSelectIslemYeriKalem(input) {
    let substr = input.slice(0, -1);
    let inputWl = document.getElementById(`${input}`);
    let inputW = document.getElementById(`${substr}`);
    let val = inputWl.value;
    inputW.value = val;
    $.ajax({
        url: '/Servis/IslemYeriGetirW',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: val },
        success: function (caris) {
            $("#kalemIslemYeriW").html("");
            var s = '<option selected  value="' + val + '" >' + caris + '</option>';
            $.ajax({
                url: '/Servis/IslemYeriListW',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (cariList) {
                    $("#kalemIslemYeriW").html(s);
                    $.each(cariList, function (i, db) {
                        $("#kalemIslemYeriW").append(
                            $('<option></option>').val(db.islemYeriId).html(db.islemYeriAdi));
                    });
                }
            })
        }
    });
}
function DurumFilter(id) {

    window.location.href = '/Servis/ServisBilgileri?sonDurumId=' + id;

}
function KapandiServis() {
    let tumu = document.getElementById("chckTumuServis");
    tumu.checked = !tumu.checked;
}
function TumuServis() {
    let kapandi = document.getElementById("chckKapandiServis");
    kapandi.checked = !kapandi.checked;
}
function ProjeKullaniciAdi() {
    let selectKullanici = document.getElementById("selectKullaniciAdiProje");
    let labelKullanici = document.getElementById("inputKullaniciAdiProje");
    let id = selectKullanici.value;
    $.ajax({
        url: '/Proje/PersonelGetir',
        type: "GET",
        dataType: "JSON",
        data: { id: id },
        contentType: "application/json;charset=utf-8",
        success: function (personel) {
            let personelAdi2 = "";
            if (personel.personelAdi2 == null) {
                personelAdi2 = "";
            }
            labelKullanici.value = personel.personelAdi + " " + personelAdi2 + " " + personel.personelSoyadi;

        }
    })

}
function ProjeKullaniciAdiEdt() {
    let selectKullanici = document.getElementById("edtSelectKullaniciAdiProje");
    let labelKullanici = document.getElementById("edtInputKullaniciAdiProje");
    let id = selectKullanici.value;
    $.ajax({
        url: '/Proje/PersonelGetir',
        type: "GET",
        dataType: "JSON",
        data: { id: id },
        contentType: "application/json;charset=utf-8",
        success: function (personel) {
            let personelAdi2 = "";
            if (personel.personelAdi2 != null) {
                personelAdi2 = personel.personelAdi2;
            }
            labelKullanici.value = personel.personelAdi + " " + personelAdi2 + " " + personel.personelSoyadi;

        }
    })

}
$(window).keydown(function () {
    if (event.keyCode == 73) {
        $('#modalDanismanEkle').modal('show');
    }
});

function doubleClickProjeDanismanEkle(tempDanismanId) {
    let id = tempDanismanId;
    let kullaniciAdi = document.getElementById("edtSelectKullaniciAdiProje");
    let personelAdi = document.getElementById("edtInputKullaniciAdiProje");
    let btnTempKalemDuzenle = document.getElementById("inputKalemId");
    let btnTempDanismanSil = document.getElementById("btnTempDanismanSil");
    document.getElementById("inputDanismanId").value = tempDanismanId;
    // btnTempKalemDuzenle.setAttribute("asp-route-id", tempKalemId);
    //btnTempKalemDuzenle.value = tempKalemId;
    btnTempDanismanSil.value = tempDanismanId;
    $("#modalDanismanDuzenle").modal("toggle");
    $.ajax({
        url: '/Proje/PersonelGetirEdt',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempDanismanId },
        success: function (personels) {
            let personelAdi2 = "";
            if (personels.personelAdi2 != null) {
                personelAdi2 = personels.personelAdi2;
            }
            personelAdi.value = personels.personelAdi + " " + personelAdi2 + " " + personels.personelSoyadi;
            $("#edtSelectKullaniciAdiProje").html("");
            var s = '<option selected  value="' + personels.personelId + '" >' + personels.personelKullaniciAdi + '</option>';
            $.ajax({
                url: '/Proje/PersonelList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (personelList) {
                    $("#edtSelectKullaniciAdiProje").html(s);
                    $.each(personelList, function (i, db) {
                        $("#edtSelectKullaniciAdiProje").append(
                            $('<option></option>').val(db.personelId).html(db.personelKullaniciAdi));
                    });
                }
            })
            PersonelTipiGetir(tempDanismanId);
        }
    });
}

function PersonelTipiGetir(tempDanismanId) {
    let personelTipi = document.getElementById("edtSelectPersonelTipiProje");
    $.ajax({
        url: '/Proje/PersonelTipiGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempDanismanId },
        success: function (personelTipis) {
            $("#edtSelectPersonelTipiProje").html("");
            var s = '<option selected  value="' + personelTipis.personelTipiId + '" >' + personelTipis.personelTipiAciklama + '</option>';
            $.ajax({
                url: '/Proje/PersonelTipiList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (personelTipiList) {
                    $("#edtSelectPersonelTipiProje").html(s);
                    $.each(personelTipiList, function (i, db) {
                        $("#edtSelectPersonelTipiProje").append(
                            $('<option></option>').val(db.personelTipiId).html(db.personelTipiAciklama));
                    });
                }
            })

        }
    });
}

function doubleClickProjeFiyatEkle(tempFiyatListId) {
    let id = tempFiyatListId;
   
    let personelTipi = document.getElementById("edtSelectPersonelTipiF");

    let btnTempFiyatListSil = document.getElementById("btnTempFiyatSil");
    document.getElementById("inputFiyatListIdH").value = tempFiyatListId;
    btnTempFiyatListSil.value = tempFiyatListId;
  //  btnTempFiyatSil.value = tempFiyatListId;
    $("#modalFiyatDuzenle").modal("toggle");
    $.ajax({
        url: '/Proje/PersonelTipiGetirFiyat',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempFiyatListId },
        success: function (personels) {
   
            $("#edtSelectPersonelTipiF").html("");
            var s = '<option selected  value="' + personels.personelTipiId + '" >' + personels.personelTipiAciklama + '</option>';
            $.ajax({
                url: '/Proje/PersonelTipiList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (personelList) {
                    $("#edtSelectPersonelTipiF").html(s);
                    $.each(personelList, function (i, db) {
                        $("#edtSelectPersonelTipiF").append(
                            $('<option></option>').val(db.personelTipiId).html(db.personelTipiAciklama));
                    });
                }
            })
            ParaBirimiGetirProje(tempFiyatListId);
            ProjeIcerikGetir(tempFiyatListId);
        }
    });
}
function ProjeIcerikGetir(tempFiyatListId) {
    let gecerlilikBaslangic = document.getElementById("edtProjeGecerlilikBaslangic");
    let gecerlilikBitis = document.getElementById("edtProjeGecerlilikBitis");
    let fiyat = document.getElementById("edtInputFiyat");
    $.ajax({
        url: "/Proje/ProjeIcerikGetir",
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempFiyatListId },
        success: function (tempFiyatList) {
            fiyat.value = tempFiyatList.fiyat;
            gecerlilikBaslangic.value = tempFiyatList.gecerlilikTarihBaslangic.substring(0, 10);
            gecerlilikBitis.value = tempFiyatList.gecerlilikTarihBitis.substring(0,10);
        }

    })
}
function ParaBirimiGetirProje(tempFiyatListId) {
    let paraBirimi = document.getElementById("edtSelectParaBirimiProje");
    $.ajax({
        url: '/Proje/ParaBirimiGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempFiyatListId },
        success: function (paraBirimis) {
            $("#edtSelectParaBirimiProje").html("");
            var s = '<option selected  value="' + paraBirimis.paraBirimiId + '" >' + paraBirimis.paraBirimiAdi+" "+paraBirimis.paraBirimiSimge + '</option>';
            $.ajax({
                url: '/Proje/ParaBirimiList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (paraBirimiList) {
                    $("#edtSelectParaBirimiProje").html(s);
                    $.each(paraBirimiList, function (i, db) {
                        $("#edtSelectParaBirimiProje").append(
                            $('<option></option>').val(db.paraBirimiId).html(db.paraBirimiAdi+" "+db.paraBirimiSimge));
                    
                    });
                }
            })

        }
    });
}
function doubleClickTempServisProjeEkle(tempProjeIcerikId) {
    let id = tempProjeIcerikId;
    let btnTempFiyatListSil = document.getElementById("btnTempFiyatSilServisProje");
    document.getElementById("inputServisProjeH").value = tempProjeIcerikId;
    btnTempFiyatListSil.value = tempProjeIcerikId;
    //  btnTempFiyatSil.value = tempFiyatListId;
    $("#modalFiyatDuzenle").modal("toggle");
    $.ajax({
        url: '/Proje/ModulGetirServisProje',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempProjeIcerikId },
        success: function (moduls) {

            $("#edtSelectModulServisProje").html("");
            var s = '<option selected  value="' + moduls.modulId + '" >' + moduls.modulAdi + '</option>';
            $.ajax({
                url: '/Proje/ModulList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (modulList) {
                    $("#edtSelectModulServisProje").html(s);
                    $.each(modulList, function (i, db) {
                        $("#edtSelectModulServisProje").append(
                            $('<option></option>').val(db.modulId).html(db.modulAdi));
                    });
                }
            })
            ParaBirimiGetirServisProje(tempProjeIcerikId);
            ServisProjeIcerikGetir(tempProjeIcerikId);
        }
    });
}
function ServisProjeIcerikGetir(tempProjeIcerikId) {
    let gecerlilikBaslangic = document.getElementById("edtInputGecerlilikBaslangicServisProje");
    let gecerlilikBitis = document.getElementById("edtInputGecerlilikBitisServisProje");
    let fiyat = document.getElementById("edtInputFiyatServisProje");
    $.ajax({
        url: "/Proje/TempServisProjeIcerikGetir",
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempProjeIcerikId },
        success: function (tempProjeIcerikList) {
            fiyat.value = tempProjeIcerikList.fiyat;
            gecerlilikBaslangic.value = tempProjeIcerikList.gecerlilikTarihBaslangic.substring(0, 10);
            gecerlilikBitis.value = tempProjeIcerikList.gecerlilikTarihBitis.substring(0, 10);
        }

    })
}
function ParaBirimiGetirServisProje(tempProjeIcerikId) {
    let paraBirimi = document.getElementById("edtSelectParaBirimiServisProje");
    $.ajax({
        url: '/Proje/ParaBirimiGetirServisProje',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempProjeIcerikId },
        success: function (paraBirimis) {
            $("#edtSelectParaBirimiServisProje").html("");
            var s = '<option selected  value="' + paraBirimis.paraBirimiId + '" >' + paraBirimis.paraBirimiAdi + " " + paraBirimis.paraBirimiSimge + '</option>';
            $.ajax({
                url: '/Proje/ParaBirimiList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (paraBirimiList) {
                    $("#edtSelectParaBirimiServisProje").html(s);
                    $.each(paraBirimiList, function (i, db) {
                        $("#edtSelectParaBirimiServisProje").append(
                            $('<option></option>').val(db.paraBirimiId).html(db.paraBirimiAdi + " " + db.paraBirimiSimge));

                    });
                }
            })

        }
    });
}
function ProjeGuncelle() {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    if (document.querySelector('input[name="radio"]:checked') == null) {
        Toast.fire({
            icon: 'warning',
            title: 'Lütfen Seçim Yapınız.'
        })
    }

    else {
        let radio = document.querySelector('input[name="radio"]:checked').value;
        $.ajax({
            url: '/Proje/SayfaYonlendir',
            type: "GET",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            data: { id: radio },
            success: function (servisProjesi) {
                if (servisProjesi == true) {
                    window.location.href = '/Proje/ProjeDuzenleServis?id=' + radio;
                }
                else {
                    window.location.href = '/Proje/ProjeDuzenleDanisman?id=' + radio + "&isFirst=" + true;
                }
            }
        });
    }
}



function doubleClickServisProjeEkle(projeIcerikId) {
    let id = projeIcerikId;
    let btnTempFiyatListSil = document.getElementById("btnTempFiyatSilServisProje");
    document.getElementById("inputServisProjeH").value = projeIcerikId;
    btnTempFiyatListSil.value = projeIcerikId;
    //  btnTempFiyatSil.value = tempFiyatListId;
    $("#modalFiyatDuzenle").modal("toggle");
    $.ajax({
        url: '/Proje/ModulGetirServisProje',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: projeIcerikId },
        success: function (moduls) {

            $("#edtSelectModulServisProje").html("");
            var s = '<option selected  value="' + moduls.modulId + '" >' + moduls.modulAdi + '</option>';
            $.ajax({
                url: '/Proje/ModulList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (modulList) {
                    $("#edtSelectModulServisProje").html(s);
                    $.each(modulList, function (i, db) {
                        $("#edtSelectModulServisProje").append(
                            $('<option></option>').val(db.modulId).html(db.modulAdi));
                    });
                }
            })
            ParaBirimiGetirServisProjeG(projeIcerikId);
            ServisProjeIcerikGetirG(projeIcerikId);
        }
    });
}
function ServisProjeIcerikGetirG(tempProjeIcerikId) {
    let gecerlilikBaslangic = document.getElementById("edtInputGecerlilikBaslangicServisProje");
    let gecerlilikBitis = document.getElementById("edtInputGecerlilikBitisServisProje");
    let fiyat = document.getElementById("edtInputFiyatServisProje");
    $.ajax({
        url: "/Proje/TempServisProjeIcerikGetir",
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempProjeIcerikId },
        success: function (tempProjeIcerikList) {
            fiyat.value = tempProjeIcerikList.fiyat;
            gecerlilikBaslangic.value = tempProjeIcerikList.gecerlilikTarihBaslangic.substring(0, 10);
            gecerlilikBitis.value = tempProjeIcerikList.gecerlilikTarihBitis.substring(0, 10);
        }

    })
}
function ParaBirimiGetirServisProjeG(tempProjeIcerikId) {
    let paraBirimi = document.getElementById("edtSelectParaBirimiServisProje");
    $.ajax({
        url: '/Proje/ParaBirimiGetirServisProje',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempProjeIcerikId },
        success: function (paraBirimis) {
            $("#edtSelectParaBirimiServisProje").html("");
            var s = '<option selected  value="' + paraBirimis.paraBirimiId + '" >' + paraBirimis.paraBirimiAdi + " " + paraBirimis.paraBirimiSimge + '</option>';
            $.ajax({
                url: '/Proje/ParaBirimiList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (paraBirimiList) {
                    $("#edtSelectParaBirimiServisProje").html(s);
                    $.each(paraBirimiList, function (i, db) {
                        $("#edtSelectParaBirimiServisProje").append(
                            $('<option></option>').val(db.paraBirimiId).html(db.paraBirimiAdi + " " + db.paraBirimiSimge));

                    });
                }
            })

        }
    });
}

function doubleClickTempServisProjeGuncelle(tempProjeIcerikId) {
    let id = tempProjeIcerikId;
    let btnTempFiyatListSil = document.getElementById("btnTempFiyatSilServisProje");
    document.getElementById("inputServisProjeH").value = tempProjeIcerikId;
    btnTempFiyatListSil.value = tempProjeIcerikId;
    //  btnTempFiyatSil.value = tempFiyatListId;
    $("#modalFiyatDuzenle").modal("toggle");
    $.ajax({
        url: '/Proje/ModulGetirServisProje',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempProjeIcerikId },
        success: function (moduls) {

            $("#edtSelectModulServisProje").html("");
            var s = '<option selected  value="' + moduls.modulId + '" >' + moduls.modulAdi + '</option>';
            $.ajax({
                url: '/Proje/ModulList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (modulList) {
                    $("#edtSelectModulServisProje").html(s);
                    $.each(modulList, function (i, db) {
                        $("#edtSelectModulServisProje").append(
                            $('<option></option>').val(db.modulId).html(db.modulAdi));
                    });
                }
            })
            ParaBirimiGetirServisProje(tempProjeIcerikId);
            ServisProjeIcerikGetir(tempProjeIcerikId);
        }
    });
}

function doubleClickServisProjeGuncelle(projeIcerikId) {
    let id = projeIcerikId;
    let btnTempFiyatListSil = document.getElementById("btnTempFiyatSilServisProjeM");
    document.getElementById("inputServisProjeHM").value = projeIcerikId;
    btnTempFiyatListSil.value = projeIcerikId;
    //  btnTempFiyatSil.value = tempFiyatListId;
    $("#modalFiyatDuzenleMevcut").modal("toggle");
    $.ajax({
        url: '/Proje/ModulGetirServisProjeG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: projeIcerikId },
        success: function (moduls) {

            $("#edtSelectModulServisProjeM").html("");
            var s = '<option selected  value="' + moduls.modulId + '" >' + moduls.modulAdi + '</option>';
            $.ajax({
                url: '/Proje/ModulList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (modulList) {
                    $("#edtSelectModulServisProjeM").html(s);
                    $.each(modulList, function (i, db) {
                        $("#edtSelectModulServisProjeM").append(
                            $('<option></option>').val(db.modulId).html(db.modulAdi));
                    });
                }
            })
            ParaBirimiGetirServisProjeGM(projeIcerikId);
            ServisProjeIcerikGetirGM(projeIcerikId);
        }
    });
}
function ServisProjeIcerikGetirGM(tempProjeIcerikId) {
    let gecerlilikBaslangic = document.getElementById("edtInputGecerlilikBaslangicServisProjeM");
    let gecerlilikBitis = document.getElementById("edtInputGecerlilikBitisServisProjeM");
    let fiyat = document.getElementById("edtInputFiyatServisProjeM");
    $.ajax({
        url: "/Proje/ServisProjeIcerikGetirG",
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempProjeIcerikId },
        success: function (tempProjeIcerikList) {
            fiyat.value = tempProjeIcerikList.fiyat;
            gecerlilikBaslangic.value = tempProjeIcerikList.gecerlilikTarihBaslangic.substring(0, 10);
            gecerlilikBitis.value = tempProjeIcerikList.gecerlilikTarihBitis.substring(0, 10);
        }

    })
}
function ParaBirimiGetirServisProjeGM(tempProjeIcerikId) {
    let paraBirimi = document.getElementById("edtSelectParaBirimiServisProjeM");
    $.ajax({
        url: '/Proje/ParaBirimiGetirServisProjeG',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempProjeIcerikId },
        success: function (paraBirimis) {
            $("#edtSelectParaBirimiServisProjeM").html("");
            var s = '<option selected  value="' + paraBirimis.paraBirimiId + '" >' + paraBirimis.paraBirimiAdi + " " + paraBirimis.paraBirimiSimge + '</option>';
            $.ajax({
                url: '/Proje/ParaBirimiList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (paraBirimiList) {
                    $("#edtSelectParaBirimiServisProjeM").html(s);
                    $.each(paraBirimiList, function (i, db) {
                        $("#edtSelectParaBirimiServisProjeM").append(
                            $('<option></option>').val(db.paraBirimiId).html(db.paraBirimiAdi + " " + db.paraBirimiSimge));

                    });
                }
            })

        }
    });
}

function doubleClickTempFaturaMail(tempFaturaMailId) {
    let id = tempFaturaMailId;
    let personelAdi = document.getElementById("personelProjeEdt");
    let chckFaturaMaili = document.getElementById("faturaMailiProjeEdt");
    let chckServisMaili = document.getElementById("servisMailiProjeEdt");
    let personelId = document.getElementById("personelIdH");
    let faturaMailId = document.getElementById("tempFaturaMailId");
    faturaMailId.value = id;
    let btnTempPersonelSil = document.getElementById("btnTempPersonelSil");
    document.getElementById("inputServisProjeH").value = tempFaturaMailId;
    btnTempPersonelSil.value = tempFaturaMailId;
    //  btnTempFiyatSil.value = tempFiyatListId;
    $("#modalPersonelDuzenle").modal("toggle");
    $.ajax({
        url: '/Proje/CariPersonelGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempFaturaMailId },
        success: function (personel) {
            personelId.value = personel.cariPersonelId;
            let personelAdi2 = "";

            if (personel.cariPersonelAdi2 != null) {
                personelAdi2 = personel.cariPersonelAdi2;
            }
            personelAdi.value = personel.cariPersonelAdi + " " + personelAdi2+" "+personel.cariPersonelSoyadi;
            $.ajax({
                url: '/Proje/MailGonder',
                type: "GET",
                dataType: "JSON",
                contentType: "applicarion/json; charset=utf-8",
                data: { id: tempFaturaMailId },
                success: function (mail) {
                    chckFaturaMaili.checked = mail.faturaMailiGonderilecekMi;
                    chckServisMaili.checked = mail.servisMailiGonderilecekMi;
                }
            })
               
        }
    });
}
function isFirstPersonel() {
    $.ajax({
        url: '/Proje/PersonelIsFirst',
        type: "GET",
        dataType: "JSON",
        contentType: "applicarion/json; charset=utf-8",
        
        success: function (personel) {
            if (personel == true) {

            $("#modalPersonelEkle").modal("toggle");
            }
            
        }
    })
}
function projePeriyotF() {
    let periyot1 = document.getElementById("projePeriyot1");
    let periyot2 = document.getElementById("projePeriyot2");
  let  periyotId = periyot1.value;
    $.ajax({
        url: '/Proje/PeriyotGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: periyotId },
        success: function (periyot) {
            $("#projePeriyot2").html("");
            var s = '<option selected  value="' + periyot.faturalamaPeriyoduId + '" >' + periyot.faturalamaPeriyoduAciklama + '</option>';
            $.ajax({
                url: '/Proje/PeriyotList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (periyotList) {
                    $("#projePeriyot2").html(s);
                    $.each(periyotList, function (i, db) {
                        $("#projePeriyot2").append(
                            $('<option></option>').val(db.faturalamaPeriyoduId).html(db.faturalamaPeriyoduAciklama));

                    });
                }
            })

        }
    });

}
function projeProgramF() {
    let program1 = document.getElementById("projeProgram1");
    let programId = program1.value;
    $.ajax({
        url: '/Proje/ProgramGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: programId },
        success: function (program) {
            $("#projeProgram2").html("");
            var s = '<option selected  value="' + program.programId + '" >' + program.programAdi + '</option>';
            $.ajax({
                url: '/Proje/ProgramList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (programList) {
                    $("#projeProgram2").html(s);
                    $.each(programList, function (i, db) {
                        $("#projeProgram2").append(
                            $('<option></option>').val(db.programId).html(db.programAdi));

                    });
                }
            })

        }
    });

}
function projePeriyotL() {
    let periyot2 = document.getElementById("projePeriyot2");
    let periyotId = periyot2.value;
    $.ajax({
        url: '/Proje/PeriyotGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: periyotId },
        success: function (periyot) {
            $("#projePeriyot1").html("");
            var s = '<option selected  value="' + periyot.faturalamaPeriyoduId + '" >' + periyot.faturalamaPeriyoduAciklama + '</option>';
            $.ajax({
                url: '/Proje/PeriyotList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (periyotList) {
                    $("#projePeriyot1").html(s);
                    $.each(periyotList, function (i, db) {
                        $("#projePeriyot1").append(
                            $('<option></option>').val(db.faturalamaPeriyoduId).html(db.faturalamaPeriyoduAciklama));

                    });
                }
            })

        }
    });

}
function projeProgramL() {
    let program2 = document.getElementById("projeProgram2");
    let programId = program2.value;
    $.ajax({
        url: '/Proje/ProgramGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: programId },
        success: function (program) {
            $("#projeProgram1").html("");
            var s = '<option selected  value="' + program.programId + '" >' + program.programAdi + '</option>';
            $.ajax({
                url: '/Proje/ProgramList',
                type: "GET",
                dataType: "JSON",
                contentType: "application/json;charset=utf-8",
                success: function (programList) {
                    $("#projeProgram1").html(s);
                    $.each(programList, function (i, db) {
                        $("#projeProgram1").append(
                            $('<option></option>').val(db.programId).html(db.programAdi));

                    });
                }
            })

        }
    });

}
function doubleClickTempFaturaMailG(tempFaturaMailId) {
    let id = tempFaturaMailId;
    let personelAdi = document.getElementById("personelProjeEdt");
    let chckFaturaMaili = document.getElementById("faturaMailiProjeEdtG");
    let chckServisMaili = document.getElementById("servisMailiProjeEdtG");
    let personelId = document.getElementById("personelIdH");
    let faturaMailId = document.getElementById("tempFaturaMailId");
    faturaMailId.value = id;
    let btnTempPersonelSil = document.getElementById("btnTempPersonelSil");
    document.getElementById("inputServisProjeH").value = tempFaturaMailId;
    btnTempPersonelSil.value = tempFaturaMailId;
    //  btnTempFiyatSil.value = tempFiyatListId;
    $("#modalPersonelDuzenle").modal("toggle");
    $.ajax({
        url: '/Proje/CariPersonelGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempFaturaMailId },
        success: function (personel) {
            personelId.value = personel.cariPersonelId;
            let personelAdi2 = "";

            if (personel.cariPersonelAdi2 != null) {
                personelAdi2 = personel.cariPersonelAdi2;
            }
            personelAdi.value = personel.cariPersonelAdi + " " + personelAdi2 + " " + personel.cariPersonelSoyadi;
            $.ajax({
                url: '/Proje/MailGonder',
                type: "GET",
                dataType: "JSON",
                contentType: "applicarion/json; charset=utf-8",
                data: { id: tempFaturaMailId },
                success: function (mail) {
                    chckFaturaMaili.checked = mail.faturaMailiGonderilecekMi;
                    chckServisMaili.checked = mail.servisMailiGonderilecekMi;
                }
            })

        }
    });
}
function doubleClickFaturaMailG(tempFaturaMailId) {
    let id = tempFaturaMailId;
    let personelAdi = document.getElementById("personelProjeEdt");
    let chckFaturaMaili = document.getElementById("faturaMailiProjeEdtG");
    let chckServisMaili = document.getElementById("servisMailiProjeEdtG");
    let personelId = document.getElementById("personelIdH");
    let faturaMailId = document.getElementById("tempFaturaMailId");
    faturaMailId.value = id;
    let btnTempPersonelSil = document.getElementById("btnTempPersonelSil");
    document.getElementById("inputServisProjeH").value = tempFaturaMailId;
    btnTempPersonelSil.value = tempFaturaMailId;
    //  btnTempFiyatSil.value = tempFiyatListId;
    $("#modalPersonelDuzenle").modal("toggle");
    $.ajax({
        url: '/Proje/CariPersonelGetir',
        type: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        data: { id: tempFaturaMailId },
        success: function (personel) {
            personelId.value = personel.cariPersonelId;
            let personelAdi2 = "";

            if (personel.cariPersonelAdi2 != null) {
                personelAdi2 = personel.cariPersonelAdi2;
            }
            personelAdi.value = personel.cariPersonelAdi + " " + personelAdi2 + " " + personel.cariPersonelSoyadi;
            $.ajax({
                url: '/Proje/MailGonder',
                type: "GET",
                dataType: "JSON",
                contentType: "applicarion/json; charset=utf-8",
                data: { id: tempFaturaMailId },
                success: function (mail) {
                    chckFaturaMaili.checked = mail.faturaMailiGonderilecekMi;
                    chckServisMaili.checked = mail.servisMailiGonderilecekMi;
                }
            })

        }
    });
}
//function ProjeDateRange(no) {
//    let Tarih1 = document.getElementById("reservationProje1");
//    let Tarih2 = document.getElementById("reservationProje2");
//    if (no == 1) {
//        Tarih2.value = Tarih1.value;
//    }
//    else if (no == 2) {
//        Tarih1.value = Tarih2.value;
//    }
//}


function ProjeDateRange(tarih,no) {
    let Tarih1 = document.getElementById("reservationProje1");
    let Tarih2 = document.getElementById("reservationProje2");
    $.ajax({
        url: '/Proje/TarihAraligi',
        type: "GET",
        dataType: "JSON",
        contentType: "applicarion/json; charset=utf-8",
        data: { tarih: tarih },
        success: function () {
            if (no == "1") {
                Tarih2.value = Tarih1.value;
                Tarih2.inneinnerTextrHTML = Tarih1.innerText;
            }
            else if (no == "2") {
                Tarih1.value = Tarih2.value;
                Tarih1.innerText = Tarih2.innerText;
            }
        }
    })
}




//function selectRadio() {
//    let tblSehirRow = document.getElementById("tblSehirRow");

//    alert(tblSehirRow);
//    let radio = tblSehirRow.
//var span = document.getElementById("telCode");
//$.ajax({
//    url: '/DestekTablosu/EditAndAddSehirr2',
//    type: "POST",
//    dataType: "JSON",
//    contentType: "application/json; charset=utf-8",
//    data: { sehirAdi: sehirAdi, plakaKodu: plakaKodu, telefonKodu: telefonKodu },


//});
//}
//function goruntule() {
    //if (document.querySelector('input[name="radio"]:checked') == null) {
    //    alert("Lütfen Seçim Yapınız");
    //    $.ajax({

    //        type: "GET",

    //        contentType: "application/json; charset=utf-8",


    //        success: function (data) {
    //            window.location.href = '/DestekTablosu/DtSehir';
    //        },
    //        error: function (httpRequest, textStatus, errorThrown) {
    //            alert("Error: " + textStatus + " " + errorThrown + " " + httpRequest);
    //        }
    //    });
    //}
    //else {


    //}
//}

//function SendTable() {

//    alert("sd");
//    //$.ajax({
//    //    url: '/DestekTablosu/Edit',
//    //    type: "GET",
//    //    dataType: "JSON",
//    //    contentType: "application/json; charset=utf-8",
//    //    data: { table: a },

//    //    success: function (cities) {



//    //    }
//    //});
//}

////#region Müşteri Ekle>Cari Tip
//const inputCariTipEkle = document.getElementById("cariTipEkle");
//const cariTipiList = document.getElementById("cariTipiList");
//const btnCariTipi = document.getElementById("btnCariTipi");
//let firstChild;
//inputCariTipEkle.addEventListener("keypress", cariTipEkle);
//cariTipiList.addEventListener("click", secilenCariTipi);


//function cariTipEkle() {
//    if (event.key === "Enter") {
//        firstChild = cariTipiList.insertBefore;
//        const li = document.createElement("li");
//        const a = document.createElement("a");
//        let data = inputCariTipEkle.value;
//        //burada datayı controller'a parametre olarak gönder



//        a.className = "dropdown-item";

//        a.innerText = data;
//        data = "";
//        li.appendChild(a);
//        cariTipiList.insertBefore(li, cariTipiList.firstChild)
//        inputCariTipEkle.value = data;


//    }
//}
//function secilenCariTipi(e) {
//    if (e.target.tagName === 'A') {
//        btnCariTipi.innerText = e.target.innerText

//    }
//}
////#endregion
////#region Vergi Kontrol
//const btnKontrolEt = document.getElementById("btnKontrolEt");
//const inputVergiNo = document.getElementById("vergiNo");
//const accordion = document.getElementById("accordion1");
//btnKontrolEt.addEventListener("click", VergiNoKontrol);
//function VergiNoKontrol() {
//    let attirbuteVar = accordion.getAttribute("class");
//    console.log(attirbuteVar);

//    if (inputVergiNo.value !== "") {

//        accordion.setAttribute("class", "accordion-collapse show");
//        console.log(accordion);
//    }
//    if (attirbuteVar === "accordion-collapse show") {
//        accordion.setAttribute("class", "accordion-collapse collapse");
//    }
//    else {
//        console.log("hatalı");
//    }

//}
////#endregion
////#region Ulke Ekle
//const btnUlke = document.getElementById("btnUlke");
//const ulkeList = document.getElementById("ulkeList");
//const inputUlkeEkle = document.getElementById("inputUlkeEkle");
//inputUlkeEkle.addEventListener("keypress", ulkeEkle)
//ulkeList.addEventListener("click", secilenUlke)
//function ulkeEkle() {
//    if (event.key === "Enter") {
//        firstChild = ulkeList.insertBefore;
//        const li = document.createElement("li");
//        const a = document.createElement("a");
//        let data = inputUlkeEkle.value;
//        a.className = "dropdown-item";
//        a.setAttribute("href", "javascript:void(0);")
//        a.innerText = data;
//        data = "";
//        li.appendChild(a);
//        ulkeList.insertBefore(li, ulkeList.firstChild)
//        inputUlkeEkle.value = data;


//    }
//}
//function secilenUlke(e) {
//    if (e.target.tagName === 'A') {
//        btnUlke.innerText = e.target.innerText

//    }
//}
////#endregion
////#region İl Ekle
//const btnIl = document.getElementById("btnIl");
//const ilList = document.getElementById("ilList");
//const inputIlEkle = document.getElementById("inputIlEkle");
//inputIlEkle.addEventListener("keypress", ilEkle)
//ilList.addEventListener("click", secilenIl)
//function ilEkle() {
//    if (event.key === "Enter") {
//        firstChild = ilList.insertBefore;
//        const li = document.createElement("li");
//        const a = document.createElement("a");
//        let data = inputIlEkle.value;
//        a.className = "dropdown-item";
//        a.setAttribute("href", "javascript:void(0);")
//        a.innerText = data;
//        data = "";
//        li.appendChild(a);
//        ilList.insertBefore(li, ilList.firstChild)
//        inputIlEkle.value = data;


//    }
//}
//function secilenIl(e) {
//    if (e.target.tagName === 'A') {
//        btnIl.innerText = e.target.innerText

//    }
//}

////#endregion
////#region İlce Ekle
//const btnIlce = document.getElementById("btnIlce");
//const ilceList = document.getElementById("ilceList");
//const inputIlceEkle = document.getElementById("inputIlceEkle");
//inputIlceEkle.addEventListener("keypress", ilceEkle)
//ilceList.addEventListener("click", secilenIlce)
//function ilceEkle() {
//    if (event.key === "Enter") {
//        firstChild = ilceList.insertBefore;
//        const li = document.createElement("li");
//        const a = document.createElement("a");
//        let data = inputIlceEkle.value;
//        a.className = "dropdown-item";
//        a.setAttribute("href", "javascript:void(0);")
//        a.innerText = data;
//        data = "";
//        li.appendChild(a);
//        ilceList.insertBefore(li, ilceList.firstChild)
//        inputIlceEkle.value = data;


//    }
//}
//function secilenIlce(e) {
//    if (e.target.tagName === 'A') {
//        btnIlce.innerText = e.target.innerText

//    }
//}

////#endregion
////#region Cari Durum Ekle
//const btnCariDurum = document.getElementById("btnCariDurum");
//const cariDurumList = document.getElementById("cariDurumList");
//const inputCariDurumEkle = document.getElementById("inputCariDurumEkle");
//inputCariDurumEkle.addEventListener("keypress", cariDurumEkle)
//cariDurumList.addEventListener("click", secilenCariDurum)
//function cariDurumEkle() {
//    if (event.key === "Enter") {
//        firstChild = cariDurumList.insertBefore;
//        const li = document.createElement("li");
//        const a = document.createElement("a");
//        let data = inputCariDurumEkle.value;
//        var TbCariDurum = {
//            CariDurumAdi: data,
//        }


//        $.ajax({
//            url: '@Url.Action("MyAction", "Cari")',
//            type: 'POST',
//            dataType: 'json',
//            data: TbCariDurum,
//            success: function (data) {
//                alert(data);
//            }
//        });



//        fetch('CariController/MyAction', { method: 'post', body: JSON.stringify({ data: data }) });
//        a.className = "dropdown-item";
//        a.setAttribute("href", "javascript:void(0);")
//        a.innerText = data;
//        data = "";
//        li.appendChild(a);
//        cariDurumList.insertBefore(li, cariDurumList.firstChild)
//        inputCariDurumEkle.value = data;


//    }
//}
//function secilenCariDurum(e) {
//    if (e.target.tagName === 'A') {
//        btnCariDurum.innerText = e.target.innerText

//    }
//}

////#endregion
////#region Para Birimi Ekle
//const btnParaBirimi = document.getElementById("btnParaBirimi");
//const paraBirimiList = document.getElementById("paraBirimiList");
//const inputParaBirimiEkle = document.getElementById("inputParaBirimiEkle");
//inputParaBirimiEkle.addEventListener("keypress", paraBirimiEkle)
//paraBirimiList.addEventListener("click", secilenParaBirimi)
//function paraBirimiEkle() {
//    if (event.key === "Enter") {
//        firstChild = paraBirimiList.insertBefore;
//        const li = document.createElement("li");
//        const a = document.createElement("a");
//        let data = inputParaBirimiEkle.value;
//        a.className = "dropdown-item";
//        a.setAttribute("href", "javascript:void(0);")
//        a.innerText = data;
//        data = "";
//        li.appendChild(a);
//        paraBirimiList.insertBefore(li, paraBirimiList.firstChild)
//        inputParaBirimiEkle.value = data;


//    }
//}
//function secilenParaBirimi(e) {
//    if (e.target.tagName === 'A') {
//        btnParaBirimi.innerText = e.target.innerText

//    }
//}

////#endregion
////#region Sektör Ekle
//const btnSektor = document.getElementById("btnSektor");
//const sektorList = document.getElementById("sektorList");
//const inputSektorEkle = document.getElementById("inputSektorEkle");
//inputSektorEkle.addEventListener("keypress", sektorEkle)
//sektorList.addEventListener("click", secilenSektor)
//function sektorEkle() {
//    if (event.key === "Enter") {
//        firstChild = sektorList.insertBefore;
//        const li = document.createElement("li");
//        const a = document.createElement("a");
//        let data = inputSektorEkle.value;
//        a.className = "dropdown-item";
//        a.setAttribute("href", "javascript:void(0);")
//        a.innerText = data;
//        data = "";
//        li.appendChild(a);
//        sektorList.insertBefore(li, sektorList.firstChild)
//        inputSektorEkle.value = data;
//    }
//}
//function secilenSektor(e) {
//    if (e.target.tagName === 'A') {
//        btnSektor.innerText = e.target.innerText

//    }
//}

////#endregion

////#region frmIlgiliKisiEkle
//let frmIlgiliKisi = document.getElementById("frmIlgiliKisiKaydet")
//frmIlgiliKisi.addEventListener("submit", formSubmit)

//function formSubmit(event) {
//    event.preventDefault()

//}


////#endregion





