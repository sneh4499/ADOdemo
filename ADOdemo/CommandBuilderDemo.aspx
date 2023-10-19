<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommandBuilderDemo.aspx.cs" Inherits="ADOdemo.CommandBuilderDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body style="font-family: Arial;">

    <%--<div class="container">
        <center><h1>Student Record</h1></center>
        <form id="form1" runat="server">
            <div>
                <div class="row">
                    <div class="col-md-6">
                        <label>Student Id</label>
                        <asp:TextBox ID="txtStudentId" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="btnLoadData" runat="server" CssClass="btn btn-success" Text="Load Data" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <label>Student Name</label>
                        <asp:TextBox ID="txtStudentName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <label>Total Marks</label>
                        <asp:TextBox ID="txtMarks" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-info" Text="Update" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" />
                    </div>
                </div>

            </div>
        </form>

    </div>--%>

    <div class="container">
        <center><h2>Student Recored</h2></center><br />
        <form class="form-horizontal" runat="server">
            <div class="form-group">
                <label class="control-label col-sm-2">Student Id:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtStudentId" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-sm-2"></label>
                <div class="col-sm-10">
                    <asp:Button ID="btnLoadData" runat="server" CssClass="btn btn-success" Text="Load Data" OnClick="btnLoadData_Click" />
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-2">Student Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtStudentName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-sm-2">Gender</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtGender" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-sm-2">Total Marks</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtMarks" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-info" Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" OnClick="btnDelete_Click" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Label runat="server" Text="" ID="lblMessage"></asp:Label>
                </div>
            </div>

        </form>
    </div>
</body>
</html>
