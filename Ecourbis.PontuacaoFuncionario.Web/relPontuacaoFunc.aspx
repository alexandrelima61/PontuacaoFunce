<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relPontuacaoFunc.aspx.cs" Inherits="Ecourbis.PontuacaoFuncionario.Web.relPontuacaoFunc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="img/Report.png" />

    <title>Conduta e Pontuação</title>
    <%--css--%>
    <link href="css/config.page.css" rel="stylesheet" />
    <link href="css/jquery.treegrid.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="Config/DataTables/media/css/jquery.dataTables.css" rel="stylesheet" />

    <%--js--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <script src="js/jquery.treegrid.min.js"></script>
    <script src="Config/Libs/moment-with-locales.js"></script>
    <script src="Config/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="Config/DataTables/media/js/jquery.dataTables.min.js"></script>
    <script src="js/myFunctions.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-sm-12">
                    <div class="alert alert-success text-center" runat="server" id="div1">
                        <strong>Relatório de Pontuação Funcionário -
                                <asp:Label ID="lblRel" runat="server" /></strong>
                    </div>
                </div>
                <div id="result" runat="server" style="padding: 15px 15px;"></div>
            </div>
        </div>
    </form>
</body>
</html>
