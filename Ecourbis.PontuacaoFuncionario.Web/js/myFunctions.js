var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,'
        , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
        , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
        , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
    return function (table, name) {
        if (!table.nodeType) table = document.getElementById(table);
        var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML };
        window.location.href = uri + base64(format(template, ctx));
    };
})();


//Padrão de data, utilizado para configurar o modelo e a lingua desejada.
$(function () {
    //$('.datetimepicker').datetimepicker({
    //    locale: 'pt-BR',
    //    viewMode: 'years',
    //    format: 'MM/YYYY'
    //});
    $('.tree').treegrid({
        treeColumn: 0
    });
    //trazer o tree fechado
    //$('.tree').treegrid('collapseAll');
});

//define a padronização da table, informada atraves do elemento
$(document).ready(function () {
    oTable = $('.tablefilter').dataTable({
        "bPaginate": true,
        "bJQueryUI": false,
        "sPaginationType": "full_numbers",
        "dom": 'Rlfrtip',
        aLengthMenu: [
            [25, 50, 100, 200, -1],
            [25, 50, 100, 200, "Todos"]
        ],
        iDisplayLength: 25
    }).api();

    oTable.fnSort([[11, 'desc']]);
});

//cria a div contendo a gif de loadin
function ShowProgress() {
    setTimeout(function () {
        var modal = $('<div />');
        modal.addClass("modal");
        $('body').append(modal);
        var loading = $(".loading");
        loading.show();
        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
    }, 300);
}
//
$('form').live("submit", function () {
    ShowProgress();
});
//chama a gif de carrefamento para o usuario aguardar o processamento.
$(document).ready(function () {
    $('submit').click()
});

$(".fancybox").fancybox({
    autoSize: false,
    autoDimensions: false,
    width: 1250,
    height: 765,
    fitToView: false,
    padding: 0,
    title: this.title,
    href: $(this).attr('href'),
    type: 'iframe'
});