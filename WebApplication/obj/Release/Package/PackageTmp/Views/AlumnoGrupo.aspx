<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Page.Master" AutoEventWireup="true" CodeBehind="AlumnoGrupo.aspx.cs" Inherits="WebApplication.Views.AlumnoGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="py-20 bg-white">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
            <div class="lg:text-center">
                <h2 class="text-base text-indigo-600 font-semibold tracking-wide uppercase">Bienvenido</h2>
                <p class="mt-2 text-3xl leading-8 font-extrabold tracking-tight text-gray-900 sm:text-4xl">Portal de Gestión de Alumno y Grupo</p>
                <p class="mt-4 max-w-2xl text-xl text-gray-500 lg:mx-auto">Lorem ipsum dolor sit amet consect adipisicing elit. Possimus magnam voluptatum cupiditate veritatis in accusamus quisquam.</p>
            </div>
        </div>
    </div>

    <div id="toast" runat="server" class="flex absolute bottom-20 right-5 items-center p-4 space-x-4 w-full max-w-xs text-white  rounded-lg divide-x divide-white shadow space-x bg-gray-700" role="alert">
        <svg aria-hidden="true" class="w-5 h-5 text-white dark:text-blue-500" focusable="false" data-prefix="fas" data-icon="paper-plane" role="img" viewBox="0 0 512 512">
            <path fill="currentColor" d="M511.6 36.86l-64 415.1c-1.5 9.734-7.375 18.22-15.97 23.05c-4.844 2.719-10.27 4.097-15.68 4.097c-4.188 0-8.319-.8154-12.29-2.472l-122.6-51.1l-50.86 76.29C226.3 508.5 219.8 512 212.8 512C201.3 512 192 502.7 192 491.2v-96.18c0-7.115 2.372-14.03 6.742-19.64L416 96l-293.7 264.3L19.69 317.5C8.438 312.8 .8125 302.2 .0625 289.1s5.469-23.72 16.06-29.77l448-255.1c10.69-6.109 23.88-5.547 34 1.406S513.5 24.72 511.6 36.86z"></path></svg>
        <div class="pl-4 text-sm font-normal">
            <asp:Label ID="Lmessage" runat="server" Text="Label"></asp:Label>
        </div>
        <button type="button" class="ml-auto -mx-1.5 text-gray-50 focus:ring-2 p-1.5 inline-flex h-8 w-8" data-dismiss-target="#ContentPlaceHolder1_toast" aria-label="Close">
            <span class="sr-only">Close</span>
            <svg aria-hidden="true" class="w-5 h-5" fill="currentColor" viewBox="0 0 20 20">
                <path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path></svg>
        </button>
    </div>

    <div class="mb-4 border-b border-gray-300 ">
        <ul class="flex flex-wrap -mb-px text-sm font-medium text-center" id="myTab" data-tabs-toggle="#myTabContent" role="tablist">
            <li class="mr-2" role="presentation">
                <button class="inline-block p-4 rounded-t-lg border-b-2 text-blue-600 hover:text-blue-600 border-blue-600" id="profile-tab" data-tabs-target="#profile" type="button" role="tab" aria-controls="profile" aria-selected="true">Alumno y Grupo</button>
            </li>
            <li class="mr-2" role="presentation">
                <button class="inline-block p-4 rounded-t-lg border-b-2 border-transparent hover:text-gray-600 hover:border-gray-300 text-gray-500 border-gray-100 " id="dashboard-tab" data-tabs-target="#dashboard" type="button" role="tab" aria-controls="dashboard" aria-selected="false">Nuevo Alumno y Grupo</button>
            </li>
            <li class="mr-2" role="presentation">
                <button class="inline-block p-4 rounded-t-lg border-b-2 border-transparent hover:text-gray-600 hover:border-gray-300 text-gray-500  border-gray-100 " id="settings-tab" data-tabs-target="#settings" type="button" role="tab" aria-controls="settings" aria-selected="false">Buscar Alumno Grupo</button>
            </li>

        </ul>
    </div>
    <div id="myTabContent" class="pb-12 ">
        <div class=" " id="profile" role="tabpanel" aria-labelledby="profile-tab">
            <div class="overflow-x-auto relative">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="w-full text-sm text-left text-gray-500 " PageSize="25" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" Font-Bold="True" />
                    <HeaderStyle CssClass="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 " />
                    <RowStyle CssClass="bg-white border-b " />
                </asp:GridView>
            </div>
        </div>
        <div class="hidden p-4 bg-gray-50 rounded-lg " id="dashboard" role="tabpanel" aria-labelledby="dashboard-tab">
            <h5 class="text-xl font-medium text-gray-900 dark:text-white mb-4">Registra un nuevo Grupos y Cuatrimestres</h5>
            <div class="grid md:grid-cols-2 md:gap-6 mb-4">
                <div class="relative z-0 mb-6 w-full group">
                    <label for="ContentPlaceHolder1_DropDownListModalidad" class="block mb-2 text-sm font-medium text-gray-400 ">Seleccione una opción</label>
                    <asp:DropDownList ID="DropDownListModalidad" CssClass="block py-2.5 px-0 w-full text-sm text-gray-500 bg-transparent border-0 border-b-2 border-gray-200 appearance-none dark:text-gray-400 dark:border-gray-700 focus:outline-none focus:ring-0 focus:border-gray-200 peer" runat="server"></asp:DropDownList>
                </div>
                <div class="relative z-0 mb-6 w-full group">
                    <label for="ContentPlaceHolder1_DropDownListTurno" class="block mb-2 text-sm font-medium text-gray-400 ">Seleccione una opción</label>
                    <asp:DropDownList ID="DropDownListTurno" CssClass="block py-2.5 px-0 w-full text-sm text-gray-500 bg-transparent border-0 border-b-2 border-gray-200 appearance-none dark:text-gray-400 dark:border-gray-700 focus:outline-none focus:ring-0 focus:border-gray-200 peer" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="grid md:grid-cols-2 md:gap-6 mb-4">
                <div class="relative z-0 mb-6 w-full group">
                    <label for="ContentPlaceHolder1_DropDownListCuatrimestre" class="block mb-2 text-sm font-medium text-gray-400">Seleccione una opción</label>
                    <asp:DropDownList ID="DropDownListCuatrimestre" CssClass="block py-2.5 px-0 w-full text-sm text-gray-500 bg-transparent border-0 border-b-2 border-gray-200 appearance-none dark:text-gray-400 dark:border-gray-700 focus:outline-none focus:ring-0 focus:border-gray-200 peer" runat="server"></asp:DropDownList>
                </div>
                <div class="relative z-0 mb-6 w-full group">
                    <label for="ContentPlaceHolder1_DropDownListPrograma" class="block mb-2 text-sm font-medium text-gray-400">Seleccione una opción</label>
                    <asp:DropDownList ID="DropDownListPrograma" CssClass="block py-2.5 px-0 w-full text-sm text-gray-500 bg-transparent border-0 border-b-2 border-gray-200 appearance-none dark:text-gray-400 dark:border-gray-700 focus:outline-none focus:ring-0 focus:border-gray-200 peer" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="grid md:grid-cols-2 md:gap-6 mb-4">
                <div class="relative z-0 mb-6 w-full group">

                    <label for="ContentPlaceHolder1_DropDownListGrupo" class="block mb-2 text-sm font-medium text-gray-400 ">Seleccione una opción</label>
                    <asp:DropDownList ID="DropDownListGrupo" CssClass="block py-2.5 px-0 w-full text-sm text-gray-500 bg-transparent border-0 border-b-2 border-gray-200 appearance-none dark:text-gray-400 dark:border-gray-700 focus:outline-none focus:ring-0 focus:border-gray-200 peer" runat="server"></asp:DropDownList>
                </div>

            </div>
            <asp:Button ID="Button2" CssClass="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800" runat="server" Text="Crear Alumno" OnClick="Button3_Click" />
        </div>
        <div class="hidden p-10 bg-gray-50 rounded-lg  " id="settings" role="tabpanel" aria-labelledby="settings-tab">
            <div class="grid md:grid-cols-3 md:gap-6 mb-4">
                <div class="relative z-0 mb-6 w-full group">
                    <asp:TextBox ID="buscaid" runat="server" CssClass="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" "></asp:TextBox>
                    <label for="ContentPlaceHolder1_TextBoxRegistro" class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Identificador del grupo y cuatrimestre</label>
                </div>
                <div>
                    <asp:Button ID="Button3" CssClass="text-white bg-gradient-to-r from-blue-500 via-blue-600 to-blue-700 hover:bg-gradient-to-br focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center mr-2 mb-2" runat="server" Text="Buscar Grupo y Cuatrimestre" OnClick="Button5_Click" />
                </div>
            </div>
            <div runat="server" id="Datos" class="p-6 max-w-sm bg-white rounded-lg border border-gray-200 shadow-md dark:bg-gray-800 dark:border-gray-700">
                <a href="#">
                    <h5 class="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">Grado y Cuatrimestre</h5>
                </a>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400 ">
                    Turno:
                    <asp:Label ID="Turno" CssClass="font-ligh" runat="server" Text=""></asp:Label>
                </p>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400 ">
                    Modalidad:
                    <asp:Label ID="Modalidad" CssClass="font-ligh" runat="server" Text=""></asp:Label>
                </p>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400 ">
                    Periodo:
                    <asp:Label ID="Periodo" CssClass="font-ligh" runat="server" Text=""></asp:Label>
                </p>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400 ">
                    Programa:
                    <asp:Label ID="Programa" CssClass="font-ligh" runat="server" Text=""></asp:Label>
                </p>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400 ">
                    Grado:
                    <asp:Label ID="Grado" CssClass="font-ligh" runat="server" Text=""></asp:Label>
                </p>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400 ">
                    Letra:
                    <asp:Label ID="Letra" CssClass="font-ligh" runat="server" Text=""></asp:Label>
                </p>
                <asp:TextBox ID="id" type="hidden" runat="server"></asp:TextBox>
                <asp:Button ID="Button4" runat="server" CssClass="focus:outline-none text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900" Text="Eliminar Grupo y Cuatrimestre" OnClick="Button4_Click" />
            </div>
        </div>
    </div>

</asp:Content>
