# 🛠️ Concurso.App.gestion

[![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?logo=dotnet)](https://dotnet.microsoft.com/en-us/download)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Build](https://img.shields.io/badge/build-passing-brightgreen)]()
[![PlantUML](https://img.shields.io/badge/PlantUML-ERD-lightgrey?logo=uml)](https://plantuml.com/)

Generador automático de soluciones .NET 8 a partir de archivos Excel estructurados con definición de entidades. El sistema aplica normalización, genera diagramas UML, crea arquitectura en capas, API RESTful, vistas Razor estilizadas, y funcionalidad de reportes exportables a PDF y Excel.

---

## 📂 Estructura del Proyecto

```
Concurso.App.gestion/
│
├── Domain/              # Entidades y lógica de negocio
├── Infrastructure/      # DbContext, configuraciones EF Core
├── Application/         # Servicios, DTOs, lógica de aplicación
├── Web/                 # Controladores, Vistas Razor, Frontend
├── Diagrams/            # Diagramas PlantUML (ERD, Arquitectura)
└── azuredeploy.json     # ARM Template para despliegue en Azure
```

---

## 📦 Tecnologías Utilizadas

- .NET 8.0
- Entity Framework Core 8.x (Code First)
- ASP.NET Core MVC (Razor Pages)
- Bootstrap 5.3 personalizado
- Font Awesome 6.0
- PlantUML (diagramas ER y arquitectura)
- Swagger (documentación API)
- iTextSharp (exportar PDF)
- EPPlus (exportar Excel)
- ARM Templates para despliegue en Azure

---

## 🚀 Instrucciones de Uso

1. **Clona este repositorio:**
   ```bash
   git clone https://github.com/tu-usuario/Concurso.App.gestion.git
   cd Concurso.App.gestion
   ```

2. **Carga el archivo Excel en formato:**
   - Entidad | Atributo | Tipo de Dato | Tamaño | Descripción

3. **Ejecuta la solución en Visual Studio 2022+** o con `dotnet run`.

4. **Crea la base de datos local:**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Accede a la app en navegador:**
   ```url
   https://localhost:5001
   ```

---

## 🧾 Reportes y Funcionalidades Adicionales

- Vista `ReportePedidos`: gráficos y tablas de productos con opción de exportación PDF y Excel.
- Dashboard administrativo con KPIs y tarjetas visuales.
- Swagger UI para probar endpoints.

---

## ☁️ Despliegue en Azure (opcional)

Usa el archivo `azuredeploy.json` para automatizar el despliegue con:

- App Service
- Azure SQL Database

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo `LICENSE` para más información.
