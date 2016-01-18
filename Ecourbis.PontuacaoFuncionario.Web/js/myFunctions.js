//Padrão de data, utilizado para configurar o modelo e a lingua desejada.
$(function () {
    $('.datetimepicker').datetimepicker({
        locale: 'pt-BR',
        viewMode: 'years',
        format: 'MM/YYYY'
    });
    $('.tree').treegrid({
        treeColumn: 0,
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
        "dom": 'Rlfrtip'
    });

    oTable.fnSort([[9, 'desc']]);
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