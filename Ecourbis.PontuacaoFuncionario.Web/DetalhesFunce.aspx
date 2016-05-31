<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalhesFunce.aspx.cs" Inherits="Ecourbis.PontuacaoFuncionario.Web.DetalhesFunce" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Conduta e Pontuação</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="img/Report.png" />

    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/config.page.css" rel="stylesheet" />

</head>
<body style="padding: 5px 0 5px 0">
    <form id="form1" runat="server">
        <div class="container">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="clearfix">
                        <div class="col-sm-12">
                            <div class="col-sm-4">
                            </div>
                            <div class="col-sm-8">
                                <strong class="panel-title titulo-painel" style="text-align: center">PONTUAÇÃO POR FUNCIONÁRIO</strong>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div id="relatorio" runat="server" style="padding: 15px 15px;"></div>
                </div>
            </div>
        </div>
    </form>
    <script src="http://code.jquery.com/jquery-latest.js"></script>
    <script type="text/javascript">
        /*** Imprimir a página ao carregar a página*/        
        if (jQuery)// Versão jQuery
            jQuery(function () { if (typeof (window.print) != 'undefined') { window.print(); } });            
        else// Versão convencional
            window.onload = function () {if (typeof (window.print) != 'undefined') {/*window.print();*/} }        
    </script>
</body>
</html>
