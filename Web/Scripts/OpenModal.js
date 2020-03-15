$(function () {
    $.ajaxSetup({ cache: false });
    $("#addPos").click(function (e) {
        console.log('button pressed');

        $.get("/Position/DetailPosition", function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show'); 
        });
        e.preventDefault();
    });

    $.ajaxSetup({ cache: false });
    $("#addEmployee").click(function (e) {
        console.log('button pressed');
        e.preventDefault();
        $.get("/Employee/EmployeeDetail", function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
            $('form').submit(function (e) {
                e.preventDefault();

                $.post('/Employee/AddEmployee', $('form').serialize(), function (data) {
                }).done(function () {
                    $.ajax({
                        url: '/Home/MainTable',
                        contentType: 'application/html; charset=utf-8',
                        type: 'GET',
                        dataType: 'html'
                    })
                        .done(function (resultData) {
                            $('.mainTable').html(resultData);
                        });
                    }).fail(function (resultData) {
                        alert("Во время добавления произошла ошибка, сотрудник не добавлен");
                    });
            });
        });
    });

});