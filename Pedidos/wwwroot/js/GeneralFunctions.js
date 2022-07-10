function GenericSend(controller, model, callback) {
    $.ajax({
        type: 'POST',
        url: controller,
        data: model,
        async: false,
        cache: false,
        success: function (result) {
            //Obtengo el tipo de dato del argumento callback
            tipoCallback = typeof (callback);

            if (tipoCallback == 'function') {
                //Ejecuta la función callBack teniendo como argumento lo que respondio
                //el servidor (result)
                callback(result);
            }
            else { $("#" + callback).html(result); }
        },
        error: function (errorHtml) { alert(controller + ":" + JSON.stringify(errorHtml)); },
        complete: function () { }
    })
}

function setupDownload() {
    $("#descargaPDF").click(function () {
        html2canvas($("#myChart"), {
            onrendered: function (canvas) {
                var imgData = canvas.toDataURL("image/png");
                var doc = new jsPDF('p', 'mm');
                doc.addImage(imgData, 'PNG', 10, 40);

                var nombrePDF = document.getElementById("panel").getAttribute("data-pdf");
                var tituloGrafica = document.getElementById("panel").getAttribute("data-titulo");

                doc.text(40, 20, tituloGrafica);
                doc.save(nombrePDF);
            }
        })
    })
}