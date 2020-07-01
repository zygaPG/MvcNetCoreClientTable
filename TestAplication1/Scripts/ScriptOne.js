var editLock = false;

$(document).ready(function () {


});





$("#AddButton").on("click", AddClick);



function AddClick() {
    if (!editLock) {
        $("#AddButton").css({ "transform": "translateY(-800%)", "opacity": "0" });
        $("#AddRow").css({ "transform": "translateY(0%)", "opacity": "1" })
    }

}

function EditClick(id, name, surname, year) {
    if (!editLock) {
        editLock = true;
        $(".tabelka").css({
            "opacity": "0.7", "filter": "blur(  1px)"
        });

        $("#idEdit").val(id);
        $("#nameEdit").val(name);
        $("#surnameEdit").val(surname);
        $("#yearEdit").val(year);

        $("#EditBox").css({ "transform": "translateX(0px)", "opacity": "1" })
    }
}

$("#EditBack").on("click", EditBack);

function EditBack() {
    editLock = false;
    $(".tabelka").css({
        "opacity": "1", "filter": "blur(  0px)"
    });
    $("#EditBox").css({ "transform": "translateX(-300%)", "opacity": "0" })
}




jQuery.get('file:///C:/testrobota/test.txt', function (data) {
    alert(data);
    
});