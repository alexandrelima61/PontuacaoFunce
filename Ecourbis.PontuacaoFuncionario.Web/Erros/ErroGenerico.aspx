<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutPadrao.Master" AutoEventWireup="true" CodeBehind="ErroGenerico.aspx.cs" Inherits="Ecourbis.PontuacaoFuncionario.Web.Erros.ErroGenerico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" style="margin-top: 80px; padding: 0 3px;">
        <style type="text/css">
            .auto-style1 {
                width: 100%;
            }

            .auto-style2 {
                width: 154px;
            }

            .auto-style3 {
                font-weight: bold;
                font-size: x-large;
            }

            .auto-style4 {
                width: 128px;
                height: 128px;
            }
        </style>

        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" rowspan="6">
                        <img alt="" class="auto-style4" src="../Erros/Imagens/erro.png" /></td>
                    <td>
                        <asp:Label ID="lblErro" runat="server" Style="font-weight: 700; font-size: x-large; color: #FF3300"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIp" runat="server" CssClass="auto-style3" Text="IP:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUsuario" runat="server" CssClass="auto-style3" Text="Usuário:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPagina" runat="server" CssClass="auto-style3" Text="Página:"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
