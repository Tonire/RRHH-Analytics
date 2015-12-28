var array = new Array();
var lastCode = "";
$('#vender').on("click", function () {
    if (array.length >= 1) {
        var json = JSON.stringify(array);
        $.ajax(
       {
           method: "POST",
           url: '/Ventas/Create',
           success: function (data) {
               //alert(data);
               if (data === "Ok") {
                   //Venta realizada
                   $('#success').attr("style", "display:block");
                   limpiarTabla();
               } else {
                   //Error
                   $('#error').attr("style", "display:block");
                   $('#div-error').append(data);
               }
           },
           data: {
               'data': json
           }
       })
    }
});

function add() {
    if ($('#cantidad').val() != "" && parseInt($('#cantidad').val())>0) {
        var objeto = { referencia: $('#idProducto').val(), cantidad: $('#cantidad').val() };
        array.push(objeto);
        var stringHTML = "<tr><td>" + $('#idProducto').val() + "</td><td>" + $('#idProducto').find(":selected").text() + "</td><td>" + $('#cantidad').val() + "</td><td><a href='#' onClick='return quitar(this)' class='fa fa-remove' id='" + array.length + "'></a></td></tr>";
        $('#tbody').append(stringHTML);
    }
}

$('#add').on("click", function () {
    if ($('#cantidad').val() != "" && parseInt($('#cantidad').val()) > 0) {
        var objeto = { referencia: $('#idProducto').val(), cantidad: $('#cantidad').val() };
        array.push(objeto);
        var stringHTML = "<tr><td>" + $('#idProducto').val() + "</td><td>" + $('#idProducto').find(":selected").text() + "</td><td>" + $('#cantidad').val() + "</td><td><a href='#' onClick='return quitar(this)' class='fa fa-remove' id='" + array.length + "'></a></td></tr>";
        $('#tbody').append(stringHTML);
    }
});

function quitar(elemento) {
    var quitar = $(elemento).attr('id');
    var arrayAux = new Array();
    for (var i = 0; i < array.length; i++) {
        if (i == parseInt(quitar)-1) {
            arrayAux[i] = "@";
        } else {
            arrayAux[i] = array[i];
        }
    }
    arrayAux = $.grep(arrayAux, function (value) {
        return value != "@";
    });
    array = arrayAux;
    $(elemento).parent().parent().remove();
    lastCode = "";
}

function limpiarTabla() {
    $('#tbody').empty();
    $('#idProducto').val("");
    $('#cantidad').val("");
}
function mostrar() {

    if($('#webcam').hasClass('oculto')){
        document.getElementById('webcam').setAttribute('style', 'display:block');
        $('#webcam').toggleClass('oculto', false);
        $('#webcam').toggleClass('visible', true);
    } else {
        $('#webcam').toggleClass('visible', false);
        $('#webcam').toggleClass('oculto', true);
        document.getElementById('webcam').setAttribute('style', 'display:none');
    }
    
}




$(function () {
    var App = {
        init: function () {
            Quagga.init(this.state, function (err) {
                if (err) {
                    console.log(err);
                    return;
                }
                App.attachListeners();
                Quagga.start();
            });
        },
        attachListeners: function () {
            var self = this;

            $(".controls").on("click", "button.stop", function (e) {
                e.preventDefault();
                Quagga.stop();
            });

            $(".controls .reader-config-group").on("change", "input, select", function (e) {
                e.preventDefault();
                var $target = $(e.target),
                    value = $target.attr("type") === "checkbox" ? $target.prop("checked") : $target.val(),
                    name = $target.attr("name"),
                    state = self._convertNameToState(name);

                console.log("Value of " + state + " changed to " + value);
                self.setState(state, value);
            });
        },
        _accessByPath: function (obj, path, val) {
            var parts = path.split('.'),
                depth = parts.length,
                setter = (typeof val !== "undefined") ? true : false;

            return parts.reduce(function (o, key, i) {
                if (setter && (i + 1) === depth) {
                    o[key] = val;
                }
                return key in o ? o[key] : {};
            }, obj);
        },
        _convertNameToState: function (name) {
            return name.replace("_", ".").split("-").reduce(function (result, value) {
                return result + value.charAt(0).toUpperCase() + value.substring(1);
            });
        },
        detachListeners: function () {
            $(".controls").off("click", "button.stop");
            $(".controls .reader-config-group").off("change", "input, select");
        },
        setState: function (path, value) {
            var self = this;

            if (typeof self._accessByPath(self.inputMapper, path) === "function") {
                value = self._accessByPath(self.inputMapper, path)(value);
            }

            self._accessByPath(self.state, path, value);

            console.log(JSON.stringify(self.state));
            App.detachListeners();
            Quagga.stop();
            App.init();
        },
        inputMapper: {
            inputStream: {
                constraints: function (value) {
                    var values = value.split('x');
                    return {
                        width: parseInt(values[0]),
                        height: parseInt(values[1]),
                        facing: "environment"
                    }
                }
            },
            numOfWorkers: function (value) {
                return parseInt(value);
            },
            decoder: {
                readers: function (value) {
                    return [value + "_reader"];
                }
            }
        },
        state: {
            inputStream: {
                type: "LiveStream",
                constraints: {
                    width: 640,
                    height: 480,
                    facing: "environment" // or user
                }
            },
            locator: {
                patchSize: "medium",
                halfSample: true
            },
            numOfWorkers: 4,
            decoder: {
                readers: ["code_128_reader"]
            },
            locate: true
        },
        lastResult: null
    };

    App.init();

    Quagga.onProcessed(function (result) {
        var drawingCtx = Quagga.canvas.ctx.overlay,
            drawingCanvas = Quagga.canvas.dom.overlay;

        if (result) {
            if (result.boxes) {
                drawingCtx.clearRect(0, 0, parseInt(drawingCanvas.getAttribute("width")), parseInt(drawingCanvas.getAttribute("height")));
                result.boxes.filter(function (box) {
                    return box !== result.box;
                }).forEach(function (box) {
                    Quagga.ImageDebug.drawPath(box, { x: 0, y: 1 }, drawingCtx, { color: "green", lineWidth: 2 });
                });
            }

            if (result.box) {
                Quagga.ImageDebug.drawPath(result.box, { x: 0, y: 1 }, drawingCtx, { color: "#00F", lineWidth: 2 });
            }

            if (result.codeResult && result.codeResult.code) {
                Quagga.ImageDebug.drawPath(result.line, { x: 'x', y: 'y' }, drawingCtx, { color: 'red', lineWidth: 3 });
            }
        }
    });

    Quagga.onDetected(function (result) {
        var code = result.codeResult.code;
        
        if (code === lastCode) {

        } else {
            $('#idProducto').val(code).change();
            navigator.vibrate(500);
            var cantidad = 1;
            if (parseInt($('#cantidad').val()) >= 1) {
                cantidad = $('#cantidad').val();
            } else {
                cantidad = 1;
            }
            $('#cantidad').val(cantidad);
            add();
            lastCode = code;
        }
        
    });
});