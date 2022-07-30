<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication.Views.Home" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="bg-white">
        <div class="max-w-2xl mx-auto py-16 px-4 sm:py-24 sm:px-6 lg:max-w-7xl lg:px-8">
            <div class="sm:text-center lg:text-left mb-20">
                <h1 class="text-4xl tracking-tight font-extrabold text-gray-900 sm:text-5xl md:text-6xl">
                    <span class="block xl:inline">Bienvenido al Sistema </span>
                    <span class="block text-indigo-600 xl:inline">Control Covid-19</span>
                </h1>
                <p class="mt-3 text-base text-gray-500  sm:mx-auto md:mt-5 md:text-xl lg:mx-0">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.  </p>
            </div>

            <div class="grid grid-cols-1 gap-y-10 sm:grid-cols-2 gap-x-6 lg:grid-cols-3 xl:grid-cols-4 xl:gap-x-8">
                <a href="Profesores.aspx" class="group">
                    <div class="w-full aspect-w-1 aspect-h-1 bg-gray-200  rounded-lg overflow-hidden xl:aspect-w-7 xl:aspect-h-8">
                        <img src="../images/profesores.png">
                    </div>

                    <p class="mt-1 text-lg font-medium text-gray-900">Profesores</p>
                </a>
                <a href="Alumnos.aspx" class="group">
                    <div class="w-full aspect-w-1 aspect-h-1 bg-gray-200 rounded-lg overflow-hidden xl:aspect-w-7 xl:aspect-h-8">
                        <img src="../images/estudiante.png">
                    </div>
                    <p class="mt-1 text-lg font-medium text-gray-900">Alumnos</p>
                </a>
                <a href="#" class="group">
                    <div class="w-full aspect-w-1 aspect-h-1 bg-gray-200 rounded-lg overflow-hidden xl:aspect-w-7 xl:aspect-h-8">
                        <img src="../images/medico.png" alt="Tall slender porcelain bottle with natural clay textured body and cork stopper." class="w-full h-full object-center object-cover group-hover:opacity-75">
                    </div>
                    <p class="mt-1 text-lg font-medium text-gray-900">Médicos</p>
                </a>
                <a href="Cuatrimestres.aspx" class="group">
                    <div class="w-full aspect-w-1 aspect-h-1 bg-gray-200 rounded-lg overflow-hidden xl:aspect-w-7 xl:aspect-h-8">
                        <img src="../images/cuatrimestre.png" alt="Tall slender porcelain bottle with natural clay textured body and cork stopper." class="w-full h-full object-center object-cover group-hover:opacity-75">
                    </div>
                    <p class="mt-1 text-lg font-medium text-gray-900">Cuatrimestres</p>
                </a>
                <a href="GrupoCuatrimestre.aspx" class="group">
                    <div class="w-full aspect-w-1 aspect-h-1 bg-gray-200 rounded-lg overflow-hidden xl:aspect-w-7 xl:aspect-h-8">
                        <img src="../images/carrera.png" alt="Tall slender porcelain bottle with natural clay textured body and cork stopper." class="w-full h-full object-center object-cover group-hover:opacity-75">
                    </div>
                    <p class="mt-1 text-lg font-medium text-gray-900">Grupo Cuatrimestre</p>
                </a>
                <a href="#" class="group">
                    <div class="w-full aspect-w-1 aspect-h-1 bg-gray-200 rounded-lg overflow-hidden xl:aspect-w-7 xl:aspect-h-8">
                        <img src="../images/tecnico.png" alt="Tall slender porcelain bottle with natural clay textured body and cork stopper." class="w-full h-full object-center object-cover group-hover:opacity-75">
                    </div>
                    <p class="mt-1 text-lg font-medium text-gray-900">Programa Educativo</p>
                </a>
            </div>
        </div>
    </div>

</asp:Content>
