<%@ Page Language="C#" AutoEventWireup="true" MasterpageFile="~/Masterpage.Master" CodeBehind="Danhsachtruonghoc.aspx.cs" Inherits="thicuoiky.Danhsachtruonghoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div>
                 <asp:Label ID="Label3" runat="server" Text="DANH SÁCH TRƯỜNG HỌC "></asp:Label>
            </div>
           <div>
               <asp:Label ID="Label2" runat="server" Text="Mã trường"></asp:Label>
               <asp:TextBox ID="txtmatruong" runat="server"></asp:TextBox>
           </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="Tên trường"></asp:Label>
                <asp:TextBox ID="txttentruong" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="3">
                    <Columns>
                        <asp:BoundField DataField="MaTruong" HeaderText="Mã trường " />
                        <asp:BoundField DataField="TenTruong" HeaderText="Tên trường" />
                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:Label ID="lbtthongbao" runat="server" Text="Label"></asp:Label>
            </div>
            <div>
                <asp:Button ID="btnthem" runat="server" Text="Thêm" OnClick="btnthem_Click" />
                <asp:Button ID="btnluu" runat="server" Text="Lưu" OnClick="btnluu_Click" />
                <asp:Button ID="btnsua" runat="server" Text="Sửa" OnClick="btnsua_Click" />
                <asp:Button ID="btnxoa" runat="server" Text="Xóa" OnClick="btnxoa_Click" />
            </div>
</asp:Content>
