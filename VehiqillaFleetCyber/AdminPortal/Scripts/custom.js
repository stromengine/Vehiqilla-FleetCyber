
function ToJavaScriptDate(value) {
  
    try {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));
        return dt.getFullYear() + "-" + (dt.getMonth() + 1) + "-" + dt.getDate();
    }
    catch {
        return "-";
    }
}

function BacktoMain() {
    window.location.reload();
}

function ToJavaScriptDate2(value) {

    try {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));

        return dt.getDate() + "-" + (dt.getMonth() + 1) + "-" + dt.getFullYear();
    }
    catch {
        return "-";
    }
}


function convertToDate(value) {

    try {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));
        return dt.getFullYear() + "-"
            + String(dt.getMonth() + 101).slice(-2) + "-"
            + String(dt.getDate() + 100).slice(-2);
        //dt.getFullYear() + "-" + parseInt(today.getMonth() + 1) + "-" + dt.getDate();
    }
    catch {
        return "-";
    }
}

function getDate() {
    var now = new Date();
    var month = (now.getMonth() + 1);
    var day = now.getDate();
    if (month < 10)
        month = "0" + month;
    if (day < 10)
        day = "0" + day;
    return now.getFullYear() + '-' + month + '-' + day;
}

var toast1 = $('.toast1');
toast1.toast({
    delay: 5000,
    animation: true
});
var options = {
    pageLength: 25,
    responsive: true,
    ordering: false,
    dom: '<"html5buttons"B>lTfgitp',
    buttons: [
        { extend: 'copy' },
        { extend: 'csv' },
        { extend: 'excel', title: 'ExampleFile' },
        { extend: 'pdf', title: 'ExampleFile' },

        {
            extend: 'print',
            customize: function (win) {
                $(win.document.body).addClass('white-bg');
                $(win.document.body).css('font-size', '10px');

                $(win.document.body).find('table')
                    .addClass('compact')
                    .css('font-size', 'inherit');
            }
        }
    ]
};
// Upgrade button class name
$.fn.dataTable.Buttons.defaults.dom.button.className = 'btn btn-white btn-sm';

//$(document).ready(function () {
//    $('.i-checks').iCheck({
//        checkboxClass: 'icheckbox_square-green',
//        radioClass: 'iradio_square-green'
//    });
//});

//$('.checkAll').checkAll({
//    name: 'checkGroup',
//    inverter: '.invert',
//    vagueCls: 'indeterminate',
//    onInit: function (len, count, ids, nodes, value) {
//        // init callback
//        // params : len, count, length , ids, value, nodes
//        $('.statusbar').text(len + ' items, checked ' + count + ' item');
//    },
//    onCheck: function (id, val, len, count, ids, nodes, value) {
//        // checking callback
//        // params : id,val,len,count,ids,value,nodes
//        $('.statusbar').text(len + ' items, checked ' + count + ' item');
//    },
//    onFull: function (count, ids, nodes) {
//        // all in checked callback
//        // params : count|len, length , ids, value, nodes
//        $('.statusbar').text(count + ' items, checked ' + count + ' item');
//    },
//    onEmpty: function (len) {
//        //no checked items callback
//        // params : len
//        $('.statusbar').text(len + ' items, checked 0 item');
//    }
//});

$(document).ready(function () {

    $(".select2_demo_1").select2({
        theme: 'bootstrap4',
    });
    $(".select2_demo_2").select2({
        theme: 'bootstrap4',
        placeholder: "",
        allowClear: true
    });
    $(".select2_demo_3").select2({
        theme: 'bootstrap4',
        placeholder: "",
        allowClear: true
    });
});


$(document)
    .ajaxStart(function () {
        $('#AjaxLoader').show();
    })
    .ajaxStop(function () {
        setTimeout(function () { $('#AjaxLoader').hide(); }, 200);
        //console.log($('#AllowPost').val());
        //console.log($('#AllowEdit').val());
        //console.log($('#AllowDelete').val());
        //console.log($('#AllowAdd').val());
        //console.log($('#AllowView').val());
        /*alert("Know your Rights");*/
        let post = $('#AllowPost').val(); //alert("Post" + post);
        let edit = $('#AllowEdit').val(); 
        let del = $('#AllowDelete').val(); 
        let add = $('#AllowAdd').val(); 
        let view = $('#AllowView').val(); 
        let unpost = $('#AllowUnpost').val(); 

        if (post == "False") {
            //alert("Post" + post);
            $('#IS_POST').prop("readonly", true);
            $('#IS_POST').prop("disabled", true);
            //alert("Post" + post);
        }
        if (edit == "False") {
            $('.fa-pencil').parent().hide();
        }
        if (del == "False") {
            $('.fa-trash').parent().hide();
        }
        if (add == "False") {
            if (requestType != "edit") {
                $('button:contains("Save")').prop("disabled", true);
                requestType = "";
            }
        }
        if (view == "False") {
            $('.fa-folder').parent().hide();
        }
        if (unpost == "False") {
            $('#IS_POST').prop("readonly", false);
        }
        

        $("tr td").each(function () {
            let unpost = $('#AllowUnpost').val();

            var h = $(this).html();
            if (h == '<i class="fa fa-check" style="color:green"></i>' && unpost=='False') {
                $(this).next().find('.fa-trash').parent().hide();//.find('.fa-trash').parent();
                $(this).next().find('.fa-pencil').parent().hide();//.find('.fa-trash').parent();
            }
        });
    });




