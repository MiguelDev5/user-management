# 📌 User Management - ASP.NET

Sistema de gestión de usuarios desarrollado en **ASP.NET con C#**, que implementa un flujo completo de autenticación, control de intentos de acceso y bloqueo de cuentas.

---

## 🚀 Funcionalidades

- ✅ Activación de cuenta (pantalla *Welcome*)
- 🔐 Inicio de sesión con validación de credenciales
- ⚠️ Control de intentos fallidos (`LoginAttempts`)
- 🚫 Bloqueo automático después de múltiples intentos fallidos
- 👤 Visualización del perfil de usuario autenticado
- 👤 Refrezcar sesión

---

## 🧱 Arquitectura

El proyecto sigue una estructura basada en:

- **Models**: Representación de entidades como `Account`
- **ViewModels**: Manejo de datos de entrada (`LoginViewModel`)
- **Controllers**: Lógica de negocio (`AuthController`)
- **Views**: Interfaces de usuario (Login, Welcome, BlockedAccount, Profile)

---

## 🛠️ Tecnologías utilizadas

- ASP.NET (MVC)
- C#
- Entity Framework
- Data Annotations
- SQL Server

---

## 🔄 Flujo de autenticación

1. El usuario activa su cuenta en la pantalla **Welcome**
2. Ingresa sus credenciales en el **Login**
3. El sistema valida:
   - Existencia del usuario
   - Estado de bloqueo
   - Contraseña correcta
4. Si falla:
   - Se incrementa `LoginAttempts`
   - Si supera el límite → cuenta bloqueada
5. Si es exitoso:
   - Se reinician los intentos
   - Redirección al **perfil del usuario**