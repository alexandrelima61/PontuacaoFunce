<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutPadrao.Master" AutoEventWireup="true" CodeBehind="relPontuacao.aspx.cs" Inherits="Ecourbis.PontuacaoFuncionario.Web.relPontuacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top: 80px; padding: 0 3px;">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-sm-10 text-center">
                    <div class="alert alert-info text-center" runat="server" id="div1">
                        <strong>Relatório de Pontuação Funcionário</strong>
                    </div>                    
                </div>
                <div class="col-sm-2 text-right">
                    <div class="form-group">
                        <asp:Button Text="Atualizar Dados" runat="server" ID="btnGrRel"
                            OnClick="btnGrRel_Click" CssClass="btn btn-primary btn-lg" />
                    </div>
                </div>
            </div>             

            <div id="relatorio" runat="server" style="padding: 15px 15px;"></div>
        </div>
    </div>
</asp:Content>
