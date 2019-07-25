<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relPontuacaoFunc.aspx.cs" Inherits="Ecourbis.PontuacaoFuncionario.Web.relPontuacaoFunc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="The description of my page" />
    <link rel="shortcut icon" href="img/Report.png" />

    <title>Conduta e Pontuação</title>
    <%--css--%>
    <link href="css/config.page.css" rel="stylesheet" />
    <link href="css/jquery.treegrid.css" rel="stylesheet" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap.min.css" rel="stylesheet" />


    <%--js--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <script src="js/jquery.treegrid.min.js"></script>
    <script src="Config/Libs/moment-with-locales.js"></script>
    <script src="Config/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap.min.js"></script>
    <script src="js/myFunctions.js"></script>

</head>
<body>
    <form id="form1" runat="server">

        <div class="panel panel-default" style="margin-top: 6px;">
            <div class="panel-body">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="alert alert-info text-center" runat="server" id="div1">
                            <strong>Relatório de Pontuação Funcionário -
                                <asp:Label ID="lblRel" runat="server" /></strong>
                        </div>
                    </div>
                    <div class="col-sm-12 text-right">
                        <div class="col-sm-12">
                            <button class="btn btn-sm btn-success"
                                id="export_to_excel">
                                Exportar para Excel
                            </button>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div id="result" runat="server" style="padding: 15px 15px;"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        $(document).on('click', '#export_to_excel', function (e) {
            e.preventDefault();
            e.stopPropagation();
            var htmltable = document.getElementById('tableToExcelUnidade');
            var html = htmltable.outerHTML;
            window.open('data:application/vnd.ms-excel,' + encodeURIComponent(html));
        });

        /*
         * https://datatables.net/plug-ins/i18n/
         */
        $(document).ready(function () {
            $('#tbl-child-unit').DataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json"
                },
                "order": [[11, "desc"]],
                "lengthMenu": [[ 25, 50, 100, -1], [ 25, 50, 100, "Todos"]]
            });
        });

    </script>

</body>
</html>
