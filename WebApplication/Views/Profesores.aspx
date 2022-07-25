<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Profesores.aspx.cs" Inherits="WebApplication.Views.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="mb-4 border-b border-gray-300 ">
        <ul class="flex flex-wrap -mb-px text-sm font-medium text-center" id="myTab" data-tabs-toggle="#myTabContent" role="tablist">
            <li class="mr-2" role="presentation">
                <button class="inline-block p-4 rounded-t-lg border-b-2 text-blue-600 hover:text-blue-600 border-blue-600" id="profile-tab" data-tabs-target="#profile" type="button" role="tab" aria-controls="profile" aria-selected="true">Profesores Contagiados</button>
            </li>
            <li class="mr-2" role="presentation">
                <button class="inline-block p-4 rounded-t-lg border-b-2 border-transparent hover:text-gray-600 hover:border-gray-300 text-gray-500 border-gray-100 " id="dashboard-tab" data-tabs-target="#dashboard" type="button" role="tab" aria-controls="dashboard" aria-selected="false">Profesores</button>
            </li>
            <li class="mr-2" role="presentation">
                <button class="inline-block p-4 rounded-t-lg border-b-2 border-transparent hover:text-gray-600 hover:border-gray-300 text-gray-500  border-gray-100 " id="settings-tab" data-tabs-target="#settings" type="button" role="tab" aria-controls="settings" aria-selected="false">Nuevo Profesor</button>
            </li>
            <li role="presentation">
                <button class="inline-block p-4 rounded-t-lg border-b-2 border-transparent hover:text-gray-600 hover:border-gray-300  text-gray-500 border-gray-100 " id="contacts-tab" data-tabs-target="#contacts" type="button" role="tab" aria-controls="contacts" aria-selected="false">Eliminar Profesor</button>
            </li>
        </ul>
    </div>
    <div id="myTabContent" class="pb-5 ">
        <div class=" " id="profile" role="tabpanel" aria-labelledby="profile-tab">
            <div class="overflow-x-auto relative  my-4 flex flex-wrap">
                <div class="flex items-center mr-4">
                    <asp:DropDownList ID="DropDownListCuatri" CssClass="bg-blue-100 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" runat="server"></asp:DropDownList>
                </div>
                <div class="flex items-center mr-4">
                    <asp:DropDownList ID="DropDownListPrograma" CssClass="bg-blue-100 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" runat="server"></asp:DropDownList>
                </div>

                <div class="flex items-center mr-4">
                    <asp:Button ID="Button1" runat="server" Text="Buscar Contagiados" CssClass="text-white bg-gradient-to-r from-blue-500 via-blue-600 to-blue-700 hover:bg-gradient-to-br focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center mr-2 mb-2" OnClick="Button1_Click" />
                </div>
            </div>

            <div class="overflow-x-auto relative">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="w-full text-sm text-left text-gray-500" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" Font-Bold="True" />
                    <HeaderStyle CssClass="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 " />
                    <RowStyle CssClass="bg-white border-b " />
                    <Columns>
                        <asp:BoundField DataField="Id_PositivoProfesor" HeaderText="Identificador" />
                        <asp:BoundField DataField="Nombre Completo" HeaderText="Nombre Completo" />
                        <asp:BoundField DataField="Genero" HeaderText="Genero" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                        <asp:BoundField DataField="Fecha de Contagio" HeaderText="Fecha de Contagio" />
                        <asp:BoundField DataField="Veces Contagiadas" HeaderText="Veces Contagiadas" />
                        <asp:BoundField DataField="Turno" HeaderText="Turno" />
                        <asp:CommandField ShowSelectButton="True" SelectText="Ver más" HeaderText="Opciones" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="hidden p-4 bg-gray-50 rounded-lg " id="dashboard" role="tabpanel" aria-labelledby="dashboard-tab">
            <div class="overflow-x-auto relative">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="w-full text-sm text-left text-gray-500 " OnPageIndexChanging="GridView1_PageIndexChanging">
                    <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" Font-Bold="True" />
                    <HeaderStyle CssClass="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 " />
                    <RowStyle CssClass="bg-white border-b " />
                </asp:GridView>
            </div>
        </div>
        <div class="hidden p-10 bg-gray-50 rounded-lg  " id="settings" role="tabpanel" aria-labelledby="settings-tab">
            <h5 class="text-xl font-medium text-gray-900 dark:text-white mb-4">Registra un nuevo Profesor</h5>
            <div class="grid md:grid-cols-2 md:gap-6 mb-4">
                <div class="relative z-0 mb-6 w-full group">
                    <asp:TextBox ID="TextBoxRegistro" runat="server" type="number" CssClass="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" "></asp:TextBox>
                    <label for="ContentPlaceHolder1_TextBoxRegistro" class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Registro Empleado</label>
                </div>
                <div class="relative z-0 mb-6 w-full group">
                    <asp:TextBox ID="TextBoxNombre" runat="server" type="number" CssClass="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" "></asp:TextBox>
                    <label for="ContentPlaceHolder1_TextBoxNombre" class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Nombre</label>
                </div>
            </div>
            <div class="grid md:grid-cols-2 md:gap-6 mb-4">
                <div class="relative z-0 mb-6 w-full group">
                    <asp:TextBox ID="TextBoxPaterno" runat="server" CssClass="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" "></asp:TextBox>
                    <label for="ContentPlaceHolder1_TextBoxPaterno" class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Apellido Paterno</label>
                </div>
                <div class="relative z-0 mb-6 w-full group">
                    <asp:TextBox ID="TextBoxMaterno" runat="server" CssClass="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" "></asp:TextBox>
                    <label for="ContentPlaceHolder1_TextBoxMaterno" class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Apellido Materno</label>
                </div>
            </div>
            <div class="grid md:grid-cols-3 md:gap-6 mb-4">
                <div class="relative z-0 mb-6 w-full group">
                    <label for="ContentPlaceHolder1_DropDownListGenero" class="sr-only">Seleccione una opción</label>
                    <asp:DropDownList ID="DropDownListGenero" CssClass="block py-2.5 px-0 w-full text-sm text-gray-500 bg-transparent border-0 border-b-2 border-gray-200 appearance-none dark:text-gray-400 dark:border-gray-700 focus:outline-none focus:ring-0 focus:border-gray-200 peer" runat="server"></asp:DropDownList>
                </div>
                <div class="relative z-0 mb-6 w-full group">
                    <label for="ContentPlaceHolder1_DropDownListCategoria" class="sr-only">Seleccione una opción</label>
                    <asp:DropDownList ID="DropDownListCategoria" CssClass="block py-2.5 px-0 w-full text-sm text-gray-500 bg-transparent border-0 border-b-2 border-gray-200 appearance-none dark:text-gray-400 dark:border-gray-700 focus:outline-none focus:ring-0 focus:border-gray-200 peer" runat="server"></asp:DropDownList>
                </div>
                <div class="relative z-0 mb-6 w-full group">
                    <label for="ContentPlaceHolder1_DropDownListEstadoCivil" class="sr-only">Seleccione una opción</label>
                    <asp:DropDownList ID="DropDownListEstadoCivil" CssClass="block py-2.5 px-0 w-full text-sm text-gray-500 bg-transparent border-0 border-b-2 border-gray-200 appearance-none dark:text-gray-400 dark:border-gray-700 focus:outline-none focus:ring-0 focus:border-gray-200 peer" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="grid md:grid-cols-2 md:gap-6 mb-4">
                <div class="relative z-0 mb-6 w-full group">
                    <asp:TextBox ID="TextBoxCorreo" runat="server" type="email" CssClass="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" "></asp:TextBox>
                    <label for="ContentPlaceHolder1_TextBoxCorreo" class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Correo Electronico</label>
                </div>
                <div class="relative z-0 mb-6 w-full group">
                    <asp:TextBox ID="TextBoxCelular" runat="server" type="tel" CssClass="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" "></asp:TextBox>
                    <label for="ContentPlaceHolder1_TextBoxCelular" class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Celular</label>
                </div>
            </div>


            <asp:Button ID="Button2" CssClass="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800" runat="server" Text="Crear Profesor" OnClick="Button2_Click" />
        </div>
        <div class="hidden p-4 bg-gray-50 rounded-lg " id="contacts" role="tabpanel" aria-labelledby="contacts-tab">
            <p class="text-sm text-gray-500">This is some placeholder content the <strong class="font-medium text-gray-800 dark:text-white">Contacts tab's associated content</strong>. Clicking another tab will toggle the visibility of this one for the next. The tab JavaScript swaps classes to control the content visibility and styling.</p>
        </div>
    </div>


</asp:Content>
