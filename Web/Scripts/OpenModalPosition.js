$(function () {
    $.ajaxSetup({ cache: false });
    $("#addPos").click(function (e) {
        console.log('button pressed');

        $.get("/Home/DetailPosition", function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show'); 
        });
        e.preventDefault();
    });

    $.ajaxSetup({ cache: false });
    $("#addEmployee").click(function (e) {
        console.log('button pressed');
        e.preventDefault();
        $.get("/Home/EmployeeDetail", function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
            $('.send').click(function(e){
                console.log('send');
                $.ajax ({  
                    url: '/Home/MainTable',  
                    contentType: 'application/html; charset=utf-8',  
                    type: 'GET' ,  
                    dataType: 'html'  
                    })  
                    .done (function (resultData) {  
                    $('.mainTable').html(resultData);  
                    })
                })
            });
    });

});