$('#eliminar1').on("click", function () {
    var array = new Array();
    $('.check').each(function (index) {

        if ($(this).is(":checked")) {
            var padre = $(this).parent().parent();
            var hermanoPadre = padre.next();
            var hijoHermanoPadre = hermanoPadre.first();
            array.push($(this).parent().parent().next().first().children().val());
        }
    });
    for (var key in array) {
        if (key == array.length-1) {
            $.ajax({
                url: '/Mensajes/Delete/' + array[key],
                type: 'GET',
                success: function (result) {
                    location.reload();
                }
            });
        } else {
            $.ajax({
                url: '/Mensajes/Delete/' + array[key],
                type: 'GET',
                success: function (result) {

                }
            });
        }
        
    }
});
$('#eliminar2').on("click", function () {
    var array = new Array();
    $('.check').each(function (index) {

        if ($(this).is(":checked")) {
            var padre = $(this).parent().parent();
            var hermanoPadre = padre.next();
            var hijoHermanoPadre = hermanoPadre.first();
            array.push($(this).parent().parent().next().first().children().val());
        }
    });
    for (var key in array) {
        if (key == array.length-1) {
            $.ajax({
                url: '/Mensajes/Delete/' + array[key],
                type: 'GET',
                success: function (result) {
                    location.reload();
                }
            });
        } else {
            $.ajax({
                url: '/Mensajes/Delete/' + array[key],
                type: 'GET',
                success: function (result) {

                }
            });
        }

    }

});