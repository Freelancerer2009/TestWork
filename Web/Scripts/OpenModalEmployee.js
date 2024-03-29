﻿$(function () {
    $.ajaxSetup({ cache: false });
    $("#addEmployee").click(function (e) {
        console.log('button pressed');
        e.preventDefault();
        $.get("/Home/EmployeeDetail", function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
            $('form').submit(function (e) {
                e.preventDefault();

                $.post('/Home/AddEmployee', $('form').serialize(), function (data) {
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
                });
            });
        });
    });

});